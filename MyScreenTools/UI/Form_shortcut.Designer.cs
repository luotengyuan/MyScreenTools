namespace 屏幕工具
{
    partial class Form_shortcut
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_shortcut));
            this.tb_ocr_basic_key = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_ocr_basic_set = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // tb_ocr_basic_key
            // 
            this.tb_ocr_basic_key.Location = new System.Drawing.Point(184, 63);
            this.tb_ocr_basic_key.Name = "tb_ocr_basic_key";
            this.tb_ocr_basic_key.ReadOnly = true;
            this.tb_ocr_basic_key.Size = new System.Drawing.Size(57, 21);
            this.tb_ocr_basic_key.TabIndex = 8;
            this.tb_ocr_basic_key.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_ocr_basic_key.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tb_ocr_basic_key_KeyUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "文字识别：";
            // 
            // btn_ocr_basic_set
            // 
            this.btn_ocr_basic_set.Location = new System.Drawing.Point(268, 61);
            this.btn_ocr_basic_set.Name = "btn_ocr_basic_set";
            this.btn_ocr_basic_set.Size = new System.Drawing.Size(74, 23);
            this.btn_ocr_basic_set.TabIndex = 10;
            this.btn_ocr_basic_set.Text = "设置";
            this.btn_ocr_basic_set.UseVisualStyleBackColor = true;
            this.btn_ocr_basic_set.Click += new System.EventHandler(this.btn_ocr_basic_set_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(137, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 12;
            this.label4.Text = "Alt + ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(85, 168);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(221, 12);
            this.label5.TabIndex = 13;
            this.label5.Text = "注意：目前仅支持Alt+单个字母的组合键";
            // 
            // Form_shortcut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 202);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_ocr_basic_set);
            this.Controls.Add(this.tb_ocr_basic_key);
            this.Controls.Add(this.label2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form_shortcut";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "快捷键设置";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_shortcut_FormClosing);
            this.Load += new System.EventHandler(this.Form_shortcut_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox tb_ocr_basic_key;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_ocr_basic_set;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
    }
}