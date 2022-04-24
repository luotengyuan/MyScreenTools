using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using 屏幕工具.Bean;
using Microsoft.Win32;
using System.Security.Principal;
using IWshRuntimeLibrary;//需要引入IWshRuntimeLibrary。在添加引用对话框中搜索(COM>>类型库)Windows Script Host Object Model，选择之后添加到Project的引用中。
using Microsoft.CSharp;//Microsoft.CSharp 否则会提示 缺少编译器要求的成员 Microsoft.CSharp.RuntimeBinder.Binder.Convert
using System.Threading;
using System.Text.RegularExpressions;

namespace 屏幕工具
{
    public partial class Form_main : Form
    {

        #region 变量定义

        // 定义布尔值记录截图状态，防止同时进入多个截图状态
        private bool isScreenShot;
        private int mScreenWidth, mScreenHigth;
        private int mLastLocationX, mLastLocationY;

        private Baidu.Aip.Ocr.Ocr client;
        private bool isInit = false;

        private const int CatchHotKeyID = 101;
        private const int OcrBasicHotKeyID = 102;
        private const int PickColorHotKeyKeyID = 103;

        private bool is_translate_from_init = false;
        private bool is_translate_to_init = false;

        #endregion

        #region 初始化
        public Form_main()
        {
            InitializeComponent();

            cb_auto_translate.Checked = Properties.Settings.Default.TranslateAuto;
            cb_drag_translate.Checked = Properties.Settings.Default.TranslateDrag;
            
            // 显示翻译选择列表
            DataTable dt_from = new DataTable();
            dt_from.Columns.Add("Text", Type.GetType("System.String"));
            dt_from.Columns.Add("Value", Type.GetType("System.String"));
            dt_from.Rows.Add("自动", "auto");
            dt_from.Rows.Add("中文", "zh");
            dt_from.Rows.Add("英文", "en");
            cb_translate_from.DataSource = dt_from;
            cb_translate_from.DisplayMember = "Text";   // Text，即显式的文本
            cb_translate_from.ValueMember = "Value";    // Value，即实际的值
            int cb_translate_from_idx = Properties.Settings.Default.TranslateFrom;
            if (cb_translate_from_idx < 0 || cb_translate_from_idx >= dt_from.Rows.Count)
            {
                cb_translate_from_idx = 0;
            }
            cb_translate_from.SelectedIndex = cb_translate_from_idx;

            DataTable dt_to = new DataTable();
            dt_to.Columns.Add("Text", Type.GetType("System.String"));
            dt_to.Columns.Add("Value", Type.GetType("System.String"));
            dt_to.Rows.Add("自动", "auto");
            dt_to.Rows.Add("中文", "zh");
            dt_to.Rows.Add("英文", "en");
            cb_translate_to.DataSource = dt_to;
            cb_translate_to.DisplayMember = "Text";   // Text，即显式的文本
            cb_translate_to.ValueMember = "Value";    // Value，即实际的值
            int cb_translate_to_idx = Properties.Settings.Default.TranslateTo;
            if (cb_translate_to_idx < 0 || cb_translate_to_idx >= dt_to.Rows.Count)
            {
                cb_translate_to_idx = 0;
            }
            cb_translate_to.SelectedIndex = cb_translate_to_idx;

            int translateType = Properties.Settings.Default.TranslateType;
            if (translateType < 0 || translateType >= 2)
            {
                translateType = 0;
            }
            cb_translate_type.SelectedIndex = translateType;

        }

        private void Form_main_Load(object sender, EventArgs e)
        {
            //splitContainer1.Panel2Collapsed = !splitContainer1.Panel2Collapsed;
            InitBaiduYun(Properties.Settings.Default.OCRApiKey, Properties.Settings.Default.OCRSecretKey, false);
            var g = Graphics.FromHwnd(IntPtr.Zero);
            IntPtr desktop = g.GetHdc();
            mScreenWidth = System32.GetDeviceCaps(desktop, (int)DeviceCap.DESKTOPHORZRES);
            mScreenHigth = System32.GetDeviceCaps(desktop, (int)DeviceCap.DESKTOPVERTRES);
            RegisterAllHotKey();
            StartOrStopMouseHook();
        }

        private void RegisterAllHotKey()
        {
            ////Handle为当前窗口句柄
            ////101为快捷键自定义ID
            ////0x0002为Ctrl键,
            ////0x0001为Alt键，或运算符|表同时按住两个键有效
            ////0x41为A键。
            //bool isRegistered = HotKey.RegisterHotKey(Handle, 101, (0x0002 | 0x0001), 0x41);
            //if (isRegistered == false)
            //{
            //    this.notifyIcon.ShowBalloonTip(300, "快捷键被占用", "无法使用快捷键截图！点击查看", ToolTipIcon.Info);
            //}
            int catchHotKey = Properties.Settings.Default.CatchHotKey;
            if (catchHotKey != 0)
            {
                bool isRegistered = HotKey.RegisterHotKey(Handle, CatchHotKeyID, 0x0001, catchHotKey);
                if (isRegistered == false)
                {
                    this.notifyIcon.ShowBalloonTip(300, "快捷键被占用", "无法使用快捷键截图！点击查看", ToolTipIcon.Info);
                }
            }
            int ocrBasicHotKey = Properties.Settings.Default.OcrBasicHotKey;
            if (ocrBasicHotKey != 0)
            {
                bool isRegistered = HotKey.RegisterHotKey(Handle, OcrBasicHotKeyID, 0x0001, ocrBasicHotKey);
                if (isRegistered == false)
                {
                    this.notifyIcon.ShowBalloonTip(300, "快捷键被占用", "无法使用快捷键文字识别！点击查看", ToolTipIcon.Info);
                }
            }
            int pickColorHotKey = Properties.Settings.Default.PickColorHotKey;
            if (pickColorHotKey != 0)
            {
                bool isRegistered = HotKey.RegisterHotKey(Handle, PickColorHotKeyKeyID, 0x0001, pickColorHotKey);
                if (isRegistered == false)
                {
                    this.notifyIcon.ShowBalloonTip(300, "快捷键被占用", "无法使用快捷键屏幕取色！点击查看", ToolTipIcon.Info);
                }
            }
        }

        private void UnregisterAllHotKey()
        {
            HotKey.UnregisterHotKey(Handle, CatchHotKeyID);
            HotKey.UnregisterHotKey(Handle, OcrBasicHotKeyID);
            HotKey.UnregisterHotKey(Handle, PickColorHotKeyKeyID);
        }

        private void InitBaiduYun(string apiKey, string secretKey)
        {
            InitBaiduYun(apiKey, secretKey, true);
        }

        private void InitBaiduYun(string apiKey, string secretKey, bool isTip)
        {
            if (apiKey == null || apiKey.Length <= 0 || secretKey == null || secretKey.Length <= 0)
            {
                if (isTip)
                {
                    MessageBox.Show("百度云OCR账号信息未设置：请点击【设置】-->【百度云设置】进行修改");
                }
                return;
            }
            client = new Baidu.Aip.Ocr.Ocr(apiKey, secretKey);
            client.Timeout = 60000;  // 修改超时时间
            isInit = true;
        }

        private void Form_main_Resize(object sender, EventArgs e)
        {
            //最小化时隐藏窗体
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.Visible = false;
            }
        }

        private void ShowForm()
        {
            if (this.Visible == true)
            {
                this.WindowState = FormWindowState.Minimized;
            }
            else
            {
                this.Visible = true;
                this.WindowState = FormWindowState.Normal;
            }
        }
        #endregion

        #region 点击事件

        private void btn_screenshot_Click(object sender, EventArgs e)
        {
            ScreenShot(CatchType.CATCH);
        }

        private void btn_ocr_basic_Click(object sender, EventArgs e)
        {
            if (!isInit)
            {
                MessageBox.Show("百度云OCR账号信息未设置：请点击【设置】-->【百度云设置】进行修改");
                return;
            }
            ScreenShot(CatchType.OCR_BASIC);
        }

        #endregion


        //截图状态的判定
        private void ScreenShot(CatchType type)
        {
            if (isScreenShot == false)
            {
                if (type == CatchType.CATCH)
                {
                    isScreenShot = true;
                    mLastLocationX = this.Location.X;
                    mLastLocationY = this.Location.Y;
                    this.Location = new Point(mScreenWidth, mScreenHigth);
                    PrScrnHelper.PrScrn();
                    this.Location = new Point(mLastLocationX, mLastLocationY);
                    isScreenShot = false;
                    return;
                }
                Form_catch form_catch = new Form_catch(type);
                //注册Catch窗体定义的事件委托
                form_catch.SetICSEvent += new SetICS(SetisScreenShot);
                //进入截图
                DialogResult result = form_catch.ShowDialog();
                if (result == DialogResult.OK && type != CatchType.CATCH)
                {
                    if (this.Visible == false)
                    {
                        this.ShowForm();
                    }
                    string ocr_result = null;
                    if (type == CatchType.OCR_BASIC)
                    {
                        ocr_result = OcrBasic(form_catch.catchPicture);
                    }
                    if (ocr_result != null)
                    {
                        tb_ocr_result.Text = ocr_result;
                        if (cb_auto_translate.Checked)
                        {
                            ShowTranslateResult(tb_ocr_result.Text);
                        }
                    }
                    else
                    {
                        tb_ocr_result.Text = "";
                        MessageBox.Show("识别失败");
                    }
                }
            }
        }
        //处理事件委托，设置截图状态
        public void SetisScreenShot(bool isScreenShot)
        {
            this.isScreenShot = isScreenShot;
            //ShowForm();
            if (this.Visible)
            {
                if (isScreenShot)
                {
                    mLastLocationX = this.Location.X;
                    mLastLocationY = this.Location.Y;
                    this.Location = new Point(mScreenWidth, mScreenHigth);
                }
                else
                {
                    this.Location = new Point(mLastLocationX, mLastLocationY);
                }
            }
        }

        private String OcrBasic(string path)
        {
            try
            {
                // 图片文件路径
                var image = System.IO.File.ReadAllBytes(path);
                // 调用通用文字识别, 图片参数为本地图片，可能会抛出网络等异常，请使用try/catch捕获
                //var result = client.GeneralBasic(image);//通用文字识别
                var result = client.AccurateBasic(image);//通用文字识别（高精度版）
                if (result == null)
                {
                    Console.WriteLine("识别结果为空");
                    return null;
                }
                Console.WriteLine(result);
                OcrBasicBean bean = JsonConvert.DeserializeObject<OcrBasicBean>(result.ToString());
                if (bean == null)
                {
                    Console.WriteLine("识别结果解析错误");
                    return null;
                }
                StringBuilder sb = new StringBuilder();
                for (int i = 0; bean.WordsResult != null && i < bean.WordsResult.Count; i++)
                {
                    sb.Append(bean.WordsResult[i].Words);
                    if (i != bean.WordsResult.Count - 1)
                    {
                        sb.Append("\r\n");
                    }
                }
                //复制到粘贴板
                Clipboard.SetText(sb.ToString());
                return sb.ToString();
                //// 如果有可选参数
                //var options = new Dictionary<string, object>{
                //    {"language_type", "CHN_ENG"},
                //    {"detect_direction", "true"},
                //    {"detect_language", "true"},
                //    {"probability", "true"}
                //};
                //// 带参数调用通用文字识别, 图片参数为本地图片
                //result = client.GeneralBasic(image, options);
                //Console.WriteLine(result);
            }
            catch (Exception e)
            {
                Console.WriteLine("识别出错：" + e.ToString());
                return null;
            }
        }

        private void 百度云设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_baiduyun baiduyun = new Form_baiduyun();
            DialogResult result = baiduyun.ShowDialog();
            if (result == DialogResult.OK)
            {
                InitBaiduYun(Properties.Settings.Default.OCRApiKey, Properties.Settings.Default.OCRSecretKey);
            }
        }

        private void 快捷键设置ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_shortcut shortcut = new Form_shortcut();
            DialogResult result = shortcut.ShowDialog();
            if (result == DialogResult.OK)
            {
                UnregisterAllHotKey();
                RegisterAllHotKey();
            }
        }

        private void 显示ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ShowForm();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void notifyIcon_BalloonTipClicked(object sender, EventArgs e)
        {
            MessageBox.Show("请检查是否启动了QQ或其他占用快捷键的程序\r\n或者先前打开了该截图工具尚未关闭。若要使用\r\n快捷键，请关闭占用程序并重新打开截图工具。", "帮助", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
        }

        private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.ShowForm();
            }
        }

        private void Form_main_FormClosing(object sender, FormClosingEventArgs e)
        {
            UnregisterAllHotKey();
            notifyIcon.Dispose();
        }

        //重载WndProc窗口事件方法，以响应快捷键
        protected override void WndProc(ref Message m)
        {
            switch (m.WParam.ToInt32())
            {
                case CatchHotKeyID:
                    ScreenShot(CatchType.CATCH);
                    break;
                case OcrBasicHotKeyID:
                    if (!isInit)
                    {
                        MessageBox.Show("百度云OCR账号信息未设置！请点击【设置】-->【百度云设置】进行修改");
                        return;
                    }
                    else
                    {
                        ScreenShot(CatchType.OCR_BASIC);
                    }
                    break;
                case PickColorHotKeyKeyID:
                    ShowPickColor();
                    break;
                default:
                    break;
            }
            const int WM_SYSCOMMAND = 0x0112;
            const int SC_CLOSE = 0xF060;
            if (m.Msg == WM_SYSCOMMAND && (int)m.WParam == SC_CLOSE)
            {
                // User clicked close button
                //this.WindowState = FormWindowState.Minimized;
                ShowForm();
                return;
            }
            base.WndProc(ref m);
        }

        private void 文字识别ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!isInit)
            {
                MessageBox.Show("百度云OCR账号信息未设置！请点击【设置】-->【百度云设置】进行修改");
                return;
            }
            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Title = "请选择文件夹",
                Filter = "图片文件|*.jpg;*.png;*.jpeg;*.bmp"//jpg/jpeg/png/bmp
            };

            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string ocr_result = OcrBasic(openFileDialog.FileName);
                if (ocr_result != null)
                {
                    tb_ocr_result.Text = ocr_result;
                }
                else
                {
                    tb_ocr_result.Text = "";
                    MessageBox.Show("识别失败");
                }
            }
        }

        private void 关于我们ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_about about = new Form_about();
            about.Show();
        }

        private void btn_ocr_copy_Click(object sender, EventArgs e)
        {
            //复制到粘贴板
            if (!"".Equals(tb_ocr_result.Text))
            {
                Clipboard.SetText(tb_ocr_result.Text);
            }
        }

        private void btn_ocr_clean_Click(object sender, EventArgs e)
        {
            tb_ocr_result.Text = "";
        }

        private void SetAppAutoRun(bool autoRun)
        {
            if (autoRun) //设置开机自启动 
            {
                string path = System.Windows.Forms.Application.ExecutablePath;
                RegistryKey rk = Registry.LocalMachine;
                RegistryKey rk2 = rk.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run");
                rk2.SetValue("JcShutdown", path);
                rk2.Close();
                rk.Close();
            }
            else //取消开机自启动 
            {
                RegistryKey rk = Registry.LocalMachine;
                RegistryKey rk2 = rk.CreateSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run");
                rk2.DeleteValue("JcShutdown", false);
                rk2.Close();
                rk.Close();
            }
        }
        
        private void SetAppAutoRun2(bool autoRun)
        {
            string filename = Application.ExecutablePath.Substring(Application.StartupPath.Length + 1);//去斜杠和路径，文件名带扩展名
            string truefilename = getExeName(true);//不带扩展名的文件名
            string StartupPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.CommonStartup);
            if (autoRun) //设置开机自启动 
            {
                /*方法一快捷方式*/
                //路径带文件名：Application.ExecutablePath
                //路径不带文件名：Application.StartupPath
                ShortcutCreator.CreateShortcut(StartupPath, truefilename, Application.ExecutablePath);//创建快捷方式到系统启动文件夹下
            }
            else //取消开机自启动 
            {
                /*方法一快捷方式*/
                System.IO.File.Delete(StartupPath + @"\" + truefilename + ".lnk");
            }
        }

        private bool IsAppAutoRun2()
        {
            /*方法一快捷方式*/
            string filename = Application.ExecutablePath.Substring(Application.StartupPath.Length + 1);//去斜杠和路径，文件名带扩展名
            string truefilename = getExeName(true);//不带扩展名的文件名
            string StartupPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.CommonStartup);
            return System.IO.File.Exists(StartupPath + @"\" + truefilename + ".lnk");
        }

        /// <summary>
        /// 获取本应用的不带扩展名的文件名称
        /// </summary>
        /// <param name="noexe"></param>
        /// <returns></returns>
        public string getExeName (bool noexe=false)
        {
            if (noexe)
            {
                string filename=Application.ExecutablePath.Substring (Application.StartupPath.Length+1);
                int dotaddr = filename.LastIndexOf('.');
                return filename.Substring(0,dotaddr);//不带扩展名
            }
            else
            {
                return Application.ExecutablePath.Substring(Application.StartupPath.Length + 1);//带扩名
            }
        }

        public static bool IsAdministrator()
        {
            WindowsIdentity identity = WindowsIdentity.GetCurrent();
            WindowsPrincipal principal = new WindowsPrincipal(identity);
            return principal.IsInRole(WindowsBuiltInRole.Administrator);

        }

        private void btn_translate_Click(object sender, EventArgs e)
        {
            ShowTranslateResult(tb_ocr_result.Text);
        }

        private void ShowTranslateResult(string text)
        {
            string ret = "";
            if (true)
            {
                if (cb_translate_type.SelectedIndex == 0)
                {
                    ret = TextTranslateBasic(text);
                }
                else
                {
                    ret = TextTranslateDictionary(text);
                }
            }
            if (ret != null)
            {
                tb_translate_result.Text = ret;
            }
        }

        private string TextTranslateBasic(string text)
        {
            string tokenJsonStr = BaiduTranslateUtils.GetAccessToken();
            if (tokenJsonStr == null)
            {
                return null;
            }
            JObject jsonObj = JObject.Parse(tokenJsonStr);
            if (jsonObj == null)
            {
                return null;
            }
            string token = jsonObj["access_token"].ToString();
            if (token == null && "".Equals(token))
            {
                return null;
            }
            string from = cb_translate_from.SelectedValue.ToString();
            if (from.Equals("auto"))
            {
                if (HasChinese(text))
                {
                    from = "zh";
                }
                else
                {
                    from = "en";
                }
            }
            string to = cb_translate_to.SelectedValue.ToString();
            if (to.Equals("auto"))
            {
                if (HasChinese(text))
                {
                    to = "en";
                }
                else
                {
                    to = "zh";
                }
            }
            string retStr = BaiduTranslateUtils.TextTranslateBasic(token, text.Trim(), from, to, "");
            if (retStr == null)
            {
                return null;
            }
            TextTranslateBasicBean bean = JsonConvert.DeserializeObject<TextTranslateBasicBean>(retStr);
            if (bean == null || bean.Result == null || bean.Result.TransResult == null || bean.Result.TransResult.Count <= 0)
            {
                return null;
            }
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < bean.Result.TransResult.Count; i++)
            {
                sb.Append(bean.Result.TransResult[i].Dst);
                if (i != bean.Result.TransResult.Count - 1)
                {
                    sb.Append("\r\n"); 
                }
            }
            return sb.ToString();
        }

        private string TextTranslateDictionary(string text)
        {
            string tokenJsonStr = BaiduTranslateUtils.GetAccessToken();
            if (tokenJsonStr == null)
            {
                return null;
            }
            JObject jsonObj = JObject.Parse(tokenJsonStr);
            if (jsonObj == null)
            {
                return null;
            }
            string token = jsonObj["access_token"].ToString();
            if (token == null && "".Equals(token))
            {
                return null;
            }
            string from = cb_translate_from.SelectedValue.ToString();
            if (from.Equals("auto"))
            {
                if (HasChinese(text))
                {
                    from = "zh";
                }
                else
                {
                    from = "en";
                }
            }
            string to = cb_translate_to.SelectedValue.ToString();
            if (to.Equals("auto"))
            {
                if (HasChinese(text))
                {
                    to = "en";
                }
                else
                {
                    to = "zh";
                }
            }
            string retStr = BaiduTranslateUtils.TextTranslateDictionary(token, text.Trim(), from, to, "");
            if (retStr == null)
            {
                return null;
            }
            TextTranslateDictionaryBean bean = JsonConvert.DeserializeObject<TextTranslateDictionaryBean>(retStr);
            if (bean == null || bean.Result == null || bean.Result.TransResult == null || bean.Result.TransResult.Count <= 0)
            {
                return null;
            }
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < bean.Result.TransResult.Count; i++)
            {
                string transResultDict = bean.Result.TransResult[i].Dict;
                if (transResultDict == null || "".Equals(transResultDict.Trim()))
                {
                    sb.Append(bean.Result.TransResult[i].Dst);
                    continue;
                }
                DictionaryMeansBean means = JsonConvert.DeserializeObject<DictionaryMeansBean>(transResultDict);
                if (means == null || means.WordResult == null || means.WordResult.SimpleMeans == null || means.WordResult.SimpleMeans.WordMeans == null || means.WordResult.SimpleMeans.WordMeans.Count <= 0)
                {
                    sb.Append(bean.Result.TransResult[i].Dst);
                    continue;
                }
                for (int j = 0; j < means.WordResult.SimpleMeans.WordMeans.Count; j++)
                {
                    sb.Append(means.WordResult.SimpleMeans.WordMeans[j]);
                    if (j != means.WordResult.SimpleMeans.WordMeans.Count - 1)
                    {
                        sb.Append("\r\n");
                    }
                }
                if (i != bean.Result.TransResult.Count - 1)
                {
                    sb.Append("\r\n");
                }
            }
            return sb.ToString();
        }

        private void cb_auto_translate_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.TranslateAuto = cb_auto_translate.Checked;
            Properties.Settings.Default.Save();
        }

        private void cb_translate_from_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!is_translate_from_init)
            {
                is_translate_from_init = true;
            }
            else
            {
                Properties.Settings.Default.TranslateFrom = cb_translate_from.SelectedIndex;
                Properties.Settings.Default.Save();
            }
        }

        private void cb_translate_to_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!is_translate_to_init)
            {
                is_translate_to_init = true;
            }
            else
            {
                Properties.Settings.Default.TranslateTo = cb_translate_to.SelectedIndex;
                Properties.Settings.Default.Save();
            }
        }

        private void cb_translate_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.TranslateType = cb_translate_type.SelectedIndex;
            Properties.Settings.Default.Save();
        }

        private void cb_drag_translate_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.TranslateDrag = cb_drag_translate.Checked;
            Properties.Settings.Default.Save();
            StartOrStopMouseHook();
        }

        private void StartOrStopMouseHook()
        {
            MouseHook mouseHook = new MouseHook();
            if (cb_drag_translate.Checked)
            {
                mouseHook.MouseMove += new MouseEventHandler(mouseHook_MouseMove);
                mouseHook.MouseDown += new MouseEventHandler(mouseHook_MouseDown);
                mouseHook.MouseUp += new MouseEventHandler(mouseHook_MouseUp);
                mouseHook.Start();
            }
            else
            {
                mouseHook.MouseMove -= new MouseEventHandler(mouseHook_MouseMove);
                mouseHook.MouseDown -= new MouseEventHandler(mouseHook_MouseDown);
                mouseHook.MouseUp -= new MouseEventHandler(mouseHook_MouseUp);
                mouseHook.Stop();
            }
        }

        bool isDown = false;
        void mouseHook_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //鼠标左键点下 则开始绘制
                isDown = true;
            }
        }
        bool isMove = false;

        void mouseHook_MouseMove(object sender, MouseEventArgs e)
        {
            //richTextBox2.Text = Cursor.Current.ToString();
            if (isDown && cb_drag_translate.Checked)
            {
                isMove = true;
            }
        }

        void mouseHook_MouseUp(object sender, MouseEventArgs e)
        {

            if (e.Button == MouseButtons.Left)
            {
                Thread t = new Thread(() =>
                {
                    //Thread.Sleep(2000);
                    if (isDown && isMove)
                    {
                        SendKeys.SendWait("^c");
                        SendKeys.Flush();
                        IDataObject iData = Clipboard.GetDataObject();
                        if (null != iData)
                        {
                            if (iData.GetDataPresent(DataFormats.Text)) //检查是否存在文本
                            {
                                for (int i = 0; i < 5; i++)
                                {
                                    Thread.Sleep(100);
                                    string res = (String)iData.GetData(DataFormats.Text);
                                    if (!string.IsNullOrWhiteSpace(res))
                                    {
                                        if (!ForegroundWindow.ApplicationIsActivated())
                                        {
                                            tb_ocr_result.Text = res;
                                        }
                                        ShowTranslateResult(res);
                                        Clipboard.Clear();
                                        break;
                                    }
                                }
                            }
                        }

                    }
                    isDown = false;
                    isMove = false;
                });
                Control.CheckForIllegalCrossThreadCalls = false;
                t.SetApartmentState(ApartmentState.STA);
                t.Start();

            }
        }

        private void btn_color_Click(object sender, EventArgs e)
        {
            ShowPickColor();
        }

        private void ShowPickColor()
        {
            Form_color color = new Form_color();
            if (this.Visible)
            {
                mLastLocationX = this.Location.X;
                mLastLocationY = this.Location.Y;
                this.Location = new Point(mScreenWidth, mScreenHigth);
            }
            color.ShowDialog();
            if (this.Visible)
            {
                this.Location = new Point(mLastLocationX, mLastLocationY);
            }
        }

        /// <summary>
        /// 判断字符串中是否包含中文
        /// </summary>
        /// <param name="str">需要判断的字符串</param>
        /// <returns>判断结果</returns>
        public bool HasChinese(string str)
        {
            return Regex.IsMatch(str, @"[\u4e00-\u9fa5]");
        }

    }
}
