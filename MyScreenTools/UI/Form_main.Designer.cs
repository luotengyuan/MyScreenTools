namespace 屏幕工具
{
    partial class Form_main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_main));
            this.menuStrip_main = new System.Windows.Forms.MenuStrip();
            this.文件ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.图片文字识别ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.文字识别ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.表格识别ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.关于ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.开机启动ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.百度云设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.文字识别服务ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.机器翻译服务ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.快捷键设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.截图设置ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.复制图像内容到剪切板ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.复制图像路径到剪切板ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.关于ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.关于我们ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_ocr_excel = new System.Windows.Forms.Button();
            this.btn_screenshot = new System.Windows.Forms.Button();
            this.btn_screen_paste = new System.Windows.Forms.Button();
            this.btn_ocr_basic = new System.Windows.Forms.Button();
            this.btn_screen_gif = new System.Windows.Forms.Button();
            this.btn_color = new System.Windows.Forms.Button();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btn_ocr_copy_to_excel = new System.Windows.Forms.Button();
            this.btn_ocr_clean = new System.Windows.Forms.Button();
            this.btn_ocr_copy = new System.Windows.Forms.Button();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tab_page_word = new System.Windows.Forms.TabPage();
            this.tb_ocr_result = new System.Windows.Forms.TextBox();
            this.tab_page_form = new System.Windows.Forms.TabPage();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cb_translate_type = new System.Windows.Forms.ComboBox();
            this.cb_drag_translate = new System.Windows.Forms.CheckBox();
            this.btn_translate = new System.Windows.Forms.Button();
            this.cb_auto_translate = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_translate_to = new System.Windows.Forms.ComboBox();
            this.cb_translate_from = new System.Windows.Forms.ComboBox();
            this.tb_translate_result = new System.Windows.Forms.TextBox();
            this.contextMenuStrip_notify = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.显示ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.截图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.贴图ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.屏幕取色ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.文字识别ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.表格识别ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btn_gif_compress = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.btn_text_paster = new System.Windows.Forms.Button();
            this.menuStrip_main.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tab_page_word.SuspendLayout();
            this.tab_page_form.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.contextMenuStrip_notify.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip_main
            // 
            this.menuStrip_main.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip_main.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文件ToolStripMenuItem,
            this.关于ToolStripMenuItem,
            this.关于ToolStripMenuItem1});
            this.menuStrip_main.Location = new System.Drawing.Point(0, 0);
            this.menuStrip_main.Name = "menuStrip_main";
            this.menuStrip_main.Padding = new System.Windows.Forms.Padding(4, 2, 0, 2);
            this.menuStrip_main.Size = new System.Drawing.Size(841, 25);
            this.menuStrip_main.TabIndex = 0;
            this.menuStrip_main.Text = "menuStrip1";
            // 
            // 文件ToolStripMenuItem
            // 
            this.文件ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.图片文字识别ToolStripMenuItem});
            this.文件ToolStripMenuItem.Name = "文件ToolStripMenuItem";
            this.文件ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.文件ToolStripMenuItem.Text = "文件";
            // 
            // 图片文字识别ToolStripMenuItem
            // 
            this.图片文字识别ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文字识别ToolStripMenuItem,
            this.表格识别ToolStripMenuItem1});
            this.图片文字识别ToolStripMenuItem.Image = global::屏幕工具.Properties.Resources.打开;
            this.图片文字识别ToolStripMenuItem.Name = "图片文字识别ToolStripMenuItem";
            this.图片文字识别ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.图片文字识别ToolStripMenuItem.Text = "打开";
            // 
            // 文字识别ToolStripMenuItem
            // 
            this.文字识别ToolStripMenuItem.Image = global::屏幕工具.Properties.Resources.ocr_128;
            this.文字识别ToolStripMenuItem.Name = "文字识别ToolStripMenuItem";
            this.文字识别ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.文字识别ToolStripMenuItem.Text = "文字识别";
            this.文字识别ToolStripMenuItem.Click += new System.EventHandler(this.文字识别ToolStripMenuItem_Click);
            // 
            // 表格识别ToolStripMenuItem1
            // 
            this.表格识别ToolStripMenuItem1.Image = global::屏幕工具.Properties.Resources.ocr_48;
            this.表格识别ToolStripMenuItem1.Name = "表格识别ToolStripMenuItem1";
            this.表格识别ToolStripMenuItem1.Size = new System.Drawing.Size(124, 22);
            this.表格识别ToolStripMenuItem1.Text = "表格识别";
            this.表格识别ToolStripMenuItem1.Click += new System.EventHandler(this.表格识别ToolStripMenuItem1_Click);
            // 
            // 关于ToolStripMenuItem
            // 
            this.关于ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.开机启动ToolStripMenuItem,
            this.百度云设置ToolStripMenuItem,
            this.快捷键设置ToolStripMenuItem,
            this.截图设置ToolStripMenuItem});
            this.关于ToolStripMenuItem.Name = "关于ToolStripMenuItem";
            this.关于ToolStripMenuItem.Size = new System.Drawing.Size(44, 21);
            this.关于ToolStripMenuItem.Text = "设置";
            // 
            // 开机启动ToolStripMenuItem
            // 
            this.开机启动ToolStripMenuItem.Image = global::屏幕工具.Properties.Resources.选择框_选中;
            this.开机启动ToolStripMenuItem.Name = "开机启动ToolStripMenuItem";
            this.开机启动ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.开机启动ToolStripMenuItem.Text = "开机启动";
            this.开机启动ToolStripMenuItem.Click += new System.EventHandler(this.开机启动ToolStripMenuItem_Click);
            // 
            // 百度云设置ToolStripMenuItem
            // 
            this.百度云设置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.文字识别服务ToolStripMenuItem,
            this.机器翻译服务ToolStripMenuItem});
            this.百度云设置ToolStripMenuItem.Image = global::屏幕工具.Properties.Resources.网站账号;
            this.百度云设置ToolStripMenuItem.Name = "百度云设置ToolStripMenuItem";
            this.百度云设置ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.百度云设置ToolStripMenuItem.Text = "百度云设置";
            // 
            // 文字识别服务ToolStripMenuItem
            // 
            this.文字识别服务ToolStripMenuItem.Name = "文字识别服务ToolStripMenuItem";
            this.文字识别服务ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.文字识别服务ToolStripMenuItem.Text = "文字识别服务";
            this.文字识别服务ToolStripMenuItem.Click += new System.EventHandler(this.文字识别服务ToolStripMenuItem_Click);
            // 
            // 机器翻译服务ToolStripMenuItem
            // 
            this.机器翻译服务ToolStripMenuItem.Name = "机器翻译服务ToolStripMenuItem";
            this.机器翻译服务ToolStripMenuItem.Size = new System.Drawing.Size(148, 22);
            this.机器翻译服务ToolStripMenuItem.Text = "机器翻译服务";
            this.机器翻译服务ToolStripMenuItem.Click += new System.EventHandler(this.机器翻译服务ToolStripMenuItem_Click);
            // 
            // 快捷键设置ToolStripMenuItem
            // 
            this.快捷键设置ToolStripMenuItem.Image = global::屏幕工具.Properties.Resources.快捷键;
            this.快捷键设置ToolStripMenuItem.Name = "快捷键设置ToolStripMenuItem";
            this.快捷键设置ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.快捷键设置ToolStripMenuItem.Text = "快捷键设置";
            this.快捷键设置ToolStripMenuItem.Click += new System.EventHandler(this.快捷键设置ToolStripMenuItem_Click);
            // 
            // 截图设置ToolStripMenuItem
            // 
            this.截图设置ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.复制图像内容到剪切板ToolStripMenuItem,
            this.复制图像路径到剪切板ToolStripMenuItem,
            this.toolStripSeparator1});
            this.截图设置ToolStripMenuItem.Image = global::屏幕工具.Properties.Resources.设置;
            this.截图设置ToolStripMenuItem.Name = "截图设置ToolStripMenuItem";
            this.截图设置ToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.截图设置ToolStripMenuItem.Text = "截图设置";
            // 
            // 复制图像内容到剪切板ToolStripMenuItem
            // 
            this.复制图像内容到剪切板ToolStripMenuItem.Image = global::屏幕工具.Properties.Resources.选择框_选中;
            this.复制图像内容到剪切板ToolStripMenuItem.Name = "复制图像内容到剪切板ToolStripMenuItem";
            this.复制图像内容到剪切板ToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.复制图像内容到剪切板ToolStripMenuItem.Text = "复制图像内容到剪切板";
            this.复制图像内容到剪切板ToolStripMenuItem.Click += new System.EventHandler(this.复制图像内容到剪切板ToolStripMenuItem_Click);
            // 
            // 复制图像路径到剪切板ToolStripMenuItem
            // 
            this.复制图像路径到剪切板ToolStripMenuItem.Image = global::屏幕工具.Properties.Resources.选择框_未选;
            this.复制图像路径到剪切板ToolStripMenuItem.Name = "复制图像路径到剪切板ToolStripMenuItem";
            this.复制图像路径到剪切板ToolStripMenuItem.Size = new System.Drawing.Size(196, 22);
            this.复制图像路径到剪切板ToolStripMenuItem.Text = "复制图像路径到剪切板";
            this.复制图像路径到剪切板ToolStripMenuItem.Click += new System.EventHandler(this.复制图像路径到剪切板ToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(193, 6);
            // 
            // 关于ToolStripMenuItem1
            // 
            this.关于ToolStripMenuItem1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.关于我们ToolStripMenuItem});
            this.关于ToolStripMenuItem1.Name = "关于ToolStripMenuItem1";
            this.关于ToolStripMenuItem1.Size = new System.Drawing.Size(44, 21);
            this.关于ToolStripMenuItem1.Text = "关于";
            // 
            // 关于我们ToolStripMenuItem
            // 
            this.关于我们ToolStripMenuItem.Image = global::屏幕工具.Properties.Resources.关于软件;
            this.关于我们ToolStripMenuItem.Name = "关于我们ToolStripMenuItem";
            this.关于我们ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.关于我们ToolStripMenuItem.Text = "关于我们";
            this.关于我们ToolStripMenuItem.Click += new System.EventHandler(this.关于我们ToolStripMenuItem_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.btn_ocr_excel);
            this.groupBox3.Controls.Add(this.btn_screenshot);
            this.groupBox3.Controls.Add(this.btn_screen_paste);
            this.groupBox3.Controls.Add(this.btn_ocr_basic);
            this.groupBox3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.groupBox3.Location = new System.Drawing.Point(738, 27);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox3.Size = new System.Drawing.Size(94, 177);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "主要功能";
            // 
            // btn_ocr_excel
            // 
            this.btn_ocr_excel.BackColor = System.Drawing.SystemColors.Control;
            this.btn_ocr_excel.Location = new System.Drawing.Point(4, 112);
            this.btn_ocr_excel.Margin = new System.Windows.Forms.Padding(2);
            this.btn_ocr_excel.Name = "btn_ocr_excel";
            this.btn_ocr_excel.Size = new System.Drawing.Size(86, 27);
            this.btn_ocr_excel.TabIndex = 4;
            this.btn_ocr_excel.Text = "表格识别";
            this.btn_ocr_excel.UseVisualStyleBackColor = false;
            this.btn_ocr_excel.Click += new System.EventHandler(this.btn_ocr_excel_Click);
            // 
            // btn_screenshot
            // 
            this.btn_screenshot.BackColor = System.Drawing.SystemColors.Control;
            this.btn_screenshot.Location = new System.Drawing.Point(4, 19);
            this.btn_screenshot.Margin = new System.Windows.Forms.Padding(2);
            this.btn_screenshot.Name = "btn_screenshot";
            this.btn_screenshot.Size = new System.Drawing.Size(86, 27);
            this.btn_screenshot.TabIndex = 0;
            this.btn_screenshot.Text = "截图";
            this.btn_screenshot.UseVisualStyleBackColor = false;
            this.btn_screenshot.Click += new System.EventHandler(this.btn_screenshot_Click);
            // 
            // btn_screen_paste
            // 
            this.btn_screen_paste.BackColor = System.Drawing.SystemColors.Control;
            this.btn_screen_paste.Location = new System.Drawing.Point(4, 50);
            this.btn_screen_paste.Margin = new System.Windows.Forms.Padding(2);
            this.btn_screen_paste.Name = "btn_screen_paste";
            this.btn_screen_paste.Size = new System.Drawing.Size(86, 27);
            this.btn_screen_paste.TabIndex = 3;
            this.btn_screen_paste.Text = "贴图";
            this.btn_screen_paste.UseVisualStyleBackColor = false;
            this.btn_screen_paste.Click += new System.EventHandler(this.btn_screen_paste_Click);
            // 
            // btn_ocr_basic
            // 
            this.btn_ocr_basic.BackColor = System.Drawing.SystemColors.Control;
            this.btn_ocr_basic.Location = new System.Drawing.Point(4, 81);
            this.btn_ocr_basic.Margin = new System.Windows.Forms.Padding(2);
            this.btn_ocr_basic.Name = "btn_ocr_basic";
            this.btn_ocr_basic.Size = new System.Drawing.Size(86, 27);
            this.btn_ocr_basic.TabIndex = 1;
            this.btn_ocr_basic.Text = "文字识别";
            this.btn_ocr_basic.UseVisualStyleBackColor = false;
            this.btn_ocr_basic.Click += new System.EventHandler(this.btn_ocr_basic_Click);
            // 
            // btn_screen_gif
            // 
            this.btn_screen_gif.BackColor = System.Drawing.SystemColors.Control;
            this.btn_screen_gif.Location = new System.Drawing.Point(4, 50);
            this.btn_screen_gif.Margin = new System.Windows.Forms.Padding(2);
            this.btn_screen_gif.Name = "btn_screen_gif";
            this.btn_screen_gif.Size = new System.Drawing.Size(86, 27);
            this.btn_screen_gif.TabIndex = 5;
            this.btn_screen_gif.Text = "GIF录屏";
            this.toolTip.SetToolTip(this.btn_screen_gif, "将屏幕操作录制成GIF动图");
            this.btn_screen_gif.UseVisualStyleBackColor = false;
            this.btn_screen_gif.Click += new System.EventHandler(this.btn_screen_gif_Click);
            // 
            // btn_color
            // 
            this.btn_color.BackColor = System.Drawing.SystemColors.Control;
            this.btn_color.Location = new System.Drawing.Point(4, 19);
            this.btn_color.Margin = new System.Windows.Forms.Padding(2);
            this.btn_color.Name = "btn_color";
            this.btn_color.Size = new System.Drawing.Size(86, 27);
            this.btn_color.TabIndex = 2;
            this.btn_color.Text = "屏幕取色";
            this.toolTip.SetToolTip(this.btn_color, "提取屏幕中某个像素点的颜色值");
            this.btn_color.UseVisualStyleBackColor = false;
            this.btn_color.Click += new System.EventHandler(this.btn_color_Click);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.Location = new System.Drawing.Point(9, 25);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(2);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.groupBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.AutoScroll = true;
            this.splitContainer1.Panel2.Controls.Add(this.groupBox2);
            this.splitContainer1.Size = new System.Drawing.Size(724, 513);
            this.splitContainer1.SplitterDistance = 338;
            this.splitContainer1.SplitterWidth = 3;
            this.splitContainer1.TabIndex = 3;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btn_ocr_copy_to_excel);
            this.groupBox1.Controls.Add(this.btn_ocr_clean);
            this.groupBox1.Controls.Add(this.btn_ocr_copy);
            this.groupBox1.Controls.Add(this.tabControl);
            this.groupBox1.Location = new System.Drawing.Point(2, 2);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(720, 334);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "文字识别";
            // 
            // btn_ocr_copy_to_excel
            // 
            this.btn_ocr_copy_to_excel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ocr_copy_to_excel.BackColor = System.Drawing.SystemColors.Control;
            this.btn_ocr_copy_to_excel.Location = new System.Drawing.Point(448, 18);
            this.btn_ocr_copy_to_excel.Margin = new System.Windows.Forms.Padding(2);
            this.btn_ocr_copy_to_excel.Name = "btn_ocr_copy_to_excel";
            this.btn_ocr_copy_to_excel.Size = new System.Drawing.Size(86, 27);
            this.btn_ocr_copy_to_excel.TabIndex = 4;
            this.btn_ocr_copy_to_excel.Text = "复制到表格";
            this.btn_ocr_copy_to_excel.UseVisualStyleBackColor = false;
            this.btn_ocr_copy_to_excel.Click += new System.EventHandler(this.btn_ocr_copy_to_excel_Click);
            // 
            // btn_ocr_clean
            // 
            this.btn_ocr_clean.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ocr_clean.BackColor = System.Drawing.SystemColors.Control;
            this.btn_ocr_clean.Location = new System.Drawing.Point(628, 18);
            this.btn_ocr_clean.Margin = new System.Windows.Forms.Padding(2);
            this.btn_ocr_clean.Name = "btn_ocr_clean";
            this.btn_ocr_clean.Size = new System.Drawing.Size(86, 27);
            this.btn_ocr_clean.TabIndex = 2;
            this.btn_ocr_clean.Text = "清空";
            this.btn_ocr_clean.UseVisualStyleBackColor = false;
            this.btn_ocr_clean.Click += new System.EventHandler(this.btn_ocr_clean_Click);
            // 
            // btn_ocr_copy
            // 
            this.btn_ocr_copy.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_ocr_copy.BackColor = System.Drawing.SystemColors.Control;
            this.btn_ocr_copy.Location = new System.Drawing.Point(538, 18);
            this.btn_ocr_copy.Margin = new System.Windows.Forms.Padding(2);
            this.btn_ocr_copy.Name = "btn_ocr_copy";
            this.btn_ocr_copy.Size = new System.Drawing.Size(86, 27);
            this.btn_ocr_copy.TabIndex = 1;
            this.btn_ocr_copy.Text = "复制";
            this.btn_ocr_copy.UseVisualStyleBackColor = false;
            this.btn_ocr_copy.Click += new System.EventHandler(this.btn_ocr_copy_Click);
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tab_page_word);
            this.tabControl.Controls.Add(this.tab_page_form);
            this.tabControl.Location = new System.Drawing.Point(5, 30);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(713, 303);
            this.tabControl.TabIndex = 3;
            this.tabControl.SelectedIndexChanged += new System.EventHandler(this.tabControl_SelectedIndexChanged);
            // 
            // tab_page_word
            // 
            this.tab_page_word.Controls.Add(this.tb_ocr_result);
            this.tab_page_word.Location = new System.Drawing.Point(4, 22);
            this.tab_page_word.Name = "tab_page_word";
            this.tab_page_word.Padding = new System.Windows.Forms.Padding(3);
            this.tab_page_word.Size = new System.Drawing.Size(705, 277);
            this.tab_page_word.TabIndex = 0;
            this.tab_page_word.Text = "文字";
            this.tab_page_word.UseVisualStyleBackColor = true;
            // 
            // tb_ocr_result
            // 
            this.tb_ocr_result.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_ocr_result.Location = new System.Drawing.Point(5, 5);
            this.tb_ocr_result.Margin = new System.Windows.Forms.Padding(2);
            this.tb_ocr_result.Multiline = true;
            this.tb_ocr_result.Name = "tb_ocr_result";
            this.tb_ocr_result.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_ocr_result.Size = new System.Drawing.Size(695, 267);
            this.tb_ocr_result.TabIndex = 0;
            // 
            // tab_page_form
            // 
            this.tab_page_form.Controls.Add(this.dataGridView);
            this.tab_page_form.Location = new System.Drawing.Point(4, 22);
            this.tab_page_form.Name = "tab_page_form";
            this.tab_page_form.Padding = new System.Windows.Forms.Padding(3);
            this.tab_page_form.Size = new System.Drawing.Size(705, 277);
            this.tab_page_form.TabIndex = 1;
            this.tab_page_form.Text = "表格";
            this.tab_page_form.UseVisualStyleBackColor = true;
            // 
            // dataGridView
            // 
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(3, 3);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.RowHeadersVisible = false;
            this.dataGridView.RowTemplate.Height = 23;
            this.dataGridView.Size = new System.Drawing.Size(699, 271);
            this.dataGridView.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.cb_translate_type);
            this.groupBox2.Controls.Add(this.cb_drag_translate);
            this.groupBox2.Controls.Add(this.btn_translate);
            this.groupBox2.Controls.Add(this.cb_auto_translate);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cb_translate_to);
            this.groupBox2.Controls.Add(this.cb_translate_from);
            this.groupBox2.Controls.Add(this.tb_translate_result);
            this.groupBox2.Location = new System.Drawing.Point(4, 4);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(720, 182);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "翻译";
            // 
            // cb_translate_type
            // 
            this.cb_translate_type.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.cb_translate_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_translate_type.FormattingEnabled = true;
            this.cb_translate_type.Items.AddRange(new object[] {
            "句子翻译",
            "词典翻译"});
            this.cb_translate_type.Location = new System.Drawing.Point(532, 15);
            this.cb_translate_type.Margin = new System.Windows.Forms.Padding(2);
            this.cb_translate_type.Name = "cb_translate_type";
            this.cb_translate_type.Size = new System.Drawing.Size(92, 20);
            this.cb_translate_type.TabIndex = 7;
            this.cb_translate_type.SelectedIndexChanged += new System.EventHandler(this.cb_translate_type_SelectedIndexChanged);
            // 
            // cb_drag_translate
            // 
            this.cb_drag_translate.AutoSize = true;
            this.cb_drag_translate.Location = new System.Drawing.Point(80, 19);
            this.cb_drag_translate.Margin = new System.Windows.Forms.Padding(2);
            this.cb_drag_translate.Name = "cb_drag_translate";
            this.cb_drag_translate.Size = new System.Drawing.Size(72, 16);
            this.cb_drag_translate.TabIndex = 6;
            this.cb_drag_translate.Text = "划词翻译";
            this.cb_drag_translate.UseVisualStyleBackColor = true;
            this.cb_drag_translate.CheckedChanged += new System.EventHandler(this.cb_drag_translate_CheckedChanged);
            // 
            // btn_translate
            // 
            this.btn_translate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_translate.BackColor = System.Drawing.SystemColors.Control;
            this.btn_translate.Location = new System.Drawing.Point(627, 11);
            this.btn_translate.Margin = new System.Windows.Forms.Padding(2);
            this.btn_translate.Name = "btn_translate";
            this.btn_translate.Size = new System.Drawing.Size(86, 27);
            this.btn_translate.TabIndex = 2;
            this.btn_translate.Text = "翻译";
            this.btn_translate.UseVisualStyleBackColor = false;
            this.btn_translate.Click += new System.EventHandler(this.btn_translate_Click);
            // 
            // cb_auto_translate
            // 
            this.cb_auto_translate.AutoSize = true;
            this.cb_auto_translate.Location = new System.Drawing.Point(4, 19);
            this.cb_auto_translate.Margin = new System.Windows.Forms.Padding(2);
            this.cb_auto_translate.Name = "cb_auto_translate";
            this.cb_auto_translate.Size = new System.Drawing.Size(72, 16);
            this.cb_auto_translate.TabIndex = 5;
            this.cb_auto_translate.Text = "自动翻译";
            this.cb_auto_translate.UseVisualStyleBackColor = true;
            this.cb_auto_translate.CheckedChanged += new System.EventHandler(this.cb_auto_translate_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(259, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(17, 12);
            this.label1.TabIndex = 4;
            this.label1.Text = "→";
            // 
            // cb_translate_to
            // 
            this.cb_translate_to.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_translate_to.FormattingEnabled = true;
            this.cb_translate_to.Location = new System.Drawing.Point(280, 15);
            this.cb_translate_to.Margin = new System.Windows.Forms.Padding(2);
            this.cb_translate_to.Name = "cb_translate_to";
            this.cb_translate_to.Size = new System.Drawing.Size(92, 20);
            this.cb_translate_to.TabIndex = 3;
            this.cb_translate_to.SelectedIndexChanged += new System.EventHandler(this.cb_translate_to_SelectedIndexChanged);
            // 
            // cb_translate_from
            // 
            this.cb_translate_from.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_translate_from.FormattingEnabled = true;
            this.cb_translate_from.Location = new System.Drawing.Point(163, 15);
            this.cb_translate_from.Margin = new System.Windows.Forms.Padding(2);
            this.cb_translate_from.Name = "cb_translate_from";
            this.cb_translate_from.Size = new System.Drawing.Size(92, 20);
            this.cb_translate_from.TabIndex = 2;
            this.cb_translate_from.SelectedIndexChanged += new System.EventHandler(this.cb_translate_from_SelectedIndexChanged);
            // 
            // tb_translate_result
            // 
            this.tb_translate_result.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_translate_result.Location = new System.Drawing.Point(4, 42);
            this.tb_translate_result.Margin = new System.Windows.Forms.Padding(2);
            this.tb_translate_result.Multiline = true;
            this.tb_translate_result.Name = "tb_translate_result";
            this.tb_translate_result.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_translate_result.Size = new System.Drawing.Size(712, 136);
            this.tb_translate_result.TabIndex = 1;
            // 
            // contextMenuStrip_notify
            // 
            this.contextMenuStrip_notify.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip_notify.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.显示ToolStripMenuItem,
            this.截图ToolStripMenuItem,
            this.贴图ToolStripMenuItem,
            this.屏幕取色ToolStripMenuItem,
            this.文字识别ToolStripMenuItem1,
            this.表格识别ToolStripMenuItem,
            this.退出ToolStripMenuItem});
            this.contextMenuStrip_notify.Name = "contextMenuStrip1";
            this.contextMenuStrip_notify.Size = new System.Drawing.Size(125, 158);
            // 
            // 显示ToolStripMenuItem
            // 
            this.显示ToolStripMenuItem.Name = "显示ToolStripMenuItem";
            this.显示ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.显示ToolStripMenuItem.Text = "显示界面";
            this.显示ToolStripMenuItem.Click += new System.EventHandler(this.显示ToolStripMenuItem_Click);
            // 
            // 截图ToolStripMenuItem
            // 
            this.截图ToolStripMenuItem.Name = "截图ToolStripMenuItem";
            this.截图ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.截图ToolStripMenuItem.Text = "截图";
            this.截图ToolStripMenuItem.Click += new System.EventHandler(this.截图ToolStripMenuItem_Click);
            // 
            // 贴图ToolStripMenuItem
            // 
            this.贴图ToolStripMenuItem.Name = "贴图ToolStripMenuItem";
            this.贴图ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.贴图ToolStripMenuItem.Text = "贴图";
            this.贴图ToolStripMenuItem.Click += new System.EventHandler(this.贴图ToolStripMenuItem_Click);
            // 
            // 屏幕取色ToolStripMenuItem
            // 
            this.屏幕取色ToolStripMenuItem.Name = "屏幕取色ToolStripMenuItem";
            this.屏幕取色ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.屏幕取色ToolStripMenuItem.Text = "屏幕取色";
            this.屏幕取色ToolStripMenuItem.Click += new System.EventHandler(this.屏幕取色ToolStripMenuItem_Click);
            // 
            // 文字识别ToolStripMenuItem1
            // 
            this.文字识别ToolStripMenuItem1.Name = "文字识别ToolStripMenuItem1";
            this.文字识别ToolStripMenuItem1.Size = new System.Drawing.Size(124, 22);
            this.文字识别ToolStripMenuItem1.Text = "文字识别";
            this.文字识别ToolStripMenuItem1.Click += new System.EventHandler(this.文字识别ToolStripMenuItem1_Click);
            // 
            // 表格识别ToolStripMenuItem
            // 
            this.表格识别ToolStripMenuItem.Name = "表格识别ToolStripMenuItem";
            this.表格识别ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.表格识别ToolStripMenuItem.Text = "表格识别";
            this.表格识别ToolStripMenuItem.Click += new System.EventHandler(this.表格识别ToolStripMenuItem_Click);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.退出ToolStripMenuItem.Text = "退出";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.contextMenuStrip_notify;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "屏幕截图工具";
            this.notifyIcon.Visible = true;
            this.notifyIcon.BalloonTipClicked += new System.EventHandler(this.notifyIcon_BalloonTipClicked);
            this.notifyIcon.MouseClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseClick);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.btn_text_paster);
            this.groupBox4.Controls.Add(this.btn_gif_compress);
            this.groupBox4.Controls.Add(this.btn_screen_gif);
            this.groupBox4.Controls.Add(this.btn_color);
            this.groupBox4.Location = new System.Drawing.Point(738, 209);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(94, 329);
            this.groupBox4.TabIndex = 4;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "其他功能";
            // 
            // btn_gif_compress
            // 
            this.btn_gif_compress.BackColor = System.Drawing.SystemColors.Control;
            this.btn_gif_compress.Location = new System.Drawing.Point(4, 81);
            this.btn_gif_compress.Margin = new System.Windows.Forms.Padding(2);
            this.btn_gif_compress.Name = "btn_gif_compress";
            this.btn_gif_compress.Size = new System.Drawing.Size(86, 27);
            this.btn_gif_compress.TabIndex = 6;
            this.btn_gif_compress.Text = "GIF压缩";
            this.toolTip.SetToolTip(this.btn_gif_compress, "对GIF图像进行压缩和其他操作");
            this.btn_gif_compress.UseVisualStyleBackColor = false;
            this.btn_gif_compress.Click += new System.EventHandler(this.btn_gif_compress_Click);
            // 
            // btn_text_paster
            // 
            this.btn_text_paster.BackColor = System.Drawing.SystemColors.Control;
            this.btn_text_paster.Location = new System.Drawing.Point(4, 112);
            this.btn_text_paster.Margin = new System.Windows.Forms.Padding(2);
            this.btn_text_paster.Name = "btn_text_paster";
            this.btn_text_paster.Size = new System.Drawing.Size(86, 27);
            this.btn_text_paster.TabIndex = 7;
            this.btn_text_paster.Text = "贴文字";
            this.toolTip.SetToolTip(this.btn_text_paster, "将文字张贴到置顶窗口，方便操作。");
            this.btn_text_paster.UseVisualStyleBackColor = false;
            this.btn_text_paster.Click += new System.EventHandler(this.btn_text_paster_Click);
            // 
            // Form_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(841, 549);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.menuStrip_main);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip_main;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form_main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "屏幕工具";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form_main_FormClosing);
            this.Load += new System.EventHandler(this.Form_main_Load);
            this.Resize += new System.EventHandler(this.Form_main_Resize);
            this.menuStrip_main.ResumeLayout(false);
            this.menuStrip_main.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tab_page_word.ResumeLayout(false);
            this.tab_page_word.PerformLayout();
            this.tab_page_form.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.contextMenuStrip_notify.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip_main;
        private System.Windows.Forms.ToolStripMenuItem 文件ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 图片文字识别ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于ToolStripMenuItem1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ToolStripMenuItem 百度云设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 快捷键设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 关于我们ToolStripMenuItem;
        private System.Windows.Forms.Button btn_ocr_basic;
        private System.Windows.Forms.Button btn_screenshot;
        private System.Windows.Forms.TextBox tb_ocr_result;
        private System.Windows.Forms.Button btn_translate;
        private System.Windows.Forms.CheckBox cb_auto_translate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cb_translate_to;
        private System.Windows.Forms.ComboBox cb_translate_from;
        private System.Windows.Forms.TextBox tb_translate_result;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip_notify;
        private System.Windows.Forms.ToolStripMenuItem 文字识别ToolStripMenuItem;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ToolStripMenuItem 显示ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.Button btn_ocr_clean;
        private System.Windows.Forms.Button btn_ocr_copy;
        private System.Windows.Forms.CheckBox cb_drag_translate;
        private System.Windows.Forms.Button btn_color;
        private System.Windows.Forms.ComboBox cb_translate_type;
        private System.Windows.Forms.Button btn_screen_paste;
        private System.Windows.Forms.ToolStripMenuItem 开机启动ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 截图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 贴图ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 屏幕取色ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 文字识别ToolStripMenuItem1;
        private System.Windows.Forms.Button btn_ocr_excel;
        private System.Windows.Forms.Button btn_ocr_copy_to_excel;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tab_page_word;
        private System.Windows.Forms.TabPage tab_page_form;
        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.ToolStripMenuItem 表格识别ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 表格识别ToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem 文字识别服务ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 机器翻译服务ToolStripMenuItem;
        private System.Windows.Forms.Button btn_screen_gif;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btn_gif_compress;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ToolStripMenuItem 截图设置ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 复制图像内容到剪切板ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 复制图像路径到剪切板ToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Button btn_text_paster;

    }
}

