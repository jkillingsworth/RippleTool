﻿using System;
using System.Windows.Forms;
using WeifenLuo.WinFormsUI.Docking;

namespace RippleTool.UI
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            statusItemServerUri.Text = Integration.configServerUri;
        }

        private void Show(DockContent dockContent)
        {
            dockContent.Show(dockPanel);
        }

        private void menuItemFileExit_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void menuItemViewResponse_Click(object sender, EventArgs e)
        {
            Show(new ResponseForm());
        }

        private void menuItemViewPing_Click(object sender, EventArgs e)
        {
            Show(new PingForm());
        }

        private void menuItemViewRandom_Click(object sender, EventArgs e)
        {
            Show(new RandomForm());
        }
    }
}