using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Resources;
using System.Text;
using System.Windows.Forms;
using KeyboardStatus.Properties;
using Microsoft.Win32;
using AdrHook;

namespace KeyboardStatus
{
    public partial class MainForm : Form
    {

        private bool showCapsLockIcon = true;
        private bool showNumberLockIcon = true;
        private bool startWithSys = false;

        private NotifyIcon notifyCaps;
        private NotifyIcon notifyNum;

        public MainForm()
        {
            InitializeComponent();
            InitForm();
            InitNotifyIcon();
        }

        private void InitForm()
        {
            this.ShowInTaskbar = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            this.Load += (sender, args) =>
            {
                this.WindowState = FormWindowState.Minimized;
            };
            this.Shown += (sender, args) =>
            {
                this.Hide();
                OptionSet.Option.ReadOption(out showCapsLockIcon, out showNumberLockIcon, out startWithSys);
                cbShowCapslock.Checked = showCapsLockIcon;
                cbShowNumberLock.Checked = showNumberLockIcon;
                cbStartWithSystem.Checked = startWithSys;

                gbSet.Enabled = OptionSet.IsAdministrator();
                if (gbSet.Enabled)
                {
                    labelTip.Text = "以上为当前设置；";
                }
                else
                {
                    labelTip.Text = "以上为默认设置；";
                }
            };

            this.Closing += (sender, args) =>
            {
                this.Hide();
                args.Cancel = true;
            };
        }

        private void InitNotifyIcon()
        {
            HookManager.KeyDown += HookManagerOnKeyDown;

            if (showCapsLockIcon)
            {
                notifyCaps = new NotifyIcon();
                SetCapslockStatus(true);
            }

            if (showNumberLockIcon)
            {
                notifyNum = new NotifyIcon();
                SetNumberLockStatus(true);
            }

            SetNotifyIcon();

        }

        private void HookManagerOnKeyDown(object sender, KeyEventArgs e)
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

        private void SetNotifyIcon()
        {
       
            EventHandler handlerAbout = OnNotifyIconAboutClick;
            EventHandler handlerOption = OnNotifyIconOptionClick;
            EventHandler handlerExit = OnNotifyIconExitClick;

            ContextMenuStrip notifyMenu = new ContextMenuStrip();
            notifyMenu.Items.Add(new ToolStripButton("About   ", null, handlerAbout));
            notifyMenu.Items.Add(new ToolStripButton("Option  ", null, handlerOption));
            notifyMenu.Items.Add(new ToolStripButton("Exit    ", null, handlerExit));

            notifyCaps.ContextMenuStrip = notifyMenu;
            notifyCaps.MouseDoubleClick += NotifySetOnMouseClick;
            notifyNum.ContextMenuStrip = notifyMenu;
            notifyNum.MouseDoubleClick += NotifySetOnMouseClick;
        }

        private void NotifySetOnMouseClick(object sender, MouseEventArgs mouseEventArgs)
        {
            if (mouseEventArgs.Button == MouseButtons.Left)
            {
                this.Show();
                this.WindowState = FormWindowState.Normal;              
            }
        }

        private void OnNotifyIconExitClick(object sender, EventArgs e)
        {
            notifyCaps.Visible = false;
            notifyNum.Visible = false;
            this.Close();
            this.Dispose();
            Application.Exit();
        }

        private void OnNotifyIconOptionClick(object sender, EventArgs e)
        {
            this.Show();
            this.WindowState = FormWindowState.Normal;
        }

        private void OnNotifyIconAboutClick(object sender, EventArgs eventArgs)
        {
            FormAbout about = new FormAbout();
            about.ShowDialog();
        }

        public void SetCapslockStatus(bool init = false)
        {
            bool status = init ? KeyStatus.CapsLockStatus : !KeyStatus.CapsLockStatus;
            Icon notifyIcon = status ? 
                Resources.A_16px_1168287_easyicon_net : 
                Resources.a_lowercase_16px_1168286_easyicon_net;
            notifyCaps.Icon = notifyIcon;
            notifyCaps.Visible = showCapsLockIcon;
        }

        public void SetNumberLockStatus(bool init = false)
        {
            bool status = init ? KeyStatus.NumLockStatus : !KeyStatus.NumLockStatus;
            Icon notifyIcon = status ?
                Resources._5_16px_1168277_easyicon_net :
                Resources._4_direction_16px_1074524_easyicon_net;
            notifyNum.Icon = notifyIcon;
            notifyNum.Visible = showNumberLockIcon;
        }

        private void cbStartWithSystem_CheckedChanged(object sender, EventArgs e)
        {
            startWithSys = cbStartWithSystem.Checked;
            OptionSet.Option.SaveStartWithSysOption(startWithSys);
        }

        private void cbShowCapslock_CheckedChanged(object sender, EventArgs e)
        {
            showCapsLockIcon = cbShowCapslock.Checked;
            OptionSet.Option.SaveCapslockOption(showCapsLockIcon);
            SetCapslockStatus(true);
        }

        private void cbShowNumberLock_CheckedChanged(object sender, EventArgs e)
        {
            showNumberLockIcon = cbShowNumberLock.Checked;
            OptionSet.Option.SaveNumlockOption(showNumberLockIcon);
            SetNumberLockStatus(true);
        }
    }
}
