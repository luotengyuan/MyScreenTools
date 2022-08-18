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
            this.tb_api_key = new System.Windows.Forms.TextBox();
            this.tb_secret_key = new System.Windows.Forms.TextBox();
            this.btn_set = new System.Windows.Forms.Button();
            this.ll_baiduyun = new System.Windows.Forms.LinkLabel();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.groupBox.SuspendLayout();
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
            // tb_api_key
            // 
            this.tb_api_key.Location = new System.Drawing.Point(116, 23);
            this.tb_api_key.Name = "tb_api_key";
            this.tb_api_key.Size = new System.Drawing.Size(289, 21);
            this.tb_api_key.TabIndex = 2;
            // 
            // tb_secret_key
            // 
            this.tb_secret_key.Location = new System.Drawing.Point(116, 50);
            this.tb_secret_key.Name = "tb_secret_key";
            this.tb_secret_key.Size = new System.Drawing.Size(289, 21);
            this.tb_secret_key.TabIndex = 3;
            // 
            // btn_set
            // 
            this.btn_set.Location = new System.Drawing.Point(41, 86);
            this.btn_set.Name = "btn_set";
            this.btn_set.Size = new System.Drawing.Size(392, 27);
            this.btn_set.TabIndex = 4;
            this.btn_set.Text = "设置";
            this.btn_set.UseVisualStyleBackColor = true;
            this.btn_set.Click += new System.EventHandler(this.btn_set_Click);
            // 
            // ll_baiduyun
            // 
            this.ll_baiduyun.AutoSize = true;
            this.ll_baiduyun.LinkColor = System.Drawing.Color.Red;
            this.ll_baiduyun.Location = new System.Drawing.Point(86, 166);
            this.ll_baiduyun.Name = "ll_baiduyun";
            this.ll_baiduyun.Size = new System.Drawing.Size(359, 12);
            this.ll_baiduyun.TabIndex = 5;
            this.ll_baiduyun.TabStop = true;
            this.ll_baiduyun.Text = "如何注册和开通百度云账号以及申请APIKey和SecretKey请点击这里";
            this.ll_baiduyun.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.ll_baiduyun_LinkClicked);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(37, 166);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 12);
            this.label3.TabIndex = 6;
            this.label3.Text = "提示：";
            // 
            // groupBox
            // 
            this.groupBox.Controls.Add(this.tb_secret_key);
            this.groupBox.Controls.Add(this.label1);
            this.groupBox.Controls.Add(this.label2);
            this.groupBox.Controls.Add(this.btn_set);
            this.groupBox.Controls.Add(this.tb_api_key);
            this.groupBox.Location = new System.Drawing.Point(12, 12);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(470, 139);
            this.groupBox.TabIndex = 7;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "百度云图像文字识别";
            // 
            // Form_baiduyun
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(493, 200);
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.ll_baiduyun);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form_baiduyun";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "百度云设置";
            this.Load += new System.EventHandler(this.Form_baiduyun_Load);
            this.groupBox.ResumeLayout(false);
            this.groupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tb_api_key;
        private System.Windows.Forms.TextBox tb_secret_key;
        private System.Windows.Forms.Button btn_set;
        private System.Windows.Forms.LinkLabel ll_baiduyun;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.GroupBox groupBox;
    }
}