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


namespace OblikConfigurator
{

    internal struct GeneralInfo
    {
        public CurrentValues CurrentValues;
        public MinuteValues MinuteValues;
        public DateTime MeterTime;
        public int DayGraphRecords;
        public int EventLogRecords;
    }

    public partial class MainForm : Form
    {
        ConnectForm connectionForm;
        SegmenstMapForm segmantsMapForm;
        Label[] channels;
        Control[] controls;
        Action action1, action2;

        
        public MainForm()
        {
            InitializeComponent();
            AutoupdateTimer.Interval = 1000;
            channels = new Label[8]
            {
                Channel1Label,
                Channel2Label,
                Channel3Label,
                Channel4Label,
                Channel5Label,
                Channel6Label,
                Channel7Label,
                Channel8Label
            };
            
            controls = new Control[]
            {
                ClearDayGraphButton,
                DayGraphButton,
                EventLogButton,
                NetConfigButton,
                SyncTimeButton,
                UpdateInfoButton,
                ClearEventLogButton,
             
            };


        }
        #region Утилиты

        /// <summary>
        /// Управление состоянием кнопок
        /// </summary>
        /// <param name="status">Состояние вкл/выкл</param>
        internal void SetControlsStatus(bool status)
        {
            foreach (Button btn in controls)
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
            CosLabel.Text = "------";
            CurrentTimeLabel.Text = "------";
            DayGraphRecsLabel.Text = "------";
            EventLogRecsLabel.Text = "------";
            FreqLabel.Text = "------";
            lblFW.Text = "------";
            IaLabel.Text = "------";
            IbLabel.Text = "------";
            IcLabel.Text = "------";
            MeterTimeLabel.Text = "------";
            ActPowerLabel.Text = "------";
            lblPort.Text = "------";
            lblProtocol.Text = "------";
            ReaPowerLabel.Text = "------";
            UaLabel.Text = "------";
            UbLabel.Text = "------";
            UcLabel.Text = "------";
            CurrentTimeLabel.Text = "------";
            for (int i = 0; i < 8; i++)
            {
                channels[i].Text = "--";
            }
            StatusLabel.Text = "Нет подключения";
            StatusLabel.BackColor = Color.Gold;

        }
        /// <summary>
        /// Инициализация при подключении
        /// </summary>
        internal void Connect()
        {
            Default();
            connectionForm.Close();
            Visible = true;
            if (Settings.isConnected)
            {
                SetControlsStatus(true);
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
            Task uit = new Task(UpdateInfo);
            uit.Start();
           
        }

        internal void UpdateInfo()
        {
            UpdateGeneralInfoLabels(GetGeneralInfo());
        }

        internal GeneralInfo GetGeneralInfo()
        {
            GeneralInfo result = new GeneralInfo();
            result.CurrentValues = Settings.Oblik.CurrentValues;
            result.MinuteValues = Settings.Oblik.MinuteValues;
            result.DayGraphRecords = Settings.Oblik.DayGraphPointer;
            result.EventLogRecords = Settings.Oblik.EventLogPointer;
            result.MeterTime = ((DateTime)Settings.Oblik.CurrentTimeUTC).ToLocalTime();
            return result;
        }

        /// <summary>
        /// Соединение с проверкой ошибок
        /// </summary>
        /// <param name="action">Дествие с возможным исключением</param>
        /// <param name="sucsess">Действие при успешной операции action</param>    
        internal void SafeConnect(Action action, Action sucsess = default)
        {
            void dummy() { }    //Заглушка

            sucsess += dummy;

            int repeats = Settings.Repeats;
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
                        AutoUpdateCheckbox.Checked = false;
                        AutoupdateTimer.Enabled = false;
                    }
                }
            }
            if (status)
            {
                sucsess.Invoke();
            }
        }

        /// <summary>
        /// Индикация состояния подключения
        /// </summary>
        internal void SetConnectionStatus(ConnectionStatus status)
        {
            switch (status)
            {
                case ConnectionStatus.OK:
                    StatusLabel.Text = "OK";
                    StatusLabel.BackColor = Color.LimeGreen;
                    break;
                case ConnectionStatus.Wait:
                    StatusLabel.Text = "Ожидание...";
                    StatusLabel.BackColor = Color.Yellow;
                    break;
                case ConnectionStatus.Error:
                    StatusLabel.Text = "Ошибка!";
                    StatusLabel.BackColor = Color.Red;
                    break;
                default:
                    StatusLabel.Text = "??????";
                    StatusLabel.BackColor = Color.DarkOrange;
                    break;
            }
        }

        /// <summary>
        /// Полчение информации о прошивке счетчика
        /// </summary>
        internal void UpdateFirmwareInfo()
        {
            FirmwareInfo fwInfo = new FirmwareInfo();
            action1 = () => fwInfo = Settings.Oblik.Firmware;
            action2 = () => lblFW.Text = $"{fwInfo.Version}.{fwInfo.Build}";
            SafeConnect(action1, action2);            
        }

        

        /// <summary>
        /// Обновление настроек сети счетчика
        /// </summary>
        internal void UpdateNetwokConfig()
        {
            NetworkConfig netconfig = new NetworkConfig();
            action1 = () => netconfig = Settings.Oblik.NetworkConfig; 
            action2 = () =>
            {
                lblPort.Text = Settings.oblikDriver.Port;
                lblAddress.Text = netconfig.Addr.ToString();
                lblProtocol.Text = (netconfig.Addr == 0) ? "Direct" : "Network";
                lblBaudrate.Text = (115200 / netconfig.Divisor).ToString();
            };
            SafeConnect(action1, action2);
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

        /// <summary>
        /// Сообщение об отсутствии подключения
        /// </summary>
        internal void ConnectionAlert()
        {
            MessageBox.Show("Нет подключения!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
        #endregion


        /*-------------------------Обработчики событий-----------------------------*/

        internal void UpdateGeneralInfoLabels(GeneralInfo generalInfo)
        {
            //Текущие значения
            float P = generalInfo.CurrentValues.Act_pw;
            float Q = generalInfo.CurrentValues.Rea_pw;
            float angle = (float)Math.Atan(Q / P);
            float sig = Math.Sign(angle);
            float cos = (float)Math.Cos(angle);
            if (sig == -1)
            {
                CosLabel.Text = string.Format("{0:f3}", cos) + "(C)";
            }
            else
            {
                CosLabel.Text = string.Format("{0:f3}", cos) + "(L)";
            }
            UaLabel.Text = $"{(float)generalInfo.CurrentValues.Volt1:f2}";
            UbLabel.Text = $"{(float)generalInfo.CurrentValues.Volt2:f2}";
            UcLabel.Text = $"{(float)generalInfo.CurrentValues.Volt3:f2}";
            IaLabel.Text = string.Format("{0:f2}", (float)generalInfo.CurrentValues.Curr1);
            IbLabel.Text = string.Format("{0:f2}", (float)generalInfo.CurrentValues.Curr2);
            IcLabel.Text = string.Format("{0:f2}", (float)generalInfo.CurrentValues.Curr3);
            FreqLabel.Text = string.Format("{0:f3}", generalInfo.CurrentValues.Freq / 30f);
            ActPowerLabel.Text = string.Format("{0:f4}", P);
            ReaPowerLabel.Text = string.Format("{0:f4}", Q);

            Channel1Label.Text = generalInfo.MinuteValues.Channel_1.ToString();
            Channel2Label.Text = generalInfo.MinuteValues.Channel_2.ToString();
            Channel3Label.Text = generalInfo.MinuteValues.Channel_3.ToString();
            Channel4Label.Text = generalInfo.MinuteValues.Channel_4.ToString();
            Channel5Label.Text = generalInfo.MinuteValues.Channel_5.ToString();
            Channel6Label.Text = generalInfo.MinuteValues.Channel_6.ToString();
            Channel7Label.Text = generalInfo.MinuteValues.Channel_7.ToString();
            Channel8Label.Text = generalInfo.MinuteValues.Channel_8.ToString();
            //Логи
            DayGraphRecsLabel.Text = generalInfo.DayGraphRecords.ToString();
            EventLogRecsLabel.Text = generalInfo.EventLogRecords.ToString();
            //Часы
            MeterTimeLabel.Text = string.Format("{0:T}", generalInfo.MeterTime.ToLocalTime());
            CurrentTimeLabel.Text = string.Format("{0:T}", DateTime.Now);
        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
            Default();
            SetControlsStatus(false);
            connectionForm = new ConnectForm(this);
            connectionForm.Show();
            connectionForm.BringToFront();
        }

        private void NetConfigButton_Click(object sender, EventArgs e)
        {

        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void chbAutoUpdate_CheckedChanged(object sender, EventArgs e)
        {
            AutoupdateTimer.Enabled = AutoUpdateCheckbox.Checked;
        }

        private void tmrTimer_Tick(object sender, EventArgs e)
        {
            UpdateGeneralInfo();
        }

        private void btnUpdateInfo_Click(object sender, EventArgs e)
        {
            UpdateGeneralInfo();
        }

        private void картаСегментовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!Settings.isConnected)
            {
                ConnectionAlert();
                return;
            }

            SegmentsMapRecord[] map = new SegmentsMapRecord[0];
            action1 = () => map = Settings.Oblik.SegmentsMap;
            action2 = () =>
            {
                segmantsMapForm = new SegmenstMapForm(map);
                segmantsMapForm.Show();
                segmantsMapForm.BringToFront();
            };
            SafeConnect(action1, action2);
        }

 

        private void btnClearDayGraph_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Стереть суточный график?","Подтверждение" ,MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SafeConnect(Settings.Oblik.CleanDayGraph);
                SafeConnect(() => { DayGraphRecsLabel.Text = Settings.Oblik.DayGraphPointer.ToString(); });
            }
        }

        private void ClearEventLog_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Стереть пртокол событий?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                SafeConnect(Settings.Oblik.CleanEventLog);
                SafeConnect(() => { EventLogRecsLabel.Text = Settings.Oblik.EventLogPointer.ToString(); });
            }
        }

        private void btnSyncTime_Click(object sender, EventArgs e)
        {
            SafeConnect(() => { Settings.Oblik.CurrentTimeUTC = DateTime.UtcNow; });
        }

        private void ConnectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            connectionForm = new ConnectForm(this);
            connectionForm.Show();
            connectionForm.BringToFront();
        }

        private void MainForm_Deactivate(object sender, EventArgs e)
        {
            AutoupdateTimer.Enabled = false;
        }

        private void MainForm_Activated(object sender, EventArgs e)
        {
            if (AutoUpdateCheckbox.Checked)
            {
                AutoupdateTimer.Enabled = true;
            }
        }

        private void очиститьОкноToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rtbLog.Clear();
        }
    }
}
