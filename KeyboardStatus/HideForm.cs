using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using AdrHook;

namespace KeyboardStatus
{
    public partial class HideForm : Form
    {
        

        public HideForm()
        {
            InitializeComponent();
            NotifyIconManager.InitNotifyIcon();
        }

        // 隐藏窗体
        protected override CreateParams CreateParams
        {
            get
            {
                Hide();
                return base.CreateParams;
            }
        }


    }
}
