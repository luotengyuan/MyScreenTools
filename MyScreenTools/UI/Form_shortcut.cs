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
        int mCatchHotKey = 0;
        int mPasteHotKey = 0;
        int mPickColorHotKey = 0;
        int mOcrBasicHotKey = 0;
        int mOcrExcelHotKey = 0;
        bool mIsSetSuccess = false;
        public Form_shortcut()
        {
            InitializeComponent();
        }

        private void Form_shortcut_Load(object sender, EventArgs e)
        {
            mCatchHotKey = Properties.Settings.Default.CatchHotKey;
            if (mCatchHotKey != 0)
            {
                tb_catch_key.Text = Char.ConvertFromUtf32(mCatchHotKey);
            }
            mPasteHotKey = Properties.Settings.Default.PasteHotKey;
            if (mPasteHotKey != 0)
            {
                tb_paste_key.Text = Char.ConvertFromUtf32(mPasteHotKey);
            }
            mPickColorHotKey = Properties.Settings.Default.PickColorHotKey;
            if (mPickColorHotKey != 0)
            {
                tb_pick_color_key.Text = Char.ConvertFromUtf32(mPickColorHotKey);
            }
            mOcrBasicHotKey = Properties.Settings.Default.OcrBasicHotKey;
            if (mOcrBasicHotKey != 0)
            {
                tb_ocr_basic_key.Text = Char.ConvertFromUtf32(mOcrBasicHotKey);
            }
            mOcrExcelHotKey = Properties.Settings.Default.OcrExcelHotKey;
            if (mOcrExcelHotKey != 0)
            {
                tb_ocr_excel_key.Text = Char.ConvertFromUtf32(mOcrExcelHotKey);
            }
        }

        private void Form_shortcut_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (mIsSetSuccess)
            {
                this.DialogResult = DialogResult.OK;
            }
        }

        private void tb_catch_key_KeyUp(object sender, KeyEventArgs e)
        {
            // 目前仅支持Alt+单个字母的组合键
            if (e.KeyValue >= 0x41 && e.KeyValue <= 0x5A)
            {
                tb_catch_key.Text = e.KeyCode.ToString();
                mCatchHotKey = e.KeyValue;
            }
        }

        private void btn_catch_set_Click(object sender, EventArgs e)
        {
            if (mCatchHotKey != 0)
            {
                Properties.Settings.Default.CatchHotKey = mCatchHotKey;
                Properties.Settings.Default.Save();
                mIsSetSuccess = true;
            }
            else
            {
                MessageBox.Show("设置失败");
            }
        }

        private void tb_paste_key_KeyUp(object sender, KeyEventArgs e)
        {
            // 目前仅支持Alt+单个字母的组合键
            if (e.KeyValue >= 0x41 && e.KeyValue <= 0x5A)
            {
                tb_paste_key.Text = e.KeyCode.ToString();
                mPasteHotKey = e.KeyValue;
            }
        }

        private void btn_paste_set_Click(object sender, EventArgs e)
        {
            if (mPasteHotKey != 0)
            {
                Properties.Settings.Default.PasteHotKey = mPasteHotKey;
                Properties.Settings.Default.Save();
                mIsSetSuccess = true;
            }
            else
            {
                MessageBox.Show("设置失败");
            }
        }

        private void tb_pick_color_key_KeyUp(object sender, KeyEventArgs e)
        {
            // 目前仅支持Alt+单个字母的组合键
            if (e.KeyValue >= 0x41 && e.KeyValue <= 0x5A)
            {
                tb_pick_color_key.Text = e.KeyCode.ToString();
                mPickColorHotKey = e.KeyValue;
            }
        }

        private void btn_color_Click(object sender, EventArgs e)
        {
            if (mPickColorHotKey != 0)
            {
                Properties.Settings.Default.PickColorHotKey = mPickColorHotKey;
                Properties.Settings.Default.Save();
                mIsSetSuccess = true;
            }
            else
            {
                MessageBox.Show("设置失败");
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

        private void tb_ocr_excel_key_KeyUp(object sender, KeyEventArgs e)
        {
            // 目前仅支持Alt+单个字母的组合键
            if (e.KeyValue >= 0x41 && e.KeyValue <= 0x5A)
            {
                tb_ocr_excel_key.Text = e.KeyCode.ToString();
                mOcrExcelHotKey = e.KeyValue;
            }
        }

        private void btn_ocr_excel_set_Click(object sender, EventArgs e)
        {
            if (mOcrExcelHotKey != 0)
            {
                Properties.Settings.Default.OcrExcelHotKey = mOcrExcelHotKey;
                Properties.Settings.Default.Save();
                mIsSetSuccess = true;
            }
            else
            {
                MessageBox.Show("设置失败");
            }
        }

        #region 这里代码是监听按键事件，实现组合键识别
        List<KeyEventArgs> catchKeyList = new List<KeyEventArgs>();
        bool isCatchKeyStart = false;
        private void tb_KeyDown(object sender, KeyEventArgs e)
        {
            Console.WriteLine("KeyDown： KeyCode = " + e.KeyCode + "  KeyData = " + e.KeyData + "  KeyValue = " + e.KeyValue);
            if (!isCatchKeyStart)
            {
                tb_catch_key.Text = "";
                isCatchKeyStart = true;
                catchKeyList.Clear();
            }
            if (!ContainsKey(catchKeyList, e) && e.KeyValue != 229)
            {
                catchKeyList.Add(e);
            }
        }

        private bool ContainsKey(List<KeyEventArgs> keyList, KeyEventArgs e)
        {
            if (keyList == null || e == null)
            {
                return false;
            }
            foreach (var item in keyList)
            {
                if (item.KeyValue == e.KeyValue)
                {
                    return true;
                }
            }
            return false;
        }

        private void tb_KeyUp(object sender, KeyEventArgs e)
        {
            Console.WriteLine("KeyUp： KeyCode = " + e.KeyCode + "  KeyData = " + e.KeyData + "  KeyValue = " + e.KeyValue);
            if (isCatchKeyStart)
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < catchKeyList.Count; i++)
                {
                    sb.Append(catchKeyList[i].KeyCode.ToString().Replace("Key", ""));
                    if (i != catchKeyList.Count - 1)
                    {
                        sb.Append( " + ");
                    }
                }
                tb_catch_key.Text = "";
                tb_catch_key.Text = sb.ToString();
                isCatchKeyStart = false;
            }
        }
        #endregion

    }
}
