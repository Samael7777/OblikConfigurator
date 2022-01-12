﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO.Ports;
using Oblik;
using Oblik.Driver;

namespace OblikConfigurator
{
    public partial class ConnectForm : Form
    {
        private readonly SerialConnectionParams serialConnectionParams;
        private readonly MainForm MainForm;

        public ConnectForm(MainForm MainForm)
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
            PortCombobox.Enabled = true;
        }

        private void rb232_CheckedChanged(object sender, EventArgs e)
        {
            serialConnectionParams.IsDirectConnected = true;
            AddressNumeric.Enabled = false;
            PortCombobox.Enabled = false;
        }
    }
}
