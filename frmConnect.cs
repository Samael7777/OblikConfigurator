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
        internal frmMain mainForm;
        public frmConnect(frmMain sender)
        {
            mainForm = sender;
            InitializeComponent();
            ScanPorts();
            rb485.Select();
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
            numAddr.Value = Settings.currentConnection.Address;
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
                MessageBox.Show("Доступных портов не обнаружено!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }     

        private void btnOK_Click(object sender, EventArgs e)
        {
            switch (Settings.protocol)
            {
                case Settings.Protocol.RS232:
                    Settings.currentConnection.Address = 0;
                    Settings.currentConnection.Baudrate = 9600;
                    break;
                case Settings.Protocol.RS485:
                    Settings.currentConnection.Baudrate = Settings.baudrates[cbBaudrate.SelectedIndex];
                    Settings.currentConnection.Address = (byte)numAddr.Value;
                    break;
                default:
                    break;
            }
            Settings.currentConnection.Port = cbPort.SelectedItem.ToString();
            Settings.currentConnection.Timeout = (int)nTimeout.Value;
            Settings.currentConnection.Repeats = (int)nRepeats.Value;
            Settings.currentConnection.User = (UserLevel)cbAccess.SelectedIndex;
            Settings.currentConnection.Password = tbPassword.Text;
            Settings.isConnected = true;
            mainForm.Connect();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ScanPorts();
        }

        private void rb485_CheckedChanged(object sender, EventArgs e)
        {
            Settings.protocol = Settings.Protocol.RS485;
            numAddr.Enabled = true;
            cbPort.Enabled = true;
        }

        private void rb232_CheckedChanged(object sender, EventArgs e)
        {
            Settings.protocol = Settings.Protocol.RS232;
            numAddr.Enabled = false;
            cbPort.Enabled = false;
        }
    }
}
