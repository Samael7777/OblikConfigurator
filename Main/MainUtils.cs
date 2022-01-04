using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oblik;
using Oblik.Driver;

namespace OblikConfigurator
{
    public partial class frmMain : Form
    {
        /// <summary>
        /// Управление состоянием кнопок
        /// </summary>
        /// <param name="status">Состояние вкл/выкл</param>
        internal void SetButtonsStatus(bool status)
        {
            foreach (Button btn in buttons)
            {
                btn.Enabled = status;
            }
        }
        /// <summary>
        /// Надписи по умолчанию
        /// </summary>
        internal void Default()
        {
            lblAddress.Text = "------";
            lblBaudrate.Text = "------";
            lblCos.Text = "------";
            lblCurrTime.Text = "------";
            lblDayGraphRecs.Text = "------";
            lblEventLogRecs.Text = "------";
            lblFreq.Text = "------";
            lblFW.Text = "------";
            lblIa.Text = "------";
            lblIb.Text = "------";
            lblIc.Text = "------";
            lblMeterTime.Text = "------";
            lblP.Text = "------";
            lblPort.Text = "------";
            lblProtocol.Text = "------";
            lblQ.Text = "------";
            lblUa.Text = "------";
            lblUb.Text = "------";
            lblUc.Text = "------";
            for (int i = 0; i < 8; i++)
            {
                channels[i].Text = "--";
            }

        }
        /// <summary>
        /// Инициализация при подключении
        /// </summary>
        internal void Connect()
        {
            Default();
            connectionForm.Close();
            if (Settings.isConnected)
            {
                SetButtonsStatus(true);
                oblikDriver = new OblikSerialDriver(Settings.currentConnection);
                oblik = new Meter(oblikDriver);
                UpdateFirmwareInfo();
                UpdateNetwokConfig();
                UpdateGeneralInfo();
            }           
        }

        /// <summary>
        /// Обновление текущей информации
        /// </summary>
        internal void UpdateGeneralInfo()
        {
            UpdateLogs();
            UpdateCurrentValues();
            UpdateTime();
        }

        /// <summary>
        /// Соединение с проверкой ошибок
        /// </summary>
        internal bool SafeConnect(Action action)
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
                    if (ex.ErrorCode == Error.OpenPortError)
                    {
                        repeats = 0;
                    }
                    else
                    {
                        repeats--;
                    }
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
        /// Полчение информации о прошивке счетчика
        /// </summary>
        internal void UpdateFirmwareInfo()
        {
            if (SafeConnect(oblik.Firmware.Read))
            {
                lblFW.Text = $"{oblik.Firmware.Version}.{oblik.Firmware.Build}";
            }

        }

        /// <summary>
        /// Обновление счетчиков записей журналов
        /// </summary>
        internal void UpdateLogs()
        {
            if (SafeConnect(oblik.EventRecords.ReadRecords)
                && SafeConnect(oblik.DayGraphRecords.ReadRecords))
            {
                lblDayGraphRecs.Text = oblik.DayGraphRecords.NumberOfRecords.ToString();
                lblEventLogRecs.Text = oblik.EventRecords.NumberOfRecords.ToString();
            }
        }

        /// <summary>
        /// Обновление настроек сети счетчика
        /// </summary>
        internal void UpdateNetwokConfig()
        {
            if (SafeConnect(oblik.MeterNetwork.Read))
            {
                lblPort.Text = Settings.currentConnection.Port;
                lblAddress.Text = oblik.MeterNetwork.Addr.ToString();
                lblProtocol.Text = (Settings.currentConnection.Address == 0) ? "RS-232" : "RS-485";
                lblBaudrate.Text = oblik.MeterNetwork.Speed.ToString();
            }
        }

        /// <summary>
        /// Обновить значения времени
        /// </summary>
        internal void UpdateTime()
        {
            SafeConnect(() => { lblMeterTime.Text = string.Format("{0:T}", oblik.MeterTime.Time); });
            lblCurrTime.Text = string.Format("{0:T}", DateTime.Now);
        }

        /// <summary>
        /// Обновление текущих показаний
        /// </summary>
        internal void UpdateCurrentValues()
        {
            if (SafeConnect(oblik.CurrentVals.Read) && SafeConnect(oblik.MinuteVals.Read))
            {
                float P = oblik.CurrentVals.Act_pw;
                float Q = oblik.CurrentVals.Rea_pw;
                float angle = (float)Math.Atan(Q / P);
                float sig = Math.Sign(angle);
                float cos = (float)Math.Cos(angle);
                if (sig == -1)
                {
                    lblCos.Text = string.Format("{0:f4}", cos) + "(C)";
                }
                else
                {
                    lblCos.Text = string.Format("{0:f4}", cos) + "(L)";
                }
                lblUa.Text = string.Format("{0:f4}", oblik.CurrentVals.Volt1);
                lblUb.Text = string.Format("{0:f4}", oblik.CurrentVals.Volt2);
                lblUc.Text = string.Format("{0:f4}", oblik.CurrentVals.Volt3);
                lblIa.Text = string.Format("{0:f4}", oblik.CurrentVals.Curr1);
                lblIb.Text = string.Format("{0:f4}", oblik.CurrentVals.Curr2);
                lblIc.Text = string.Format("{0:f4}", oblik.CurrentVals.Curr3);
                lblFreq.Text = string.Format("{0:f4}", oblik.CurrentVals.Freq);
                lblP.Text = string.Format("{0:f4}", P);
                lblQ.Text = string.Format("{0:f4}", Q);

                //Импульсные каналы
                for (int i = 0; i < 8; i++)
                {
                    channels[i].Text = oblik.MinuteVals.channel[i].ToString();
                }
            }
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

    }
}
