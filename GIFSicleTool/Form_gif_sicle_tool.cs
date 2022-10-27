using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace GIFSicleTool
{
    public partial class Form_gif_sicle_tool : Form
    {

        #region 全局变量
        /// <summary>
        /// gifsicle.exe程序存放路径（当前程序运行同一目录）
        /// </summary>
        private string gifsicle_exe_file_path = System.AppDomain.CurrentDomain.BaseDirectory + "\\gifsicle.exe";
        /// <summary>
        /// 过滤后的待处理输入文件路径列表
        /// </summary>
        List<string> filePathList;
        /// <summary>
        /// 压缩参数字符串拼接内容
        /// </summary>
        StringBuilder operateSb;
        /// <summary>
        /// 自定义输出目录路径
        /// </summary>
        string customOutPath;

        #endregion

        #region 初始化界面

        public Form_gif_sicle_tool()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            initView();
        }

        /// <summary>
        /// 初始化界面
        /// </summary>
        private void initView()
        {
            int output_mode = Properties.Settings.Default.Setting_output_mode;
            if (output_mode == 0)
            {
                radioButton1.Checked = true;
            }
            else if (output_mode == 1)
            {
                radioButton2.Checked = true;
            }
            else
            {
                radioButton3.Checked = true;
            }
            txtSelectPath.Text = Properties.Settings.Default.Setting_output_path;
            cb_compress_defult.Checked = Properties.Settings.Default.Setting_is_compress_defult;
            cb_compress_defult_level.SelectedIndex = Properties.Settings.Default.Setting_compress_defult_level;
            cb_compress_color.Checked = Properties.Settings.Default.Setting_is_compress_color;
            cb_compress_color_level.SelectedIndex = Properties.Settings.Default.Setting_compress_color_level;
            cb_compress_scale.Checked = Properties.Settings.Default.Setting_is_compress_scale;
            trackBar_compress_scale.Value = Properties.Settings.Default.Setting_compress_scale;
            tb_compress_scale.Text = trackBar_compress_scale.Value.ToString();
            cb_compress_lossy.Checked = Properties.Settings.Default.Setting_is_compress_lossy;
            trackBar_compress_lossy.Value = Properties.Settings.Default.Setting_compress_lossy;
            tb_compress_lossy.Text = trackBar_compress_lossy.Value.ToString();
            cb_compress_resize.Checked = Properties.Settings.Default.Setting__is_compress_resize;
            tb_compress_resize_width.Text = Properties.Settings.Default.Setting_compress_resize_width;
            tb_compress_resize_height.Text = Properties.Settings.Default.Setting_compress_resize_height;
        }

        #endregion

        #region 拖放文件

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            DragFile(e);
        }

        /// <summary>
        /// 文件拖拽到界面后处理方法
        /// </summary>
        /// <param name="e"></param>
        void DragFile(DragEventArgs e)
        {
            //如果拖进来的是文件类型
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] paths = e.Data.GetData(DataFormats.FileDrop) as string[];
                foreach (var pathStr in paths)
                {
                    if (pathStr.ToLower().EndsWith(".gif"))
                    {
                        AppendInputFilePathToList(pathStr);
                    }
                }
            }
        }

        #endregion

        #region 事件处理方法
        private void btn_start_Click(object sender, EventArgs e)
        {
            // 判断gifsicle.exe文件是否存在，不存在则拷贝资源文件中的文件到当前文件夹
            if (!IsGifSicleExeFileExist())
            {
                MessageBox.Show("可执行程序不存在，请将gifsicle.exe文件拷贝到当前程序所在文件夹。");
                return;
            }
            // 读取输入文件列表
            if (string.IsNullOrWhiteSpace(txtFilePath.Text))
            {
                MessageBox.Show("请先选择输入文件！");
                return;
            }
            filePathList = new List<string>();
            string[] filePathArr = txtFilePath.Text.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var filePath in filePathArr)
            {
                if (!string.IsNullOrWhiteSpace(filePath))
                {
                    filePathList.Add(filePath);
                }
            }
            if (filePathList.Count <= 0)
            {
                MessageBox.Show("获取输入文件为空，请检查输入文件！");
                return;
            }
            // 读取输出文件参数
            customOutPath = txtSelectPath.Text.Trim().TrimEnd('\\');
            if (radioButton3.Checked)
            {
                if (string.IsNullOrWhiteSpace(customOutPath))
                {
                    MessageBox.Show("请选择自定义输出文件夹！");
                    return;
                }
                else
                {
                    if (!Directory.Exists(customOutPath))
                    {
                        Directory.CreateDirectory(customOutPath);
                    }
                    if (!Directory.Exists(customOutPath))
                    {
                        MessageBox.Show("创建输出文件夹失败，请检查输出文件夹路径是否正确！");
                        return;
                    }
                }
            }

            // 读取操作选项
            operateSb = new StringBuilder();
            if (cb_compress_defult.Checked)
            {
                operateSb.Append("-O" + (cb_compress_defult_level.SelectedIndex + 1) + " ");
            }
            else
            {
                if (cb_compress_color.Checked)
                {
                    int color = 256;
                    switch (cb_compress_color_level.SelectedIndex)
                    {
                        case 0:
                            color = 256;
                            break;
                        case 1:
                            color = 128;
                            break;
                        case 2:
                            color = 64;
                            break;
                        case 3:
                            color = 32;
                            break;
                        case 4:
                            color = 16;
                            break;
                        case 5:
                            color = 8;
                            break;
                        case 6:
                            color = 4;
                            break;
                        case 7:
                            color = 2;
                            break;
                        default:
                            break;
                    }
                    operateSb.Append("--colors " + color + " ");
                }
                if (cb_compress_scale.Checked)
                {
                    operateSb.Append("--scale " + (trackBar_compress_scale.Value / (double)100).ToString("0.00") + " ");
                }
                if (cb_compress_lossy.Checked)
                {
                    operateSb.Append("--lossy=" + trackBar_compress_lossy.Value + " ");
                }
                if (cb_compress_resize.Checked)
                {
                    int w = 0;
                    if (!string.IsNullOrWhiteSpace(tb_compress_resize_width.Text))
                    {
                        w = int.Parse(tb_compress_resize_width.Text);
                    }
                    int h = 0;
                    if (!string.IsNullOrWhiteSpace(tb_compress_resize_height.Text))
                    {
                        h = int.Parse(tb_compress_resize_height.Text);
                    }
                    if (w > 0 && h > 0)
                    {
                        operateSb.Append("--resize " + w + "x" + h + " ");
                    }
                    else if (w > 0)
                    {
                        operateSb.Append("--resize-width " + w + " ");
                    }
                    else if (h > 0)
                    {
                        operateSb.Append("--resize-height " + h + " ");
                    }
                }
            }
            if (operateSb.Length == 0)
            {
                MessageBox.Show("请选择正确的压缩参数！");
                return;
            }

            // 保存设置
            SaveConfigInfo();

            btn_start.Enabled = false;
            BackgroundWorker bgw = new BackgroundWorker();
            bgw.WorkerReportsProgress = true;
            bgw.DoWork += bgw_save_DoWork;
            bgw.ProgressChanged += bgw_save_ProgressChanged;
            bgw.RunWorkerCompleted += bgw_save_Completed;
            bgw.RunWorkerAsync();

        }

        private void btnSelectFile_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "GIF文件|*.gif|所有文件|*.*";
            ofd.RestoreDirectory = true;
            ofd.Multiselect = true;
            ofd.FilterIndex = 1;
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                foreach (var fName in ofd.FileNames)
                {
                    AppendInputFilePathToList(fName);
                }
            }
        }

        private void btnClearTxt_Click(object sender, EventArgs e)
        {
            txtFilePath.Clear();
            txtFilePath.ClearUndo();
        }


        private void btn_clean_log_Click(object sender, EventArgs e)
        {
            tb_log.Text = "";
        }

        private void btnSelectPath_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            if (fbd.ShowDialog() == DialogResult.OK)
            {
                txtSelectPath.Text = fbd.SelectedPath;
                if (!radioButton3.Checked)
                {
                    radioButton3.Checked = true;
                }
            }
        }

        private void txtBiLi_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= (char)48 && e.KeyChar <= (char)57) || e.KeyChar == (char)Keys.Delete || e.KeyChar == (char)Keys.Back)
            {
            }
            else
            {
                e.Handled = true;
            }
        }

        private void tb_compress_lossy_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= (char)48 && e.KeyChar <= (char)57) || e.KeyChar == (char)Keys.Delete || e.KeyChar == (char)Keys.Back)
            {
            }
            else
            {
                e.Handled = true;
            }
        }

        private void tb_compress_resize_width_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= (char)48 && e.KeyChar <= (char)57) || e.KeyChar == (char)Keys.Delete || e.KeyChar == (char)Keys.Back)
            {
            }
            else
            {
                e.Handled = true;
            }
        }

        private void tb_compress_resize_height_KeyPress(object sender, KeyPressEventArgs e)
        {
            if ((e.KeyChar >= (char)48 && e.KeyChar <= (char)57) || e.KeyChar == (char)Keys.Delete || e.KeyChar == (char)Keys.Back)
            {
            }
            else
            {
                e.Handled = true;
            }
        }

        private void cb_compress_defult_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_compress_defult.Checked)
            {
                cb_compress_color.Enabled = false;
                panel_color.Enabled = false;
                cb_compress_scale.Enabled = false;
                panel_scale.Enabled = false;
                cb_compress_lossy.Enabled = false;
                panel_lossy.Enabled = false;
                cb_compress_resize.Enabled = false;
                panel_resize.Enabled = false;
            }
            else
            {
                cb_compress_color.Enabled = true;
                panel_color.Enabled = true;
                cb_compress_scale.Enabled = true;
                panel_scale.Enabled = true;
                cb_compress_lossy.Enabled = true;
                panel_lossy.Enabled = true;
                cb_compress_resize.Enabled = true;
                panel_resize.Enabled = true;
            }
        }

        private void trackBar_compress_scale_Scroll(object sender, EventArgs e)
        {
            tb_compress_scale.Text = trackBar_compress_scale.Value.ToString();
        }

        private void trackBar_compress_lossy_Scroll(object sender, EventArgs e)
        {
            tb_compress_lossy.Text = trackBar_compress_lossy.Value.ToString();
        }

        #endregion

        #region 业务方法

        /// <summary>
        /// 日志添加到界面方法
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private bool AppendInputFilePathToList(string path)
        {
            string[] filePathArr = txtFilePath.Text.Split(new char[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var filePath in filePathArr)
            {
                if (filePath.Equals(path))
                {
                    return false;
                }
            }
            txtFilePath.Text += path + "\r\n";
            return true;
        }

        /// <summary>
        /// 执行cmd命令方法
        /// </summary>
        /// <param name="mingLing"></param>
        /// <returns></returns>
        string CMD(string mingLing)
        {
            System.Diagnostics.Process p = new System.Diagnostics.Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.UseShellExecute = false;    //是否使用操作系统shell启动
            p.StartInfo.RedirectStandardInput = true;//接受来自调用程序的输入信息
            p.StartInfo.RedirectStandardOutput = true;//由调用程序获取输出信息
            p.StartInfo.RedirectStandardError = true;//重定向标准错误输出
            p.StartInfo.CreateNoWindow = true;//不显示程序窗口
            p.Start();//启动程序

            //向cmd窗口发送输入信息
            p.StandardInput.WriteLine(mingLing + "&exit");

            p.StandardInput.AutoFlush = true;
            //p.StandardInput.WriteLine("exit");
            //向标准输入写入要执行的命令。这里使用&是批处理命令的符号，表示前面一个命令不管是否执行成功都执行后面(exit)命令，如果不执行exit命令，后面调用ReadToEnd()方法会假死
            //同类的符号还有&&和||前者表示必须前一个命令执行成功才会执行后面的命令，后者表示必须前一个命令执行失败才会执行后面的命令

            //获取cmd窗口的输出信息
            string output = p.StandardOutput.ReadToEnd();

            //StreamReader reader = p.StandardOutput;
            //string line=reader.ReadLine();
            //while (!reader.EndOfStream)
            //{
            //    str += line + "  ";
            //    line = reader.ReadLine();
            //}

            p.WaitForExit();//等待程序执行完退出进程
            p.Close();

            //Console.WriteLine(output);
            return output;
        }

        /// <summary>
        /// 防止路径中间有空格导致不能正常使用
        /// </summary>
        /// <param name="strPath"></param>
        /// <returns></returns>
        public string CheckSafePath(string strPath)
        {
            if (strPath.IndexOf(" ") > -1)
            {
                return "\"" + strPath + "\"";
            }
            return strPath;
        }

        /// <summary>
        /// 保存配置参数
        /// </summary>
        private void SaveConfigInfo()
        {
            if (radioButton1.Checked)
            {
                Properties.Settings.Default.Setting_output_mode = 0;
            }
            else if (radioButton2.Checked)
            {
                Properties.Settings.Default.Setting_output_mode = 1;
            }
            else
            {
                Properties.Settings.Default.Setting_output_mode = 2;
            }
            Properties.Settings.Default.Setting_output_path = txtSelectPath.Text;
            Properties.Settings.Default.Setting_is_compress_defult = cb_compress_defult.Checked;
            Properties.Settings.Default.Setting_compress_defult_level = cb_compress_defult_level.SelectedIndex;
            Properties.Settings.Default.Setting_is_compress_color = cb_compress_color.Checked;
            Properties.Settings.Default.Setting_compress_color_level = cb_compress_color_level.SelectedIndex;
            Properties.Settings.Default.Setting_is_compress_scale = cb_compress_scale.Checked;
            Properties.Settings.Default.Setting_compress_scale = trackBar_compress_scale.Value;
            Properties.Settings.Default.Setting_is_compress_lossy = cb_compress_lossy.Checked;
            Properties.Settings.Default.Setting_compress_lossy = trackBar_compress_lossy.Value;
            Properties.Settings.Default.Setting__is_compress_resize = cb_compress_resize.Checked;
            Properties.Settings.Default.Setting_compress_resize_width = tb_compress_resize_width.Text;
            Properties.Settings.Default.Setting_compress_resize_height = tb_compress_resize_height.Text;
            Properties.Settings.Default.Save();
        }

        /// <summary>
        /// 后台处理任务工作
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgw_save_DoWork(object sender, DoWorkEventArgs e)
        {
            int i = 0;
            // 遍历执行文件
            foreach (var filePath in filePathList)
            {
                i++;
                AppendLogText("------------------ " + i + "/" + filePathList.Count + " ------------------");
                string savaFileName = "Modif_" + Path.GetFileName(filePath);//保存文件名
                string savaFilePath = Directory.GetParent(filePath).FullName.ToString() + "\\" + savaFileName;//保存文件路径及文件名
                string safeFilePath = CheckSafePath(filePath);
                savaFilePath = CheckSafePath(savaFilePath);
                string str = "";
                if (radioButton1.Checked)
                {
                    str = "gifsicle.exe " + operateSb.ToString() + safeFilePath + " -o " + savaFilePath;
                }
                else if (radioButton2.Checked)
                {
                    str = "gifsicle.exe " + operateSb.ToString() + safeFilePath + " -o " + Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + "\\" + savaFileName;
                }
                else
                {
                    str = "gifsicle.exe " + operateSb.ToString() + safeFilePath + " -o " + customOutPath + "\\" + savaFileName;
                }
                AppendLogText("执行命令：" + str);
                string ret = CMD(str);
                ret = ret.Substring(ret.IndexOf(str) + str.Length, ret.Length - ret.IndexOf(str) - str.Length - 1);
                AppendLogText("输出结果：" + ret);
            }
        }

        /// <summary>
        /// 后台任务进度
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgw_save_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
        }

        /// <summary>
        /// 后台任务完成
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void bgw_save_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            btn_start.Enabled = true;
            MessageBox.Show("处理完成");
        }

        /// <summary>
        /// 是否gifscile.exe文件存在
        /// </summary>
        /// <returns></returns>
        private bool IsGifSicleExeFileExist()
        {
            if (File.Exists(gifsicle_exe_file_path))
            {
                return true;
            }
            // 如果文件不存在，则从资源文件中拷贝出来
            //保存资源文件
            FileStream str = new FileStream(gifsicle_exe_file_path, FileMode.OpenOrCreate);
            /*注：     
             * 1.先添加组件--->常规--->资源文件
             * 2.在Resource1.resx中添加资源--->添加现有文件--->把文件名改成test
             */
            str.Write(Properties.Resources.gifsicle, 0, Properties.Resources.gifsicle.Length);
            str.Close();
            if (File.Exists(gifsicle_exe_file_path))
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// 添加日志到界面
        /// </summary>
        /// <param name="text"></param>
        private void AppendLogText(string text)
        {
            this.BeginInvoke(new UpdateLog(_AppendLogText), text);
        }

        /// <summary>
        /// 添加日志到界面
        /// </summary>
        /// <param name="text"></param>
        delegate void UpdateLog(string text);

        /// <summary>
        /// 添加日志到界面
        /// </summary>
        /// <param name="text"></param>
        private void _AppendLogText(string text)
        {
            tb_log.Text += DateTime.Now.ToString() + "  " + text + "\r\n";
            tb_log.SelectionStart = tb_log.Text.Length;
            tb_log.ScrollToCaret();
        }

        #endregion

    }
}
