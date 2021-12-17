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
    public partial class frmMain : Form
    {
        frmConnect connectionForm;

        FirmwareInfo firmwareInfo;
        CurrentValues currentValues;
        MinuteValues minuteValues;
        DayGraph dayGraph;
        EventLog eventLog;
        NetworkConfig networkConfig;

        public frmMain()
        {
            InitializeComponent();          
        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
            connectionForm = new frmConnect(this);
            connectionForm.Show();
            connectionForm.BringToFront();
        }
        //Инициализация при подключении
        internal void Connect()
        {
            connectionForm.Close();
            firmwareInfo = new FirmwareInfo(Settings.currentConnection);         
            currentValues = new CurrentValues(Settings.currentConnection);
            minuteValues = new MinuteValues(Settings.currentConnection);
            dayGraph = new DayGraph(Settings.currentConnection);
            eventLog = new EventLog(Settings.currentConnection);
            networkConfig = new NetworkConfig(Settings.currentConnection);

            UpdateInfo();
        }
        //Полчение информации о счетчике
        internal void UpdateInfo()
        {
            firmwareInfo.Read();
            networkConfig.Read();
            lblFW.Text = $"{firmwareInfo.Version}.{firmwareInfo.Build}";
            lblPort.Text = Settings.currentConnection.Port;
            lblAddress.Text = networkConfig.Addr.ToString();
            lblProtocol.Text = (Settings.currentConnection.Address == 0) ? "RS-232" : "RS-485";
            lblBaudrate.Text = networkConfig.Speed.ToString();

            UpdateCurrentValues();
        }
        //Обновление текущих показаний
        internal void UpdateCurrentValues()
        {
            currentValues.Read();
            lblFreq.Text = currentValues.Freq.ToString();
            lblUa.Text = currentValues.Volt1.ToString();

        }

        //Индикация состояния подключения
        internal void SetStatus(bool status)
        {
            if (status)
            {
                lblStatus.Text = "OK";
                lblStatus.BackColor = Color.LimeGreen;
            }
            else
            {
                lblStatus.Text = "Ошибка";
                lblStatus.BackColor = Color.Red;
            }
        }

        private void btnNetConfig_Click(object sender, EventArgs e)
        {

        }
    }
}
