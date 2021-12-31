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
        frmSegmenstMap segmantsMapForm;
        internal Meter oblik;
        internal OblikSerialDriver oblikDriver;

        /// <summary>
        /// статус соединения
        /// </summary>
        internal enum ConnectionStatus
        {
            OK,
            Wait,
            Error,
        }
        
   
        public frmMain()
        {
            InitializeComponent();
            tmrTimer.Interval = 1000;
        }

        #region Служебные методы

        /// <summary>
        /// Инициализация при подключении
        /// </summary>
        internal void Connect()
        {
            connectionForm.Close();
            oblikDriver = new OblikSerialDriver(Settings.currentConnection);
            oblik = new Meter(oblikDriver);

            UpdateInfo();
        }

        /// <summary>
        /// Соединение с проверкой ошибок
        /// </summary>
        /// <param name="segment">Сегмент</param>
        public bool SafeConnect(Action action)
        {

            int repeats = Settings.currentConnection.Repeats;
            bool status = false;
            while ((repeats > 0) && !status)
            {
                try
                {
                    SetConnectionStatus(ConnectionStatus.Wait);
                    action.Invoke();
                    SetConnectionStatus(ConnectionStatus.OK);
                    status = true;
                }
                catch (OblikIOException ex)
                {
                    status = false;
                    SetConnectionStatus(ConnectionStatus.Error);
                    repeats--;
                    if (repeats == 0)
                    {
                        AddLog(ex.Message);
                        //Отключение автообновления текущих показаний
                        chbAutoUpdate.Checked = false;
                        tmrTimer.Enabled = false;
                    }
                }
            }
            return status;
        }

        /// <summary>
        /// Индикация состояния подключения
        /// </summary>
        internal void SetConnectionStatus(ConnectionStatus status)
        {
            switch (status)
            {
                case ConnectionStatus.OK:
                    lblStatus.Text = "OK";
                    lblStatus.BackColor = Color.LimeGreen;
                    break;
                case ConnectionStatus.Wait:
                    lblStatus.Text = "Ожидание...";
                    lblStatus.BackColor = Color.Yellow;
                    break;
                case ConnectionStatus.Error:
                    lblStatus.Text = "Ошибка!";
                    lblStatus.BackColor = Color.Red;
                    break;
                default:
                    lblStatus.Text = "??????";
                    lblStatus.BackColor = Color.DarkOrange;
                    break;
            }
        }

        /// <summary>
        /// Полчение информации о счетчике
        /// </summary>
        internal void UpdateInfo()
        {
            if (!SafeConnect(oblik.ReadGeneralInfo))
            {
                return;
            }

            lblFW.Text = $"{oblik.Firmware.Version}.{oblik.Firmware.Build}";
            lblPort.Text = Settings.currentConnection.Port;
            lblAddress.Text = oblik.MeterNetwork.Addr.ToString();
            lblProtocol.Text = (Settings.currentConnection.Address == 0) ? "RS-232" : "RS-485";
            lblBaudrate.Text = oblik.MeterNetwork.Speed.ToString();

            lblDayGraphRecs.Text = oblik.DayGraphRecords.NumberOfRecords.ToString();
            lblEventLogRecs.Text = oblik.EventRecords.NumberOfRecords.ToString();

            UpdateCurrentValues();
        }

        /// <summary>
        /// Обновление текущих показаний
        /// </summary>
        internal void UpdateCurrentValues()
        {

            if (!SafeConnect(oblik.CurrentVals.Read))
            {
                return;
            }

            float Ua = oblik.CurrentVals.Volt1;
            float Ub = oblik.CurrentVals.Volt2;
            float Uc = oblik.CurrentVals.Volt3;
            float Ia = oblik.CurrentVals.Curr1;
            float Ib = oblik.CurrentVals.Curr2;
            float Ic = oblik.CurrentVals.Curr3;
            float freq = oblik.CurrentVals.Freq;
            float P = oblik.CurrentVals.Act_pw;
            float Q = oblik.CurrentVals.Rea_pw;

            float angle = (float)Math.Atan(Q / P);
            float sig = Math.Sign(angle);
            float cos = (float)Math.Cos(angle);
            if (sig == -1)
            {
                lblCos.Text = String.Format("{0:f4}", cos) + "(C)";
            }
            else
            {
                lblCos.Text = String.Format("{0:f4}", cos) + "(L)";
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

        /// <summary>
        /// Добавить запись в лог
        /// </summary>
        /// <param name="message">Сообщение</param>
        internal void AddLog(string message)
        {
            DateTime currentTime = DateTime.Now;
            rtbLog.AppendText($"{currentTime} : {message} \n");
        }
        #endregion

        /*-------------------------Обработчики событий-----------------------------*/

        private void frmMain_Shown(object sender, EventArgs e)
        {
            connectionForm = new frmConnect(this);
            connectionForm.Show();
            connectionForm.BringToFront();
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

        private void btnUpdateInfo_Click(object sender, EventArgs e)
        {
            UpdateCurrentValues();
        }

        private void картаСегментовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            segmantsMapForm = new frmSegmenstMap(this, oblik);
            segmantsMapForm.Show();
            segmantsMapForm.BringToFront();
        }


        private void соединениеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            connectionForm = new frmConnect(this);
            connectionForm.Show();
            connectionForm.BringToFront();
        }
    }
}
