using CommonLibrary;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 屏幕工具
{
    //定义委托
    public delegate void SetICS(bool isScreenShot);
    public partial class Form_catch : Form
    {
        //鼠标位置的枚举
        private enum MouseLocation
        {
            LeftUpPoint, LeftDownPoint, RightUpPoint, RightDownPoint, LeftLine, RightLine, UpLine, DownLine,
            InRectangle, OutOfRectangle
        }
        private MouseLocation mouseLocation;
        //定义该委托的事件
        public event SetICS SetICSEvent;
        //截屏原始图片
        private Bitmap originBmp;
        //鼠标左键按下的坐标
        private Point mouseDownPoint;
        //调节截图框时的固定不动点
        private Point fixedPoint;
        //是否允许绘制矩形截图状态
        private bool isDraw;
        //截图完成状态
        private bool isCatched;
        //是否允许调节矩形框
        private bool isAdjust;
        //绘制的截图矩形框
        private Rectangle rect;

        private bool is_copy_image_path;

        public Rectangle Rect
        {
            get { return rect; }
            set { rect = value; }
        }

        //缩放比
        private double scale;
        // 截图类型
        private CatchType mCatchType;
        // 默认的图片保持路径
        private readonly string _pathTemp = Path.GetTempPath() + @"MyScreenTools\Catch\";
        //public string catchPicture = System.AppDomain.CurrentDomain.BaseDirectory + "\\catch.jpg";
        public string catchPicture = null;
        public Form_catch(CatchType type, bool is_copy_image_path)
        {
            InitializeComponent();
            mCatchType = type;
            this.is_copy_image_path = is_copy_image_path;
            //MessageBox.Show("" + System.IO.Directory.GetCurrentDirectory()
            //    + "\n" + System.AppDomain.CurrentDomain.BaseDirectory
            //    + "\n" + System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName
            //    + "\n" + System.Environment.CurrentDirectory
            //    + "\n" + System.IO.Directory.GetCurrentDirectory()
            //    + "\n" + System.AppDomain.CurrentDomain.SetupInformation.ApplicationBase
            //    + "\n" + System.Windows.Forms.Application.StartupPath
            //    + "\n" + System.Windows.Forms.Application.ExecutablePath);
        }

        //将当前屏幕截图，显示到全屏无标题栏窗体上
        private void Form_catch_Load(object sender, EventArgs e)
        {
            //设置截图状态为开始
            SetICSEvent(true);
            //隐藏窗体，保证截屏图片为当前屏幕而不是被窗体覆盖
            this.Hide();
            //以当前窗口大小（窗口默认最大化，即全屏）创建截屏空白图片
            var g = Graphics.FromHwnd(IntPtr.Zero);
            IntPtr desktop = g.GetHdc();
            int width = System32DllHelper.GetDeviceCaps(desktop, (int)DeviceCap.DESKTOPHORZRES);
            int higth = System32DllHelper.GetDeviceCaps(desktop, (int)DeviceCap.DESKTOPVERTRES);
            scale = width * 1.0 / this.Width;
            //int width = 1920;
            //int higth = 1080;
            //int width = this.Width;
            //int higth = this.Height;
            //MessageBox.Show("Width: " + width + "  Height: " + higth);
            //this.originBmp = new Bitmap(this.Width, this.Height);
            this.originBmp = new Bitmap(width, higth);
            //以截屏图片作为画板
            using (Graphics gs = Graphics.FromImage(originBmp))
            {
                //复制当前屏幕到画板上，即将截屏图片的内容设置为当前屏幕
                //gs.CopyFromScreen(0, 0, 0, 0, this.Size);
                //gs.CopyFromScreen(0, 0, 0, 0, new System.Drawing.Size(width, higth));
                gs.CopyFromScreen(0, 0, 0, 0, new System.Drawing.Size(width, higth));
            }
            //将截屏图片设为窗体背景
            //this.Width = width;
            //this.Height = higth;
            this.BackgroundImage = new Bitmap(this.originBmp);
            //SaveFile(new Bitmap(this.originBmp));
            //添加截屏时的黑色遮罩，即在窗体背景上绘制全屏半透明黑色填充矩形
            using (Graphics blackgs = Graphics.FromImage(this.BackgroundImage))
            {
                using (SolidBrush backBrush = new SolidBrush(Color.FromArgb(100, 0, 0, 0)))
                {
                    blackgs.FillRectangle(backBrush, 0, 0, width, higth);
                }
            }
            //显示窗体
            this.Show();
            //激活当前窗体，使之具有焦点。主要针对win8 Metro界面的截图。
            this.Activate();
        }

        //右键点击动作
        private void Form_catch_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                //开始绘制矩形框前，即初始状态，直接退出截图
                if (isCatched == false)
                {
                    this.Close();
                }
                //若矩形框已绘制，设定状态为初始状态，设定矩形各参数为0，
                //刷新窗体重绘，以清除已绘制的矩形，重新开始截图，即撤销功能。
                else
                {
                    this.isCatched = false;
                    this.isAdjust = false;
                    this.isDraw = false;
                    this.rect = new Rectangle(0, 0, 0, 0);
                    this.Refresh();
                    panel_menu.Visible = false;
                }
            }
        }

        //鼠标双击复制截图到剪贴板并存储
        private void Form_catch_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left && isCatched == true)
            {
                Bitmap bitmap = getCatchPictureBitmap();
                if (bitmap != null)
                {
                    //复制到剪贴板
                    Clipboard.SetImage(bitmap);
                    //保持到默认路径
                    SaveFile(bitmap, true);
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
            }
        }

        //鼠标左键按下开始截图
        private void Form_catch_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //未捕获时，设定状态为允许绘制矩形
                if (isCatched == false)
                {
                    this.isDraw = true;

                }
                else
                {
                    //捕获完成后在矩形框内按下左键，设置状态为调节矩形框位置和大小
                    //为方便使用，矩形框内外以及边和顶点的判定都为目标附近
                    if (MousePosition.X > rect.Left - 3 && MousePosition.X < rect.Right + 3
                        && MousePosition.Y > rect.Top - 3 && MousePosition.Y < rect.Bottom + 3)
                    {
                        this.isAdjust = true;
                    }
                }
                //记下鼠标左键按下的坐标,设置显示光标
                this.CursorLocation();
                this.mouseDownPoint = new Point(e.X, e.Y);
            }
        }

        private void Form_catch_MouseMove(object sender, MouseEventArgs e)
        {
            //移动鼠标绘制矩形
            if (this.isDraw == true)
            {
                //鼠标按下并移动设定状态为已捕获
                this.isCatched = true;
                panel_menu.Visible = true;
                if (mCatchType != CatchType.CATCH)
                {
                    btn_dowload.Visible = false;
                }
                //记录矩形左上角点的坐标
                Point leftUpPoint = new Point(this.mouseDownPoint.X, this.mouseDownPoint.Y);
                if (e.X < this.mouseDownPoint.X)
                    leftUpPoint.X = e.X;
                if (e.Y < this.mouseDownPoint.Y)
                    leftUpPoint.Y = e.Y;
                //获取矩形的长和宽
                int wideth = Math.Abs(this.mouseDownPoint.X - e.X);
                int height = Math.Abs(this.mouseDownPoint.Y - e.Y);
                //防止分辨率为0的截图区域
                if (wideth == 0)
                    ++wideth;
                if (height == 0)
                    ++height;
                //记录绘制的矩形
                this.rect = new Rectangle(leftUpPoint.X, leftUpPoint.Y, wideth, height);
                //刷新窗体，以触发OnPain事件重绘窗体
                this.Refresh();
            }
            //调节矩形框
            else
            {
                if (isCatched == true)
                {
                    //捕获完成，按下左键前显示当鼠标在矩形框上时的形状
                    if (isAdjust == false)
                    {
                        this.CursorLocation();
                    }
                    else
                    {
                        //计算调节矩形框的大小和位置
                        Point leftUpPoint = new Point(this.fixedPoint.X, this.fixedPoint.Y);
                        if (e.X < this.fixedPoint.X)
                            leftUpPoint.X = e.X;
                        if (e.Y < this.fixedPoint.Y)
                            leftUpPoint.Y = e.Y;
                        int wideth = Math.Abs(this.fixedPoint.X - e.X);
                        int height = Math.Abs(this.fixedPoint.Y - e.Y);
                        switch (mouseLocation)
                        {
                            //校正以上计算的矩形框位置以及大小
                            case MouseLocation.InRectangle:
                                leftUpPoint.X = this.fixedPoint.X + e.X - this.mouseDownPoint.X;
                                leftUpPoint.Y = this.fixedPoint.Y + e.Y - this.mouseDownPoint.Y;
                                wideth = this.rect.Width;
                                height = this.rect.Height;
                                //防止矩形框移出屏幕外
                                if (leftUpPoint.X < 0)
                                    leftUpPoint.X = 0;
                                if (leftUpPoint.Y < 0)
                                    leftUpPoint.Y = 0;
                                if (leftUpPoint.X + wideth >= this.Width)
                                    leftUpPoint.X = this.Width - wideth - 1;
                                if (leftUpPoint.Y + height >= this.Height)
                                    leftUpPoint.Y = this.Height - height - 1;
                                break;
                            case MouseLocation.LeftLine:
                            case MouseLocation.RightLine:
                                leftUpPoint.Y = this.rect.Y;
                                height = this.rect.Height;
                                break;
                            case MouseLocation.UpLine:
                            case MouseLocation.DownLine:
                                leftUpPoint.X = this.rect.X;
                                wideth = this.rect.Width;
                                break;
                        }
                        //防止分辨率为0的截图区域
                        if (wideth == 0)
                            ++wideth;
                        if (height == 0)
                            ++height;
                        //改变矩形框，刷新重绘
                        this.rect = new Rectangle(leftUpPoint.X, leftUpPoint.Y, wideth, height);
                        this.Refresh();
                    }
                }
            }
        }

        //放开鼠标左键，设置状态
        private void Form_catch_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //不允许绘制和调整
                this.isDraw = false;
                this.isAdjust = false;
            }
        }

        //按下ESC键退出截图
        private void Form_catch_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 27)
            {
                this.Close();
            }
        }

        //窗口关闭时设置主窗口的截图状态标记
        private void Form_catch_FormClosing(object sender, FormClosingEventArgs e)
        {
            SetICSEvent(false);
        }

        //重载OnPaint事件，窗体每次重绘所调用的函数
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            //防止窗体第一次显示时绘出分辨率显示
            if (this.rect.Width != 0)
            {
                int tempX = this.rect.X + this.rect.Width - panel_menu.Width;
                int tempY = this.rect.Y + this.rect.Height;
                if (this.Height - (this.rect.Y + this.rect.Height) < panel_menu.Height)
                {
                    tempY = this.rect.Y + this.rect.Height - panel_menu.Height;
                }
                panel_menu.Location = new Point(tempX, tempY);
                //向窗体添加画板，绘制矩形
                Graphics gs = e.Graphics;
                //绘制截屏图片上的矩形框选中部分到当前画板上的矩形框部分，以覆盖黑色遮罩
                Rectangle tempRect = new Rectangle(GetScaleInt(this.rect.X), GetScaleInt(this.rect.Y), GetScaleInt(this.rect.Width), GetScaleInt(this.rect.Height));
                gs.DrawImage(this.originBmp, this.rect, tempRect, GraphicsUnit.Pixel);
                //定义画笔
                using (Pen linePen = new Pen(Color.FromArgb(255, 0, 174, 255), 1))
                {
                    //绘制矩形
                    gs.DrawRectangle(linePen, this.rect);
                    //绘出线条上的点
                    using (SolidBrush pointBrush = new SolidBrush(Color.FromArgb(255, 0, 174, 255)))
                    {
                        //顶点
                        gs.FillRectangle(pointBrush, this.rect.X - 2, this.rect.Y - 2, 4, 4);
                        gs.FillRectangle(pointBrush, this.rect.Right - 2, this.rect.Y - 2, 4, 4);
                        gs.FillRectangle(pointBrush, this.rect.X - 2, this.rect.Bottom - 2, 4, 4);
                        gs.FillRectangle(pointBrush, this.rect.Right - 2, this.rect.Bottom - 2, 4, 4);
                        //中点
                        gs.FillRectangle(pointBrush, this.rect.X - 2, (this.rect.Y + this.rect.Bottom) / 2 - 2, 4, 4);
                        gs.FillRectangle(pointBrush, (this.rect.X + this.rect.Right) / 2 - 2, this.rect.Y - 2, 4, 4);
                        gs.FillRectangle(pointBrush, (this.rect.X + this.rect.Right) / 2 - 2, this.rect.Bottom - 2, 4, 4);
                        gs.FillRectangle(pointBrush, this.rect.Right - 2, (this.rect.Y + this.rect.Bottom) / 2 - 2, 4, 4);
                    }
                }
                //定义分辨率文字显示背景画刷，ARGB值。
                using (SolidBrush backBrush = new SolidBrush(Color.FromArgb(150, 0, 0, 0)))
                {
                    //绘制分辨率文字背景
                    //靠近屏幕上方和右边缘调整背景绘图位置，避免超出屏幕范围
                    if (this.rect.Y < 16)
                    {
                        if (this.rect.X + 70 > this.Width - 71)
                            gs.FillRectangle(backBrush, this.rect.X - 71, this.rect.Y, 70, 15);
                        else
                            gs.FillRectangle(backBrush, this.rect.X, this.rect.Y, 70, 15);
                    }
                    else
                    {
                        if (this.rect.X > this.Width - 71)
                            gs.FillRectangle(backBrush, this.rect.X - 71, this.rect.Y - 16, 70, 15);
                        else

                            gs.FillRectangle(backBrush, this.rect.X, this.rect.Y - 16, 70, 15);
                    }
                }
                //定义绘制文字字体
                using (Font drawFont = new Font("Arial", 9))
                {
                    //定义分辨率文字画刷
                    using (SolidBrush drawBrush = new SolidBrush(Color.White))
                    {
                        //获取分辨率文字
                        string ratio = this.rect.Width.ToString() + " x " + rect.Height.ToString();
                        //绘制分辨率文字
                        if (this.rect.Y < 16)
                        {
                            if (this.rect.X > this.Width - 71)
                                gs.DrawString(ratio, drawFont, drawBrush, new Point(this.rect.X - 71, this.rect.Y));
                            else
                                gs.DrawString(ratio, drawFont, drawBrush, new Point(this.rect.X, this.rect.Y));
                        }
                        else
                        {
                            if (this.rect.X > this.Width - 71)
                                gs.DrawString(ratio, drawFont, drawBrush, new Point(this.rect.X - 71, this.rect.Y - 16));
                            else
                                gs.DrawString(ratio, drawFont, drawBrush, new Point(this.rect.X, this.rect.Y - 16));
                        }
                    }
                }
            }
        }
        private static ImageCodecInfo GetImageCodecInfo(ImageFormat imageFormat)
        {
            ImageCodecInfo[] imageCodecInfoArr = ImageCodecInfo.GetImageDecoders();
            foreach (ImageCodecInfo imageCodecInfo in imageCodecInfoArr)
            {
                if (imageCodecInfo.FormatID == imageFormat.Guid)
                {
                    return imageCodecInfo;
                }
            }
            return null;
        }

        public string getCatchPicturePath()
        {
            if (!Directory.Exists(_pathTemp))
            {
                Directory.CreateDirectory(_pathTemp);
            }
            return String.Format("{0}catch_{1}.jpg", _pathTemp, DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss"));
        }

        //储存图片
        private void SaveFile(Bitmap bmp, bool isDefaultFile)
        {
            try
            {
                if (isDefaultFile)
                {
                    catchPicture = getCatchPicturePath();
                    bmp.Save(catchPicture, System.Drawing.Imaging.ImageFormat.Jpeg);
                }
                else
                {
                    //用当前时间作为文件名
                    string time = DateTime.Now.ToString();
                    //去除时间中的非法字符
                    string filename = null;
                    foreach (char symbol in time)
                    {
                        if (symbol != '/' && symbol != ':' && symbol != ' ')
                            filename += symbol;
                    }
                    saveFileDialog1.FileName = "截图" + filename;
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        //存储为jpeg或者png格式
                        switch (saveFileDialog1.FilterIndex)
                        {
                            case 0:
                                bmp.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Png);
                                break;
                            case 1:
                                bmp.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                                break;
                            default:
                                bmp.Save(saveFileDialog1.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);
                                break;
                        }
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("请把程序安装在C盘以外的位置");
            }
        }

        //判定并记录鼠标与矩形框的位置关系，改变鼠标形状，并记录下矩形框上的一个标记点，
        //用作计算调节矩形框时矩形框的位置及大小     
        private void CursorLocation()
        {
            int mouseX = Control.MousePosition.X;
            int mouseY = Control.MousePosition.Y;
            //鼠标在矩形内
            if (mouseX > rect.Left + 2 && mouseX < rect.Right - 2 && mouseY > rect.Top + 2 && mouseY < rect.Bottom - 2)
            {
                Cursor.Current = Cursors.SizeAll;
                if (this.isAdjust == true)
                {
                    this.mouseLocation = MouseLocation.InRectangle;
                    this.fixedPoint = new Point(this.rect.Left, this.rect.Top);
                }
            }
            //鼠标在矩形外
            else if (mouseX < rect.Left - 2 || mouseX > rect.Right + 2 || mouseY < rect.Top - 2 || mouseY > rect.Bottom + 2)
            {
                Cursor.Current = Cursors.Default;
                this.mouseLocation = MouseLocation.OutOfRectangle;
            }
            //鼠标在矩形上
            else
            {
                //鼠标在矩形的左边宽以及顶点上
                if (mouseX > rect.Left - 3 && mouseX < rect.Left + 3)
                {
                    if (mouseY > rect.Top - 3 && mouseY < rect.Top + 3)
                    {
                        Cursor.Current = Cursors.SizeNWSE;
                        if (this.isAdjust == true)
                        {
                            this.mouseLocation = MouseLocation.LeftUpPoint;
                            this.fixedPoint = new Point(this.rect.Right, this.rect.Bottom);
                        }
                    }
                    else if (mouseY > rect.Bottom - 3 && mouseY < rect.Bottom + 3)
                    {
                        Cursor.Current = Cursors.SizeNESW;
                        if (this.isAdjust == true)
                        {
                            this.mouseLocation = MouseLocation.LeftDownPoint;
                            this.fixedPoint = new Point(this.rect.Right, this.rect.Top);
                        }
                    }
                    else
                    {
                        Cursor.Current = Cursors.SizeWE;
                        if (this.isAdjust == true)
                        {
                            this.mouseLocation = MouseLocation.LeftLine;
                            this.fixedPoint = new Point(this.rect.Right, this.rect.Top);
                        }
                    }
                }
                //鼠标在矩形的右边宽以及顶点上
                else if (mouseX > rect.Right - 3 && mouseX < rect.Right + 3)
                {
                    if (mouseY == rect.Top)
                    {
                        Cursor.Current = Cursors.SizeNESW;
                        if (this.isAdjust == true)
                        {
                            this.mouseLocation = MouseLocation.RightUpPoint;
                            this.fixedPoint = new Point(this.rect.Left, this.rect.Bottom);
                        }
                    }
                    else if (mouseY > rect.Bottom - 3 && mouseY < rect.Bottom + 3)
                    {
                        Cursor.Current = Cursors.SizeNWSE;
                        if (this.isAdjust == true)
                        {
                            this.mouseLocation = MouseLocation.RightDownPoint;
                            this.fixedPoint = new Point(this.rect.Left, this.rect.Top);
                        }
                    }
                    else
                    {
                        Cursor.Current = Cursors.SizeWE;
                        if (this.isAdjust == true)
                        {
                            this.mouseLocation = MouseLocation.RightLine;
                            this.fixedPoint = new Point(this.rect.Left, this.rect.Top);
                        }

                    }
                }
                //鼠标在矩形的长上
                else
                {
                    if (mouseY > rect.Top - 3 && mouseY < rect.Top + 3)
                    {
                        Cursor.Current = Cursors.SizeNS;
                        if (this.isAdjust == true)
                        {
                            this.mouseLocation = MouseLocation.UpLine;
                            this.fixedPoint = new Point(this.rect.Left, this.rect.Bottom);
                        }
                    }
                    else
                    {
                        Cursor.Current = Cursors.SizeNS;
                        if (this.isAdjust == true)
                        {
                            this.mouseLocation = MouseLocation.DownLine;
                            this.fixedPoint = new Point(this.rect.Left, this.rect.Top);
                        }
                    }
                }
            }
        }

        private int GetScaleInt(int val)
        {
            return (int) (val * scale);
        }

        private void btn_confirm_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = getCatchPictureBitmap();
            if (bitmap != null)
            {
                //保持到默认路径
                SaveFile(bitmap, true);
                if (is_copy_image_path)
                {
                    //复制保存的文件路径到剪贴板
                    StringCollection files = new StringCollection();
                    files.Add(catchPicture);
                    Clipboard.SetFileDropList(files);
                }
                else
                {
                    //复制原始图像到剪贴板
                    Clipboard.SetImage(bitmap);
                }
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_dowload_Click(object sender, EventArgs e)
        {
            Bitmap bitmap = getCatchPictureBitmap();
            if (bitmap != null)
            {
                //选择文件路径保存文件
                SaveFile(bitmap, false);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private Bitmap getCatchPictureBitmap()
        {
            if (isCatched == false)
            {
                return null;
            }
            //新建矩形大小的图片，并作为画板
            Bitmap bmp = new Bitmap(rect.Width, rect.Height);
            using (Graphics gs = Graphics.FromImage(bmp))
            {
                //从原始截屏图片originBmp上截取指定的矩形部分rect到图片画板bmp的指定部分，单位为像素。
                Rectangle tempRect = new Rectangle(GetScaleInt(this.rect.X), GetScaleInt(this.rect.Y), GetScaleInt(this.rect.Width), GetScaleInt(this.rect.Height));
                gs.DrawImage(this.originBmp, new Rectangle(0, 0, this.rect.Width, this.rect.Height), tempRect, GraphicsUnit.Pixel);
            }
            return bmp;
        }
    }
}
