using Oblik;
using System;
using System.Linq;
using System.Windows.Forms;

namespace OblikConfigurator
{
    public partial class FormDayGraph : Form
    {
        public FormDayGraph(DayGraphRecord[] records, float ener_cf)
        {
            InitializeComponent();
            foreach (DayGraphRecord item in records.Reverse())
            {
                DatagridDayGraph.Rows.Add
                    (
                        ((DateTime)item.TimeStamp).ToLocalTime(),
                        $"{item.Act_en_p * ener_cf}",
                        $"{item.Act_en_n * ener_cf}",
                        $"{item.Rea_en_p * ener_cf}",
                        $"{item.Rea_en_n * ener_cf}",
                        item.Channel_1,
                        item.Channel_2,
                        item.Channel_3,
                        item.Channel_4,
                        item.Channel_5,
                        item.Channel_6,
                        item.Channel_7,
                        item.Channel_8
                    );
            }
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}