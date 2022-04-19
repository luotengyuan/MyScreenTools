namespace 屏幕工具
{
    partial class Form_catch
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_catch));
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.btn_confirm = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_dowload = new System.Windows.Forms.Button();
            this.panel_menu = new System.Windows.Forms.Panel();
            this.panel_menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // saveFileDialog1
            // 
            this.saveFileDialog1.Filter = "png文件|*.png|jpg文件|*.jpg";
            this.saveFileDialog1.Title = "保存截图";
            // 
            // btn_confirm
            // 
            this.btn_confirm.BackgroundImage = global::屏幕工具.Properties.Resources.确认;
            this.btn_confirm.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_confirm.FlatAppearance.BorderSize = 0;
            this.btn_confirm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_confirm.Location = new System.Drawing.Point(80, 5);
            this.btn_confirm.Name = "btn_confirm";
            this.btn_confirm.Size = new System.Drawing.Size(30, 23);
            this.btn_confirm.TabIndex = 0;
            this.btn_confirm.UseVisualStyleBackColor = true;
            this.btn_confirm.Click += new System.EventHandler(this.btn_confirm_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.BackgroundImage = global::屏幕工具.Properties.Resources.取消;
            this.btn_cancel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_cancel.FlatAppearance.BorderSize = 0;
            this.btn_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_cancel.Location = new System.Drawing.Point(47, 5);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(30, 23);
            this.btn_cancel.TabIndex = 1;
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_dowload
            // 
            this.btn_dowload.BackColor = System.Drawing.Color.Transparent;
            this.btn_dowload.BackgroundImage = global::屏幕工具.Properties.Resources.下载;
            this.btn_dowload.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btn_dowload.FlatAppearance.BorderSize = 0;
            this.btn_dowload.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_dowload.Location = new System.Drawing.Point(13, 3);
            this.btn_dowload.Name = "btn_dowload";
            this.btn_dowload.Size = new System.Drawing.Size(25, 27);
            this.btn_dowload.TabIndex = 2;
            this.btn_dowload.UseVisualStyleBackColor = false;
            this.btn_dowload.Click += new System.EventHandler(this.btn_dowload_Click);
            // 
            // panel_menu
            // 
            this.panel_menu.AutoSize = true;
            this.panel_menu.BackColor = System.Drawing.Color.White;
            this.panel_menu.Controls.Add(this.btn_dowload);
            this.panel_menu.Controls.Add(this.btn_cancel);
            this.panel_menu.Controls.Add(this.btn_confirm);
            this.panel_menu.Location = new System.Drawing.Point(12, 12);
            this.panel_menu.Name = "panel_menu";
            this.panel_menu.Size = new System.Drawing.Size(119, 34);
            this.panel_menu.TabIndex = 1;
            this.panel_menu.Visible = false;
            // 
            // Form_catch
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackgroundImage = global::屏幕工具.Properties.Resources.bg;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.ClientSize = new System.Drawing.Size(772, 556);
            this.Controls.Add(this.panel_menu);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form_catch";
            this.ShowInTaskbar = false;
            this.Text = "截图";
            this.TopMost = true;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_catch_FormClosing);
            this.Load += new System.EventHandler(this.Form_catch_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form_catch_KeyDown);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.Form_catch_MouseClick);
            this.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.Form_catch_MouseDoubleClick);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Form_catch_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Form_catch_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Form_catch_MouseUp);
            this.panel_menu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button btn_dowload;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_confirm;
        private System.Windows.Forms.Panel panel_menu;
    }
}