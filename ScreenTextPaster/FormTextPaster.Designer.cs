namespace ScreenTextPaster
{
    partial class FormTextPaster
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.cb_bold = new System.Windows.Forms.CheckBox();
            this.cb_text_size = new System.Windows.Forms.ComboBox();
            this.tb_paster = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(84, 7);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "字体大小：";
            // 
            // cb_bold
            // 
            this.cb_bold.AutoSize = true;
            this.cb_bold.Location = new System.Drawing.Point(12, 6);
            this.cb_bold.Name = "cb_bold";
            this.cb_bold.Size = new System.Drawing.Size(48, 16);
            this.cb_bold.TabIndex = 1;
            this.cb_bold.Text = "粗体";
            this.cb_bold.UseVisualStyleBackColor = true;
            this.cb_bold.CheckedChanged += new System.EventHandler(this.cb_bold_CheckedChanged);
            // 
            // cb_text_size
            // 
            this.cb_text_size.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_text_size.FormattingEnabled = true;
            this.cb_text_size.Items.AddRange(new object[] {
            "5",
            "5.5",
            "6.5",
            "7.5",
            "9",
            "10.5",
            "12",
            "14",
            "15",
            "16",
            "18",
            "20",
            "22",
            "24",
            "26",
            "28",
            "36",
            "42",
            "48",
            "72"});
            this.cb_text_size.Location = new System.Drawing.Point(147, 3);
            this.cb_text_size.Name = "cb_text_size";
            this.cb_text_size.Size = new System.Drawing.Size(121, 20);
            this.cb_text_size.TabIndex = 2;
            this.cb_text_size.SelectedIndexChanged += new System.EventHandler(this.cb_text_size_SelectedIndexChanged);
            // 
            // tb_paster
            // 
            this.tb_paster.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_paster.Location = new System.Drawing.Point(0, 28);
            this.tb_paster.Multiline = true;
            this.tb_paster.Name = "tb_paster";
            this.tb_paster.Size = new System.Drawing.Size(601, 117);
            this.tb_paster.TabIndex = 3;
            // 
            // FormTextPaster
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(602, 146);
            this.Controls.Add(this.tb_paster);
            this.Controls.Add(this.cb_text_size);
            this.Controls.Add(this.cb_bold);
            this.Controls.Add(this.label1);
            this.MinimumSize = new System.Drawing.Size(350, 140);
            this.Name = "FormTextPaster";
            this.ShowIcon = false;
            this.Text = "帖文字";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.FormTextPaster_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox cb_bold;
        private System.Windows.Forms.ComboBox cb_text_size;
        private System.Windows.Forms.TextBox tb_paster;
    }
}

