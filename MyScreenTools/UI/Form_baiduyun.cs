using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace 屏幕工具
{
    public partial class Form_baiduyun : Form
    {
        private BaiduYunType mType;
        public Form_baiduyun(BaiduYunType type)
        {
            this.mType = type;
            InitializeComponent();
        }

        private void Form_baiduyun_Load(object sender, EventArgs e)
        {
            if (mType == BaiduYunType.OCR)
            {
                groupBox.Text = "百度图像云文字识别";
                string apiKey = Properties.Settings.Default.OCRApiKey;
                string secretKey = Properties.Settings.Default.OCRSecretKey;
                if (apiKey != null && apiKey.Length > 0 && secretKey != null && secretKey.Length > 0)
                {
                    tb_api_key.Text = apiKey;
                    tb_secret_key.Text = secretKey;
                }
            }
            else
            {
                groupBox.Text = "百度机器翻译";
                string apiKey_translate = Properties.Settings.Default.TranslateApiKey;
                string secretKey_translate = Properties.Settings.Default.TranslateSecretKey;
                if (apiKey_translate != null && apiKey_translate.Length > 0 && secretKey_translate != null && secretKey_translate.Length > 0)
                {
                    tb_api_key.Text = apiKey_translate;
                    tb_secret_key.Text = secretKey_translate;
                }
            }
        }

        private void btn_set_Click(object sender, EventArgs e)
        {
            if (mType == BaiduYunType.OCR)
            {
                string apiKey = tb_api_key.Text.Trim();
                string secretKey = tb_secret_key.Text.Trim();
                if (apiKey != null && apiKey.Length > 0 && secretKey != null && secretKey.Length > 0)
                {
                    Properties.Settings.Default.OCRApiKey = apiKey;
                    Properties.Settings.Default.OCRSecretKey = secretKey;
                    Properties.Settings.Default.Save();
                    this.DialogResult = DialogResult.OK;
                    MessageBox.Show("设置成功");
                }
                else
                {
                    MessageBox.Show("请输入正确的Key信息");
                }
            }
            else
            {
                string apiKey = tb_api_key.Text.Trim();
                string secretKey = tb_secret_key.Text.Trim();
                if (apiKey != null && apiKey.Length > 0 && secretKey != null && secretKey.Length > 0)
                {
                    Properties.Settings.Default.TranslateApiKey = apiKey;
                    Properties.Settings.Default.TranslateSecretKey = secretKey;
                    Properties.Settings.Default.Save();
                    this.DialogResult = DialogResult.OK;
                    MessageBox.Show("设置成功");
                }
                else
                {
                    MessageBox.Show("请输入正确的Key信息");
                }
            }
        }

        private void ll_baiduyun_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://blog.csdn.net/loutengyuan/article/details/126402566");
        }
    }
}
