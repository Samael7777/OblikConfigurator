using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Oblik;

namespace OblikConfigurator
{
    public partial class FormNetConfig : Form
    {
        readonly FormMain mainForm;

        public FormNetConfig(FormMain form, NetworkConfig currentConfig)
        {
            InitializeComponent();

            mainForm = form;

            foreach (int item in Settings.baudrates)
            {
                BaudrateCombobox.Items.Add(item);
            }
            BaudrateCombobox.Text = currentConfig.Baudrate.ToString();
            AddressNumeric.Value = currentConfig.Address;
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            NetworkConfig netconfig = default;
            netconfig.Address = (int)AddressNumeric.Value;
            netconfig.Baudrate = Settings.baudrates[BaudrateCombobox.SelectedIndex];
            mainForm.SaveNetworkConfig(netconfig);
            Close();
        }
    }
}
