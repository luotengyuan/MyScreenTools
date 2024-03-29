﻿using System;
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
    public partial class Form_about : Form
    {
        public Form_about()
        {
            InitializeComponent();
            lb_version.Text = "V" + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            lb_author.Text = "Lois（QQ：234808404）";
            string path = System.AppDomain.CurrentDomain.BaseDirectory + "\\Readme.txt";
            StreamReader sr = new StreamReader(path, Encoding.Default);
            string content;
            while ((content = sr.ReadLine()) != null)
            {
                tb_version_log.Text += content + "\r\n";
            }
            tb_version_log.Focus();
            tb_version_log.SelectionStart = 0;  //设置起始位置
            tb_version_log.SelectionLength = 0;  //设置长度
            tb_version_log.ScrollToCaret();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://blog.csdn.net/loutengyuan/article/details/125669369");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/luotengyuan/MyScreenTools");
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://gitee.com/luotengyuan/MyScreenTools");
        }
    }
}
