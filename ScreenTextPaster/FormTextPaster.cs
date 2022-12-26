using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ScreenTextPaster
{
    public partial class FormTextPaster : Form
    {
        public FormTextPaster()
        {
            InitializeComponent();
        }

        private void FormTextPaster_Load(object sender, EventArgs e)
        {
            cb_text_size.SelectedIndex = 7;
            setTextBoxFont();
        }

        private void cb_text_size_SelectedIndexChanged(object sender, EventArgs e)
        {
            setTextBoxFont();
        }

        private void cb_bold_CheckedChanged(object sender, EventArgs e)
        {
            setTextBoxFont();
        }

        private void setTextBoxFont()
        {
            if (cb_bold.Checked)
            {
                tb_paster.Font = new Font(tb_paster.Font.FontFamily, float.Parse(cb_text_size.Text), tb_paster.Font.Style | FontStyle.Bold);
            }
            else
            {
                tb_paster.Font = new Font(tb_paster.Font.FontFamily, float.Parse(cb_text_size.Text), tb_paster.Font.Style ^ FontStyle.Bold);
            }
            //tb_paster.Font = new Font(tb_paster.Font.FontFamily, float.Parse(cb_text_size.Text), tb_paster.Font.Style);
        }
    }
}
