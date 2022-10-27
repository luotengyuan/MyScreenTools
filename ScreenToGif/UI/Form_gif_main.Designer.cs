namespace ScreenToGif.UI
{
    partial class Form_gif_main
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_gif_main));
            this.panel_gif_area = new System.Windows.Forms.Panel();
            this.panel_progress = new System.Windows.Forms.Panel();
            this.pb_save = new System.Windows.Forms.ProgressBar();
            this.btn_continue = new System.Windows.Forms.Button();
            this.btn_single = new System.Windows.Forms.Button();
            this.btn_clean = new System.Windows.Forms.Button();
            this.btn_setting = new System.Windows.Forms.Button();
            this.btn_copy = new System.Windows.Forms.Button();
            this.btn_save = new System.Windows.Forms.Button();
            this.cms_setting = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.帧率ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fPSToolStripMenuItem_1 = new System.Windows.Forms.ToolStripMenuItem();
            this.fPSToolStripMenuItem_5 = new System.Windows.Forms.ToolStripMenuItem();
            this.fPSToolStripMenuItem_10 = new System.Windows.Forms.ToolStripMenuItem();
            this.fPSToolStripMenuItem_16 = new System.Windows.Forms.ToolStripMenuItem();
            this.fPSToolStripMenuItem_33 = new System.Windows.Forms.ToolStripMenuItem();
            this.fPSToolStripMenuItem_50 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.自定义区域ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.全屏区域ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.捕获鼠标ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.压缩编码ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.原始编码ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel_btn_area = new System.Windows.Forms.Panel();
            this.panel_btn_area_2 = new System.Windows.Forms.Panel();
            this.btn_exit = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.panel_gif_area.SuspendLayout();
            this.panel_progress.SuspendLayout();
            this.cms_setting.SuspendLayout();
            this.panel_btn_area.SuspendLayout();
            this.panel_btn_area_2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_gif_area
            // 
            this.panel_gif_area.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_gif_area.BackColor = System.Drawing.Color.Lime;
            this.panel_gif_area.Controls.Add(this.panel_progress);
            this.panel_gif_area.Location = new System.Drawing.Point(0, 0);
            this.panel_gif_area.Margin = new System.Windows.Forms.Padding(4);
            this.panel_gif_area.Name = "panel_gif_area";
            this.panel_gif_area.Size = new System.Drawing.Size(679, 417);
            this.panel_gif_area.TabIndex = 0;
            // 
            // panel_progress
            // 
            this.panel_progress.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_progress.BackColor = System.Drawing.SystemColors.Control;
            this.panel_progress.Controls.Add(this.pb_save);
            this.panel_progress.Location = new System.Drawing.Point(3, 353);
            this.panel_progress.Name = "panel_progress";
            this.panel_progress.Size = new System.Drawing.Size(673, 50);
            this.panel_progress.TabIndex = 1;
            this.panel_progress.Visible = false;
            // 
            // pb_save
            // 
            this.pb_save.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pb_save.Location = new System.Drawing.Point(8, 15);
            this.pb_save.Name = "pb_save";
            this.pb_save.Size = new System.Drawing.Size(659, 23);
            this.pb_save.TabIndex = 0;
            // 
            // btn_continue
            // 
            this.btn_continue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_continue.Location = new System.Drawing.Point(10, 7);
            this.btn_continue.Margin = new System.Windows.Forms.Padding(4);
            this.btn_continue.Name = "btn_continue";
            this.btn_continue.Size = new System.Drawing.Size(38, 29);
            this.btn_continue.TabIndex = 1;
            this.btn_continue.Text = "录制";
            this.toolTip.SetToolTip(this.btn_continue, "连续录制（Alt+Q）");
            this.btn_continue.UseVisualStyleBackColor = true;
            this.btn_continue.Click += new System.EventHandler(this.btn_continue_Click);
            // 
            // btn_single
            // 
            this.btn_single.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_single.Location = new System.Drawing.Point(10, 43);
            this.btn_single.Margin = new System.Windows.Forms.Padding(4);
            this.btn_single.Name = "btn_single";
            this.btn_single.Size = new System.Drawing.Size(38, 29);
            this.btn_single.TabIndex = 2;
            this.btn_single.Text = "单帧";
            this.toolTip.SetToolTip(this.btn_single, "单帧录制（Alt+W）");
            this.btn_single.UseVisualStyleBackColor = true;
            this.btn_single.Click += new System.EventHandler(this.btn_single_Click);
            // 
            // btn_clean
            // 
            this.btn_clean.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_clean.Location = new System.Drawing.Point(10, 80);
            this.btn_clean.Margin = new System.Windows.Forms.Padding(4);
            this.btn_clean.Name = "btn_clean";
            this.btn_clean.Size = new System.Drawing.Size(38, 29);
            this.btn_clean.TabIndex = 3;
            this.btn_clean.Text = "清空";
            this.toolTip.SetToolTip(this.btn_clean, "清空已录制数据");
            this.btn_clean.UseVisualStyleBackColor = true;
            this.btn_clean.Click += new System.EventHandler(this.btn_clean_Click);
            // 
            // btn_setting
            // 
            this.btn_setting.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_setting.Location = new System.Drawing.Point(10, 117);
            this.btn_setting.Margin = new System.Windows.Forms.Padding(4);
            this.btn_setting.Name = "btn_setting";
            this.btn_setting.Size = new System.Drawing.Size(38, 29);
            this.btn_setting.TabIndex = 5;
            this.btn_setting.Text = "设置";
            this.toolTip.SetToolTip(this.btn_setting, "设置录制参数");
            this.btn_setting.UseVisualStyleBackColor = true;
            this.btn_setting.Click += new System.EventHandler(this.btn_setting_Click);
            // 
            // btn_copy
            // 
            this.btn_copy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_copy.Location = new System.Drawing.Point(10, 153);
            this.btn_copy.Margin = new System.Windows.Forms.Padding(4);
            this.btn_copy.Name = "btn_copy";
            this.btn_copy.Size = new System.Drawing.Size(38, 29);
            this.btn_copy.TabIndex = 6;
            this.btn_copy.Text = "复制";
            this.toolTip.SetToolTip(this.btn_copy, "复制GIF到剪切板");
            this.btn_copy.UseVisualStyleBackColor = true;
            this.btn_copy.Click += new System.EventHandler(this.btn_copy_Click);
            // 
            // btn_save
            // 
            this.btn_save.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_save.Location = new System.Drawing.Point(10, 189);
            this.btn_save.Margin = new System.Windows.Forms.Padding(4);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(38, 29);
            this.btn_save.TabIndex = 7;
            this.btn_save.Text = "保存";
            this.toolTip.SetToolTip(this.btn_save, "保存GIF到文件");
            this.btn_save.UseVisualStyleBackColor = true;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // cms_setting
            // 
            this.cms_setting.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cms_setting.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.帧率ToolStripMenuItem,
            this.toolStripSeparator1,
            this.自定义区域ToolStripMenuItem,
            this.全屏区域ToolStripMenuItem,
            this.toolStripSeparator2,
            this.捕获鼠标ToolStripMenuItem,
            this.toolStripSeparator3,
            this.压缩编码ToolStripMenuItem,
            this.原始编码ToolStripMenuItem});
            this.cms_setting.Name = "cms_setting";
            this.cms_setting.Size = new System.Drawing.Size(137, 154);
            // 
            // 帧率ToolStripMenuItem
            // 
            this.帧率ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fPSToolStripMenuItem_1,
            this.fPSToolStripMenuItem_5,
            this.fPSToolStripMenuItem_10,
            this.fPSToolStripMenuItem_16,
            this.fPSToolStripMenuItem_33,
            this.fPSToolStripMenuItem_50});
            this.帧率ToolStripMenuItem.Name = "帧率ToolStripMenuItem";
            this.帧率ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.帧率ToolStripMenuItem.Text = "帧率";
            // 
            // fPSToolStripMenuItem_1
            // 
            this.fPSToolStripMenuItem_1.Name = "fPSToolStripMenuItem_1";
            this.fPSToolStripMenuItem_1.Size = new System.Drawing.Size(114, 22);
            this.fPSToolStripMenuItem_1.Text = "1 FPS";
            this.fPSToolStripMenuItem_1.Click += new System.EventHandler(this.fPSToolStripMenuItem_1_Click);
            // 
            // fPSToolStripMenuItem_5
            // 
            this.fPSToolStripMenuItem_5.Name = "fPSToolStripMenuItem_5";
            this.fPSToolStripMenuItem_5.Size = new System.Drawing.Size(114, 22);
            this.fPSToolStripMenuItem_5.Text = "5 FPS";
            this.fPSToolStripMenuItem_5.Click += new System.EventHandler(this.fPSToolStripMenuItem_5_Click);
            // 
            // fPSToolStripMenuItem_10
            // 
            this.fPSToolStripMenuItem_10.Name = "fPSToolStripMenuItem_10";
            this.fPSToolStripMenuItem_10.Size = new System.Drawing.Size(114, 22);
            this.fPSToolStripMenuItem_10.Text = "10 FPS";
            this.fPSToolStripMenuItem_10.Click += new System.EventHandler(this.fPSToolStripMenuItem_10_Click);
            // 
            // fPSToolStripMenuItem_16
            // 
            this.fPSToolStripMenuItem_16.Name = "fPSToolStripMenuItem_16";
            this.fPSToolStripMenuItem_16.Size = new System.Drawing.Size(114, 22);
            this.fPSToolStripMenuItem_16.Text = "16 FPS";
            this.fPSToolStripMenuItem_16.Click += new System.EventHandler(this.fPSToolStripMenuItem_16_Click);
            // 
            // fPSToolStripMenuItem_33
            // 
            this.fPSToolStripMenuItem_33.Name = "fPSToolStripMenuItem_33";
            this.fPSToolStripMenuItem_33.Size = new System.Drawing.Size(114, 22);
            this.fPSToolStripMenuItem_33.Text = "33 FPS";
            this.fPSToolStripMenuItem_33.Click += new System.EventHandler(this.fPSToolStripMenuItem_33_Click);
            // 
            // fPSToolStripMenuItem_50
            // 
            this.fPSToolStripMenuItem_50.Name = "fPSToolStripMenuItem_50";
            this.fPSToolStripMenuItem_50.Size = new System.Drawing.Size(114, 22);
            this.fPSToolStripMenuItem_50.Text = "50 FPS";
            this.fPSToolStripMenuItem_50.Click += new System.EventHandler(this.fPSToolStripMenuItem_50_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(133, 6);
            // 
            // 自定义区域ToolStripMenuItem
            // 
            this.自定义区域ToolStripMenuItem.Name = "自定义区域ToolStripMenuItem";
            this.自定义区域ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.自定义区域ToolStripMenuItem.Text = "自定义区域";
            this.自定义区域ToolStripMenuItem.Click += new System.EventHandler(this.自定义区域ToolStripMenuItem_Click);
            // 
            // 全屏区域ToolStripMenuItem
            // 
            this.全屏区域ToolStripMenuItem.Name = "全屏区域ToolStripMenuItem";
            this.全屏区域ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.全屏区域ToolStripMenuItem.Text = "全屏区域";
            this.全屏区域ToolStripMenuItem.Click += new System.EventHandler(this.全屏区域ToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(133, 6);
            // 
            // 捕获鼠标ToolStripMenuItem
            // 
            this.捕获鼠标ToolStripMenuItem.Name = "捕获鼠标ToolStripMenuItem";
            this.捕获鼠标ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.捕获鼠标ToolStripMenuItem.Text = "捕获鼠标";
            this.捕获鼠标ToolStripMenuItem.Click += new System.EventHandler(this.捕获鼠标ToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(133, 6);
            // 
            // 压缩编码ToolStripMenuItem
            // 
            this.压缩编码ToolStripMenuItem.Name = "压缩编码ToolStripMenuItem";
            this.压缩编码ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.压缩编码ToolStripMenuItem.Text = "压缩编码";
            this.压缩编码ToolStripMenuItem.Click += new System.EventHandler(this.压缩编码ToolStripMenuItem_Click);
            // 
            // 原始编码ToolStripMenuItem
            // 
            this.原始编码ToolStripMenuItem.Name = "原始编码ToolStripMenuItem";
            this.原始编码ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.原始编码ToolStripMenuItem.Text = "原始编码";
            this.原始编码ToolStripMenuItem.Click += new System.EventHandler(this.原始编码ToolStripMenuItem_Click);
            // 
            // panel_btn_area
            // 
            this.panel_btn_area.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel_btn_area.Controls.Add(this.panel_btn_area_2);
            this.panel_btn_area.Location = new System.Drawing.Point(677, 0);
            this.panel_btn_area.Name = "panel_btn_area";
            this.panel_btn_area.Size = new System.Drawing.Size(56, 417);
            this.panel_btn_area.TabIndex = 8;
            // 
            // panel_btn_area_2
            // 
            this.panel_btn_area_2.Controls.Add(this.btn_continue);
            this.panel_btn_area_2.Controls.Add(this.btn_exit);
            this.panel_btn_area_2.Controls.Add(this.btn_setting);
            this.panel_btn_area_2.Controls.Add(this.btn_copy);
            this.panel_btn_area_2.Controls.Add(this.btn_single);
            this.panel_btn_area_2.Controls.Add(this.btn_clean);
            this.panel_btn_area_2.Controls.Add(this.btn_save);
            this.panel_btn_area_2.Location = new System.Drawing.Point(0, 0);
            this.panel_btn_area_2.Name = "panel_btn_area_2";
            this.panel_btn_area_2.Size = new System.Drawing.Size(56, 264);
            this.panel_btn_area_2.TabIndex = 9;
            // 
            // btn_exit
            // 
            this.btn_exit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_exit.Location = new System.Drawing.Point(10, 226);
            this.btn_exit.Margin = new System.Windows.Forms.Padding(4);
            this.btn_exit.Name = "btn_exit";
            this.btn_exit.Size = new System.Drawing.Size(38, 29);
            this.btn_exit.TabIndex = 8;
            this.btn_exit.Text = "退出";
            this.toolTip.SetToolTip(this.btn_exit, "退出全屏模式");
            this.btn_exit.UseVisualStyleBackColor = true;
            this.btn_exit.Visible = false;
            this.btn_exit.Click += new System.EventHandler(this.btn_exit_Click);
            // 
            // Form_gif_main
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(733, 415);
            this.Controls.Add(this.panel_btn_area);
            this.Controls.Add(this.panel_gif_area);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form_gif_main";
            this.Text = "GIF录屏  999 x 766";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_gif_main_FormClosing);
            this.Load += new System.EventHandler(this.Form_gif_main_Load);
            this.LocationChanged += new System.EventHandler(this.Form_gif_main_LocationChanged);
            this.SizeChanged += new System.EventHandler(this.Form_gif_main_SizeChanged);
            this.panel_gif_area.ResumeLayout(false);
            this.panel_progress.ResumeLayout(false);
            this.cms_setting.ResumeLayout(false);
            this.panel_btn_area.ResumeLayout(false);
            this.panel_btn_area_2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel_gif_area;
        private System.Windows.Forms.Button btn_continue;
        private System.Windows.Forms.Button btn_single;
        private System.Windows.Forms.Button btn_clean;
        private System.Windows.Forms.Button btn_setting;
        private System.Windows.Forms.Button btn_copy;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.ContextMenuStrip cms_setting;
        private System.Windows.Forms.ToolStripMenuItem 帧率ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fPSToolStripMenuItem_1;
        private System.Windows.Forms.ToolStripMenuItem fPSToolStripMenuItem_5;
        private System.Windows.Forms.ToolStripMenuItem fPSToolStripMenuItem_10;
        private System.Windows.Forms.ToolStripMenuItem fPSToolStripMenuItem_16;
        private System.Windows.Forms.ToolStripMenuItem fPSToolStripMenuItem_33;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem 自定义区域ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 全屏区域ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem 捕获鼠标ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fPSToolStripMenuItem_50;
        private System.Windows.Forms.Panel panel_btn_area;
        private System.Windows.Forms.Button btn_exit;
        private System.Windows.Forms.Panel panel_btn_area_2;
        private System.Windows.Forms.Panel panel_progress;
        private System.Windows.Forms.ProgressBar pb_save;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem 压缩编码ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 原始编码ToolStripMenuItem;
        private System.Windows.Forms.ToolTip toolTip;
    }
}

