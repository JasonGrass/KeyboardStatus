using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace KeyboardStatus
{
    public partial class FormAbout : Form
    {
        public FormAbout()
        {
            InitializeComponent();           
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/JasonGrass/KeyboardStatus");  
        }
    }
}
