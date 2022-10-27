using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ScreenToGif.Encoding;
using System.Timers;
using System.Collections.Specialized;
using System.Windows;
using ScreenToGif.LibHelper;

namespace ScreenToGif.UI
{
    public partial class Form_gif_main : Form
    {

        #region 界面镂空参数方法

        private const uint WS_EX_LAYERED = 0x80000;//异形窗体特效的实现
        private const int GWL_EXSTYLE = -20;//设定一个新的扩展风格
        private const int LWA_COLORKEY = 1;//透明方式
        [DllImport("user32", EntryPoint = "SetWindowLong")]
        //改变指定窗口的属性
        private static extern uint SetWindowLong(IntPtr hwnd, int nIndex, uint dwNewLong);
        [DllImport("user32", EntryPoint = "SetLayeredWindowAttributes")]
        //设置分层窗口透明度
        private static extern int SetLayeredWindowAttributes(IntPtr hwnd, int crKey, int bAlpha, int dwFlags);

        #endregion

        #region 屏幕相关参数

        /// <summary>
        /// 经过缩放后的屏幕实际尺寸
        /// </summary>
        private int full_screen_width_real;
        private int full_screen_higth_real;
        /// <summary>
        /// 设备原本的屏幕尺寸
        /// </summary>
        private int full_screen_width_device;
        private int full_screen_higth_device;
        /// <summary>
        /// 屏幕缩放比例
        /// </summary>
        private double scale = 1;

        #endregion

        #region 界面设置相关参数
        
        /// <summary>
        /// 帧率
        /// </summary>
        private int gif_fps = 0;
        /// <summary>
        /// 是否全屏录制
        /// </summary>
        private bool is_full_screen = false;
        /// <summary>
        /// 是否捕获鼠标位置
        /// </summary>
        private bool is_catch_mouse = false;

        /// <summary>
        /// 录制区域尺寸大小
        /// </summary>
        private Size gif_area_size;
        /// <summary>
        /// 录制区域左上角坐标点
        /// </summary>
        private Point gif_area_location;

        /// <summary>
        /// 窗口尺寸大小
        /// </summary>
        private Size form_size;
        /// <summary>
        /// 窗口左上角坐标点
        /// </summary>
        private Point form_location;

        /// <summary>
        /// 已选择的帧率选项
        /// </summary>
        ToolStripMenuItem sltFpsToolStripMenuItem = null;

        /// <summary>
        /// 过滤第一次窗口尺寸变化
        /// </summary>
        private bool firstSizeChangedTag = true;
        /// <summary>
        /// 过滤第一次窗口位置变化
        /// </summary>
        private bool firstLocationChangedTag = true;

        #endregion

        #region 录制相关参数

        /// <summary>
        /// 自动录制定时器
        /// </summary>
        System.Timers.Timer timer = null;
        /// <summary>
        /// 是否正在自动录制
        /// </summary>
        bool isRunning = false;
        /// <summary>
        /// 录制帧列表
        /// </summary>
        List<string> _listFrames = new List<string>();        
        /// <summary>
        /// 录制生成的图片临时存放路径
        /// </summary>
        private readonly string _pathTemp = Path.GetTempPath() + @"ScreenToGif\Recording\";
        private readonly string _pathCopy = Path.GetTempPath() + @"ScreenToGif\Copy\";
        /// <summary>
        /// 录制帧计数（用于在临时目录中存放文件命名）
        /// </summary>
        private int _frameCount = 0;
        /// <summary>
        /// 是否拷贝到剪切板
        /// </summary>
        private bool isCopyMode = false;
        private string copyPath = null;

        #endregion

        #region 快捷键相关参数
        private const int KeyID_btn_continue = 1001;
        private const int KeyID_btn_single = 102;
        #endregion

        #region 初始化方法

        public Form_gif_main()
        {
            InitializeComponent();
            SetTopAndHollow();
        }

        private void Form_gif_main_Load(object sender, EventArgs e)
        {
            InitView();
            InitTimer();
            CreateTemp();
            _addDel = AddFrames;
            RegisterHotKey();
        }

        private void Form_gif_main_FormClosing(object sender, FormClosingEventArgs e)
        {
            UnregisterHotKey();
        }

        private void Form_gif_main_SizeChanged(object sender, EventArgs e)
        {
            SetTitel();
            SetGifAreaSize();
            if (firstSizeChangedTag)
            {
                firstSizeChangedTag = !firstSizeChangedTag;
            }
            else
            {
                SetFormSize();
            }
        }

        private void Form_gif_main_LocationChanged(object sender, EventArgs e)
        {
            SetGifAreaLocation();
            if (firstLocationChangedTag)
            {
                firstLocationChangedTag = !firstLocationChangedTag;
            }
            else
            {
                SetFormLocation();
            }
        }

        /// <summary>
        /// 初始化界面
        /// </summary>
        private void InitView()
        {
            InitConfig();
            SetTitel();
        }

        /// <summary>
        /// 初始化配置信息
        /// </summary>
        private void InitConfig()
        {
            full_screen_width_real = Screen.PrimaryScreen.Bounds.Width;
            full_screen_higth_real = Screen.PrimaryScreen.Bounds.Height;
            //获取屏幕真实宽高
            var g = Graphics.FromHwnd(IntPtr.Zero);
            IntPtr desktop = g.GetHdc();
            full_screen_width_device = System32DllHelper.GetDeviceCaps(desktop, (int)DeviceCap.DESKTOPHORZRES);
            full_screen_higth_device = System32DllHelper.GetDeviceCaps(desktop, (int)DeviceCap.DESKTOPVERTRES);
            scale = full_screen_width_device * 1.0 / full_screen_width_real;
            gif_area_size = Properties.Settings.Default.Setting_gif_area_size;
            gif_area_location = Properties.Settings.Default.Setting_gif_area_location;
            form_size = Properties.Settings.Default.Setting_form_size;
            form_location = Properties.Settings.Default.Setting_form_location;
            if (form_location.X > 0 && form_location.Y > 0 && form_location.X < full_screen_width_device - 100 && form_location.Y < full_screen_higth_device - 100)
            {
                this.Location = form_location;
            }
            else
            {
                SetGifAreaLocation();
            }
            if (form_size.Width > 50 && form_size.Height > 50)
            {
                this.Size = form_size;
            }
            else
            {
                SetGifAreaSize();
            }
            gif_fps = Properties.Settings.Default.Setting_gif_fps;
            switch (gif_fps)
            {
                case 1:
                    fPSToolStripMenuItem_1.CheckState = CheckState.Checked;
                    sltFpsToolStripMenuItem = fPSToolStripMenuItem_1;
                    break;
                case 5:
                    fPSToolStripMenuItem_5.CheckState = CheckState.Checked;
                    sltFpsToolStripMenuItem = fPSToolStripMenuItem_5;
                    break;
                case 10:
                    fPSToolStripMenuItem_10.CheckState = CheckState.Checked;
                    sltFpsToolStripMenuItem = fPSToolStripMenuItem_10;
                    break;
                case 16:
                    fPSToolStripMenuItem_16.CheckState = CheckState.Checked;
                    sltFpsToolStripMenuItem = fPSToolStripMenuItem_16;
                    break;
                case 33:
                    fPSToolStripMenuItem_33.CheckState = CheckState.Checked;
                    sltFpsToolStripMenuItem = fPSToolStripMenuItem_33;
                    break;
                case 50:
                    fPSToolStripMenuItem_50.CheckState = CheckState.Checked;
                    sltFpsToolStripMenuItem = fPSToolStripMenuItem_50;
                    break;
                default:
                    gif_fps = 10;
                    fPSToolStripMenuItem_10.CheckState = CheckState.Checked;
                    sltFpsToolStripMenuItem = fPSToolStripMenuItem_10;
                    break;
            }
            bool is_full = Properties.Settings.Default.Setting_is_full_screen;
            if (is_full)
            {
                GoToFullScreen();
                全屏区域ToolStripMenuItem.CheckState = CheckState.Checked;
            }
            else
            {
                ExitFullScreen();
                自定义区域ToolStripMenuItem.CheckState = CheckState.Checked;
            }
            is_catch_mouse = Properties.Settings.Default.Setting_is_catch_mouse;
            if (is_catch_mouse)
            {
                捕获鼠标ToolStripMenuItem.CheckState = CheckState.Checked;
            }
            int encode_mode = Properties.Settings.Default.Setting_form_encode_mode;
            if (encode_mode == 0)
            {
                压缩编码ToolStripMenuItem.CheckState = CheckState.Checked;
            }
            else
            {
                原始编码ToolStripMenuItem.CheckState = CheckState.Checked;
            }
        }

        /// <summary>
        /// 创建临时目录
        /// </summary>
        private void CreateTemp()
        {
            #region Temp Folder

            try
            {
                Directory.Delete(_pathTemp, true);
            }
            catch (Exception)
            {
            }
            if (!Directory.Exists(_pathTemp))
            {
                Directory.CreateDirectory(_pathTemp);
            }
            if (!Directory.Exists(_pathCopy))
            {
                Directory.CreateDirectory(_pathCopy);
            }

            #endregion
        }

        /// <summary>
        /// 初始化定时器
        /// </summary>
        private void InitTimer()
        {
            timer = new System.Timers.Timer();
            timer.Interval = 1000 / gif_fps;
            timer.Elapsed += new ElapsedEventHandler(TimerUp);
        }

        /// <summary>
        /// Timer类执行定时到点事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TimerUp(object sender, ElapsedEventArgs e)
        {
            AddBitmapToList();
        }

        #endregion

        #region 按钮点击事件

        private void btn_continue_Click(object sender, EventArgs e)
        {
            ContinueRecordStartOrPause();
        }

        private void btn_single_Click(object sender, EventArgs e)
        {
            AddBitmapToList();
        }

        private void btn_clean_Click(object sender, EventArgs e)
        {
            CleanAllFrames();
        }

        private void btn_setting_Click(object sender, EventArgs e)
        {
            cms_setting.Show(btn_setting, 0, btn_setting.Size.Height);
        }

        private void btn_copy_Click(object sender, EventArgs e)
        {
            if (_listFrames == null || _listFrames.Count <= 0)
            {
                MessageBox.Show("没有需要保持的数据");
                return;
            }
            if (isRunning)
            {
                MessageBox.Show("请先暂停录制");
                return;
            }
            string temp_path = String.Format("{0}GIF_{1}.gif", _pathCopy, DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
            isCopyMode = true;
            copyPath = temp_path;
            SaveGifToFile(temp_path);
            
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            if (_listFrames == null || _listFrames.Count <= 0)
            {
                MessageBox.Show("没有需要保持的数据");
                return;
            }
            if (isRunning)
            {
                MessageBox.Show("请先暂停录制");
                return;
            }
            SaveFileDialog savedialog = new SaveFileDialog();
            savedialog.FileName = "保存动图";
            savedialog.Filter = "Gif 图片|*.gif";
            savedialog.FilterIndex = 0;
            savedialog.RestoreDirectory = true;//保存对话框是否记忆上次打开的目录
            savedialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);//初始默认目录，桌面
            savedialog.CheckPathExists = true;//检查目录
            savedialog.FileName = "GIF_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");//设置默认文件名
            if (savedialog.ShowDialog() == DialogResult.OK)
            {
                isCopyMode = false;
                SaveGifToFile(savedialog.FileName);
            }

        }

        /// <summary>
        /// 退出全屏状态
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_exit_Click(object sender, EventArgs e)
        {
            ExitFullScreen();
        }

        #endregion

        #region 设置菜单选项点击事件

        private void fPSToolStripMenuItem_1_Click(object sender, EventArgs e)
        {
            if (sltFpsToolStripMenuItem != fPSToolStripMenuItem_1)
            {
                sltFpsToolStripMenuItem.CheckState = CheckState.Unchecked;
                fPSToolStripMenuItem_1.CheckState = CheckState.Checked;
                sltFpsToolStripMenuItem = fPSToolStripMenuItem_1;
                gif_fps = 1;
                Properties.Settings.Default.Setting_gif_fps = gif_fps;
                Properties.Settings.Default.Save();
                timer.Interval = 1000 / gif_fps;
            }
        }

        private void fPSToolStripMenuItem_5_Click(object sender, EventArgs e)
        {
            if (sltFpsToolStripMenuItem != fPSToolStripMenuItem_5)
            {
                sltFpsToolStripMenuItem.CheckState = CheckState.Unchecked;
                fPSToolStripMenuItem_5.CheckState = CheckState.Checked;
                sltFpsToolStripMenuItem = fPSToolStripMenuItem_5;
                gif_fps = 5;
                Properties.Settings.Default.Setting_gif_fps = gif_fps;
                Properties.Settings.Default.Save();
                timer.Interval = 1000 / gif_fps;
            }
        }

        private void fPSToolStripMenuItem_10_Click(object sender, EventArgs e)
        {
            if (sltFpsToolStripMenuItem != fPSToolStripMenuItem_10)
            {
                sltFpsToolStripMenuItem.CheckState = CheckState.Unchecked;
                fPSToolStripMenuItem_10.CheckState = CheckState.Checked;
                sltFpsToolStripMenuItem = fPSToolStripMenuItem_10;
                gif_fps = 10;
                Properties.Settings.Default.Setting_gif_fps = gif_fps;
                Properties.Settings.Default.Save();
                timer.Interval = 1000 / gif_fps;
            }
        }

        private void fPSToolStripMenuItem_16_Click(object sender, EventArgs e)
        {
            if (sltFpsToolStripMenuItem != fPSToolStripMenuItem_16)
            {
                sltFpsToolStripMenuItem.CheckState = CheckState.Unchecked;
                fPSToolStripMenuItem_16.CheckState = CheckState.Checked;
                sltFpsToolStripMenuItem = fPSToolStripMenuItem_16;
                gif_fps = 16;
                Properties.Settings.Default.Setting_gif_fps = gif_fps;
                Properties.Settings.Default.Save();
                timer.Interval = 1000 / gif_fps;
            }
        }

        private void fPSToolStripMenuItem_33_Click(object sender, EventArgs e)
        {
            if (sltFpsToolStripMenuItem != fPSToolStripMenuItem_33)
            {
                sltFpsToolStripMenuItem.CheckState = CheckState.Unchecked;
                fPSToolStripMenuItem_33.CheckState = CheckState.Checked;
                sltFpsToolStripMenuItem = fPSToolStripMenuItem_33;
                gif_fps = 33;
                Properties.Settings.Default.Setting_gif_fps = gif_fps;
                Properties.Settings.Default.Save();
                timer.Interval = 1000 / gif_fps;
            }
        }

        private void fPSToolStripMenuItem_50_Click(object sender, EventArgs e)
        {
            if (sltFpsToolStripMenuItem != fPSToolStripMenuItem_50)
            {
                sltFpsToolStripMenuItem.CheckState = CheckState.Unchecked;
                fPSToolStripMenuItem_50.CheckState = CheckState.Checked;
                sltFpsToolStripMenuItem = fPSToolStripMenuItem_50;
                gif_fps = 50;
                Properties.Settings.Default.Setting_gif_fps = gif_fps;
                Properties.Settings.Default.Save();
                timer.Interval = 1000 / gif_fps;
            }
        }

        private void 自定义区域ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExitFullScreen();
        }

        private void 全屏区域ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GoToFullScreen();
        }

        private void 捕获鼠标ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (捕获鼠标ToolStripMenuItem.CheckState == CheckState.Checked)
            {
                捕获鼠标ToolStripMenuItem.CheckState = CheckState.Unchecked;
                is_catch_mouse = false;
            }
            else
            {
                捕获鼠标ToolStripMenuItem.CheckState = CheckState.Checked;
                is_catch_mouse = true;
            }
            Properties.Settings.Default.Setting_is_catch_mouse = is_catch_mouse;
            Properties.Settings.Default.Save();
        }

        private void 压缩编码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            压缩编码ToolStripMenuItem.CheckState = CheckState.Checked;
            原始编码ToolStripMenuItem.CheckState = CheckState.Unchecked;
            Properties.Settings.Default.Setting_form_encode_mode = 0;
            Properties.Settings.Default.Save();
        }

        private void 原始编码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            压缩编码ToolStripMenuItem.CheckState = CheckState.Unchecked;
            原始编码ToolStripMenuItem.CheckState = CheckState.Checked;
            Properties.Settings.Default.Setting_form_encode_mode = 1;
            Properties.Settings.Default.Save();
        }

        #endregion

        #region 录制方法

        /// <summary>
        /// Saves the Bitmap to the disk and adds the filename in the list of frames.
        /// </summary>
        /// <param name="filename">The final filename of the Bitmap.</param>
        /// <param name="bitmap">The Bitmap to save in the disk.</param>
        public delegate void AddFrame(string filename, Bitmap bitmap);

        private AddFrame _addDel;

        private void AddFrames(string filename, Bitmap bitmap)
        {
            _listFrames.Add(filename);
            bitmap.Save(filename);
            bitmap.Dispose();
        }

        private void CallBack(IAsyncResult r)
        {
            if (this.IsDisposed) return;
            _addDel.EndInvoke(r);
            SetTitel();
        }

        private void AddBitmapToList()
        {
            Bitmap originBmp;
            if (is_full_screen)
            {
                originBmp = new Bitmap(full_screen_width_device, full_screen_higth_device);
            }
            else
            {
                originBmp = new Bitmap(GetScaleSize(gif_area_size.Width), GetScaleSize(gif_area_size.Height));
            }
            //以截屏图片作为画板
            using (Graphics gs = Graphics.FromImage(originBmp))
            {
                //复制当前屏幕到画板上，即将截屏图片的内容设置为当前屏幕
                gs.CopyFromScreen(is_full_screen ? 0 : GetScaleSize(gif_area_location.X), is_full_screen ? 0 : GetScaleSize(gif_area_location.Y), 0, 0, new System.Drawing.Size(originBmp.Width, originBmp.Height));
                if (is_catch_mouse)
                {
                    CursorInfo cursorInfo;
                    cursorInfo.cbSize = Marshal.SizeOf(typeof(CursorInfo));
                    System32DllHelper.GetCursorInfo(out cursorInfo);
                    System.Windows.Forms.Cursor cur = new System.Windows.Forms.Cursor(cursorInfo.hCursor);
                    cur.Draw(gs, new Rectangle(GetScaleSize(cursorInfo.ptScreenPos.X) - GetScaleSize(gif_area_location.X), GetScaleSize(cursorInfo.ptScreenPos.Y) - GetScaleSize(gif_area_location.Y), cur.Size.Width, cur.Size.Height));
                }
            }
            _addDel.BeginInvoke(String.Format("{0}{1}.bmp", _pathTemp, _frameCount), originBmp, CallBack, null);
            _frameCount++;
            SetTitel();
        }

        #endregion

        #region 公共方法

        /// <summary>
        /// 连续录制开始或暂停
        /// </summary>
        private void ContinueRecordStartOrPause()
        {
            if (!isRunning)
            {
                isRunning = true;
                timer.Start();
                btn_continue.Text = "暂停";
                SetTitel();
            }
            else
            {
                isRunning = false;
                timer.Stop();
                btn_continue.Text = "继续";
                SetTitel();
            }
        }

        /// <summary>
        /// 设置镂空界面
        /// </summary>
        private void SetTopAndHollow()
        {
            this.TopMost = true;
            SetWindowLong(Handle, GWL_EXSTYLE, WS_EX_LAYERED);
            SetLayeredWindowAttributes(Handle, 0x00FF00, 255, LWA_COLORKEY);//替换某种颜色为透明（0x00FF00：绿色）
        }

        /// <summary>
        /// 更新标题
        /// </summary>
        private void SetTitel()
        {
            Action action = () =>
            {
                // 标题内容
                // 1：GIF录屏
                // 2：宽高：458x698
                // 1：状态：未开始、录制中、已暂停
                // 1：已录制帧数：54帧
                this.Text = string.Format("GIF录屏 {0}x{1} {2} {3}帧", panel_gif_area.Size.Width, panel_gif_area.Size.Height, GetStatusStr(), _listFrames == null ? 0 : _listFrames.Count);
            };
            this.Invoke(action);
        }

        /// <summary>
        /// 获取状态字符串
        /// </summary>
        /// <returns></returns>
        private string GetStatusStr()
        {
            if (isRunning)
            {
                return "录制中";
            }
            else if (_listFrames == null || _listFrames.Count <= 0)
            {
                return "未开始";
            }
            else
            {
                return "已暂停";
            }
        }

        private void bgw_save_DoWork(object sender, DoWorkEventArgs e)
        {
            var bgworker = sender as BackgroundWorker;
            //获取从RunWorkerAsync（）方法里面传递的参数的值
            string path = (string) e.Argument;
            bool ret = false;

            if (压缩编码ToolStripMenuItem.CheckState == CheckState.Checked)
            {
                #region Ngif encoding

                int numImage = 0;

                #region Paint Unchanged Pixels

                var listToEncode = new List<FrameInfo>();

                bool paintTransparent = true;

                if (paintTransparent)//Settings.Default.paintTransparent)
                {
                    listToEncode = ImageUtil.PaintTransparentAndCut(_listFrames, Color.LawnGreen, bgworker);
                }

                #endregion

                using (var _encoder = new AnimatedGifEncoder())
                {
                    _encoder.Start(path);
                    _encoder.SetQuality(10);
                    _encoder.SetRepeat(0); // 0 = Always, -1 once

                    #region For Each Frame

                    try
                    {
                        if (paintTransparent)
                        {
                            #region With Transparency

                            _encoder.SetTransparent(Color.LawnGreen);
                            _encoder.SetDispose(1); //Undraw Method, "Leave".

                            foreach (FrameInfo image in listToEncode)
                            {
                                var bitmapAux = new Bitmap(image.Image);

                                _encoder.SetDelay(1000 / gif_fps);
                                _encoder.AddFrame(bitmapAux, image.PositionTopLeft.X, image.PositionTopLeft.Y);

                                bitmapAux.Dispose();
                                numImage++;
                                bgworker.ReportProgress(numImage);
                            }

                            #endregion
                        }
                        else
                        {
                            #region Without
                            foreach (var image in _listFrames)
                            {
                                _encoder.SetDelay(1000 / gif_fps);
                                _encoder.AddFrame(image.From());
                                numImage++;
                                bgworker.ReportProgress(numImage);
                            }

                            #endregion
                        }
                        ret = true;

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error in the Ngif encoding." + ex.ToString());
                    }

                    #endregion
                }

                #region Clean Speciffic Variables

                listToEncode.Clear();
                listToEncode = null;

                #endregion

                #endregion
            }
            else
            {

                using (var stream = new MemoryStream())
                {
                    using (var encoderNet = new GifEncoder(stream, null, null, 0))
                    {
                        for (int i = 0; i < _listFrames.Count; i++)
                        {
                            var bitmapAux = new Bitmap(_listFrames[i]);
                            encoderNet.AddFrame(bitmapAux, 0, 0, TimeSpan.FromMilliseconds(1000 / gif_fps));
                            bitmapAux.Dispose();
                            bgworker.ReportProgress(i + 1);
                        }
                    }

                    stream.Position = 0;

                    try
                    {
                        using (var fileStream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None, 0x2000, false))
                        {
                            stream.WriteTo(fileStream);
                        }
                        ret = true;
                    }
                    catch (Exception)
                    {
                    }
                }
            }
            e.Result = ret;
        }

        private void bgw_save_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            pb_save.Value = e.ProgressPercentage;
        }

        private void bgw_save_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            UpdateSaveStatusView(false);
            if (isCopyMode)
            {
                if ((bool)e.Result)
                {
                    StringCollection files = new StringCollection();
                    files.Add(copyPath);
                    Clipboard.SetFileDropList(files);
                    if (压缩编码ToolStripMenuItem.CheckState == CheckState.Checked)
                    {
                        CleanAllFrames();
                    }
                    MessageBox.Show("复制到剪切板成功");
                }
                else
                {
                    MessageBox.Show("保存GIF文件失败");
                }
            }
            else
            {
                if ((bool)e.Result)
                {
                    if (压缩编码ToolStripMenuItem.CheckState == CheckState.Checked)
                    {
                        CleanAllFrames();
                    }
                    MessageBox.Show("保存成功");
                }
                else
                {
                    MessageBox.Show("保存GIF文件失败");
                }
            }


        }

        /// <summary>
        /// 保存GIF到图片
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private void SaveGifToFile(string path)
        {
            UpdateSaveStatusView(true);
            int count = _listFrames.Count;
            pb_save.Maximum = count;
            pb_save.Value = 0;
            BackgroundWorker bgw_save = new BackgroundWorker();
            bgw_save.WorkerReportsProgress = true;
            bgw_save.DoWork += bgw_save_DoWork;
            bgw_save.ProgressChanged += bgw_save_ProgressChanged;
            bgw_save.RunWorkerCompleted += bgw_save_Completed;
            bgw_save.RunWorkerAsync(path);
        }

        private void UpdateSaveStatusView(bool isSaving)
        {
            panel_progress.Visible = isSaving;
            btn_continue.Enabled = !isSaving;
            btn_single.Enabled = !isSaving;
            btn_clean.Enabled = !isSaving;
            btn_setting.Enabled = !isSaving;
            btn_copy.Enabled = !isSaving;
            btn_save.Enabled = !isSaving;
            btn_exit.Enabled = !isSaving;
        }

        private void CleanAllFrames()
        {
            _listFrames.Clear();
            if (!isRunning)
            {
                btn_continue.Text = "录制";
            }
            SetTitel();
        }

        /// <summary>
        /// 更新窗口尺寸
        /// </summary>
        private void SetFormSize()
        {
            if (!is_full_screen)
            {
                form_size.Width = this.Size.Width;
                form_size.Height = this.Size.Height;
                Properties.Settings.Default.Setting_form_size = form_size;
                Properties.Settings.Default.Save();
            }
        }

        /// <summary>
        /// 更新窗口位置
        /// </summary>
        private void SetFormLocation()
        {
            if (!is_full_screen)
            {
                form_location.X = this.Location.X;
                form_location.Y = this.Location.Y;
                Properties.Settings.Default.Setting_form_location = form_location;
                Properties.Settings.Default.Save();
            }
        }

        /// <summary>
        /// 更新录制区域尺寸
        /// </summary>
        private void SetGifAreaSize()
        {
            if (!is_full_screen)
            {
                gif_area_size.Width = panel_gif_area.Size.Width;
                gif_area_size.Height = panel_gif_area.Size.Height;
                Properties.Settings.Default.Setting_gif_area_size = gif_area_size;
                Properties.Settings.Default.Save();
            }
        }

        /// <summary>
        /// 更新录制区域位置
        /// </summary>
        private void SetGifAreaLocation()
        {
            if (!is_full_screen)
            {
                int margin = (this.Size.Width - this.ClientRectangle.Width) / 2;
                gif_area_location.X = this.Location.X + panel_gif_area.Location.X + margin;
                gif_area_location.Y = this.Location.Y + panel_gif_area.Location.Y + (this.Height - this.ClientRectangle.Height - margin - 2);
                Properties.Settings.Default.Setting_gif_area_location = gif_area_location;
                Properties.Settings.Default.Save();
            }
        }

        /// <summary>
        /// 进入全屏模式
        /// </summary>
        private void GoToFullScreen()
        {
            if (!is_full_screen)
            {
                is_full_screen = true;
                this.WindowState = FormWindowState.Maximized;
                panel_btn_area.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(255)))), ((int)(((byte)(0)))));
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
                SetTopAndHollow();
                自定义区域ToolStripMenuItem.CheckState = CheckState.Unchecked;
                全屏区域ToolStripMenuItem.CheckState = CheckState.Checked;
                Properties.Settings.Default.Setting_is_full_screen = is_full_screen;
                Properties.Settings.Default.Save();
                btn_exit.Visible = true;
                panel_btn_area_2.Location = new Point(0, (full_screen_higth_real - panel_btn_area_2.Size.Height) / 2);
            }
        }

        /// <summary>
        /// 退出全屏模式
        /// </summary>
        private void ExitFullScreen()
        {
            if (is_full_screen)
            {
                panel_btn_area_2.Location = new Point(0, 0);
                this.WindowState = FormWindowState.Normal;
                this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Sizable;
                panel_btn_area.BackColor = SystemColors.Control;
                SetTopAndHollow();
                自定义区域ToolStripMenuItem.CheckState = CheckState.Checked;
                全屏区域ToolStripMenuItem.CheckState = CheckState.Unchecked;
                btn_exit.Visible = false;
                is_full_screen = false;
                Properties.Settings.Default.Setting_is_full_screen = is_full_screen;
                Properties.Settings.Default.Save();
            }
        }

        /// <summary>
        /// 获取经过缩放的屏幕尺寸
        /// </summary>
        /// <param name="size"></param>
        /// <returns></returns>
        private int GetScaleSize(int size)
        {
            return (int)(size * scale);
        }

        #endregion

        #region 快捷键注册注销

        /// <summary>
        /// 注册快捷键
        /// </summary>
        private void RegisterHotKey()
        {
            bool isRegistered_continue = HotKeyDllHelper.RegisterHotKey(Handle, KeyID_btn_continue, 0x0001, 81);
            bool isRegistered_single = HotKeyDllHelper.RegisterHotKey(Handle, KeyID_btn_single, 0x0001, 87);
            if (!isRegistered_continue && !isRegistered_single)
            {
                MessageBox.Show("连续录制（Alt+Q）和单帧录制（Alt+W）快捷键设置失败");
            }
            else if (!isRegistered_continue)
            {
                MessageBox.Show("连续录制（Alt+Q）快捷键设置失败");
            }
            else if (!isRegistered_single)
            {
                MessageBox.Show("单帧录制（Alt+W）快捷键设置失败");
            }
        }

        /// <summary>
        /// 注销快捷键
        /// </summary>
        private void UnregisterHotKey()
        {
            HotKeyDllHelper.UnregisterHotKey(Handle, KeyID_btn_continue);
            HotKeyDllHelper.UnregisterHotKey(Handle, KeyID_btn_single);
        }

        #endregion

        #region 快捷键响应

        //重载WndProc窗口事件方法，以响应快捷键
        protected override void WndProc(ref Message m)
        {
            switch (m.WParam.ToInt32())
            {
                case KeyID_btn_continue:
                    ContinueRecordStartOrPause();
                    break;
                case KeyID_btn_single:
                    AddBitmapToList();
                    break;
                default:
                    break;
            }
            base.WndProc(ref m);
        }

        #endregion
    }
}
