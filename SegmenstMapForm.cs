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
    public partial class SegmenstMapForm : Form
    {
        public SegmenstMapForm(SegmentsMapRecord[] Map)
        {
            InitializeComponent();

            foreach (SegmentsMapRecord segment in Map)
            {
                string accsess = ((segment.Rights & 128) == 0) ? "Чтение" : "Запись";
                string rights = string.Format("{0:d4}", System.Convert.ToString(segment.Rights & 127, 2));
                dgvMap.Rows.Add(segment.Id, accsess, rights.PadLeft(4, '0'), segment.Size);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
