using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace KeyboardStatus
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            //获取欲启动进程名  
            string strProcessName = System.Diagnostics.Process.GetCurrentProcess().ProcessName;
            ////获取版本号  
            //CommonData.VersionNumber = Application.ProductVersion;  
            //检查进程是否已经启动，已经启动则显示报错信息退出程序。  
            if (System.Diagnostics.Process.GetProcessesByName(strProcessName).Length > 1)
            {
                System.Environment.Exit(1);
            }

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new HideForm());
        }
    }
}
