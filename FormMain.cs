using System;
using System.Drawing;
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

    public partial class FormMain : Form
    {
        
        
        CalcUnits currentCoeffs;
        float Ki, Ku, Ken, Kpow;

        readonly Label[] channels;
        readonly Control[] controls;
        readonly InfoUpdater InfoUpdater;
        
        public FormMain()
        {
            InitializeComponent();

            InfoUpdater = new InfoUpdater(this);
            currentCoeffs = new CalcUnits();

            TimerAutoupdate.Interval = 1000;
            channels = new Label[8]
            {
                LabelChannel1,
                LabelChannel2,
                LabelChannel3,
                LabelChannel4,
                LabelChannel5,
                LabelChannel6,
                LabelChannel7,
                LabelChannel8
            };
            
            controls = new Control[]
            {
                ButtonClearDayGraph,
                ButtonDayGraph,
                ButtonEventLog,
                ButtonNetConfig,
                ButtonSyncTime,
                ButtonUpdateInfo,
                ButtonClearEventLog,
             
            };
        }

        #region Утилиты
        
        /// <summary>
        /// Управление состоянием автообновления
        /// </summary>
        /// <param name="state"></param>
        internal void SetAutoUpdate(bool state)
        {
            CheckboxAutoUpdate.Checked = state;
            TimerAutoupdate.Enabled = state;
        }
        
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
            инструментыToolStripMenuItem.Enabled = status;
            настройкиToolStripMenuItem.Enabled = status;
        }
        
        /// <summary>
        /// Надписи по умолчанию
        /// </summary>
        internal void Default()
        {
            LabelAddress.Text = "------";
            LabelBaudrate.Text = "------";
            LabelCos.Text = "------";
            LabelCurrentTime.Text = "------";
            LabelDayGraphRecs.Text = "------";
            LabelEventLogRecs.Text = "------";
            LabelFreq.Text = "------";
            LabelFW.Text = "------";
            LabelIa.Text = "------";
            LabelIb.Text = "------";
            LabelIc.Text = "------";
            LabelMeterTime.Text = "------";
            LabelActPower.Text = "------";
            LabelPort.Text = "------";
            LabelProtocol.Text = "------";
            LabelReaPower.Text = "------";
            LabelUa.Text = "------";
            LabelUb.Text = "------";
            LabelUc.Text = "------";
            LabelCurrentTime.Text = "------";
            for (int i = 0; i < 8; i++)
            {
                channels[i].Text = "--";
            }
            LabelStatus.Text = "Нет подключения";
            LabelStatus.BackColor = Color.Gold;

        }
        
        /// <summary>
        /// Инициализация при подключении
        /// </summary>
        internal void Connect()
        {
            Default();
            Visible = true;
            if (Settings.isConnected)
            {
                SetControlsStatus(true);
                UpdateFirmwareInfo();
                UpdateNetwokConfig();
                UpdateGeneralInfo();
                UpdateCoeffs();
            }
        }

        /// <summary>
        /// Обновление коэффициентов измерений 
        /// </summary>
        internal void UpdateCoeffs()
        {
            void SetCoeffs(CalcUnits coeffs)
            {
                currentCoeffs = coeffs;
                Ken = (float)(currentCoeffs.Ener_fct * Math.Pow(10, currentCoeffs.Ener_unit - 6));
                Kpow = (float)(currentCoeffs.Powr_fct * Math.Pow(10, currentCoeffs.Powr_unit));
                Ki = (float)(currentCoeffs.Curr_fct * Math.Pow(10, currentCoeffs.Curr_unit));
                Ku = (float)(currentCoeffs.Volt_fct * Math.Pow(10, currentCoeffs.Volt_unit));
            }
            InfoUpdater.UpdateAsync(() => Settings.Oblik.CalculationParams, SetCoeffs);
        }

        /// <summary>
        /// Обновление текущей информации
        /// </summary>
        internal void UpdateGeneralInfo()
        {
            GeneralInfo GetGeneralInfo()
            {
                return new GeneralInfo
                {
                    CurrentValues = Settings.Oblik.CurrentValues,
                    MinuteValues = Settings.Oblik.MinuteValues,
                    DayGraphRecords = Settings.Oblik.DayGraphPointer,
                    EventLogRecords = Settings.Oblik.EventLogPointer,
                    MeterTime = ((DateTime)Settings.Oblik.CurrentTimeUTC).ToLocalTime()
                };
            }

            void SetGeneralInfo(GeneralInfo generalInfo)
            {
                //Коэффициенты
                float energyCoeff, powerCoeff, currentCoeff, voltageCoeff;
                if (CheckboxCoeffs.Checked)
                {
                    voltageCoeff = Ku;
                    currentCoeff = Ki;
                    energyCoeff = Ken;
                    powerCoeff = Kpow;
                }
                else
                {
                    energyCoeff = 1;
                    powerCoeff = 1;
                    currentCoeff = 1;
                    voltageCoeff = 1;
                }

                //Текущие значения
                float P = generalInfo.CurrentValues.Act_pw;
                float Q = generalInfo.CurrentValues.Rea_pw;
                float angle = (float)Math.Atan(Q / P);
                float sig = Math.Sign(angle);
                float cos = (float)Math.Cos(angle);
                if (sig == -1)
                {
                    LabelCos.Text = string.Format("{0:f3}", cos) + "(C)";
                }
                else
                {
                    LabelCos.Text = string.Format("{0:f3}", cos) + "(L)";
                }

                LabelUa.Text = $"{generalInfo.CurrentValues.Volt1 * voltageCoeff:f2}";
                LabelUb.Text = $"{generalInfo.CurrentValues.Volt2 * voltageCoeff:f2}";
                LabelUc.Text = $"{generalInfo.CurrentValues.Volt3 * voltageCoeff:f2}";
                LabelIa.Text = $"{generalInfo.CurrentValues.Curr1 * currentCoeff:f2}";
                LabelIb.Text = $"{generalInfo.CurrentValues.Curr2 * currentCoeff:f2}";
                LabelIc.Text = $"{generalInfo.CurrentValues.Curr3 * currentCoeff:f2}";
                LabelFreq.Text = $"{generalInfo.CurrentValues.Freq / 30f:f3}";
                LabelActPower.Text = $"{P * powerCoeff:f4}";
                LabelReaPower.Text = $"{Q * powerCoeff:f4}";

                LabelChannel1.Text = generalInfo.MinuteValues.Channel_1.ToString();
                LabelChannel2.Text = generalInfo.MinuteValues.Channel_2.ToString();
                LabelChannel3.Text = generalInfo.MinuteValues.Channel_3.ToString();
                LabelChannel4.Text = generalInfo.MinuteValues.Channel_4.ToString();
                LabelChannel5.Text = generalInfo.MinuteValues.Channel_5.ToString();
                LabelChannel6.Text = generalInfo.MinuteValues.Channel_6.ToString();
                LabelChannel7.Text = generalInfo.MinuteValues.Channel_7.ToString();
                LabelChannel8.Text = generalInfo.MinuteValues.Channel_8.ToString();
                //Логи
                LabelDayGraphRecs.Text = generalInfo.DayGraphRecords.ToString();
                LabelEventLogRecs.Text = generalInfo.EventLogRecords.ToString();
                //Часы
                LabelMeterTime.Text = $"{generalInfo.MeterTime.ToLocalTime():T}";
                LabelCurrentTime.Text = $"{DateTime.Now:T}";
            }

            InfoUpdater.UpdateAsync(GetGeneralInfo, SetGeneralInfo);    
        }

        /// <summary>
        /// Индикация состояния подключения
        /// </summary>
        internal void SetConnectionStatus(ConnectionStatus status)
        {
            switch (status)
            {
                case ConnectionStatus.OK:
                    LabelStatus.Text = "OK";
                    LabelStatus.BackColor = Color.LimeGreen;
                    break;
                case ConnectionStatus.Wait:
                    LabelStatus.Text = "Ожидание...";
                    LabelStatus.BackColor = Color.Yellow;
                    break;
                case ConnectionStatus.Error:
                    LabelStatus.Text = "Ошибка!";
                    LabelStatus.BackColor = Color.Red;
                    break;
                default:
                    LabelStatus.Text = "??????";
                    LabelStatus.BackColor = Color.DarkOrange;
                    break;
            }
        }

        /// <summary>
        /// Полчение информации о прошивке счетчика
        /// </summary>
        internal void UpdateFirmwareInfo()
        {
            InfoUpdater.UpdateAsync(() => Settings.Oblik.Firmware, (info) => LabelFW.Text = $"{info.Version}.{info.Build}");
        }

        /// <summary>
        /// Обновление настроек сети счетчика
        /// </summary>
        internal void UpdateNetwokConfig()
        {
            void SetNetconfigLabels(NetworkConfig netconfig)
            {
                LabelPort.Text = Settings.oblikDriver.Port;
                LabelAddress.Text = $"{netconfig.Address:X2}";
                LabelProtocol.Text = (Settings.Oblik.IsDirectConnected) ? "Direct" : "Network";
                LabelBaudrate.Text = netconfig.Baudrate.ToString();
            }

            InfoUpdater.UpdateAsync(() => Settings.Oblik.NetworkConfig, SetNetconfigLabels);
        }

        /// <summary>
        /// Записть в счетчик новых сетевых настроек
        /// </summary>
        /// <param name="config"></param>
        internal void SaveNetworkConfig(NetworkConfig config)
        {
            InfoUpdater.Execute(() => Settings.Oblik.NetworkConfig = config);
            UpdateNetwokConfig();
        }

        internal void SaveCalculationParams(CalcUnits calcUnits)
        {
            InfoUpdater.Execute(() => Settings.Oblik.CalculationParams = calcUnits);
            UpdateCoeffs();
        }

        /// <summary>
        /// Добавить запись в лог
        /// </summary>
        /// <param name="message">Сообщение</param>
        internal void AddLog(string message)
        {
            DateTime currentTime = DateTime.Now;
            ReachTexBoxLog.AppendText($"{currentTime} : {message} \n");
        }

        /// <summary>
        /// Показать суточный график
        /// </summary>
        /// <param name="records">Количество последних записей</param>
        internal void DayGraphShow(int records)
        {
            InfoUpdater.UpdateAsync(
                () => Settings.Oblik.GetDayGraphRecords(records),
                (recs) =>
                {
                    FormDayGraph formDG = new FormDayGraph(recs);
                    formDG.Show();
                });
        }


        /// <summary>
        /// Установка подключения к счетчику
        /// </summary>
        private void SetConnection()
        {
            if (!Settings.isConnected)
            {
                Default();
                SetControlsStatus(false);
            }
            FormConnect formConnection = new FormConnect(this);
            formConnection.Show();
            formConnection.BringToFront();
        }
        #endregion


        /*-------------------------Обработчики событий-----------------------------*/


        private void MainForm_Shown(object sender, EventArgs e)
        {
            SetConnection();       
        }

        private void NetConfigButton_Click(object sender, EventArgs e)
        {
            SetAutoUpdate(false);
            void ShowNetconfigForm(NetworkConfig currentConfig)
            {
                FormNetConfig formNetConfig = new FormNetConfig(this, currentConfig);
                formNetConfig.Show();
            }

            InfoUpdater.UpdateAsync(() => Settings.Oblik.NetworkConfig, ShowNetconfigForm);
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void chbAutoUpdate_CheckedChanged(object sender, EventArgs e)
        {
            TimerAutoupdate.Enabled = CheckboxAutoUpdate.Checked;
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
            void SetSegmentsMap(SegmentsMapRecord[] map)
            {
                FormSegmenstMap formSegmentsMap = new FormSegmenstMap(map);
                formSegmentsMap.Show();
                formSegmentsMap.BringToFront();
            };
            InfoUpdater.UpdateAsync(() => Settings.Oblik.SegmentsMap, SetSegmentsMap);
        }

 

        private void btnClearDayGraph_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Стереть суточный график?","Подтверждение" ,MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                InfoUpdater.UpdateAsync(
                    () =>
                    {
                        Settings.Oblik.CleanDayGraph();
                        return Settings.Oblik.DayGraphPointer; 
                    }, 
                    (pointer) => LabelDayGraphRecs.Text = pointer.ToString());
            }
        }

        private void ClearEventLog_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Стереть пртокол событий?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                InfoUpdater.UpdateAsync(
                    () =>
                    {
                        Settings.Oblik.CleanEventLog();
                        return Settings.Oblik.EventLogPointer;
                    }, 
                    (pointer) => LabelEventLogRecs.Text = pointer.ToString());
            }
        }

        private void btnSyncTime_Click(object sender, EventArgs e)
        {
            InfoUpdater.ExecuteAsync(() => Settings.Oblik.CurrentTimeUTC = DateTime.UtcNow);
            InfoUpdater.UpdateAsync(
                () => (DateTime)Settings.Oblik.CurrentTimeUTC, 
                (time) => LabelMeterTime.Text = string.Format("{0:T}", time.ToLocalTime())
            );
            LabelCurrentTime.Text = $"{DateTime.Now:T}";
        }

        private void ConnectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SetConnection();
        }

        private void MainForm_Deactivate(object sender, EventArgs e)
        {
            TimerAutoupdate.Enabled = false;
        }

        private void ButtonDayGraph_Click(object sender, EventArgs e)
        {
            InfoUpdater.Update(() => Settings.Oblik.DayGraphPointer,
                (recs) =>
                {
                    FormLogRequest formLogRequest = new FormLogRequest(this, recs);
                    formLogRequest.Show();
                });
        }

        private void настройкаПараметровToolStripMenuItem_Click(object sender, EventArgs e)
        {
           InfoUpdater.UpdateAsync(
                () => Settings.Oblik.CalculationParams, 
                (coeffs) =>
                {
                    FormParams formParams = new FormParams(this, coeffs);
                    formParams.Show();
                });        
        }

        private void MainForm_Activated(object sender, EventArgs e)
        {
            if (CheckboxAutoUpdate.Checked)
            {
                TimerAutoupdate.Enabled = true;
            }
        }

        private void очиститьОкноToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReachTexBoxLog.Clear();
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
