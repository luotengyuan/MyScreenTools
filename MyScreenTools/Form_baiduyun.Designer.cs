namespace 屏幕工具
{
    partial class Form_baiduyun
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_baiduyun));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tb_ocr_api_key = new System.Windows.Forms.TextBox();
            this.tb_ocr_secret_key = new System.Windows.Forms.TextBox();
            this.btn_ocr_set = new System.Windows.Forms.Button();
            this.ll_baiduyun = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tb_translate_secret_key = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btn_translate_set = new System.Windows.Forms.Button();
            this.tb_translate_api_key = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(53, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "ApiKey：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "SecretKry：";
            // 
            // tb_ocr_api_key
            // 
            this.tb_ocr_api_key.Location = new System.Drawing.Point(116, 23);
            this.tb_ocr_api_key.Name = "tb_ocr_api_key";
            this.tb_ocr_api_key.Size = new System.Drawing.Size(289, 21);
            this.tb_ocr_api_key.TabIndex = 2;
            // 
            // tb_ocr_secret_key
            // 
            this.tb_ocr_secret_key.Location = new System.Drawing.Point(116, 50);
            this.tb_ocr_secret_key.Name = "tb_ocr_secret_key";
            this.tb_ocr_secret_key.Size = new System.Drawing.Size(289, 21);
            this.tb_ocr_secret_key.TabIndex = 3;
            // 
            // btn_ocr_set
            // 
            this.btn_ocr_set.Location = new System.Drawing.Point(41, 86);
            this.btn_ocr_set.Name = "btn_ocr_set";
            this.btn_ocr_set.Size = new System.Drawing.Size(364, 27);
            this.btn_ocr_set.TabIndex = 4;
            this.btn_ocr_set.Text = "设置";
            this.btn_ocr_set.UseVisualStyleBackColor = true;
            this.btn_ocr_set.Click += new System.EventHandler(this.btn_set_Click);
            // 
            // ll_baiduyun
            // 
            this.ll_baiduyun.AutoSize = true;
            this.ll_baiduyun.Location = new System.Drawing.Point(118, 290);
            this.ll_baiduyun.Name = "ll_baiduyun";
            this.ll_baiduyun.Size = new System.Drawing.Size(299, 12);
            this.ll_baiduyun.TabIndex = 5;
            this.ll_baiduyun.TabStop = true;
            this.ll_baiduyun.Text = "如何注册和开通百度云账号以及申请APIKey和SecretKey";
            this.ll_baiduyun.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ll_baiduyun_LinkClicked);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(69, 290);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "提示：";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tb_ocr_secret_key);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btn_ocr_set);
            this.groupBox1.Controls.Add(this.tb_ocr_api_key);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(484, 129);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "百度云图像文字识别";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tb_translate_secret_key);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.btn_translate_set);
            this.groupBox2.Controls.Add(this.tb_translate_api_key);
            this.groupBox2.Location = new System.Drawing.Point(12, 147);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(484, 129);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "百度云文本翻译";
            // 
            // tb_translate_secret_key
            // 
            this.tb_translate_secret_key.Location = new System.Drawing.Point(116, 50);
            this.tb_translate_secret_key.Name = "tb_translate_secret_key";
            this.tb_translate_secret_key.Size = new System.Drawing.Size(289, 21);
            this.tb_translate_secret_key.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(57, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "ApiKey：";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(39, 53);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 12);
            this.label5.TabIndex = 1;
            this.label5.Text = "SecretKry：";
            // 
            // btn_translate_set
            // 
            this.btn_translate_set.Location = new System.Drawing.Point(41, 86);
            this.btn_translate_set.Name = "btn_translate_set";
            this.btn_translate_set.Size = new System.Drawing.Size(364, 27);
            this.btn_translate_set.TabIndex = 4;
            this.btn_translate_set.Text = "设置";
            this.btn_translate_set.UseVisualStyleBackColor = true;
            this.btn_translate_set.Click += new System.EventHandler(this.btn_translate_set_Click);
            // 
            // tb_translate_api_key
            // 
            this.tb_translate_api_key.Location = new System.Drawing.Point(116, 23);
            this.tb_translate_api_key.Name = "tb_translate_api_key";
            this.tb_translate_api_key.Size = new System.Drawing.Size(289, 21);
            this.tb_translate_api_key.TabIndex = 2;
            // 
            // Form_baiduyun
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 316);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ll_baiduyun);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form_baiduyun";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "百度云设置";
            this.Load += new System.EventHandler(this.Form_baiduyun_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_ocr_api_key;
        private System.Windows.Forms.TextBox tb_ocr_secret_key;
        private System.Windows.Forms.Button btn_ocr_set;
        private System.Windows.Forms.LinkLabel ll_baiduyun;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox tb_translate_secret_key;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_translate_set;
        private System.Windows.Forms.TextBox tb_translate_api_key;
    }
}