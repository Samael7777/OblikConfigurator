using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;

namespace OblikConfigurator
{
    public partial class frmConnect : Form
    {
        internal string port;
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

        }

        private void cbPort_SelectedIndexChanged(object sender, EventArgs e)
        {
            port = cbPort.SelectedText;
        }

        private void ScanPorts()
        {
            string[] ports = SerialPort.GetPortNames();
            foreach (string port in ports)
            {
                cbPort.Items.Add(port);
            }
            cbPort.Text = ports[0];
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cbBaudrate_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            Settings.currentConnection.Baudrate = Settings.baudrates[cbBaudrate.SelectedIndex];           
        }
    }
}
