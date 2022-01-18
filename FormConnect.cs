using Oblik;
using Oblik.Driver;
using System;
using System.IO.Ports;
using System.Windows.Forms;

namespace OblikConfigurator
{
    public partial class FormConnect : Form
    {
        private readonly SerialConnectionParams serialConnectionParams;
        private readonly FormMain MainForm;

        public FormConnect(FormMain MainForm)
        {
            this.MainForm = MainForm;
            this.MainForm.Visible = false;
            InitializeComponent();

            //Соединение через COM-порт
            serialConnectionParams = new SerialConnectionParams();
            foreach (int br in Settings.baudrates)
            {
                BaudrateCombobox.Items.Add(br.ToString());
            }
            ScanPorts();
            Prot485Radiobutton.Select();
            BaudrateCombobox.Text = Settings.connectionParams.Baudrate.ToString();
            TimeoutNumeric.Value = Settings.connectionParams.Timeout;
            RepeatsNumeric.Value = Settings.Repeats;
            AddressNumeric.Value = Settings.connectionParams.Address;

            //Настройки соединения
            AccessCombobox.SelectedIndex = (int)Settings.connectionParams.User;
            PasswordTextbox.Text = Settings.connectionParams.Password;
        }

        //Сканирование доступных портов
        private void ScanPorts()
        {
            ConnectButton.Enabled = true;
            PortCombobox.Enabled = true;
            PortCombobox.Items.Clear(); //Очистка старого списка

            string[] ports = SerialPort.GetPortNames();
            foreach (string port in ports)
            {
                PortCombobox.Items.Add(port);
            }
            try
            {
                PortCombobox.Text = ports[0];
            }
            catch (IndexOutOfRangeException)
            {
                //Доступных портов не обнаружено
                PortCombobox.Enabled = false;
                ConnectButton.Enabled = false;
                MessageBox.Show("Доступных портов не обнаружено!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
            MainForm.Visible = true;
        }

        //Сохранение настроек
        private void btnOK_Click(object sender, EventArgs e)
        {
            switch (ConnectTabControl.SelectedIndex)
            {
                case 0:
                    //Выбрано соединение через COM-порт
                    Settings.connectionParams.Address = (byte)AddressNumeric.Value;
                    Settings.Repeats = (int)RepeatsNumeric.Value;
                    Settings.connectionParams.User = (UserLevel)AccessCombobox.SelectedIndex;
                    Settings.connectionParams.Password = PasswordTextbox.Text;
                    Settings.connectionParams.Baudrate = Settings.baudrates[BaudrateCombobox.SelectedIndex];
                    Settings.connectionParams.Timeout = (int)TimeoutNumeric.Value;

                    serialConnectionParams.Port = PortCombobox.SelectedItem.ToString();
                    Settings.oblikDriver = new OblikSerialDriver(serialConnectionParams);
                    Settings.Oblik = new Meter(Settings.oblikDriver, Settings.connectionParams);
                    Settings.isConnected = true;
                    Close();
                    MainForm.Connect();
                    break;

                default: break;
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            ScanPorts();
        }

        private void rb485_CheckedChanged(object sender, EventArgs e)
        {
            serialConnectionParams.IsDirectConnected = false;
            AddressNumeric.Enabled = true;
        }

        private void rb232_CheckedChanged(object sender, EventArgs e)
        {
            serialConnectionParams.IsDirectConnected = true;
            AddressNumeric.Enabled = false;
        }
    }
}