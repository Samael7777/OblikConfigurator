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
    public partial class frmSegmenstMap : Form
    {
        private frmMain mainForm;
        private Meter oblik;
        public frmSegmenstMap(frmMain mainform, Meter meter)
        {
            InitializeComponent();
            mainForm = mainform;
            oblik = meter;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnReadMap_Click(object sender, EventArgs e)
        {
            mainForm.SafeConnect(oblik.SegmentsList.Read);
            foreach (SegmentsMapRow segment in oblik.SegmentsList.SegmentsMapList)
            {
                string accsess = (segment.Access == 0) ? "Чтение" : "Запись";
                string rights = String.Format("{0:d4}",System.Convert.ToString(segment.Rights, 2));
                dgvMap.Rows.Add(segment.Num, accsess, rights.PadLeft(4,'0'), segment.Size);
            }
        }
    }
}
