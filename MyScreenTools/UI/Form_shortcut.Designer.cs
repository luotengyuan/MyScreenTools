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
            this.btn_catch_set = new System.Windows.Forms.Button();
            this.tb_ocr_basic_key = new System.Windows.Forms.TextBox();
            this.tb_catch_key = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_ocr_basic_set = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_color = new System.Windows.Forms.Button();
            this.tb_pick_color_key = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.btn_paste_set = new System.Windows.Forms.Button();
            this.tb_paste_key = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btn_ocr_excel_set = new System.Windows.Forms.Button();
            this.tb_ocr_excel_key = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_catch_set
            // 
            this.btn_catch_set.Location = new System.Drawing.Point(267, 21);
            this.btn_catch_set.Name = "btn_catch_set";
            this.btn_catch_set.Size = new System.Drawing.Size(74, 23);
            this.btn_catch_set.TabIndex = 9;
            this.btn_catch_set.Text = "设置";
            this.btn_catch_set.UseVisualStyleBackColor = true;
            this.btn_catch_set.Click += new System.EventHandler(this.btn_catch_set_Click);
            // 
            // tb_ocr_basic_key
            // 
            this.tb_ocr_basic_key.Location = new System.Drawing.Point(183, 111);
            this.tb_ocr_basic_key.Name = "tb_ocr_basic_key";
            this.tb_ocr_basic_key.ReadOnly = true;
            this.tb_ocr_basic_key.Size = new System.Drawing.Size(57, 21);
            this.tb_ocr_basic_key.TabIndex = 8;
            this.tb_ocr_basic_key.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_ocr_basic_key.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tb_ocr_basic_key_KeyUp);
            // 
            // tb_catch_key
            // 
            this.tb_catch_key.Location = new System.Drawing.Point(183, 21);
            this.tb_catch_key.Name = "tb_catch_key";
            this.tb_catch_key.ReadOnly = true;
            this.tb_catch_key.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tb_catch_key.Size = new System.Drawing.Size(57, 21);
            this.tb_catch_key.TabIndex = 7;
            this.tb_catch_key.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_catch_key.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tb_catch_key_KeyUp);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(47, 114);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 6;
            this.label2.Text = "文字识别：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(71, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 12);
            this.label1.TabIndex = 5;
            this.label1.Text = "截图：";
            // 
            // btn_ocr_basic_set
            // 
            this.btn_ocr_basic_set.Location = new System.Drawing.Point(267, 109);
            this.btn_ocr_basic_set.Name = "btn_ocr_basic_set";
            this.btn_ocr_basic_set.Size = new System.Drawing.Size(74, 23);
            this.btn_ocr_basic_set.TabIndex = 10;
            this.btn_ocr_basic_set.Text = "设置";
            this.btn_ocr_basic_set.UseVisualStyleBackColor = true;
            this.btn_ocr_basic_set.Click += new System.EventHandler(this.btn_ocr_basic_set_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(136, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 11;
            this.label3.Text = "Alt + ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(136, 114);
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
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(136, 85);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 17;
            this.label6.Text = "Alt + ";
            // 
            // btn_color
            // 
            this.btn_color.Location = new System.Drawing.Point(267, 80);
            this.btn_color.Name = "btn_color";
            this.btn_color.Size = new System.Drawing.Size(74, 23);
            this.btn_color.TabIndex = 16;
            this.btn_color.Text = "设置";
            this.btn_color.UseVisualStyleBackColor = true;
            this.btn_color.Click += new System.EventHandler(this.btn_color_Click);
            // 
            // tb_pick_color_key
            // 
            this.tb_pick_color_key.Location = new System.Drawing.Point(183, 82);
            this.tb_pick_color_key.Name = "tb_pick_color_key";
            this.tb_pick_color_key.ReadOnly = true;
            this.tb_pick_color_key.Size = new System.Drawing.Size(57, 21);
            this.tb_pick_color_key.TabIndex = 15;
            this.tb_pick_color_key.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_pick_color_key.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tb_pick_color_key_KeyUp);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(47, 85);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 14;
            this.label7.Text = "屏幕取色：";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(136, 56);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 12);
            this.label8.TabIndex = 21;
            this.label8.Text = "Alt + ";
            // 
            // btn_paste_set
            // 
            this.btn_paste_set.Location = new System.Drawing.Point(267, 51);
            this.btn_paste_set.Name = "btn_paste_set";
            this.btn_paste_set.Size = new System.Drawing.Size(74, 23);
            this.btn_paste_set.TabIndex = 20;
            this.btn_paste_set.Text = "设置";
            this.btn_paste_set.UseVisualStyleBackColor = true;
            this.btn_paste_set.Click += new System.EventHandler(this.btn_paste_set_Click);
            // 
            // tb_paste_key
            // 
            this.tb_paste_key.Location = new System.Drawing.Point(183, 51);
            this.tb_paste_key.Name = "tb_paste_key";
            this.tb_paste_key.ReadOnly = true;
            this.tb_paste_key.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tb_paste_key.Size = new System.Drawing.Size(57, 21);
            this.tb_paste_key.TabIndex = 19;
            this.tb_paste_key.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_paste_key.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tb_paste_key_KeyUp);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(71, 56);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(41, 12);
            this.label9.TabIndex = 18;
            this.label9.Text = "贴图：";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(136, 143);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(41, 12);
            this.label10.TabIndex = 25;
            this.label10.Text = "Alt + ";
            // 
            // btn_ocr_excel_set
            // 
            this.btn_ocr_excel_set.Location = new System.Drawing.Point(267, 138);
            this.btn_ocr_excel_set.Name = "btn_ocr_excel_set";
            this.btn_ocr_excel_set.Size = new System.Drawing.Size(74, 23);
            this.btn_ocr_excel_set.TabIndex = 24;
            this.btn_ocr_excel_set.Text = "设置";
            this.btn_ocr_excel_set.UseVisualStyleBackColor = true;
            this.btn_ocr_excel_set.Click += new System.EventHandler(this.btn_ocr_excel_set_Click);
            // 
            // tb_ocr_excel_key
            // 
            this.tb_ocr_excel_key.Location = new System.Drawing.Point(183, 140);
            this.tb_ocr_excel_key.Name = "tb_ocr_excel_key";
            this.tb_ocr_excel_key.ReadOnly = true;
            this.tb_ocr_excel_key.Size = new System.Drawing.Size(57, 21);
            this.tb_ocr_excel_key.TabIndex = 23;
            this.tb_ocr_excel_key.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tb_ocr_excel_key.KeyUp += new System.Windows.Forms.KeyEventHandler(this.tb_ocr_excel_key_KeyUp);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(47, 143);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 12);
            this.label11.TabIndex = 22;
            this.label11.Text = "表格识别：";
            // 
            // Form_shortcut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(388, 202);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.btn_ocr_excel_set);
            this.Controls.Add(this.tb_ocr_excel_key);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.btn_paste_set);
            this.Controls.Add(this.tb_paste_key);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btn_color);
            this.Controls.Add(this.tb_pick_color_key);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_ocr_basic_set);
            this.Controls.Add(this.btn_catch_set);
            this.Controls.Add(this.tb_ocr_basic_key);
            this.Controls.Add(this.tb_catch_key);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
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

        private System.Windows.Forms.Button btn_catch_set;
        private System.Windows.Forms.TextBox tb_ocr_basic_key;
        private System.Windows.Forms.TextBox tb_catch_key;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_ocr_basic_set;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_color;
        private System.Windows.Forms.TextBox tb_pick_color_key;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btn_paste_set;
        private System.Windows.Forms.TextBox tb_paste_key;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btn_ocr_excel_set;
        private System.Windows.Forms.TextBox tb_ocr_excel_key;
        private System.Windows.Forms.Label label11;
    }
}