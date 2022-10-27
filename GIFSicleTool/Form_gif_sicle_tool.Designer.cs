namespace GIFSicleTool
{
    partial class Form_gif_sicle_tool
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
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form_gif_sicle_tool));
            this.txtFilePath = new System.Windows.Forms.TextBox();
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.tb_compress_scale = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.btnClearTxt = new System.Windows.Forms.Button();
            this.trackBar_compress_lossy = new System.Windows.Forms.TrackBar();
            this.label5 = new System.Windows.Forms.Label();
            this.tb_compress_lossy = new System.Windows.Forms.TextBox();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.btnSelectPath = new System.Windows.Forms.Button();
            this.txtSelectPath = new System.Windows.Forms.TextBox();
            this.tb_log = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btn_clean_log = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.cb_compress_color = new System.Windows.Forms.CheckBox();
            this.btn_start = new System.Windows.Forms.Button();
            this.panel_color = new System.Windows.Forms.Panel();
            this.cb_compress_color_level = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cb_compress_resize = new System.Windows.Forms.CheckBox();
            this.panel_resize = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.tb_compress_resize_height = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_compress_resize_width = new System.Windows.Forms.TextBox();
            this.cb_compress_lossy = new System.Windows.Forms.CheckBox();
            this.panel_lossy = new System.Windows.Forms.Panel();
            this.cb_compress_scale = new System.Windows.Forms.CheckBox();
            this.cb_compress_defult = new System.Windows.Forms.CheckBox();
            this.panel_scale = new System.Windows.Forms.Panel();
            this.trackBar_compress_scale = new System.Windows.Forms.TrackBar();
            this.panel_defult = new System.Windows.Forms.Panel();
            this.cb_compress_defult_level = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_compress_lossy)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.panel_color.SuspendLayout();
            this.panel_resize.SuspendLayout();
            this.panel_lossy.SuspendLayout();
            this.panel_scale.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_compress_scale)).BeginInit();
            this.panel_defult.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtFilePath
            // 
            this.txtFilePath.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilePath.Location = new System.Drawing.Point(8, 25);
            this.txtFilePath.Margin = new System.Windows.Forms.Padding(4);
            this.txtFilePath.Multiline = true;
            this.txtFilePath.Name = "txtFilePath";
            this.txtFilePath.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txtFilePath.Size = new System.Drawing.Size(823, 238);
            this.txtFilePath.TabIndex = 4;
            this.txtFilePath.WordWrap = false;
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Location = new System.Drawing.Point(8, 271);
            this.btnSelectFile.Margin = new System.Windows.Forms.Padding(4);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(100, 29);
            this.btnSelectFile.TabIndex = 3;
            this.btnSelectFile.Text = "添加文件";
            this.btnSelectFile.UseVisualStyleBackColor = true;
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 24);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "比例：";
            // 
            // tb_compress_scale
            // 
            this.tb_compress_scale.Location = new System.Drawing.Point(87, 20);
            this.tb_compress_scale.Margin = new System.Windows.Forms.Padding(4);
            this.tb_compress_scale.Name = "tb_compress_scale";
            this.tb_compress_scale.Size = new System.Drawing.Size(91, 25);
            this.tb_compress_scale.TabIndex = 8;
            this.tb_compress_scale.Text = "80";
            this.tb_compress_scale.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtBiLi_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(187, 24);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(15, 15);
            this.label2.TabIndex = 9;
            this.label2.Text = "%";
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(8, 38);
            this.radioButton1.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(73, 19);
            this.radioButton1.TabIndex = 10;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "原目录";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // btnClearTxt
            // 
            this.btnClearTxt.Location = new System.Drawing.Point(116, 271);
            this.btnClearTxt.Margin = new System.Windows.Forms.Padding(4);
            this.btnClearTxt.Name = "btnClearTxt";
            this.btnClearTxt.Size = new System.Drawing.Size(100, 29);
            this.btnClearTxt.TabIndex = 13;
            this.btnClearTxt.Text = "清空";
            this.btnClearTxt.UseVisualStyleBackColor = true;
            this.btnClearTxt.Click += new System.EventHandler(this.btnClearTxt_Click);
            // 
            // trackBar_compress_lossy
            // 
            this.trackBar_compress_lossy.Location = new System.Drawing.Point(27, 61);
            this.trackBar_compress_lossy.Margin = new System.Windows.Forms.Padding(4);
            this.trackBar_compress_lossy.Maximum = 200;
            this.trackBar_compress_lossy.Minimum = 5;
            this.trackBar_compress_lossy.Name = "trackBar_compress_lossy";
            this.trackBar_compress_lossy.Size = new System.Drawing.Size(256, 56);
            this.trackBar_compress_lossy.TabIndex = 15;
            this.trackBar_compress_lossy.Value = 35;
            this.trackBar_compress_lossy.Scroll += new System.EventHandler(this.trackBar_compress_lossy_Scroll);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 28);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 15);
            this.label5.TabIndex = 16;
            this.label5.Text = "质量：";
            // 
            // tb_compress_lossy
            // 
            this.tb_compress_lossy.Location = new System.Drawing.Point(87, 24);
            this.tb_compress_lossy.Margin = new System.Windows.Forms.Padding(4);
            this.tb_compress_lossy.Name = "tb_compress_lossy";
            this.tb_compress_lossy.Size = new System.Drawing.Size(91, 25);
            this.tb_compress_lossy.TabIndex = 17;
            this.tb_compress_lossy.Text = "35";
            this.tb_compress_lossy.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_compress_lossy_KeyPress);
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Location = new System.Drawing.Point(165, 38);
            this.radioButton3.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(73, 19);
            this.radioButton3.TabIndex = 22;
            this.radioButton3.Text = "自定义";
            this.radioButton3.UseVisualStyleBackColor = true;
            // 
            // btnSelectPath
            // 
            this.btnSelectPath.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSelectPath.Location = new System.Drawing.Point(743, 31);
            this.btnSelectPath.Margin = new System.Windows.Forms.Padding(4);
            this.btnSelectPath.Name = "btnSelectPath";
            this.btnSelectPath.Size = new System.Drawing.Size(88, 29);
            this.btnSelectPath.TabIndex = 23;
            this.btnSelectPath.Text = "浏览...";
            this.btnSelectPath.UseVisualStyleBackColor = true;
            this.btnSelectPath.Click += new System.EventHandler(this.btnSelectPath_Click);
            // 
            // txtSelectPath
            // 
            this.txtSelectPath.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtSelectPath.Location = new System.Drawing.Point(252, 34);
            this.txtSelectPath.Margin = new System.Windows.Forms.Padding(4);
            this.txtSelectPath.Name = "txtSelectPath";
            this.txtSelectPath.Size = new System.Drawing.Size(480, 25);
            this.txtSelectPath.TabIndex = 24;
            // 
            // tb_log
            // 
            this.tb_log.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tb_log.Location = new System.Drawing.Point(8, 59);
            this.tb_log.Margin = new System.Windows.Forms.Padding(4);
            this.tb_log.Multiline = true;
            this.tb_log.Name = "tb_log";
            this.tb_log.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tb_log.Size = new System.Drawing.Size(823, 199);
            this.tb_log.TabIndex = 27;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txtFilePath);
            this.groupBox1.Controls.Add(this.btnSelectFile);
            this.groupBox1.Controls.Add(this.btnClearTxt);
            this.groupBox1.Location = new System.Drawing.Point(16, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox1.Size = new System.Drawing.Size(841, 308);
            this.groupBox1.TabIndex = 28;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "请添加输入文件（可拖拽添加多个GIF文件）";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.radioButton2);
            this.groupBox2.Controls.Add(this.radioButton1);
            this.groupBox2.Controls.Add(this.radioButton3);
            this.groupBox2.Controls.Add(this.btnSelectPath);
            this.groupBox2.Controls.Add(this.txtSelectPath);
            this.groupBox2.Location = new System.Drawing.Point(16, 331);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox2.Size = new System.Drawing.Size(841, 80);
            this.groupBox2.TabIndex = 29;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "输出设置";
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(95, 38);
            this.radioButton2.Margin = new System.Windows.Forms.Padding(4);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(58, 19);
            this.radioButton2.TabIndex = 25;
            this.radioButton2.Text = "桌面";
            this.radioButton2.UseVisualStyleBackColor = true;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.btn_clean_log);
            this.groupBox3.Controls.Add(this.tb_log);
            this.groupBox3.Location = new System.Drawing.Point(16, 419);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox3.Size = new System.Drawing.Size(841, 275);
            this.groupBox3.TabIndex = 30;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "日志打印";
            // 
            // btn_clean_log
            // 
            this.btn_clean_log.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_clean_log.Location = new System.Drawing.Point(743, 22);
            this.btn_clean_log.Margin = new System.Windows.Forms.Padding(4);
            this.btn_clean_log.Name = "btn_clean_log";
            this.btn_clean_log.Size = new System.Drawing.Size(89, 29);
            this.btn_clean_log.TabIndex = 14;
            this.btn_clean_log.Text = "清空";
            this.btn_clean_log.UseVisualStyleBackColor = true;
            this.btn_clean_log.Click += new System.EventHandler(this.btn_clean_log_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox4.Controls.Add(this.cb_compress_color);
            this.groupBox4.Controls.Add(this.btn_start);
            this.groupBox4.Controls.Add(this.panel_color);
            this.groupBox4.Controls.Add(this.cb_compress_resize);
            this.groupBox4.Controls.Add(this.panel_resize);
            this.groupBox4.Controls.Add(this.cb_compress_lossy);
            this.groupBox4.Controls.Add(this.panel_lossy);
            this.groupBox4.Controls.Add(this.cb_compress_scale);
            this.groupBox4.Controls.Add(this.cb_compress_defult);
            this.groupBox4.Controls.Add(this.panel_scale);
            this.groupBox4.Controls.Add(this.panel_defult);
            this.groupBox4.Location = new System.Drawing.Point(865, 15);
            this.groupBox4.Margin = new System.Windows.Forms.Padding(4);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Padding = new System.Windows.Forms.Padding(4);
            this.groupBox4.Size = new System.Drawing.Size(340, 679);
            this.groupBox4.TabIndex = 31;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "压缩操作";
            // 
            // cb_compress_color
            // 
            this.cb_compress_color.AutoSize = true;
            this.cb_compress_color.Location = new System.Drawing.Point(24, 102);
            this.cb_compress_color.Margin = new System.Windows.Forms.Padding(4);
            this.cb_compress_color.Name = "cb_compress_color";
            this.cb_compress_color.Size = new System.Drawing.Size(119, 19);
            this.cb_compress_color.TabIndex = 29;
            this.cb_compress_color.Text = "指定色彩压缩";
            this.cb_compress_color.UseVisualStyleBackColor = true;
            // 
            // btn_start
            // 
            this.btn_start.Location = new System.Drawing.Point(15, 598);
            this.btn_start.Margin = new System.Windows.Forms.Padding(4);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(304, 64);
            this.btn_start.TabIndex = 28;
            this.btn_start.Text = "开始压缩";
            this.btn_start.UseVisualStyleBackColor = true;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // panel_color
            // 
            this.panel_color.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_color.Controls.Add(this.cb_compress_color_level);
            this.panel_color.Controls.Add(this.label8);
            this.panel_color.Location = new System.Drawing.Point(16, 111);
            this.panel_color.Margin = new System.Windows.Forms.Padding(4);
            this.panel_color.Name = "panel_color";
            this.panel_color.Size = new System.Drawing.Size(303, 80);
            this.panel_color.TabIndex = 30;
            // 
            // cb_compress_color_level
            // 
            this.cb_compress_color_level.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_compress_color_level.FormattingEnabled = true;
            this.cb_compress_color_level.Items.AddRange(new object[] {
            "256",
            "128",
            "64",
            "32",
            "16",
            "8",
            "4",
            "2"});
            this.cb_compress_color_level.Location = new System.Drawing.Point(88, 29);
            this.cb_compress_color_level.Margin = new System.Windows.Forms.Padding(4);
            this.cb_compress_color_level.Name = "cb_compress_color_level";
            this.cb_compress_color_level.Size = new System.Drawing.Size(91, 23);
            this.cb_compress_color_level.TabIndex = 2;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(24, 32);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(52, 15);
            this.label8.TabIndex = 16;
            this.label8.Text = "色彩：";
            // 
            // cb_compress_resize
            // 
            this.cb_compress_resize.AutoSize = true;
            this.cb_compress_resize.Location = new System.Drawing.Point(24, 459);
            this.cb_compress_resize.Margin = new System.Windows.Forms.Padding(4);
            this.cb_compress_resize.Name = "cb_compress_resize";
            this.cb_compress_resize.Size = new System.Drawing.Size(119, 19);
            this.cb_compress_resize.TabIndex = 26;
            this.cb_compress_resize.Text = "指定尺寸压缩";
            this.cb_compress_resize.UseVisualStyleBackColor = true;
            // 
            // panel_resize
            // 
            this.panel_resize.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_resize.Controls.Add(this.label6);
            this.panel_resize.Controls.Add(this.tb_compress_resize_height);
            this.panel_resize.Controls.Add(this.label4);
            this.panel_resize.Controls.Add(this.tb_compress_resize_width);
            this.panel_resize.Location = new System.Drawing.Point(16, 468);
            this.panel_resize.Margin = new System.Windows.Forms.Padding(4);
            this.panel_resize.Name = "panel_resize";
            this.panel_resize.Size = new System.Drawing.Size(303, 112);
            this.panel_resize.TabIndex = 27;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 66);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(52, 15);
            this.label6.TabIndex = 18;
            this.label6.Text = "高度：";
            // 
            // tb_compress_resize_height
            // 
            this.tb_compress_resize_height.Location = new System.Drawing.Point(87, 62);
            this.tb_compress_resize_height.Margin = new System.Windows.Forms.Padding(4);
            this.tb_compress_resize_height.Name = "tb_compress_resize_height";
            this.tb_compress_resize_height.Size = new System.Drawing.Size(91, 25);
            this.tb_compress_resize_height.TabIndex = 19;
            this.tb_compress_resize_height.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_compress_resize_height_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 32);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(52, 15);
            this.label4.TabIndex = 16;
            this.label4.Text = "宽度：";
            // 
            // tb_compress_resize_width
            // 
            this.tb_compress_resize_width.Location = new System.Drawing.Point(87, 29);
            this.tb_compress_resize_width.Margin = new System.Windows.Forms.Padding(4);
            this.tb_compress_resize_width.Name = "tb_compress_resize_width";
            this.tb_compress_resize_width.Size = new System.Drawing.Size(91, 25);
            this.tb_compress_resize_width.TabIndex = 17;
            this.tb_compress_resize_width.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tb_compress_resize_width_KeyPress);
            // 
            // cb_compress_lossy
            // 
            this.cb_compress_lossy.AutoSize = true;
            this.cb_compress_lossy.Location = new System.Drawing.Point(24, 322);
            this.cb_compress_lossy.Margin = new System.Windows.Forms.Padding(4);
            this.cb_compress_lossy.Name = "cb_compress_lossy";
            this.cb_compress_lossy.Size = new System.Drawing.Size(89, 19);
            this.cb_compress_lossy.TabIndex = 24;
            this.cb_compress_lossy.Text = "有损压缩";
            this.cb_compress_lossy.UseVisualStyleBackColor = true;
            // 
            // panel_lossy
            // 
            this.panel_lossy.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_lossy.Controls.Add(this.label5);
            this.panel_lossy.Controls.Add(this.tb_compress_lossy);
            this.panel_lossy.Controls.Add(this.trackBar_compress_lossy);
            this.panel_lossy.Location = new System.Drawing.Point(16, 331);
            this.panel_lossy.Margin = new System.Windows.Forms.Padding(4);
            this.panel_lossy.Name = "panel_lossy";
            this.panel_lossy.Size = new System.Drawing.Size(303, 120);
            this.panel_lossy.TabIndex = 25;
            // 
            // cb_compress_scale
            // 
            this.cb_compress_scale.AutoSize = true;
            this.cb_compress_scale.Location = new System.Drawing.Point(24, 199);
            this.cb_compress_scale.Margin = new System.Windows.Forms.Padding(4);
            this.cb_compress_scale.Name = "cb_compress_scale";
            this.cb_compress_scale.Size = new System.Drawing.Size(104, 19);
            this.cb_compress_scale.TabIndex = 22;
            this.cb_compress_scale.Text = "按比例压缩";
            this.cb_compress_scale.UseVisualStyleBackColor = true;
            // 
            // cb_compress_defult
            // 
            this.cb_compress_defult.AutoSize = true;
            this.cb_compress_defult.Location = new System.Drawing.Point(24, 22);
            this.cb_compress_defult.Margin = new System.Windows.Forms.Padding(4);
            this.cb_compress_defult.Name = "cb_compress_defult";
            this.cb_compress_defult.Size = new System.Drawing.Size(89, 19);
            this.cb_compress_defult.TabIndex = 20;
            this.cb_compress_defult.Text = "默认压缩";
            this.cb_compress_defult.UseVisualStyleBackColor = true;
            this.cb_compress_defult.CheckedChanged += new System.EventHandler(this.cb_compress_defult_CheckedChanged);
            // 
            // panel_scale
            // 
            this.panel_scale.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_scale.Controls.Add(this.trackBar_compress_scale);
            this.panel_scale.Controls.Add(this.tb_compress_scale);
            this.panel_scale.Controls.Add(this.label1);
            this.panel_scale.Controls.Add(this.label2);
            this.panel_scale.Location = new System.Drawing.Point(16, 208);
            this.panel_scale.Margin = new System.Windows.Forms.Padding(4);
            this.panel_scale.Name = "panel_scale";
            this.panel_scale.Size = new System.Drawing.Size(303, 106);
            this.panel_scale.TabIndex = 23;
            // 
            // trackBar_compress_scale
            // 
            this.trackBar_compress_scale.Location = new System.Drawing.Point(27, 55);
            this.trackBar_compress_scale.Margin = new System.Windows.Forms.Padding(4);
            this.trackBar_compress_scale.Maximum = 200;
            this.trackBar_compress_scale.Minimum = 5;
            this.trackBar_compress_scale.Name = "trackBar_compress_scale";
            this.trackBar_compress_scale.Size = new System.Drawing.Size(256, 56);
            this.trackBar_compress_scale.TabIndex = 18;
            this.trackBar_compress_scale.Value = 80;
            this.trackBar_compress_scale.Scroll += new System.EventHandler(this.trackBar_compress_scale_Scroll);
            // 
            // panel_defult
            // 
            this.panel_defult.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel_defult.Controls.Add(this.cb_compress_defult_level);
            this.panel_defult.Controls.Add(this.label3);
            this.panel_defult.Location = new System.Drawing.Point(16, 31);
            this.panel_defult.Margin = new System.Windows.Forms.Padding(4);
            this.panel_defult.Name = "panel_defult";
            this.panel_defult.Size = new System.Drawing.Size(303, 63);
            this.panel_defult.TabIndex = 21;
            // 
            // cb_compress_defult_level
            // 
            this.cb_compress_defult_level.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_compress_defult_level.FormattingEnabled = true;
            this.cb_compress_defult_level.Items.AddRange(new object[] {
            "1",
            "2",
            "3"});
            this.cb_compress_defult_level.Location = new System.Drawing.Point(87, 21);
            this.cb_compress_defult_level.Margin = new System.Windows.Forms.Padding(4);
            this.cb_compress_defult_level.Name = "cb_compress_defult_level";
            this.cb_compress_defult_level.Size = new System.Drawing.Size(91, 23);
            this.cb_compress_defult_level.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 25);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 15);
            this.label3.TabIndex = 0;
            this.label3.Text = "等级：";
            // 
            // Form_gif_sicle_tool
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1223, 705);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Form_gif_sicle_tool";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "GIF压缩";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.DragEnter += new System.Windows.Forms.DragEventHandler(this.Form1_DragEnter);
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_compress_lossy)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.panel_color.ResumeLayout(false);
            this.panel_color.PerformLayout();
            this.panel_resize.ResumeLayout(false);
            this.panel_resize.PerformLayout();
            this.panel_lossy.ResumeLayout(false);
            this.panel_lossy.PerformLayout();
            this.panel_scale.ResumeLayout(false);
            this.panel_scale.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_compress_scale)).EndInit();
            this.panel_defult.ResumeLayout(false);
            this.panel_defult.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtFilePath;
        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox tb_compress_scale;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.Button btnClearTxt;
        private System.Windows.Forms.TrackBar trackBar_compress_lossy;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox tb_compress_lossy;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.Button btnSelectPath;
        private System.Windows.Forms.TextBox txtSelectPath;
        private System.Windows.Forms.TextBox tb_log;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btn_clean_log;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.CheckBox cb_compress_defult;
        private System.Windows.Forms.Panel panel_defult;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.CheckBox cb_compress_resize;
        private System.Windows.Forms.Panel panel_resize;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox tb_compress_resize_height;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tb_compress_resize_width;
        private System.Windows.Forms.CheckBox cb_compress_lossy;
        private System.Windows.Forms.Panel panel_lossy;
        private System.Windows.Forms.CheckBox cb_compress_scale;
        private System.Windows.Forms.Panel panel_scale;
        private System.Windows.Forms.ComboBox cb_compress_defult_level;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.TrackBar trackBar_compress_scale;
        private System.Windows.Forms.CheckBox cb_compress_color;
        private System.Windows.Forms.Panel panel_color;
        private System.Windows.Forms.ComboBox cb_compress_color_level;
        private System.Windows.Forms.Label label8;
    }
}

