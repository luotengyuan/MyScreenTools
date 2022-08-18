using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 屏幕工具
{
    public struct POINTAPI
    {
        public uint x;
        public uint y;
    }

    public partial class Form_color : Form
    {
        private bool stop = false;
        // 放大图
        private Bitmap zoomInBitmap;
        public Form_color()
        {
            InitializeComponent();
            zoomInBitmap = new Bitmap(this.pb_picture.Width / 2, this.pb_picture.Height / 2);
            btn_lock.Visible = false;
        }

        private void Form_color_Load(object sender, EventArgs e)
        {
            StartMouseHook();
        }

        private void Form_color_FormClosing(object sender, FormClosingEventArgs e)
        {
            StopMouseHook();
        }

        private void StartMouseHook()
        {
            MouseHook mouseHook = new MouseHook();
            mouseHook.MouseMove += new MouseEventHandler(mouseHook_MouseMove2);
            mouseHook.MouseDown += new MouseEventHandler(mouseHook_MouseDown2);
            mouseHook.Start();
        }

        private void StopMouseHook()
        {
            MouseHook mouseHook = new MouseHook();
            mouseHook.MouseMove -= new MouseEventHandler(mouseHook_MouseMove2);
            mouseHook.MouseDown -= new MouseEventHandler(mouseHook_MouseDown2);
            mouseHook.Stop();
        }

        void mouseHook_MouseDown2(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left || e.Button == MouseButtons.Right)
            {
                //鼠标左键或右键点下 则停止取色
                if (!stop)
                {
                    stop = true;
                    btn_lock.Visible = true;
                }
            }
        }

        void mouseHook_MouseMove2(object sender, MouseEventArgs e)
        {

            ShowColorInfo(e.Location.X, e.Location.Y);
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            //ShowColorInfo(0, 0);
        }

        private void ShowColorInfo(int X, int Y)
        {
            if (stop)
            {
                return;
            }
            POINTAPI Papi = new POINTAPI();
            //Papi.x = (uint)X;
            //Papi.y = (uint)Y;
            WinInfo.GetCursorPos(ref  Papi);

            Color color;
            this.tb_pixel.Text = Papi.x + "," + Papi.y;
            using (Graphics gs = Graphics.FromImage(zoomInBitmap))
            {
                //复制当前屏幕到画板上
                gs.CopyFromScreen((int)Papi.x - zoomInBitmap.Width / 2, (int)Papi.y - zoomInBitmap.Height / 2, 0, 0, new System.Drawing.Size(zoomInBitmap.Width, zoomInBitmap.Height));

                color = zoomInBitmap.GetPixel(zoomInBitmap.Width / 2, zoomInBitmap.Height / 2);
                Pen pen = new Pen(Color.Red);
                gs.DrawLine(pen, new Point(zoomInBitmap.Width / 2, 0), new Point(zoomInBitmap.Width / 2, zoomInBitmap.Height));
                gs.DrawLine(pen, new Point(0, zoomInBitmap.Height / 2), new Point(zoomInBitmap.Width, zoomInBitmap.Height / 2));
            }
            this.pb_picture.BackgroundImage = new Bitmap(this.zoomInBitmap);

            

            //uint v_hwnd = WinInfo.WindowFromPoint(Papi.x, Papi.y);
            //uint v_DC = WinInfo.GetDC(v_hwnd);
            //WinInfo.ScreenToClient(v_hwnd, ref  Papi);
            //uint v_Color = WinInfo.GetPixel(v_DC, Papi.x, Papi.y);

            uint v_Red, v_Green, v_Blue;
            v_Red = (uint)(color.R & 0xff);
            v_Green = (uint)(color.G & 0xff);
            v_Blue = (uint)(color.B & 0xff);

            this.tb_rgb.Text = v_Red.ToString("d") + "," + v_Green.ToString("d") + "," + v_Blue.ToString("d");
            this.tb_hex.Text = String.Format("{0:X2}{1:X2}{2:X2}", v_Red, v_Green, v_Blue);
            this.pb_color.BackColor = Color.FromArgb((int)v_Red, (int)v_Green, (int)v_Blue);
            double hue, sat, bri;
            ColorConversionUtils.RGB2HSB((int)v_Red, (int)v_Green, (int)v_Blue, out hue, out sat, out bri);
            this.tb_hsb.Text = ((int)hue).ToString("d") + "," + ((int)(sat * 255)).ToString("d") + "," + ((int)(bri * 255)).ToString("d");
            double h1, s1, l1;
            ColorConversionUtils.RGB2HSL((int)v_Red, (int)v_Green, (int)v_Blue, out h1, out s1, out l1);
            this.tb_hsl.Text = ((int)h1).ToString("d") + "," + ((int)(s1 * 255)).ToString("d") + "," + ((int)(l1 * 255)).ToString("d");
            double h2, s2, v2;
            ColorConversionUtils.RGB2HSV((int)v_Red, (int)v_Green, (int)v_Blue, out h2, out s2, out v2);
            this.tb_hsv.Text = ((int)h2).ToString("d") + "," + ((int)(s2 * 255)).ToString("d") + "," + ((int)(v2 * 255)).ToString("d");
            double c, m, y, k;
            ColorConversionUtils.RGB2CMYK((int)v_Red, (int)v_Green, (int)v_Blue, out c, out m, out y, out k);
            this.tb_cmyk.Text = ((int)(c * 100)).ToString("d") + "," + ((int)(m * 100)).ToString("d") + "," + ((int)(y * 100)).ToString("d") + "," + ((int)(k * 100)).ToString("d");
            //WinInfo.ReleaseDC(v_hwnd, v_DC);
        }

        private void btn_lock_Click(object sender, EventArgs e)
        {
            if (stop)
            {
                // 恢复取色
                stop = false;
                btn_lock.Visible = false;
            }
        }

    }

    public class WinInfo
    {
        [DllImport("user32.dll")]
        public static extern uint WindowFromPoint
       (
            uint x_point,
            uint y_point
       );

        [DllImport("user32.dll")]
        public static extern bool GetCursorPos
       (
            ref  POINTAPI p
       );

        [DllImport("user32.dll")]
        public static extern uint ScreenToClient
       (
            uint hwnd,
            ref  POINTAPI p
       );

        [DllImport("user32.dll")]
        public static extern uint GetDC
       (
            uint hwnd
       );

        [DllImport("gdi32.dll")]
        public static extern uint GetPixel
       (
            uint hDC,
            uint x,
            uint y
       );

        [DllImport("user32.dll")]
        public static extern uint ReleaseDC
       (
            uint hwnd,
            uint hdc
       );
    }
}
