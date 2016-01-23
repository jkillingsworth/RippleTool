﻿using System;
using WeifenLuo.WinFormsUI.Docking;

namespace RippleTool.UI
{
    public partial class PingForm : DockContent
    {
        public PingForm()
        {
            InitializeComponent();
        }

        private void buttonSubmit_Click(object sender, EventArgs e)
        {
            var command = CommandTypes.Command.NewPing(null);
            Integration.agentCommandExecution.Post(command);
        }
    }
}
