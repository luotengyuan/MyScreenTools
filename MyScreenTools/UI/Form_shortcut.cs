using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 屏幕工具
{
    public partial class Form_shortcut : Form
    {
        int mOcrBasicHotKey = 0;
        bool mIsSetSuccess = false;
        public Form_shortcut()
        {
            InitializeComponent();
        }

        private void Form_shortcut_Load(object sender, EventArgs e)
        {
            mOcrBasicHotKey = Properties.Settings.Default.OcrBasicHotKey;
            if (mOcrBasicHotKey != 0)
            {
                tb_ocr_basic_key.Text = Char.ConvertFromUtf32(mOcrBasicHotKey);
            }
        }

        private void Form_shortcut_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (mIsSetSuccess)
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private void tb_ocr_basic_key_KeyUp(object sender, KeyEventArgs e)
        {
            // 目前仅支持Alt+单个字母的组合键
            if (e.KeyValue >= 0x41 && e.KeyValue <= 0x5A)
            {
                tb_ocr_basic_key.Text = e.KeyCode.ToString();
                mOcrBasicHotKey = e.KeyValue;
            }
        }

        private void btn_ocr_basic_set_Click(object sender, EventArgs e)
        {
            if (mOcrBasicHotKey != 0)
            {
                Properties.Settings.Default.OcrBasicHotKey = mOcrBasicHotKey;
                Properties.Settings.Default.Save();
                mIsSetSuccess = true;
            }
            else
            {
                MessageBox.Show("设置失败");
            }
        }

    }
}
