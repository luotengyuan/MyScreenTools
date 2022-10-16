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
using ScreenToGif.UI;
using ScreenColorPicker.UI;
using CommonLibrary;

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
        private const int PasteHotKeyID = 102;
        private const int PickColorHotKeyKeyID = 103;
        private const int OcrBasicHotKeyID = 104;
        private const int OcrExcelHotKeyID = 105;
        private const int GifHotKeyID = 106;

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
            if (tabControl.SelectedIndex == 0)
            {
                btn_ocr_copy_to_excel.Visible = false;
            }
            else
            {
                btn_ocr_copy_to_excel.Visible = true;
            }

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
                bool isRegistered = HotKeyDllHelper.RegisterHotKey(Handle, CatchHotKeyID, 0x0001, catchHotKey);
                if (isRegistered == false)
                {
                    this.notifyIcon.ShowBalloonTip(300, "快捷键被占用", "无法使用快捷键截图！点击查看", ToolTipIcon.Info);
                }
            }
            int pasteHotKey = Properties.Settings.Default.PasteHotKey;
            if (pasteHotKey != 0)
            {
                bool isRegistered = HotKeyDllHelper.RegisterHotKey(Handle, PasteHotKeyID, 0x0001, pasteHotKey);
                if (isRegistered == false)
                {
                    this.notifyIcon.ShowBalloonTip(300, "快捷键被占用", "无法使用快捷键截图！点击查看", ToolTipIcon.Info);
                }
            }
            int pickColorHotKey = Properties.Settings.Default.PickColorHotKey;
            if (pickColorHotKey != 0)
            {
                bool isRegistered = HotKeyDllHelper.RegisterHotKey(Handle, PickColorHotKeyKeyID, 0x0001, pickColorHotKey);
                if (isRegistered == false)
                {
                    this.notifyIcon.ShowBalloonTip(300, "快捷键被占用", "无法使用快捷键屏幕取色！点击查看", ToolTipIcon.Info);
                }
            }
            int ocrBasicHotKey = Properties.Settings.Default.OcrBasicHotKey;
            if (ocrBasicHotKey != 0)
            {
                bool isRegistered = HotKeyDllHelper.RegisterHotKey(Handle, OcrBasicHotKeyID, 0x0001, ocrBasicHotKey);
                if (isRegistered == false)
                {
                    this.notifyIcon.ShowBalloonTip(300, "快捷键被占用", "无法使用快捷键文字识别！点击查看", ToolTipIcon.Info);
                }
            }
            int ocrExcelHotKey = Properties.Settings.Default.OcrExcelHotKey;
            if (ocrExcelHotKey != 0)
            {
                bool isRegistered = HotKeyDllHelper.RegisterHotKey(Handle, OcrExcelHotKeyID, 0x0001, ocrExcelHotKey);
                if (isRegistered == false)
                {
                    this.notifyIcon.ShowBalloonTip(300, "快捷键被占用", "无法使用快捷键文字识别！点击查看", ToolTipIcon.Info);
                }
            }
            int gifHotKey = Properties.Settings.Default.GifHotKey;
            if (gifHotKey != 0)
            {
                bool isRegistered = HotKeyDllHelper.RegisterHotKey(Handle, GifHotKeyID, 0x0001, gifHotKey);
                if (isRegistered == false)
                {
                    this.notifyIcon.ShowBalloonTip(300, "快捷键被占用", "无法使用快捷键文字识别！点击查看", ToolTipIcon.Info);
                }
            }
        }

        private void UnregisterAllHotKey()
        {
            HotKeyDllHelper.UnregisterHotKey(Handle, CatchHotKeyID);
            HotKeyDllHelper.UnregisterHotKey(Handle, PasteHotKeyID);
            HotKeyDllHelper.UnregisterHotKey(Handle, PickColorHotKeyKeyID);
            HotKeyDllHelper.UnregisterHotKey(Handle, OcrBasicHotKeyID);
            HotKeyDllHelper.UnregisterHotKey(Handle, OcrExcelHotKeyID);
            HotKeyDllHelper.UnregisterHotKey(Handle, GifHotKeyID);
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

        private void btn_screenshot_Click(object sender, EventArgs e)
        {
            ScreenShot(CatchType.CATCH);
        }

        private void btn_screen_paste_Click(object sender, EventArgs e)
        {
            ScreenShot(CatchType.PASTE);
        }

        private void btn_color_Click(object sender, EventArgs e)
        {
            ShowPickColor();
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

        private void btn_ocr_excel_Click(object sender, EventArgs e)
        {
            if (!isInit)
            {
                MessageBox.Show("百度云OCR账号信息未设置：请点击【设置】-->【百度云设置】进行修改");
                return;
            }
            ScreenShot(CatchType.OCR_EXCEL);
        }

        private void btn_screen_gif_Click(object sender, EventArgs e)
        {
            ShowScreenToGif();
        }

        private void btn_ocr_copy_Click(object sender, EventArgs e)
        {
            if (tabControl.SelectedIndex == 0)
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
            else
            {
                if (CopyToClipboard(dataGridView, "MyScreenTools"))
                {
                    MessageBox.Show("拷贝成功");
                }
                else
                {
                    MessageBox.Show("拷贝失败");
                }
            }
        }

        private void btn_ocr_copy_to_excel_Click(object sender, EventArgs e)
        {
            if (tabControl.SelectedIndex == 0)
            {
                tb_ocr_result.Text = "";
            }
            else
            {
                if (CopyToExcel(dataGridView, "MyScreenTools"))
                {
                    MessageBox.Show("拷贝成功");
                }
                else
                {
                    MessageBox.Show("拷贝失败");
                }
            }
        }

        private void btn_ocr_clean_Click(object sender, EventArgs e)
        {
            if (tabControl.SelectedIndex == 0)
            {
                tb_ocr_result.Text = "";
            }
            else
            {
                dataGridView.DataSource = new System.Data.DataTable();
            }
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
                if (type == CatchType.CATCH)
                {
                    isScreenShot = true;
                    mLastLocationX = this.Location.X;
                    mLastLocationY = this.Location.Y;
                    this.Location = new System.Drawing.Point(mScreenWidth, mScreenHigth);
                    PrScrnDllHelper.PrScrn();
                    this.Location = new System.Drawing.Point(mLastLocationX, mLastLocationY);
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
                    if (type == CatchType.PASTE)
                    {
                        Form_paste paste = new Form_paste(form_catch.catchPicture, form_catch.Rect);
                        paste.Show();
                    }
                    else if (type == CatchType.OCR_BASIC)
                    {
                        if (this.Visible == false)
                        {
                            this.ShowForm();
                        }
                        // 切换到文字视图
                        tabControl.SelectedIndex = 0;
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
                    else if (type == CatchType.OCR_EXCEL)
                    {
                        if (this.Visible == false)
                        {
                            this.ShowForm();
                        }
                        // 切换到表格视图
                        tabControl.SelectedIndex = 1;
                        System.Data.DataTable ocr_excel_result = null;
                        ocr_excel_result = OcrExcel(form_catch.catchPicture);
                        if (ocr_excel_result != null)
                        {
                            if (ocr_excel_result.Columns.Count <= 0)
                            {
                                MessageBox.Show("识别内容为空");
                            }
                            else
                            {
                                dataGridView.DataSource = ocr_excel_result;
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

        /// <summary>
        /// 百度表格识别
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private System.Data.DataTable OcrExcel(string path)
        {
            System.Data.DataTable dt = new System.Data.DataTable();//DataGridView未设置列名信息的时候可以直接指定DataSource
            try
            {
                // 图片文件路径
                var image = System.IO.File.ReadAllBytes(path);
                // 调用通用文字识别, 图片参数为本地图片，可能会抛出网络等异常，请使用try/catch捕获
                var result = client.Form(image);//表格识别
                if (result == null)
                {
                    Console.WriteLine("识别结果为空");
                    return null;
                }
                Console.WriteLine(result);
                OcrExcelBean bean = JsonConvert.DeserializeObject<OcrExcelBean>(result.ToString());
                if (bean == null)
                {
                    Console.WriteLine("识别结果为空");
                    return null;
                }
                if (bean.forms_result_num <= 0 || bean.forms_result == null || bean.forms_result.Count <= 0)
                {
                    Console.WriteLine("未识别到表格");
                    return null;
                }
                int maxColumn = 0;
                int maxRow = 0;
                foreach (Forms_resultItem item in bean.forms_result)
                {
                    List<BodyItem> bodyList = item.body;
                    if (bodyList == null || bodyList.Count <= 0)
                    {
                        continue;
                    }
                    foreach (BodyItem body in bodyList)
                    {
                        if (body.column + 1 > maxColumn)
                        {
                            maxColumn = body.column + 1;
                        }
                        if (body.row + 1 > maxRow)
                        {
                            maxRow = body.row + 1;
                        }
                    }
                    break;
                }
                for (int i = 0; i < maxColumn; i++)
                {
                    dt.Columns.Add("列-" + (i + 1), Type.GetType("System.String"));
                }
                for (int i = 0; i < maxRow; i++)
                {
                    DataRow dr = dt.NewRow();
                    foreach (Forms_resultItem item in bean.forms_result)
                    {
                        List<BodyItem> bodyList = item.body;
                        if (bodyList == null || bodyList.Count <= 0)
                        {
                            continue;
                        }
                        foreach (BodyItem body in bodyList)
                        {
                            if (body.row == i)
                            {
                                dr[body.column] = body.words;
                            }
                        }
                        break;
                    }
                    dt.Rows.Add(dr);
                }
                return dt;
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
                // 切换到表格视图
                tabControl.SelectedIndex = 0;
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

        private void 表格识别ToolStripMenuItem1_Click(object sender, EventArgs e)
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
                // 切换到表格视图
                tabControl.SelectedIndex = 1;
                System.Data.DataTable ocr_excel_result = null;
                ocr_excel_result = OcrExcel(openFileDialog.FileName);
                if (ocr_excel_result != null)
                {
                    if (ocr_excel_result.Columns.Count <= 0)
                    {
                        MessageBox.Show("识别内容为空");
                    }
                    else
                    {
                        dataGridView.DataSource = ocr_excel_result;
                    }
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

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (tabControl.SelectedIndex == 0)
            {
                btn_ocr_copy_to_excel.Visible = false;
            }
            else
            {
                btn_ocr_copy_to_excel.Visible = true;
            }
        }

        #endregion

        #region 系统托管图标右键菜单
        private void 显示ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.ShowForm();
        }

        private void 截图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ScreenShot(CatchType.CATCH);
        }

        private void 贴图ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ScreenShot(CatchType.PASTE);
        }

        private void 屏幕取色ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ShowPickColor();
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

        private void 表格识别ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!isInit)
            {
                MessageBox.Show("百度云OCR账号信息未设置！请点击【设置】-->【百度云设置】进行修改");
                return;
            }
            else
            {
                ScreenShot(CatchType.OCR_EXCEL);
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
                case CatchHotKeyID:
                    ScreenShot(CatchType.CATCH);
                    break;
                case PasteHotKeyID:
                    ScreenShot(CatchType.PASTE);
                    break;
                case PickColorHotKeyKeyID:
                    ShowPickColor();
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
                case OcrExcelHotKeyID:
                    if (!isInit)
                    {
                        MessageBox.Show("百度云OCR账号信息未设置！请点击【设置】-->【百度云设置】进行修改");
                        return;
                    }
                    else
                    {
                        ScreenShot(CatchType.OCR_EXCEL);
                    }
                    break;
                case GifHotKeyID:
                    ShowScreenToGif();
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

        #region 屏幕取色
        private void ShowPickColor()
        {
            Form_color color = new Form_color();
            if (this.Visible)
            {
                mLastLocationX = this.Location.X;
                mLastLocationY = this.Location.Y;
                this.Location = new System.Drawing.Point(mScreenWidth, mScreenHigth);
            }
            color.ShowDialog();
            if (this.Visible)
            {
                this.Location = new System.Drawing.Point(mLastLocationX, mLastLocationY);
            }
        }

        #endregion

        #region 截屏GIF

        private void ShowScreenToGif()
        {
            Form_gif_main gif_main = new Form_gif_main();
            if (this.Visible)
            {
                mLastLocationX = this.Location.X;
                mLastLocationY = this.Location.Y;
                this.Location = new System.Drawing.Point(mScreenWidth, mScreenHigth);
            }
            gif_main.ShowDialog();
            if (this.Visible)
            {
                this.Location = new System.Drawing.Point(mLastLocationX, mLastLocationY);
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

        /// <summary>
        /// 将DataGridView选中数据复制到Excel表格中
        /// </summary>
        /// <param name="ExportDgv"></param>
        /// <param name="DgvTitle"></param>
        /// <returns></returns>
        public bool CopyToExcel(DataGridView ExportDgv, string DgvTitle)
        {
            try
            {
                if (ExportDgv == null)
                {
                    return false;
                }
                if (ExportDgv.Columns.Count == 0 || ExportDgv.Rows.Count == 0)
                {
                    return false;
                }
                //Excela2003最大行是65535，最大列是255
                //Excela2007最大行是1048576，最大列是16384
                //if(ExportDgv.RowCount > 65536 || ExportDgv.ColumnCount > 256){
                //return false;
                //}
                ExportDgv.Focus();
                //复制数据到Clipboard
                int I = ExportDgv.GetCellCount(DataGridViewElementStates.Selected);
                if (I > 0)
                {
                    Clipboard.Clear();
                    Clipboard.SetDataObject(ExportDgv.GetClipboardContent());
                }
                //创建Excel)对象
                Microsoft.Office.Interop.Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();
                if (xlApp == null)
                {
                    return false;
                }
                //创建Excel工作薄
                Microsoft.Office.Interop.Excel.Workbook xlBook = xlApp.Workbooks.Add(true);
                //创建Excel工作表
                Microsoft.Office.Interop.Excel.Worksheet xlSheet = (Microsoft.Office.Interop.Excel.Worksheet)xlBook.Worksheets[1];// 第一个工作表
                //粘贴数据
                xlSheet.get_Range("A1", System.Type.Missing).PasteSpecial(XlPasteType.xlPasteAll, XlPasteSpecialOperation.xlPasteSpecialOperationNone, System.Type.Missing, System.Type.Missing);
                //显示工作薄区间
                xlApp.Visible = true;
                xlApp.Caption = DgvTitle;
                //设置文本表格的属性
                xlApp.Cells.EntireColumn.AutoFit();//自动列宽
                xlApp.Cells.VerticalAlignment = Microsoft.Office.Interop.Excel.Constants.xlCenter;
                xlApp.Cells.HorizontalAlignment = Microsoft.Office.Interop.Excel.Constants.xlLeft;
                xlApp.ErrorCheckingOptions.BackgroundChecking = false;
                xlApp.ErrorCheckingOptions.BackgroundChecking = false;
                return true;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 将DataGridView选中数据复制到剪贴板
        /// </summary>
        /// <param name="ExportDgv"></param>
        /// <param name="DgvTitle"></param>
        /// <returns></returns>
        public bool CopyToClipboard(DataGridView ExportDgv, string DgvTitle)
        {
            try
            {
                if (ExportDgv == null)
                {
                    return false;
                }
                if (ExportDgv.Columns.Count == 0 || ExportDgv.Rows.Count == 0)
                {
                    return false;
                }
                //Excela2003最大行是65535，最大列是255
                //Excela2007最大行是1048576，最大列是16384
                //if(ExportDgv.RowCount > 65536 || ExportDgv.ColumnCount > 256){
                //return false;
                //}
                ExportDgv.Focus();
                //复制数据到Clipboard
                int I = ExportDgv.GetCellCount(DataGridViewElementStates.Selected);
                if (I <= 0)
                {
                    return false;
                }
                Clipboard.Clear();
                Clipboard.SetDataObject(ExportDgv.GetClipboardContent());
                return true;
            }
            catch
            {
                return false;
            }
        }

        #endregion
    }
}
