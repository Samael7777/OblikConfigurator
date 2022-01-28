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
    public partial class FormInregralValues : Form
    {
        public FormInregralValues(IntegralValues values, CalcUnits coeffs, string title)
        {
            InitializeComponent();
            Text = title;
            float ener_cf = (float)Math.Pow(10, coeffs.Ener_unit - 6);  //Перевод в кВт(квар)*ч

            labelAct_A_p.Text = $"{values.Act_en_A_p * ener_cf:f4}";
            labelAct_B_p.Text = $"{values.Act_en_B_p * ener_cf:f4}";
            labelAct_C_p.Text = $"{values.Act_en_C_p * ener_cf:f4}";
            labelAct_D_p.Text = $"{values.Act_en_D_p * ener_cf:f4}";
            float act_p_sum = (values.Act_en_A_p + values.Act_en_B_p + values.Act_en_C_p + values.Act_en_D_p) * ener_cf;
            labelAct_sum_p.Text = $"{act_p_sum:f4}";

            labelAct_A_n.Text = $"{values.Act_en_A_n * ener_cf:f4}";
            labelAct_B_n.Text = $"{values.Act_en_B_n * ener_cf:f4}";
            labelAct_C_n.Text = $"{values.Act_en_C_n * ener_cf:f4}";
            labelAct_D_n.Text = $"{values.Act_en_D_n * ener_cf:f4}";

            labelRea_A_p.Text = $"{values.Rea_en_A_p * ener_cf:f4}";
            labelRea_B_p.Text = $"{values.Rea_en_B_p * ener_cf:f4}";
            labelRea_C_p.Text = $"{values.Rea_en_C_p * ener_cf:f4}";
            labelRea_D_p.Text = $"{values.Rea_en_D_p * ener_cf:f4}";

            labelRea_A_n.Text = $"{values.Rea_en_A_n * ener_cf:f4}";
            labelRea_B_n.Text = $"{values.Rea_en_B_n * ener_cf:f4}";
            labelRea_C_n.Text = $"{values.Rea_en_C_n * ener_cf:f4}";
            labelRea_D_n.Text = $"{values.Rea_en_D_n * ener_cf:f4}";

            label_c1_A.Text = values.Channel_1_A.ToString();
            label_c1_B.Text = values.Channel_1_B.ToString();
            label_c1_C.Text = values.Channel_1_C.ToString();
            label_c1_D.Text = values.Channel_1_D.ToString();

        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
