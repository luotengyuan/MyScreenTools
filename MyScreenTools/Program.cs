using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 屏幕工具
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            ////////////// 判断程序是否已经运行方法一 ///////////////
            //bool bCanRun = false;
            //Mutex mutex = new Mutex(true, "OnlyOne", out bCanRun);
            //if (!bCanRun)
            //{
            //    MessageBox.Show("不可重复启动！");
            //    return;
            //}

            ////////////// 判断程序是否已经运行方法二 ///////////////
            Process instance = RunningInstance();
            if (instance == null)
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new Form_main());
            }
            else
            {
                MessageBox.Show("已经运行了");
                HandleRunningInstance(instance);
            }

            /******************************************** 让程序以管理员身份运行 *********************************************/
            ////当前用户是管理员的时候，直接启动应用程序;如果不是管理员，则使用启动对象启动程序，以确保使用管理员身份运行
            ////获得当前登录的Windows用户标示
            //System.Security.Principal.WindowsIdentity identity = System.Security.Principal.WindowsIdentity.GetCurrent();
            //System.Security.Principal.WindowsPrincipal principal = new System.Security.Principal.WindowsPrincipal(identity);
            ////判断当前登录用户是否为管理员,如果是管理员，则直接运行
            //if (principal.IsInRole(System.Security.Principal.WindowsBuiltInRole.Administrator))
            //{
            //    Application.Run(new Form_main());
            //}
            //else
            //{
            //    //创建启动对象
            //    System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
            //    startInfo.UseShellExecute = true;
            //    startInfo.WorkingDirectory = Environment.CurrentDirectory;
            //    startInfo.FileName = Application.ExecutablePath;
            //    //设置启动动作,确保以管理员身份运行
            //    startInfo.Verb = "runas";
            //    try
            //    {
            //        System.Diagnostics.Process.Start(startInfo);
            //    }
            //    catch
            //    {
            //        return;
            //    }
            //}

        }

        #region 防止重复运行
        public static Process RunningInstance()
        {
    
            Process current = Process.GetCurrentProcess();
            Process[] processes = Process.GetProcessesByName(current.ProcessName);
            foreach (Process process in processes)
            {
                if (process.Id != current.Id)
                {
                    if (Assembly.GetExecutingAssembly().Location.Replace("/", "\\") == current.MainModule.FileName)
                    {
                        return process;
                    }
                }
            }
            return null;
        }
        public static void HandleRunningInstance(Process instance)
        {
            ShowWindowAsync(instance.MainWindowHandle, WS_SHOWNORMAL);
            SetForegroundWindow(instance.MainWindowHandle);
        }
        [DllImport("User32.dll")]
        private static extern bool ShowWindowAsync(IntPtr hWnd, int cmdShow);
        [DllImport("User32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);
        private const int WS_SHOWNORMAL = 1; 
        #endregion
    }
}
