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

namespace 屏幕工具
{
    public partial class Form_paste : Form
    {
        public Form_paste(string path, Rectangle rect)
        {
            InitializeComponent();
            this.Width = rect.Width + 20;
            this.Height = rect.Height + SystemInformation.CaptionHeight + 20;
            //常用设置图片缩放模式：
            //1.AutoSize 控件大小等于图片大小
            //2.Zoom     控件大小不变，图片按比例缩放后展示
            picture_paste.SizeMode = PictureBoxSizeMode.Zoom;
            FileStream fileStream = new FileStream(path, FileMode.Open, FileAccess.Read);
            picture_paste.Image = Image.FromStream(fileStream);
            fileStream.Close();
            //或者直接写
            //picture_paste.Image = Image.FromFile(path);

        }
    }
}
