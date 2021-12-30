using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Oblik;
using Oblik.Driver;


namespace OblikConfigurator
{
    public partial class frmMain : Form
    {
        frmConnect connectionForm;
        internal Meter oblik;
        internal OblikSerialDriver oblikDriver;
        
   
        public frmMain()
        {
            InitializeComponent();
            tmrTimer.Interval = 1000;
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
            oblikDriver = new OblikSerialDriver(Settings.currentConnection);
            oblik = new Meter(oblikDriver);

            UpdateInfo();
        }
        //Полчение информации о счетчике
        internal void UpdateInfo()
        {
            oblik.ReadGeneralInfo();

            lblFW.Text = $"{oblik.Firmware.Version}.{oblik.Firmware.Build}";
            lblPort.Text = Settings.currentConnection.Port;
            lblAddress.Text = oblik.MeterNetwork.Addr.ToString();
            lblProtocol.Text = (Settings.currentConnection.Address == 0) ? "RS-232" : "RS-485";
            lblBaudrate.Text = oblik.MeterNetwork.Speed.ToString();

            lblDayGraphRecs.Text = oblik.DayGraphRecords.NumberOfRecords.ToString();
            lblEventLogRecs.Text = oblik.EventRecords.NumberOfRecords.ToString();

            UpdateCurrentValues();
        }
        //Обновление текущих показаний
        internal void UpdateCurrentValues()
        {
            float Ua, Ub, Uc, Ia, Ib, Ic, freq, cos, P, Q, sig, angle;
            oblik.CurrentVals.Read();
            Ua = oblik.CurrentVals.Volt1;
            Ub = oblik.CurrentVals.Volt2;
            Uc = oblik.CurrentVals.Volt3;
            Ia = oblik.CurrentVals.Curr1;
            Ib = oblik.CurrentVals.Curr2;
            Ic = oblik.CurrentVals.Curr3;
            freq = oblik.CurrentVals.Freq;
            P = oblik.CurrentVals.Act_pw;
            Q = oblik.CurrentVals.Rea_pw;
            
            angle = (float)Math.Atan(Q / P);
            sig = Math.Sign(angle);
            cos = (float)Math.Cos(angle);
            if (sig == -1)
            {
                lblCos.Text = String.Format("{0:f3}", cos) + "(C)";
            }
            else
            {
                lblCos.Text = String.Format("{0:f3}", cos) + "(L)";
            }
            lblUa.Text = String.Format("{0:f4}", Ua);
            lblUb.Text = String.Format("{0:f4}", Ub);
            lblUc.Text = String.Format("{0:f4}", Uc);
            lblIa.Text = String.Format("{0:f4}", Ia);
            lblIb.Text = String.Format("{0:f4}", Ib);
            lblIc.Text = String.Format("{0:f4}", Ic);
            lblFreq.Text = String.Format("{0:f4}", freq);
            lblP.Text = String.Format("{0:f4}", P);
            lblQ.Text = String.Format("{0:f4}", Q);

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

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void chbAutoUpdate_CheckedChanged(object sender, EventArgs e)
        {
            tmrTimer.Enabled = chbAutoUpdate.Checked;
        }

        private void tmrTimer_Tick(object sender, EventArgs e)
        {
            UpdateCurrentValues();
        }
    }
}
