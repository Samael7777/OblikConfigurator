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
        frmConnect connectionForm;
        frmSegmenstMap segmantsMapForm;
        Meter oblik;
        OblikSerialDriver oblikDriver;
        Label[] channels;
        Button[] buttons;
        
        public frmMain()
        {
            InitializeComponent();
            tmrTimer.Interval = 1000;
            channels = new Label[8]
            {
                label26,
                label27,
                label28,
                label29,
                label30,
                label31,
                label32,
                label33
            };
            
            buttons = new Button[]
            {
                btnClearDayGraph,
                btnDayGraph,
                btnEventLog,
                btnNetConfig,
                btnSyncTime,
                btnUpdateInfo,
                btnClearEventLog
            };


        }

       

        /*-------------------------Обработчики событий-----------------------------*/

        private void frmMain_Shown(object sender, EventArgs e)
        {
            Default();
            SetButtonsStatus(false);
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
            UpdateGeneralInfo();
        }

        private void btnUpdateInfo_Click(object sender, EventArgs e)
        {
            UpdateGeneralInfo();
        }

        private void картаСегментовToolStripMenuItem_Click(object sender, EventArgs e)
        {
            segmantsMapForm = new frmSegmenstMap(this, oblik);
            segmantsMapForm.Show();
            segmantsMapForm.BringToFront();
        }

        private void последовательныйПортToolStripMenuItem_Click(object sender, EventArgs e)
        {
            connectionForm = new frmConnect(this);
            connectionForm.Show();
            connectionForm.BringToFront();
        }

        private void btnClearDayGraph_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Стереть суточный график?","Подтверждение" ,MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                oblik.DayGraphRecords.CleanLog();
                UpdateLogs();
            }
        }

        private void ClearEventLog_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Стереть пртокол событий?", "Подтверждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                oblik.EventRecords.CleanLog();
                UpdateLogs();
            }
        }

        private void btnSyncTime_Click(object sender, EventArgs e)
        {
            SafeConnect(oblik.MeterTime.SetCurrentTime);
        }
    }
}
