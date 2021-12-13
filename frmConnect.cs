using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using Oblik;

namespace OblikConfigurator
{
    public partial class frmConnect : Form
    {
        internal string port;
        internal frmMain mainForm;
        public frmConnect()
        {
            InitializeComponent();
            ScanPorts();
            numAddr.Value = 0;
            Settings.Initialize();
            foreach (int br in Settings.baudrates)
            {
                cbBaudrate.Items.Add(br.ToString());
            }

            cbBaudrate.Text = Settings.currentConnection.Baudrate.ToString();
            nTimeout.Value = Settings.currentConnection.Timeout;
            nRepeats.Value = Settings.currentConnection.Repeats;
            cbAccess.SelectedIndex = (int)Settings.currentConnection.User;
            tbPassword.Text = Settings.currentConnection.Password;
        }

        private void cbPort_SelectedIndexChanged(object sender, EventArgs e)
        {
            port = cbPort.SelectedText;
        }

        private void ScanPorts()
        {
            btnConnect.Enabled = true;
            cbPort.Enabled = true;
            string[] ports = SerialPort.GetPortNames();
            foreach (string port in ports)
            {
                cbPort.Items.Add(port);
            }
            try
            {
                cbPort.Text = ports[0];
            }
            catch (IndexOutOfRangeException)
            {
                //Доступных портов не обнаружено
                cbPort.Enabled = false;
                btnConnect.Enabled = false;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cbBaudrate_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            Settings.currentConnection.Baudrate = Settings.baudrates[cbBaudrate.SelectedIndex];           
        }

        private void nTimeout_ValueChanged(object sender, EventArgs e)
        {
            Settings.currentConnection.Timeout = (int)nTimeout.Value;
        }

        private void nRepeats_ValueChanged(object sender, EventArgs e)
        {
            Settings.currentConnection.Repeats = (int)nRepeats.Value;
        }

        private void cbAccess_SelectedIndexChanged(object sender, EventArgs e)
        {
            Settings.currentConnection.User = (UserLevel)cbAccess.SelectedIndex;
        }

        private void tbPassword_TextChanged(object sender, EventArgs e)
        {
            Settings.currentConnection.Password = tbPassword.Text;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Hide();
            mainForm = new frmMain();
            mainForm.Show();

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ScanPorts();
        }
    }
}
