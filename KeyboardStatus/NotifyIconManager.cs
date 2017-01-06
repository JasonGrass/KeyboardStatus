using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AdrHook;
using KeyboardStatus.Properties;

namespace KeyboardStatus
{
    static class NotifyIconManager
    {
        private static NotifyIcon notifyCaps;
        private static NotifyIcon notifyNum;

        private static MainForm mainForm;

        public static void InitNotifyIcon()
        {
            OptionSet.Option.ReadOption(out Param.ShowCapsLockIcon, out Param.ShowNumberLockIcon, out Param.StartWithSys);

            HookManager.KeyDown += HookManagerOnKeyDown;

            if (Param.ShowCapsLockIcon)
            {
                notifyCaps = new NotifyIcon();
                SetCapslockStatus(true);
            }

            if (Param.ShowNumberLockIcon)
            {
                notifyNum = new NotifyIcon();
                SetNumberLockStatus(true);
            }

            SetNotifyIcon();

        }

        private static void HookManagerOnKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.CapsLock)
            {
                SetCapslockStatus();
            }
            else if (e.KeyCode == Keys.NumLock)
            {
                SetNumberLockStatus();
            }
        }

        // 初始化 ICON
        private static void SetNotifyIcon()
        {

            EventHandler handlerAbout = OnNotifyIconAboutClick;
            EventHandler handlerOption = OnNotifyIconOptionClick;
            EventHandler handlerExit = OnNotifyIconExitClick;

            ContextMenu notifyMenu = new ContextMenu();
            MenuItem itemOption = new MenuItem("Option", handlerOption);
            MenuItem itemAbout = new MenuItem("About", handlerAbout);
            MenuItem itemExit = new MenuItem("Exit", handlerExit);
            notifyMenu.MenuItems.AddRange(new[] { itemOption, itemAbout, itemExit });

            notifyCaps.ContextMenu = notifyMenu;
            notifyNum.ContextMenu = notifyMenu;

            notifyCaps.MouseDoubleClick += NotifySetOnMouseClick;
            notifyNum.MouseDoubleClick += NotifySetOnMouseClick;

        }

        // 双击 设置
        private static void NotifySetOnMouseClick(object sender, MouseEventArgs mouseEventArgs)
        {
            if (mouseEventArgs.Button == MouseButtons.Left)
            {
                ShowMainForm();
            }
        }

        // 设置
        private static void OnNotifyIconOptionClick(object sender, EventArgs e)
        {
            ShowMainForm();
        }

        // 退出程序
        private static void OnNotifyIconExitClick(object sender, EventArgs e)
        {
            notifyCaps.Visible = false;
            notifyNum.Visible = false;
            if (mainForm != null)
            {
                mainForm.Close();
                mainForm.Dispose();
            }
            Application.Exit();
        }

        // 显示主窗体
        private static void ShowMainForm()
        {
            if (mainForm == null)
            {
                mainForm = new MainForm();
            }
            mainForm.Show();
            mainForm.WindowState = FormWindowState.Normal;
        }

        // About 
        private static void OnNotifyIconAboutClick(object sender, EventArgs eventArgs)
        {
            FormAbout about = new FormAbout();
            about.ShowDialog();
        }

        /// <summary>
        /// 设置大小写显示状态；
        /// 参数表示是否为特殊情况(初始化，显示灯)，实验发现，这些情况下，键盘状态的获取是相反的；
        /// 非特殊情况即是按键盘Capslock引发的情况
        /// </summary>
        /// <param name="special">表示是否为特殊情况</param>
        public static void SetCapslockStatus(bool special = false)
        {
            bool status = special ? KeyStatus.CapsLockStatus : !KeyStatus.CapsLockStatus;
            Icon notifyIcon = status ?
                Resources.A_16px_1168287_easyicon_net :
                Resources.a_lowercase_16px_1168286_easyicon_net;
            notifyCaps.Icon = notifyIcon;
            notifyCaps.Visible = Param.ShowCapsLockIcon;
        }

        /// <summary>
        /// 设置大小写显示状态；
        /// 参数表示是否为特殊情况(初始化，显示灯)，实验发现，这些情况下，键盘状态的获取是相反的；
        /// 非特殊情况即是按键盘NumLock引发的情况
        /// </summary>
        /// <param name="special">表示是否为特殊情况</param>
        public static void SetNumberLockStatus(bool special = false)
        {
            bool status = special ? KeyStatus.NumLockStatus : !KeyStatus.NumLockStatus;
            Icon notifyIcon = status ?
                Resources._5_16px_1168277_easyicon_net :
                Resources._4_direction_16px_1074524_easyicon_net;
            notifyNum.Icon = notifyIcon;
            notifyNum.Visible = Param.ShowNumberLockIcon;
        }

    }
}
