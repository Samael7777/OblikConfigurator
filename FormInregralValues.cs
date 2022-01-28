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
            label_c1_sum.Text = (values.Channel_1_A + values.Channel_1_B + values.Channel_1_C + values.Channel_1_D).ToString();

            label_c2_A.Text = values.Channel_2_A.ToString();
            label_c2_B.Text = values.Channel_2_B.ToString();
            label_c2_C.Text = values.Channel_2_C.ToString();
            label_c2_D.Text = values.Channel_2_D.ToString();
            label_c2_sum.Text = (values.Channel_2_A + values.Channel_2_B + values.Channel_2_C + values.Channel_2_D).ToString();

            label_c3_A.Text = values.Channel_3_A.ToString();
            label_c3_B.Text = values.Channel_3_B.ToString();
            label_c3_C.Text = values.Channel_3_C.ToString();
            label_c3_D.Text = values.Channel_3_D.ToString();
            label_c3_sum.Text = (values.Channel_3_A + values.Channel_3_B + values.Channel_3_C + values.Channel_3_D).ToString();

            label_c4_A.Text = values.Channel_4_A.ToString();
            label_c4_B.Text = values.Channel_4_B.ToString();
            label_c4_C.Text = values.Channel_4_C.ToString();
            label_c4_D.Text = values.Channel_4_D.ToString();
            label_c4_sum.Text = (values.Channel_4_A + values.Channel_4_B + values.Channel_4_C + values.Channel_4_D).ToString();

            label_c5_A.Text = values.Channel_5_A.ToString();
            label_c5_B.Text = values.Channel_5_B.ToString();
            label_c5_C.Text = values.Channel_5_C.ToString();
            label_c5_D.Text = values.Channel_5_D.ToString();
            label_c5_sum.Text = (values.Channel_5_A + values.Channel_5_B + values.Channel_5_C + values.Channel_5_D).ToString();

            label_c6_A.Text = values.Channel_6_A.ToString();
            label_c6_B.Text = values.Channel_6_B.ToString();
            label_c6_C.Text = values.Channel_6_C.ToString();
            label_c6_D.Text = values.Channel_6_D.ToString();
            label_c6_sum.Text = (values.Channel_6_A + values.Channel_6_B + values.Channel_6_C + values.Channel_6_D).ToString();

            label_c7_A.Text = values.Channel_7_A.ToString();
            label_c7_B.Text = values.Channel_7_B.ToString();
            label_c7_C.Text = values.Channel_7_C.ToString();
            label_c7_D.Text = values.Channel_7_D.ToString();
            label_c7_sum.Text = (values.Channel_7_A + values.Channel_7_B + values.Channel_7_C + values.Channel_7_D).ToString();

            label_c8_A.Text = values.Channel_8_A.ToString();
            label_c8_B.Text = values.Channel_8_B.ToString();
            label_c8_C.Text = values.Channel_8_C.ToString();
            label_c8_D.Text = values.Channel_8_D.ToString();
            label_c8_sum.Text = (values.Channel_8_A + values.Channel_8_B + values.Channel_8_C + values.Channel_8_D).ToString();

            labelEx_A.Text = values.Exceed_A.ToString();
            labelEx_B.Text = values.Exceed_B.ToString();
            labelEx_C.Text = values.Exceed_C.ToString();
            labelEx_D.Text = values.Exceed_D.ToString();

            labelMax_ex_A.Text = values.Max_exc_A.ToString();
            labelMax_ex_B.Text = values.Max_exc_B.ToString();
            labelMax_ex_C.Text = values.Max_exc_C.ToString();
            labelMax_ex_D.Text = values.Max_exc_D.ToString();
        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
