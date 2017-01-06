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
        
        public MainForm()
        {
            InitializeComponent();
            InitForm();
        }

        private void InitForm()
        {
            //this.ShowInTaskbar = false;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            this.Shown += (sender, args) =>
            {
                cbShowCapslock.Checked = Param.ShowCapsLockIcon;
                cbShowNumberLock.Checked = Param.ShowNumberLockIcon;
                cbStartWithSystem.Checked = Param.StartWithSys;

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

        private void cbStartWithSystem_CheckedChanged(object sender, EventArgs e)
        {
            Param.StartWithSys = cbStartWithSystem.Checked;
            OptionSet.Option.SaveStartWithSysOption(Param.StartWithSys);
        }

        private void cbShowCapslock_CheckedChanged(object sender, EventArgs e)
        {
            Param.ShowCapsLockIcon = cbShowCapslock.Checked;
            OptionSet.Option.SaveCapslockOption(Param.ShowCapsLockIcon);
            NotifyIconManager.SetCapslockStatus(true);
        }

        private void cbShowNumberLock_CheckedChanged(object sender, EventArgs e)
        {
            Param.ShowNumberLockIcon = cbShowNumberLock.Checked;
            OptionSet.Option.SaveNumlockOption(Param.ShowNumberLockIcon);
            NotifyIconManager.SetNumberLockStatus(true);
        }

        private void btnOpenFileDir_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("Explorer.exe", Application.ExecutablePath);
        }
    }
}
