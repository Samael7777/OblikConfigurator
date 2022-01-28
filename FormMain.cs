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
        float Ki, Ku, Kpow;
        float dispKi, dispKu, dispKpow;    //Коэффициенты для отображаемой информации

        readonly Label[] channels;
        readonly Control[] controls;
        readonly Executor Executor;
        
        public FormMain()
        {
            InitializeComponent();
            
            dispKu = 1;
            dispKi = 1;
            dispKpow = 1;

            Executor = new Executor(this);
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
                Kpow = (float)(currentCoeffs.Powr_fct * Math.Pow(10, currentCoeffs.Powr_unit));
                Ki = (float)(currentCoeffs.Curr_fct * Math.Pow(10, currentCoeffs.Curr_unit));
                Ku = (float)(currentCoeffs.Volt_fct * Math.Pow(10, currentCoeffs.Volt_unit));
            }
            Executor.ExecuteAsync(() => Settings.Oblik.CalculationParams, SetCoeffs);
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
               //Текущие значения
                float P = generalInfo.CurrentValues.Act_pw;
                float Q = generalInfo.CurrentValues.Rea_pw;
                
                float angle = (P == 0)? 0 : (float)Math.Atan(Q / P);
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
                
                //Основной канал
                LabelUa.Text = $"{generalInfo.CurrentValues.Volt1 * dispKu:f2}";
                LabelUb.Text = $"{generalInfo.CurrentValues.Volt2 * dispKu:f2}";
                LabelUc.Text = $"{generalInfo.CurrentValues.Volt3 * dispKu:f2}";
                LabelIa.Text = $"{generalInfo.CurrentValues.Curr1 * dispKi:f2}";
                LabelIb.Text = $"{generalInfo.CurrentValues.Curr2 * dispKi:f2}";
                LabelIc.Text = $"{generalInfo.CurrentValues.Curr3 * dispKi:f2}";
                LabelFreq.Text = $"{generalInfo.CurrentValues.Freq / 30f:f3}";
                LabelActPower.Text = $"{P * dispKpow:f4}";
                LabelReaPower.Text = $"{Q * dispKpow:f4}";
                //Импульсные каналы
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

            Executor.ExecuteAsync(GetGeneralInfo, SetGeneralInfo);    
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
            Executor.ExecuteAsync(() => Settings.Oblik.Firmware, (info) => LabelFW.Text = $"{info.Version}.{info.Build}");
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

            Executor.ExecuteAsync(() => Settings.Oblik.NetworkConfig, SetNetconfigLabels);
        }

        /// <summary>
        /// Записть в счетчик новых сетевых настроек
        /// </summary>
        /// <param name="config"></param>
        internal void SaveNetworkConfig(NetworkConfig config)
        {
            Executor.Execute((Action)(() => Settings.Oblik.NetworkConfig = config));
            UpdateNetwokConfig();
        }

        internal void SaveCalculationParams(CalcUnits currentCoeffs)
        {
            Executor.Execute((Action)(() => Settings.Oblik.CalculationParams = currentCoeffs));
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
            Executor.ExecuteAsync(
                () => Settings.Oblik.GetDayGraphRecords(records),
                (recs) =>
                {
                    float ener_cf = (float)Math.Pow(10, currentCoeffs.Ener_unit - 6);
                    FormDayGraph formDG = new FormDayGraph(recs, ener_cf);
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

            Executor.ExecuteAsync(() => Settings.Oblik.NetworkConfig, ShowNetconfigForm);
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
            Executor.ExecuteAsync(() => Settings.Oblik.SegmentsMap, SetSegmentsMap);
        }

 

        private void btnClearDayGraph_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Стереть суточный график?","Подтверждение" ,MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Executor.ExecuteAsync(
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
                Executor.ExecuteAsync(
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
            Executor.ExecuteAsync((Action)(() => Settings.Oblik.CurrentTimeUTC = DateTime.UtcNow));
            Executor.ExecuteAsync(
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

        private void ButtonEventLog_Click(object sender, EventArgs e)
        {
            Executor.ExecuteAsync(
                () =>
                {
                    int ptr = Settings.Oblik.EventLogPointer;
                    return Settings.Oblik.GetEventLogRecords(ptr);
                },
                (recs) =>
                {
                    FormEvents formEvents = new FormEvents(recs);
                    formEvents.Show();
                }
                );
        }

        private void текущиеСуткиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Executor.ExecuteAsync
            (
                () => { return Settings.Oblik.CurrentDayIntegralValues; },
                (values) =>
                {
                    FormInregralValues formInregralValues = new FormInregralValues(values, currentCoeffs, "Интегральные значения за текущие сутки");
                    formInregralValues.Show();
                }
            );
        }

        private void текущийМесяцToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Executor.ExecuteAsync
            (
                () => { return Settings.Oblik.CurrentMonthIntegralValues; },
                (values) =>
                {
                    FormInregralValues formInregralValues = new FormInregralValues(values, currentCoeffs, "Интегральные значения за текущий месяц");
                    formInregralValues.Show();
                }
            );
        }

        private void текущийКварталToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Executor.ExecuteAsync
            (
               () => { return Settings.Oblik.CurrentQuarterIntegralValues; },
               (values) =>
               {
                   FormInregralValues formInregralValues = new FormInregralValues(values, currentCoeffs, "Интегральные значения за текущий квартал");
                   formInregralValues.Show();
               }
            );
        }

        private void текущийГодToolStripMenuItem_Click(object sender, EventArgs e)
        {
           Executor.ExecuteAsync
           (
               () => { return Settings.Oblik.CurrentYearIntegralValues; },
               (values) =>
               {
                   FormInregralValues formInregralValues = new FormInregralValues(values, currentCoeffs, "Интегральные значения за текущий год");
                   formInregralValues.Show();
               }
           );
        }

        private void прошлыеСуткиToolStripMenuItem1_Click(object sender, EventArgs e)
        {
           Executor.ExecuteAsync
           (
               () => { return Settings.Oblik.LastDayIntegralValues; },
               (values) =>
               {
                   FormInregralValues formInregralValues = new FormInregralValues(values, currentCoeffs, "Интегральные значения за прошлые сутки");
                   formInregralValues.Show();
               }
           );
        }

        private void прошлыйМесяцToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Executor.ExecuteAsync
           (
               () => { return Settings.Oblik.LastMonthIntegralValues; },
               (values) =>
               {
                   FormInregralValues formInregralValues = new FormInregralValues(values, currentCoeffs, "Интегральные значения за прошлый месяц");
                   formInregralValues.Show();
               }
           );
        }

        private void прошлыйКварталToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Executor.ExecuteAsync
           (
               () => { return Settings.Oblik.LastQuarterIntegralValues; },
               (values) =>
               {
                   FormInregralValues formInregralValues = new FormInregralValues(values, currentCoeffs, "Интегральные значения за прошлый квартал");
                   formInregralValues.Show();
               }
           );
        }

        private void прошлыйГодToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Executor.ExecuteAsync
           (
               () => { return Settings.Oblik.LastYearIntegralValues; },
               (values) =>
               {
                   FormInregralValues formInregralValues = new FormInregralValues(values, currentCoeffs, "Интегральные значения за прошлый год");
                   formInregralValues.Show();
               }
           );
        }

        private void ButtonDayGraph_Click(object sender, EventArgs e)
        {
            Executor.Execute(
                () => Settings.Oblik.DayGraphPointer,
                (recs) =>
                {
                    FormLogRequest formLogRequest = new FormLogRequest(this, recs);
                    formLogRequest.Show();
                });
        }

        private void настройкаПараметровToolStripMenuItem_Click(object sender, EventArgs e)
        {
           Executor.ExecuteAsync(
                () => Settings.Oblik.CalculationParams, 
                (coeffs) =>
                {
                    FormParams formParams = new FormParams(this, coeffs);
                    formParams.Show();
                });        
        }

        private void CheckboxCoeffs_CheckedChanged(object sender, EventArgs e)
        {
            dispKu = (CheckboxCoeffs.Checked) ? Ku : 1;
            dispKi = (CheckboxCoeffs.Checked) ? Ki : 1;
            dispKpow = (CheckboxCoeffs.Checked) ? Kpow : 1;
            UpdateGeneralInfo();
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
