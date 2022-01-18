using System;
using System.Windows.Forms;

namespace OblikConfigurator
{
    public partial class FormLogRequest : Form
    {
        private readonly FormMain formMain;

        public FormLogRequest(FormMain form, int currentRecs)
        {
            InitializeComponent();
            formMain = form;
            LabelRecords.Text = currentRecs.ToString();
            NumericRecords.Maximum = currentRecs;
            NumericRecords.Value = (currentRecs >= 8) ? 8 : currentRecs;
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ButtonOK_Click(object sender, EventArgs e)
        {
            Close();
            formMain.DayGraphShow((int)NumericRecords.Value);
        }
    }
}