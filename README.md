# 背景
你是不是每次要截图而需要打开微信或者QQ截图而感到麻烦，你是不是经常被类似某度文库不能复制文字而感到不爽，你是不是在需要获取屏幕上某个颜色而到处找工具，你是不是想将屏幕操作生成动图图分享给其他人~~~
最近在遇到以上需求时寻找很久还是未能找到合适的方便的工具，于是自己动手写了一个Windows屏幕工具，包括：屏幕截图、贴图、屏幕取色、截图文字、表格识别（需要申请百度OCR服务）、截图翻译、划词翻译（需要申请百度翻译服务）、GIF录屏、GIF压缩等功能。并将源码开源，和提供安装程序，希望能够帮助有相同困扰的朋友。

 - 代码地址：[https://github.com/luotengyuan/MyScreenTools](https://github.com/luotengyuan/MyScreenTools)
 - ​                   [https://gitee.com/luotengyuan/MyScreenTools](https://gitee.com/luotengyuan/MyScreenTools)
 - 安装程序：[https://download.csdn.net/download/loutengyuan/85952364](https://download.csdn.net/download/loutengyuan/85952364)

# 功能介绍
## 主界面
![在这里插入图片描述](https://lois-pictures.oss-cn-hangzhou.aliyuncs.com/picture/b6fec5f28a62453bb1ab3c688e722761.png)
## 开机启动设置
设置完开机启动后就不用每次手动打开，每次需要截图或文字识别等功能就可以直接使用。
![在这里插入图片描述](https://lois-pictures.oss-cn-hangzhou.aliyuncs.com/picture/5e1b2d84e2fc4449be2fabde91b18095.gif)

## 快捷键设置
可通过快捷键设置对截图、贴图、文字识别、表格识别等功能进行快捷调用。
![在这里插入图片描述](https://lois-pictures.oss-cn-hangzhou.aliyuncs.com/picture/00d1a55ce1ca43f59cbbfe9f08dce523.gif)

## 百度云信息设置
文字识别和翻译是调用的百度云平台的接口，所以想使用这些功能的需要到百度云开放平台注册对于的Key，并设置到软件中才能正常使用。如何申请服务请参照这篇文章：[https://luotengyuan.notion.site/OCR-APIKey-SecretKey-a4ae1949601f44d1a5ef67065f56eb11](https://luotengyuan.notion.site/OCR-APIKey-SecretKey-a4ae1949601f44d1a5ef67065f56eb11)
![在这里插入图片描述](https://lois-pictures.oss-cn-hangzhou.aliyuncs.com/picture/d36e63697f93435f9116653dcfddbd96.gif)

## 截图文字识别
通过截取屏幕中文字区域，将该区域中文字提取出来，并自动复制到剪切板，直可以直接粘贴到所需要的地方。
![截图文字识别](https://lois-pictures.oss-cn-hangzhou.aliyuncs.com/picture/fc91ab6bc33545479443e459a54e6c90.gif)

## 截图文字翻译
识别图像中文字，并进行翻译成指定语言文字。
![截图文字翻译](https://lois-pictures.oss-cn-hangzhou.aliyuncs.com/picture/9632752091584e51bebc79b7b8964ea1.gif)

## 屏幕取色器
屏幕取色器提取某个像素点的RGB、HSB、HSL、HSV、CMYK等颜色值。
![屏幕取色器](https://lois-pictures.oss-cn-hangzhou.aliyuncs.com/picture/e1697fb844a44ebbb23bfb645783689f.gif)

## GIF录屏
将屏幕操作录制成GIF动图，包含全屏录制、自定义区域录制、捕获鼠标、保存文件或者复制到剪切板等功能。
![GIF录屏](https://lois-pictures.oss-cn-hangzhou.aliyuncs.com/picture/394f03cdbe3c4aa2984ad487280a5605.gif)

## GIF压缩
通过封装gifscile.exe程序的功能实现批量GIF压缩，包含默认压缩、按色彩压缩、按比例压缩、有损压缩和按尺寸压缩等。
![在这里插入图片描述](https://lois-pictures.oss-cn-hangzhou.aliyuncs.com/picture/2a7b7784916c4722a51fc901d67673a2.gif)

# 代码实现
## PrScrn.dll截图库使用
PrScrn.dll是微信截图工具，我们将这个库放到程序目录下直接调用就可以快速实现屏幕截图功能。
```csharp
        // 库方法导入
        [DllImport("PrScrn.dll", EntryPoint = "PrScrn")]
        public static extern int PrScrn();

		// 调用的地方直接使用就行
		PrScrn();
```
## 自定义截图实现
由于PrScrn.dll封装好的方法只能用于截图，对于截图后文字识别等特殊场景不支持，所以这里实现了自定义的截图工具。

```csharp
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        public string catchPicture = System.IO.Directory.GetCurrentDirectory() + "\\catch.jpg";
        public Form_catch(CatchType type)
        {
            InitializeComponent();
            mCatchType = type;
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

        //储存图片
        private void SaveFile(Bitmap bmp, bool isDefaultFile)
        {
            if (isDefaultFile)
            {
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
                //复制到剪贴板
                Clipboard.SetImage(bitmap);
                //保持到默认路径
                SaveFile(bitmap, true);
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

```
## 颜色转换

```csharp
    class ColorConversionUtils
    {

        public static void RGB2HSB(int red, int green, int blue, out double hue, out double sat, out double bri)
        {
            double r = ((double)red / 255.0);
            double g = ((double)green / 255.0);
            double b = ((double)blue / 255.0);

            double max = Math.Max(r, Math.Max(g, b));
            double min = Math.Min(r, Math.Min(g, b));

            hue = 0.0;
            if (max == r && g >= b)
            {
                if (max - min == 0) hue = 0.0;
                else hue = 60 * (g - b) / (max - min);
            }
            else if (max == r && g < b)
            {
                hue = 60 * (g - b) / (max - min) + 360;
            }
            else if (max == g)
            {
                hue = 60 * (b - r) / (max - min) + 120;
            }
            else if (max == b)
            {
                hue = 60 * (r - g) / (max - min) + 240;
            }

            sat = (max == 0) ? 0.0 : (1.0 - ((double)min / (double)max));
            bri = max;
        }

        public static void HSB2RGB(double hue, double sat, double bri, out int red, out int green, out int blue)
        {
            double r = 0;
            double g = 0;
            double b = 0;

            if (sat == 0)
            {
                r = g = b = bri;
            }
            else
            {
                // the color wheel consists of 6 sectors. Figure out which sector you're in.
                double sectorPos = hue / 60.0;
                int sectorNumber = (int)(Math.Floor(sectorPos));
                // get the fractional part of the sector
                double fractionalSector = sectorPos - sectorNumber;

                // calculate values for the three axes of the color. 
                double p = bri * (1.0 - sat);
                double q = bri * (1.0 - (sat * fractionalSector));
                double t = bri * (1.0 - (sat * (1 - fractionalSector)));

                // assign the fractional colors to r, g, and b based on the sector the angle is in.
                switch (sectorNumber)
                {
                    case 0:
                        r = bri;
                        g = t;
                        b = p;
                        break;
                    case 1:
                        r = q;
                        g = bri;
                        b = p;
                        break;
                    case 2:
                        r = p;
                        g = bri;
                        b = t;
                        break;
                    case 3:
                        r = p;
                        g = q;
                        b = bri;
                        break;
                    case 4:
                        r = t;
                        g = p;
                        b = bri;
                        break;
                    case 5:
                        r = bri;
                        g = p;
                        b = q;
                        break;
                }
            }
            red = Convert.ToInt32(r * 255);
            green = Convert.ToInt32(g * 255);
            blue = Convert.ToInt32(b * 255); ;
        }

        /// <summary>
        /// RGB转换HSL
        /// </summary>
        /// <param name="rgb"></param>
        /// <returns></returns>
        public static void RGB2HSL(int r, int g, int b, out double h, out double s, out double l)
        {
            float min, max, tmp, H, S, L;
            float R = r * 1.0f / 255, G = g * 1.0f / 255, B = b * 1.0f / 255;
            tmp = Math.Min(R, G);
            min = Math.Min(tmp, B);
            tmp = Math.Max(R, G);
            max = Math.Max(tmp, B);
            // H
            H = 0;
            if (max == min)
            {
                H = 0;  // 此时H应为未定义，通常写为0
            }
            else if (max == R && G > B)
            {
                H = 60 * (G - B) * 1.0f / (max - min) + 0;
            }
            else if (max == R && G < B)
            {
                H = 60 * (G - B) * 1.0f / (max - min) + 360;
            }
            else if (max == G)
            {
                H = H = 60 * (B - R) * 1.0f / (max - min) + 120;
            }
            else if (max == B)
            {
                H = H = 60 * (R - G) * 1.0f / (max - min) + 240;
            }
            // L 
            L = 0.5f * (max + min);
            // S
            S = 0;
            if (L == 0 || max == min)
            {
                S = 0;
            }
            else if (0 < L && L < 0.5)
            {
                S = (max - min) / (L * 2);
            }
            else if (L > 0.5)
            {
                S = (max - min) / (2 - 2 * L);
            }
            h = H;
            s = S;
            l = L;
        }

        /// <summary>
        /// HSL转换RGB
        /// </summary>
        /// <param name="hsl"></param>
        /// <returns></returns>
        public static void HSL2RGB(double h, double s, double l, out int r, out int g, out int b)
        {
            float R = 0f, G = 0f, B = 0f;
            float S = (float)s, L = (float)l;
            float temp1, temp2, temp3;
            if (S == 0f) // 灰色
            {
                R = L;
                G = L;
                B = L;
            }
            else
            {
                if (L < 0.5f)
                {
                    temp2 = L * (1.0f + S);
                }
                else
                {
                    temp2 = L + S - L * S;
                }
                temp1 = 2.0f * L - temp2;
                float H = (float)h * 1.0f / 360;
                // R
                temp3 = H + 1.0f / 3.0f;
                if (temp3 < 0) temp3 += 1.0f;
                if (temp3 > 1) temp3 -= 1.0f;
                R = temp3;
                // G
                temp3 = H;
                if (temp3 < 0) temp3 += 1.0f;
                if (temp3 > 1) temp3 -= 1.0f;
                G = temp3;
                // B
                temp3 = H - 1.0f / 3.0f;
                if (temp3 < 0) temp3 += 1.0f;
                if (temp3 > 1) temp3 -= 1.0f;
                B = temp3;
            }
            R = R * 255;
            G = G * 255;
            B = B * 255;
            r = (int)R;
            g = (int)G;
            b = (int)B;
        }
      
        /// <summary>
        /// RGB转换HSV
        /// </summary>
        /// <param name="rgb"></param>
        /// <returns></returns>
        public static void RGB2HSV(int r, int g, int b, out double h, out double s, out double v)
        {
            float min, max, tmp, H, S, V;
            float R = r * 1.0f / 255, G = g * 1.0f / 255, B = b * 1.0f / 255;
            tmp = Math.Min(R, G);
            min = Math.Min(tmp, B);
            tmp = Math.Max(R, G);
            max = Math.Max(tmp, B);
            // H
            H = 0;
            if (max == min)
            {
                H = 0;
            }
            else if (max == R && G > B)
            {
                H = 60 * (G - B) * 1.0f / (max - min) + 0;
            }
            else if (max == R && G < B)
            {
                H = 60 * (G - B) * 1.0f / (max - min) + 360;
            }
            else if (max == G)
            {
                H = H = 60 * (B - R) * 1.0f / (max - min) + 120;
            }
            else if (max == B)
            {
                H = H = 60 * (R - G) * 1.0f / (max - min) + 240;
            }
            // S
            if (max == 0)
            {
                S = 0;
            }
            else
            {
                S = (max - min) * 1.0f / max;
            }
            // V
            V = max;
            h = H;
            s = S;
            v = V;
        }
 
        /// <summary>
        /// HSV转换RGB
        /// </summary>
        /// <param name="hsv"></param>
        /// <returns></returns>
        public static void HSV2RGB(double h, double s, double v, out int r, out int g, out int b)
        {
            if (h == 360) h = 359; // 360为全黑，原因不明
            float R = 0f, G = 0f, B = 0f;
            if (s == 0)
            {
                r = (int)(v * 255);
                g = (int)(v * 255);
                b = (int)(v * 255);
                return;
            }
            float S = (float)s, V = (float)v;
            int H1 = (int)(h * 1.0f / 60), H = (int)h;
            float F = H * 1.0f / 60 - H1;
            float P = V * (1.0f - S);
            float Q = V * (1.0f - F * S);
            float T = V * (1.0f - (1.0f - F) * S);
            switch (H1)
            {
                case 0: R = V; G = T; B = P; break;
                case 1: R = Q; G = V; B = P; break;
                case 2: R = P; G = V; B = T; break;
                case 3: R = P; G = Q; B = V; break;
                case 4: R = T; G = P; B = V; break;
                case 5: R = V; G = P; B = Q; break;
            }
            R = R * 255;
            G = G * 255;
            B = B * 255;
            while (R > 255) R -= 255;
            while (R < 0) R += 255;
            while (G > 255) G -= 255;
            while (G < 0) G += 255;
            while (B > 255) B -= 255;
            while (B < 0) B += 255;
            r = (int)R;
            g = (int)G;
            b = (int)B;
        }

        public static void RGB2CMYK(int red, int green, int blue, out double c, out double m, out double y, out double k)
        {
            c = (double)(255 - red) / 255;
            m = (double)(255 - green) / 255;
            y = (double)(255 - blue) / 255;

            k = (double)Math.Min(c, Math.Min(m, y));
            if (k == 1.0)
            {
                c = m = y = 0;
            }
            else
            {
                c = (c - k) / (1 - k);
                m = (m - k) / (1 - k);
                y = (y - k) / (1 - k);
            }
        }
        public static void CMYK2RGB(double c, double m, double y, double k, out int r, out int g, out int b)
        {
            r = Convert.ToInt32((1.0 - c) * (1.0 - k) * 255.0);
            g = Convert.ToInt32((1.0 - m) * (1.0 - k) * 255.0);
            b = Convert.ToInt32((1.0 - y) * (1.0 - k) * 255.0);
        }

        public static string RGB2Hex(int r, int g, int b)
        {
            return String.Format("#{0:x2}{1:x2}{2:x2}", (int)r, (int)g, (int)b);
        }
        public static Color Hex2Color(string hexColor)
        {
            string r, g, b;

            if (hexColor != String.Empty)
            {
                hexColor = hexColor.Trim();
                if (hexColor[0] == '#') hexColor = hexColor.Substring(1, hexColor.Length - 1);

                r = hexColor.Substring(0, 2);
                g = hexColor.Substring(2, 2);
                b = hexColor.Substring(4, 2);

                r = Convert.ToString(16 * GetIntFromHex(r.Substring(0, 1)) + GetIntFromHex(r.Substring(1, 1)));
                g = Convert.ToString(16 * GetIntFromHex(g.Substring(0, 1)) + GetIntFromHex(g.Substring(1, 1)));
                b = Convert.ToString(16 * GetIntFromHex(b.Substring(0, 1)) + GetIntFromHex(b.Substring(1, 1)));

                return Color.FromArgb(Convert.ToInt32(r), Convert.ToInt32(g), Convert.ToInt32(b));
            }

            return Color.Empty;
        }
        private static int GetIntFromHex(string strHex)
        {
            switch (strHex)
            {
                case ("A"):
                    {
                        return 10;
                    }
                case ("B"):
                    {
                        return 11;
                    }
                case ("C"):
                    {
                        return 12;
                    }
                case ("D"):
                    {
                        return 13;
                    }
                case ("E"):
                    {
                        return 14;
                    }
                case ("F"):
                    {
                        return 15;
                    }
                default:
                    {
                        return int.Parse(strHex);
                    }
            }
        }
    }
```
## GIF生成
调用GifEncoder类将录制好的一张张图片转换成gif图片代码：
```csharp
        /// <summary>
        /// 保存GIF到图片
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private bool SaveGifToFile(string path)
        {
            panel_progress.Visible = true;
            using (var stream = new MemoryStream())
            {
                using (var encoderNet = new GifEncoder(stream, null, null, 0))
                {
                	// _listFrames 是每一帧图像在磁盘中保存的路径
                    int count = _listFrames.Count;
                    pb_save.Maximum = count;
                    pb_save.Value = 0;
                    for (int i = 0; i < count; i++)
                    {
                        var bitmapAux = new Bitmap(_listFrames[i]);
                        encoderNet.AddFrame(bitmapAux, 0, 0, TimeSpan.FromMilliseconds(1000 / gif_fps));
                        bitmapAux.Dispose();
                        pb_save.Value = i + 1;
                    }
                }

                stream.Position = 0;

                try
                {
                    using (var fileStream = new FileStream(path, FileMode.Create, FileAccess.Write, FileShare.None, 0x2000, false))
                    {
                        stream.WriteTo(fileStream);
                    }
                    panel_progress.Visible = false;
                    return true;
                }
                catch (Exception ex)
                {
                    //LogWriter.Log(ex, "Error while writing to disk.");
                }
            }
            panel_progress.Visible = false;
            return false;
        }
```

GifEncoder工具类：
```csharp
using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;

namespace ScreenToGif.Encoding
{
    /// <summary>
    /// Encodes multiple images as an animated gif to a stream. <br />
    /// ALWAYS wire this up in a "using" block <br />
    /// Disposing the encoder will complete the file. <br />
    /// Uses default .net GIF encoding and adds animation headers.
    /// </summary>
    public sealed class GifEncoder : IDisposable
    {
        #region Header Constants

        private const string FileType = "GIF";

        private const string FileVersion = "89a";

        private const byte FileTrailer = 0x3b;

        private const int ApplicationExtensionBlockIdentifier = 0xff21;

        private const byte ApplicationBlockSize = 0x0b;

        private const string ApplicationIdentification = "NETSCAPE2.0";

        private const int GraphicControlExtensionBlockIdentifier = 0xf921;

        private const byte GraphicControlExtensionBlockSize = 0x04;

        private const long SourceGlobalColorInfoPosition = 10;

        private const long SourceGraphicControlExtensionPosition = 781;

        private const long SourceGraphicControlExtensionLength = 8;

        private const long SourceImageBlockPosition = 789;

        private const long SourceImageBlockHeaderLength = 11;

        private const long SourceColorBlockPosition = 13;

        private const long SourceColorBlockLength = 768;

        #endregion

        private bool _isFirstImage = true;

        private int? _width;

        private int? _height;

        private int? _repeatCount;

        private readonly Stream _stream;

        /// <summary>
        /// Frame delay for the frame.
        /// </summary>
        public TimeSpan FrameDelay { get; set; }

        /// <summary>
        /// Encodes multiple images as an animated gif to a stream. <br />
        /// ALWAYS wire this in a using block <br />
        /// Disposing the encoder will complete the file. <br />
        /// Uses default .net GIF encoding and adds animation headers.
        /// </summary>
        /// <param name="stream">The stream that will be written to.</param>
        /// <param name="width">Sets the width for this gif or null to use the first frame's width.</param>
        /// <param name="height">Sets the height for this gif or null to use the first frame's height.</param>
        /// <param name="repeatCount">The repeat count of the animation</param>
        public GifEncoder(Stream stream, int? width = null, int? height = null, int? repeatCount = null)
        {
            _stream = stream;
            _width = width;
            _height = height;
            _repeatCount = repeatCount;
        }

        /// <summary>
        /// Adds a frame to this animation.
        /// </summary>
        /// <param name="img">The image to add</param>
        /// <param name="x">The positioning x offset this image should be displayed at.</param>
        /// <param name="y">The positioning y offset this image should be displayed at.</param>
        /// <param name="frameDelay">The delay of the redraw of the next frame.</param>
        public void AddFrame(Image img, int x = 0, int y = 0, TimeSpan? frameDelay = null)
        {
            using (var gifStream = new MemoryStream())
            {
                img.Save(gifStream, ImageFormat.Gif);
                if (_isFirstImage) // Steal the global color table info
                {
                    InitHeader(gifStream, img.Width, img.Height);
                }
                WriteGraphicControlBlock(gifStream, frameDelay.GetValueOrDefault(FrameDelay));
                WriteImageBlock(gifStream, !_isFirstImage, x, y, img.Width, img.Height);
            }
            _isFirstImage = false;
        }

        private void InitHeader(Stream sourceGif, int w, int h)
        {
            // File Header
            WriteString(FileType);
            WriteString(FileVersion);
            WriteShort(_width.GetValueOrDefault(w)); // Initial Logical Width
            WriteShort(_height.GetValueOrDefault(h)); // Initial Logical Height
            sourceGif.Position = SourceGlobalColorInfoPosition;
            WriteByte(sourceGif.ReadByte()); // Global Color Table Info
            WriteByte(0); // Background Color Index
            WriteByte(0); // Pixel aspect ratio
            WriteColorTable(sourceGif);

            // App Extension Header
            WriteShort(ApplicationExtensionBlockIdentifier);
            WriteByte(ApplicationBlockSize);
            WriteString(ApplicationIdentification);
            WriteByte(3); // Application block length
            WriteByte(1);
            WriteShort(_repeatCount.GetValueOrDefault(0)); // Repeat count for images.
            WriteByte(0); // terminator
        }

        private void WriteColorTable(Stream sourceGif)
        {
            sourceGif.Position = SourceColorBlockPosition; // Locating the image color table
            var colorTable = new byte[SourceColorBlockLength];
            sourceGif.Read(colorTable, 0, colorTable.Length);
            _stream.Write(colorTable, 0, colorTable.Length);
        }

        private void WriteGraphicControlBlock(Stream sourceGif, TimeSpan frameDelay)
        {
            sourceGif.Position = SourceGraphicControlExtensionPosition; // Locating the source GCE
            var blockhead = new byte[SourceGraphicControlExtensionLength];
            sourceGif.Read(blockhead, 0, blockhead.Length); // Reading source GCE

            WriteShort(GraphicControlExtensionBlockIdentifier); // Identifier
            WriteByte(GraphicControlExtensionBlockSize); // Block Size
            WriteByte(blockhead[3] & 0xf7 | 0x08); // Setting disposal flag
            WriteShort(Convert.ToInt32(frameDelay.TotalMilliseconds / 10)); // Setting frame delay
            WriteByte(blockhead[6]); // Transparent color index
            WriteByte(0); // Terminator
        }

        private void WriteImageBlock(Stream sourceGif, bool includeColorTable, int x, int y, int h, int w)
        {
            sourceGif.Position = SourceImageBlockPosition; // Locating the image block
            var header = new byte[SourceImageBlockHeaderLength];
            sourceGif.Read(header, 0, header.Length);
            WriteByte(header[0]); // Separator
            WriteShort(x); // Position X
            WriteShort(y); // Position Y
            WriteShort(h); // Height
            WriteShort(w); // Width

            if (includeColorTable) // If first frame, use global color table - else use local
            {
                sourceGif.Position = SourceGlobalColorInfoPosition;
                WriteByte(sourceGif.ReadByte() & 0x3f | 0x80); // Enabling local color table
                WriteColorTable(sourceGif);
            }
            else
            {
                WriteByte(header[9] & 0x07 | 0x07); // Disabling local color table
            }

            WriteByte(header[10]); // LZW Min Code Size

            // Read/Write image data
            sourceGif.Position = SourceImageBlockPosition + SourceImageBlockHeaderLength;

            var dataLength = sourceGif.ReadByte();
            while (dataLength > 0)
            {
                var imgData = new byte[dataLength];
                sourceGif.Read(imgData, 0, dataLength);

                _stream.WriteByte(Convert.ToByte(dataLength));
                _stream.Write(imgData, 0, dataLength);
                dataLength = sourceGif.ReadByte();
            }

            _stream.WriteByte(0); // Terminator
        }

        private void WriteByte(int value)
        {
            _stream.WriteByte(Convert.ToByte(value));
        }

        private void WriteShort(int value)
        {
            _stream.WriteByte(Convert.ToByte(value & 0xff));
            _stream.WriteByte(Convert.ToByte((value >> 8) & 0xff));
        }

        private void WriteString(string value)
        {
            _stream.Write(value.ToArray().Select(c => (byte)c).ToArray(), 0, value.Length);
        }

        public void Dispose()
        {
            // Complete Application Block
            //WriteByte(0);
            // Complete File
            WriteByte(FileTrailer);
            // Pushing data
            _stream.Flush();
        }
    }
}

```
## GIF生成
GIF压缩核心代码如下：
```csharp
// 通过CMD命令行调用gifscile.exe程序执行压缩操作
CMD("gifsicle.exe --colors 256 --scale 0.80 --lossy=35 --resize 600x500 \"C:\Users\Administrator\Desktop\GIF 2022-10-12 16-57-46.gif\" -o \"C:\Users\Administrator\Desktop\Modif_GIF 2022-10-12 16-57-46.gif\"");

/// <summary>
/// 执行cmd命令方法
/// </summary>
/// <param name="mingLing"></param>
/// <returns></returns>
string CMD(string mingLing)
{
	System.Diagnostics.Process p = new System.Diagnostics.Process();
	p.StartInfo.FileName = "cmd.exe";
	p.StartInfo.UseShellExecute = false;    //是否使用操作系统shell启动
	p.StartInfo.RedirectStandardInput = true;//接受来自调用程序的输入信息
	p.StartInfo.RedirectStandardOutput = true;//由调用程序获取输出信息
	p.StartInfo.RedirectStandardError = true;//重定向标准错误输出
	p.StartInfo.CreateNoWindow = true;//不显示程序窗口
	p.Start();//启动程序
	
	//向cmd窗口发送输入信息
	p.StandardInput.WriteLine(mingLing + "&exit");
	
	p.StandardInput.AutoFlush = true;
	//p.StandardInput.WriteLine("exit");
	//向标准输入写入要执行的命令。这里使用&是批处理命令的符号，表示前面一个命令不管是否执行成功都执行后面(exit)命令，如果不执行exit命令，后面调用ReadToEnd()方法会假死
	//同类的符号还有&&和||前者表示必须前一个命令执行成功才会执行后面的命令，后者表示必须前一个命令执行失败才会执行后面的命令
	
	//获取cmd窗口的输出信息
	string output = p.StandardOutput.ReadToEnd();
	
	//StreamReader reader = p.StandardOutput;
	//string line=reader.ReadLine();
	//while (!reader.EndOfStream)
	//{
	//    str += line + "  ";
	//    line = reader.ReadLine();
	//}
	
	p.WaitForExit();//等待程序执行完退出进程
	p.Close();
	
	//Console.WriteLine(output);
	return output;
}
```