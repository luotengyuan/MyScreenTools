namespace ScreenColorPicker.UI
{
    partial class Form_color
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_color));
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tb_pixel = new System.Windows.Forms.TextBox();
            this.tb_rgb = new System.Windows.Forms.TextBox();
            this.pb_picture = new System.Windows.Forms.PictureBox();
            this.pb_color = new System.Windows.Forms.PictureBox();
            this.tb_hex = new System.Windows.Forms.TextBox();
            this.tb_hsb = new System.Windows.Forms.TextBox();
            this.tb_hsl = new System.Windows.Forms.TextBox();
            this.tb_hsv = new System.Windows.Forms.TextBox();
            this.tb_cmyk = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btn_lock = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pb_picture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_color)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(78, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(71, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Pixel(X,Y):";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(42, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(107, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "RGB(255,255,255):";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(72, 63);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 12);
            this.label3.TabIndex = 2;
            this.label3.Text = "HEX(FFFFFF):";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(42, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 12);
            this.label4.TabIndex = 3;
            this.label4.Text = "HSB(360,255,255):";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 171);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(137, 12);
            this.label5.TabIndex = 4;
            this.label5.Text = "CMYK(100,100,100,100):";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(42, 144);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(107, 12);
            this.label6.TabIndex = 5;
            this.label6.Text = "HSV(360,255,255):";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(42, 117);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 12);
            this.label7.TabIndex = 6;
            this.label7.Text = "HSL(360,255,255):";
            // 
            // tb_pixel
            // 
            this.tb_pixel.Location = new System.Drawing.Point(153, 6);
            this.tb_pixel.Name = "tb_pixel";
            this.tb_pixel.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tb_pixel.Size = new System.Drawing.Size(114, 21);
            this.tb_pixel.TabIndex = 7;
            this.tb_pixel.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_rgb
            // 
            this.tb_rgb.Location = new System.Drawing.Point(153, 33);
            this.tb_rgb.Name = "tb_rgb";
            this.tb_rgb.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tb_rgb.Size = new System.Drawing.Size(114, 21);
            this.tb_rgb.TabIndex = 8;
            this.tb_rgb.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // pb_picture
            // 
            this.pb_picture.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pb_picture.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pb_picture.Location = new System.Drawing.Point(290, 72);
            this.pb_picture.Name = "pb_picture";
            this.pb_picture.Size = new System.Drawing.Size(120, 120);
            this.pb_picture.TabIndex = 10;
            this.pb_picture.TabStop = false;
            // 
            // pb_color
            // 
            this.pb_color.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pb_color.Location = new System.Drawing.Point(290, 6);
            this.pb_color.Name = "pb_color";
            this.pb_color.Size = new System.Drawing.Size(60, 60);
            this.pb_color.TabIndex = 9;
            this.pb_color.TabStop = false;
            // 
            // tb_hex
            // 
            this.tb_hex.Location = new System.Drawing.Point(153, 60);
            this.tb_hex.Name = "tb_hex";
            this.tb_hex.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tb_hex.Size = new System.Drawing.Size(114, 21);
            this.tb_hex.TabIndex = 12;
            this.tb_hex.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_hsb
            // 
            this.tb_hsb.Location = new System.Drawing.Point(153, 87);
            this.tb_hsb.Name = "tb_hsb";
            this.tb_hsb.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tb_hsb.Size = new System.Drawing.Size(114, 21);
            this.tb_hsb.TabIndex = 13;
            this.tb_hsb.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_hsl
            // 
            this.tb_hsl.Location = new System.Drawing.Point(153, 114);
            this.tb_hsl.Name = "tb_hsl";
            this.tb_hsl.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tb_hsl.Size = new System.Drawing.Size(114, 21);
            this.tb_hsl.TabIndex = 14;
            this.tb_hsl.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_hsv
            // 
            this.tb_hsv.Location = new System.Drawing.Point(153, 141);
            this.tb_hsv.Name = "tb_hsv";
            this.tb_hsv.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tb_hsv.Size = new System.Drawing.Size(114, 21);
            this.tb_hsv.TabIndex = 15;
            this.tb_hsv.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tb_cmyk
            // 
            this.tb_cmyk.Location = new System.Drawing.Point(153, 168);
            this.tb_cmyk.Name = "tb_cmyk";
            this.tb_cmyk.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tb_cmyk.Size = new System.Drawing.Size(114, 21);
            this.tb_cmyk.TabIndex = 16;
            this.tb_cmyk.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.DarkOrange;
            this.label8.Location = new System.Drawing.Point(42, 202);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(359, 12);
            this.label8.TabIndex = 18;
            this.label8.Text = "提醒：单击左键/右键可以锁住取色状态，需要点击解锁才能继续。";
            // 
            // btn_lock
            // 
            this.btn_lock.Font = new System.Drawing.Font("宋体", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btn_lock.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_lock.Location = new System.Drawing.Point(356, 6);
            this.btn_lock.Name = "btn_lock";
            this.btn_lock.Size = new System.Drawing.Size(54, 60);
            this.btn_lock.TabIndex = 19;
            this.btn_lock.Text = "点击这里解锁";
            this.btn_lock.UseVisualStyleBackColor = true;
            this.btn_lock.Click += new System.EventHandler(this.btn_lock_Click);
            // 
            // Form_color
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(435, 223);
            this.Controls.Add(this.btn_lock);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.tb_cmyk);
            this.Controls.Add(this.tb_hsv);
            this.Controls.Add(this.tb_hsl);
            this.Controls.Add(this.tb_hsb);
            this.Controls.Add(this.tb_hex);
            this.Controls.Add(this.pb_picture);
            this.Controls.Add(this.pb_color);
            this.Controls.Add(this.tb_rgb);
            this.Controls.Add(this.tb_pixel);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Form_color";
            this.Text = "屏幕取色器";
            this.TopMost = true;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_color_FormClosing);
            this.Load += new System.EventHandler(this.Form_color_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pb_picture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pb_color)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tb_pixel;
        private System.Windows.Forms.TextBox tb_rgb;
        private System.Windows.Forms.PictureBox pb_color;
        private System.Windows.Forms.PictureBox pb_picture;
        private System.Windows.Forms.TextBox tb_hex;
        private System.Windows.Forms.TextBox tb_hsb;
        private System.Windows.Forms.TextBox tb_hsl;
        private System.Windows.Forms.TextBox tb_hsv;
        private System.Windows.Forms.TextBox tb_cmyk;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btn_lock;
    }
}