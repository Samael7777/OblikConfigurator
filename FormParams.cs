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
    public partial class FormParams : Form
    {
        private readonly FormMain mainForm;
        private readonly int[] I1w = { 1, 5, 10, 15, 20, 30, 40, 50, 75, 80, 100, 150, 200, 300, 400, 500, 600, 750, 800, 1000, 1200, 1500, 2000, 3000, 4000, 5000, 6000, 7000, 8000, 10000, 12000, 14000, 16000, 18000, 20000, 25000, 28000, 32000, 35000, 40000 };
        private readonly int[] I2w = { 1, 5 };

        CalcUnits currentCoeffs;


        private string CoeffsString(sbyte unit, string unitname)
        {
            string[] prefixes = { "", "к", "М", "Г", "Т" };
            int index = unit / 3;
            string prefix = prefixes[index];
            float coef = (float)Math.Pow(10, unit - 3 * index);
            return $"{prefix}{unitname}" + ((coef == 1) ? "" : $" · {coef}");
        } 


        public FormParams(FormMain mainForm, CalcUnits currentCoeffs)
        {
            InitializeComponent();
            this.mainForm = mainForm;
            this.currentCoeffs = currentCoeffs;

            //Заполнение формы
            foreach (int val in I1w)
            {
                comboboxI1w.Items.Add(val);
            }

            foreach (int val in I2w)
            {
                comboboxI2w.Items.Add(val);
            }

            comboboxI1w.SelectedIndex = Array.FindIndex(I1w, (item) => (item == (int)currentCoeffs.Curr_1w));
            comboboxI2w.SelectedIndex = Array.FindIndex(I2w, (item) => (item == (int)currentCoeffs.Curr_2w));

            numericU1.Value = (decimal)currentCoeffs.Volt_1w;
            numericU2.Value = (decimal)currentCoeffs.Volt_2w;
            numericZoneA.Value = (decimal)currentCoeffs.Pwr_lim_A;
            numericZoneB.Value = (decimal)currentCoeffs.Pwr_lim_B;
            numericZoneC.Value = (decimal)currentCoeffs.Pwr_lim_C;
            numericZoneD.Value = (decimal)currentCoeffs.Pwr_lim_D;
            
            numericInterval.Value = currentCoeffs.Save_const;
            UpdateUnits();
            
        }

        private void UpdateUnits()
        {
            float Ku = currentCoeffs.Volt_1w / currentCoeffs.Volt_2w;
            currentCoeffs.Volt_unit = (sbyte)(Math.Truncate(Math.Log10(Ku)) + 1);
            currentCoeffs.Volt_fct = (float)(Ku / Math.Pow(10, currentCoeffs.Volt_unit));
            textBoxCoeffU.Text = currentCoeffs.Volt_fct.ToString();
            textBoxUnitU.Text = CoeffsString(currentCoeffs.Volt_unit, "В");

            float Ki = currentCoeffs.Curr_1w / currentCoeffs.Curr_2w;
            currentCoeffs.Curr_unit = (sbyte)Math.Truncate(Math.Log10(Ki));
            currentCoeffs.Curr_fct = (float)(Ki / Math.Pow(10, currentCoeffs.Curr_unit));
            textBoxCoeffI.Text = currentCoeffs.Curr_fct.ToString();
            textBoxUnitI.Text = CoeffsString(currentCoeffs.Curr_unit, "А");

            float Kp = Ku * Ki;
            currentCoeffs.Powr_unit = (sbyte)(Math.Truncate(Math.Log10(Kp)) + 1);
            currentCoeffs.Powr_fct = (float)(Kp / Math.Pow(10, currentCoeffs.Powr_unit));
            textBoxCoeffPow.Text = currentCoeffs.Powr_fct.ToString();
            textBoxUnitPow.Text = CoeffsString(currentCoeffs.Powr_unit, "Вт");

            float Kw = Kp / 2;              //Получасовая мощность????? Непонятно....
            currentCoeffs.Ener_unit = (sbyte)(Math.Truncate(Math.Log10(Kw)) + 3);
            currentCoeffs.Ener_fct = (float)(Kw / Math.Pow(10, currentCoeffs.Ener_unit));
            textBoxCoeffEn.Text = $"{currentCoeffs.Ener_fct:f6}";
            textBoxUnitEn.Text = CoeffsString(currentCoeffs.Ener_unit, "Вт·ч");
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            


            Close();
            mainForm.SaveCalculationParams(currentCoeffs);
        }

        private void comboboxI1w_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentCoeffs.Curr_1w = I1w[comboboxI1w.SelectedIndex];
            UpdateUnits();
        }

        private void comboboxI2w_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentCoeffs.Curr_2w = I2w[comboboxI2w.SelectedIndex];
            UpdateUnits();
        }

        private void numericU1_ValueChanged(object sender, EventArgs e)
        {
            currentCoeffs.Volt_1w = (float)numericU1.Value;
            UpdateUnits();
        }

        private void numericU2_ValueChanged(object sender, EventArgs e)
        {
            currentCoeffs.Volt_2w = (float)numericU2.Value;
            UpdateUnits();
        }

        private void numericInterval_ValueChanged(object sender, EventArgs e)
        {
            currentCoeffs.Save_const = (byte)numericInterval.Value;
        }

        private void numericZoneA_ValueChanged(object sender, EventArgs e)
        {
            currentCoeffs.Pwr_lim_A = (float)numericZoneA.Value;
        }

        private void numericZoneB_ValueChanged(object sender, EventArgs e)
        {
            currentCoeffs.Pwr_lim_B = (float)numericZoneB.Value;
        }

        private void numericZoneC_ValueChanged(object sender, EventArgs e)
        {
            currentCoeffs.Pwr_lim_C = (float)numericZoneC.Value;
        }

        private void numericZoneD_ValueChanged(object sender, EventArgs e)
        {
            currentCoeffs.Pwr_lim_D = (float)numericZoneD.Value;
        }
    }
}
