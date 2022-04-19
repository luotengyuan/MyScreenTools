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
            this.tb_ocr_basic_key.Location = new System.Drawing.Point(183, 50);
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
            this.label2.Location = new System.Drawing.Point(47, 53);
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
            this.btn_ocr_basic_set.Location = new System.Drawing.Point(267, 48);
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
            this.label4.Location = new System.Drawing.Point(136, 53);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 12);
            this.label4.TabIndex = 12;
            this.label4.Text = "Alt + ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(85, 108);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(221, 12);
            this.label5.TabIndex = 13;
            this.label5.Text = "注意：目前仅支持Alt+单个字母的组合键";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(136, 82);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 12);
            this.label6.TabIndex = 17;
            this.label6.Text = "Alt + ";
            // 
            // btn_color
            // 
            this.btn_color.Location = new System.Drawing.Point(267, 77);
            this.btn_color.Name = "btn_color";
            this.btn_color.Size = new System.Drawing.Size(74, 23);
            this.btn_color.TabIndex = 16;
            this.btn_color.Text = "设置";
            this.btn_color.UseVisualStyleBackColor = true;
            this.btn_color.Click += new System.EventHandler(this.btn_color_Click);
            // 
            // tb_pick_color_key
            // 
            this.tb_pick_color_key.Location = new System.Drawing.Point(183, 79);
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
            this.label7.Location = new System.Drawing.Point(47, 82);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 12);
            this.label7.TabIndex = 14;
            this.label7.Text = "屏幕取色：";
            // 
            // Form_shortcut
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 134);
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
    }
}