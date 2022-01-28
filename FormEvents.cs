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
    public partial class FormEvents : Form
    {
        public FormEvents(EventLogRecord[] evnts)
        {
            InitializeComponent();
            foreach (EventLogRecord item in evnts)
            {
                dataGridEvents.Rows.Add
                (
                    ((DateTime)item.TimeStamp).ToLocalTime(),
                    EventsDecoder.Decode(item.Code)
                );
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
