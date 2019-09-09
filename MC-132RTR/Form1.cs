using MC_132RTR.Controller.Middleman;
using MC_132RTR.Model.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MC_132RTR
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            InitializeGui();
        }

        public void InitializeGui()
        {
            PowerButton.Text = "POWER OFF";
            StartButton.Text = "START UP";

            DeviceRouterComboBOx.Items.Clear();
            RipDeviceComboBox.Items.Clear();

            foreach (Device Dev in Middleman.InitializeRouter())
            {
                Model.Support.Logging.OutALWAYS(Dev.ICapDev.Description);
                Model.Support.Logging.OutALWAYS(Dev.GetDescription(false));
                Model.Support.Logging.OutALWAYS(Dev.GetDescription(true));

                //DeviceRouterComboBOx.Items.Add(Dev.GetDescription(true));
            }
        }

        private void PowerButton_Click(object sender, EventArgs e)
        {

        }

        private void StartButton_Click(object sender, EventArgs e)
        {

        }

        private void ActivateDevButton_Click(object sender, EventArgs e)
        {

        }

        private void DeactivateDevButton_Click(object sender, EventArgs e)
        {

        }

        private void RipActivateButton_Click(object sender, EventArgs e)
        {

        }

        private void RipDeactivateButton_Click(object sender, EventArgs e)
        {

        }
    }
}
