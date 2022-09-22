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
using Microsoft.Office.Interop.Excel;

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

        private const int OcrBasicHotKeyID = 104;

        private bool is_translate_from_init = false;
        private bool is_translate_to_init = false;

        private bool is_auto_start = false;

        #endregion

        #region 初始化
        public Form_main()
        {
            InitializeComponent();

            cb_auto_translate.Checked = Properties.Settings.Default.TranslateAuto;
            cb_drag_translate.Checked = Properties.Settings.Default.TranslateDrag;
            
            // 显示翻译选择列表
            System.Data.DataTable dt_from = new System.Data.DataTable();
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

            System.Data.DataTable dt_to = new System.Data.DataTable();
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
            // 是否开机启动
            is_auto_start = Properties.Settings.Default.AutoStart;
            AutoStart(is_auto_start);
            //MessageBox.Show("AutoStart = " + is_auto_start);

        }

        private void Form_main_Load(object sender, EventArgs e)
        {
            //splitContainer1.Panel2Collapsed = !splitContainer1.Panel2Collapsed;
            InitBaiduYun(Properties.Settings.Default.OCRApiKey, Properties.Settings.Default.OCRSecretKey, false);
            var g = Graphics.FromHwnd(IntPtr.Zero);
            IntPtr desktop = g.GetHdc();
            mScreenWidth = System32DllHelper.GetDeviceCaps(desktop, (int)DeviceCap.DESKTOPHORZRES);
            mScreenHigth = System32DllHelper.GetDeviceCaps(desktop, (int)DeviceCap.DESKTOPVERTRES);
            RegisterAllHotKey();
            StartOrStopMouseHook();

            int runningTime = Environment.TickCount & Int32.MaxValue;     //获取系统启动后运行的毫秒数
            if (is_auto_start && runningTime < 300000)
            {
                this.WindowState = FormWindowState.Minimized;
                this.Visible = false;
            }
        }

        private void Form_main_FormClosing(object sender, FormClosingEventArgs e)
        {
            UnregisterAllHotKey();
            notifyIcon.Dispose();
        }

        private void RegisterAllHotKey()
        {
            int ocrBasicHotKey = Properties.Settings.Default.OcrBasicHotKey;
            if (ocrBasicHotKey != 0)
            {
                bool isRegistered = HotKeyDllHelper.RegisterHotKey(Handle, OcrBasicHotKeyID, 0x0001, ocrBasicHotKey);
                if (isRegistered == false)
                {
                    this.notifyIcon.ShowBalloonTip(300, "快捷键被占用", "无法使用快捷键文字识别！点击查看", ToolTipIcon.Info);
                }
            }
        }

        private void UnregisterAllHotKey()
        {
            HotKeyDllHelper.UnregisterHotKey(Handle, OcrBasicHotKeyID);
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

        #region 按钮点击事件

        private void btn_ocr_basic_Click(object sender, EventArgs e)
        {
            if (!isInit)
            {
                MessageBox.Show("百度云OCR账号信息未设置：请点击【设置】-->【百度云设置】进行修改");
                return;
            }
            ScreenShot(CatchType.OCR_BASIC);
        }

        private void btn_ocr_copy_Click(object sender, EventArgs e)
        {
            //复制到粘贴板
            if (!"".Equals(tb_ocr_result.Text))
            {
                try
                {
                    Clipboard.Clear();
                    Clipboard.SetDataObject(tb_ocr_result.Text.ToString());
                    MessageBox.Show("拷贝成功");
                }
                catch (Exception)
                {
                    MessageBox.Show("拷贝失败");
                }
            }
            else
            {
                MessageBox.Show("拷贝内容为空");
            }
        }

        private void btn_ocr_clean_Click(object sender, EventArgs e)
        {
            tb_ocr_result.Text = "";
        }

        private void btn_translate_Click(object sender, EventArgs e)
        {
            ShowTranslateResult(tb_ocr_result.Text);
        }

        #endregion

        #region 调用截图操作
        //截图状态的判定
        private void ScreenShot(CatchType type)
        {
            if (isScreenShot == false)
            {
                Form_catch form_catch = new Form_catch(type);
                //注册Catch窗体定义的事件委托
                form_catch.SetICSEvent += new SetICS(SetisScreenShot);
                //进入截图
                DialogResult result = form_catch.ShowDialog();
                if (result == DialogResult.OK && type != CatchType.CATCH)
                {
                    if (type == CatchType.OCR_BASIC)
                    {
                        if (this.Visible == false)
                        {
                            this.ShowForm();
                        }
                        string ocr_result = null;
                        ocr_result = OcrBasic(form_catch.catchPicture);
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
                            MessageBox.Show("识别失败，请检查文字识别API Key 、Secret Key是否设置正确。");
                        }
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
                    this.Location = new System.Drawing.Point(mScreenWidth, mScreenHigth);
                }
                else
                {
                    this.Location = new System.Drawing.Point(mLastLocationX, mLastLocationY);
                }
            }
        }

        #endregion

        #region 调用百度OCR接口识别结果

        /// <summary>
        /// 百度通用文字识别
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
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
                if (bean.ErrorCode != 0)
                {
                    Console.WriteLine("识别失败");
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
                Clipboard.Clear();
                Clipboard.SetDataObject(sb.ToString());
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
        #endregion

        #region 设置菜单操作
        private void 开机启动ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (AutoStart(!is_auto_start))
            {
                is_auto_start = !is_auto_start;
                Properties.Settings.Default.AutoStart = is_auto_start;
                Properties.Settings.Default.Save();
            }
        }

        private void 文字识别服务ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_baiduyun baiduyun = new Form_baiduyun(BaiduYunType.OCR);
            DialogResult result = baiduyun.ShowDialog();
            if (result == DialogResult.OK)
            {
                InitBaiduYun(Properties.Settings.Default.OCRApiKey, Properties.Settings.Default.OCRSecretKey);
            }
        }

        private void 机器翻译服务ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_baiduyun baiduyun = new Form_baiduyun(BaiduYunType.TRANSLATE);
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


        #endregion

        #region 其他菜单操作

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
                    MessageBox.Show("识别失败，请检查文字识别API Key 、Secret Key是否设置正确。");
                }
            }
        }

        private void 关于我们ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form_about about = new Form_about();
            about.Show();
        }

        #endregion

        #region 系统托管图标右键菜单
        private void 显示ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ShowForm();
        }

        private void 文字识别ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (!isInit)
            {
                MessageBox.Show("百度云OCR账号信息未设置！请点击【设置】-->【百度云设置】进行修改");
                return;
            }
            else
            {
                ScreenShot(CatchType.OCR_BASIC);
            }
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
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

        #endregion

        #region 快捷键响应

        //重载WndProc窗口事件方法，以响应快捷键
        protected override void WndProc(ref Message m)
        {
            switch (m.WParam.ToInt32())
            {
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

        #endregion

        #region 翻译

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

        #endregion

        #region 屏幕划词
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

        #endregion

        #region 通用方法
        /// <summary>
        /// 判断字符串中是否包含中文
        /// </summary>
        /// <param name="str">需要判断的字符串</param>
        /// <returns>判断结果</returns>
        public bool HasChinese(string str)
        {
            return Regex.IsMatch(str, @"[\u4e00-\u9fa5]");
        }

        public bool AutoStart(bool isAuto)
        {
            try
            {
                var value = System.Windows.Forms.Application.ExecutablePath.Replace("/", "\\");
                if (isAuto)
                {
                    var currentUser = Registry.CurrentUser;
                    var registryKey = currentUser.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run");
                    registryKey.SetValue("MyScreenTools", value);
                    registryKey.Close();
                    currentUser.Close();
                    开机启动ToolStripMenuItem.Image = Properties.Resources.选择框_选中;
                }
                else
                {
                    var currentUser2 = Registry.CurrentUser;
                    var registryKey2 = currentUser2.CreateSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Run");
                    registryKey2.DeleteValue("MyScreenTools", false);
                    registryKey2.Close();
                    currentUser2.Close();
                    开机启动ToolStripMenuItem.Image = Properties.Resources.选择框_未选;
                }
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("您需要管理员权限修改", "提示");
            }
            return false;
        }

        #endregion
    }
}
