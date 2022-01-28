namespace OblikConfigurator
{
    partial class FormParams
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormParams));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.comboboxI2w = new System.Windows.Forms.ComboBox();
            this.comboboxI1w = new System.Windows.Forms.ComboBox();
            this.numericU2 = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.numericU1 = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.numericZoneD = new System.Windows.Forms.NumericUpDown();
            this.numericZoneC = new System.Windows.Forms.NumericUpDown();
            this.numericZoneB = new System.Windows.Forms.NumericUpDown();
            this.numericZoneA = new System.Windows.Forms.NumericUpDown();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBoxUnitU = new System.Windows.Forms.TextBox();
            this.textBoxUnitI = new System.Windows.Forms.TextBox();
            this.textBoxUnitPow = new System.Windows.Forms.TextBox();
            this.textBoxUnitEn = new System.Windows.Forms.TextBox();
            this.textBoxCoeffU = new System.Windows.Forms.TextBox();
            this.textBoxCoeffI = new System.Windows.Forms.TextBox();
            this.textBoxCoeffPow = new System.Windows.Forms.TextBox();
            this.textBoxCoeffEn = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.numericInterval = new System.Windows.Forms.NumericUpDown();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericU2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericU1)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericZoneD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericZoneC)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericZoneB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericZoneA)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericInterval)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.comboboxI2w);
            this.groupBox1.Controls.Add(this.comboboxI1w);
            this.groupBox1.Controls.Add(this.numericU2);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.numericU1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(267, 92);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Коэффициенты трансформаторов";
            // 
            // comboboxI2w
            // 
            this.comboboxI2w.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboboxI2w.FormattingEnabled = true;
            this.comboboxI2w.Location = new System.Drawing.Point(176, 27);
            this.comboboxI2w.Name = "comboboxI2w";
            this.comboboxI2w.Size = new System.Drawing.Size(66, 21);
            this.comboboxI2w.TabIndex = 9;
            this.comboboxI2w.SelectedIndexChanged += new System.EventHandler(this.comboboxI2w_SelectedIndexChanged);
            // 
            // comboboxI1w
            // 
            this.comboboxI1w.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboboxI1w.FormattingEnabled = true;
            this.comboboxI1w.Location = new System.Drawing.Point(86, 27);
            this.comboboxI1w.Name = "comboboxI1w";
            this.comboboxI1w.Size = new System.Drawing.Size(66, 21);
            this.comboboxI1w.TabIndex = 8;
            this.comboboxI1w.SelectedIndexChanged += new System.EventHandler(this.comboboxI1w_SelectedIndexChanged);
            // 
            // numericU2
            // 
            this.numericU2.Location = new System.Drawing.Point(176, 54);
            this.numericU2.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericU2.Name = "numericU2";
            this.numericU2.Size = new System.Drawing.Size(66, 20);
            this.numericU2.TabIndex = 7;
            this.numericU2.ValueChanged += new System.EventHandler(this.numericU2_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(158, 56);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(12, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "/";
            // 
            // numericU1
            // 
            this.numericU1.Location = new System.Drawing.Point(86, 54);
            this.numericU1.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericU1.Name = "numericU1";
            this.numericU1.Size = new System.Drawing.Size(66, 20);
            this.numericU1.TabIndex = 5;
            this.numericU1.ValueChanged += new System.EventHandler(this.numericU1_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(158, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(12, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "/";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Напряжения";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Тока";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.numericZoneD);
            this.groupBox2.Controls.Add(this.numericZoneC);
            this.groupBox2.Controls.Add(this.numericZoneB);
            this.groupBox2.Controls.Add(this.numericZoneA);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(12, 110);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(267, 136);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Лимиты мощности";
            // 
            // numericZoneD
            // 
            this.numericZoneD.Location = new System.Drawing.Point(86, 101);
            this.numericZoneD.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericZoneD.Name = "numericZoneD";
            this.numericZoneD.Size = new System.Drawing.Size(66, 20);
            this.numericZoneD.TabIndex = 14;
            this.numericZoneD.ValueChanged += new System.EventHandler(this.numericZoneD_ValueChanged);
            // 
            // numericZoneC
            // 
            this.numericZoneC.Location = new System.Drawing.Point(86, 75);
            this.numericZoneC.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericZoneC.Name = "numericZoneC";
            this.numericZoneC.Size = new System.Drawing.Size(66, 20);
            this.numericZoneC.TabIndex = 13;
            this.numericZoneC.ValueChanged += new System.EventHandler(this.numericZoneC_ValueChanged);
            // 
            // numericZoneB
            // 
            this.numericZoneB.Location = new System.Drawing.Point(86, 49);
            this.numericZoneB.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericZoneB.Name = "numericZoneB";
            this.numericZoneB.Size = new System.Drawing.Size(66, 20);
            this.numericZoneB.TabIndex = 12;
            this.numericZoneB.ValueChanged += new System.EventHandler(this.numericZoneB_ValueChanged);
            // 
            // numericZoneA
            // 
            this.numericZoneA.Location = new System.Drawing.Point(86, 23);
            this.numericZoneA.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numericZoneA.Name = "numericZoneA";
            this.numericZoneA.Size = new System.Drawing.Size(66, 20);
            this.numericZoneA.TabIndex = 8;
            this.numericZoneA.ValueChanged += new System.EventHandler(this.numericZoneA_ValueChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(12, 103);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(43, 13);
            this.label8.TabIndex = 11;
            this.label8.Text = "Зона D";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 77);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(42, 13);
            this.label7.TabIndex = 10;
            this.label7.Text = "Зона C";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(12, 51);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(42, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Зона B";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Зона A";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBoxUnitU);
            this.groupBox3.Controls.Add(this.textBoxUnitI);
            this.groupBox3.Controls.Add(this.textBoxUnitPow);
            this.groupBox3.Controls.Add(this.textBoxUnitEn);
            this.groupBox3.Controls.Add(this.textBoxCoeffU);
            this.groupBox3.Controls.Add(this.textBoxCoeffI);
            this.groupBox3.Controls.Add(this.textBoxCoeffPow);
            this.groupBox3.Controls.Add(this.textBoxCoeffEn);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Location = new System.Drawing.Point(285, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(298, 136);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Масштабные коэффициенты и единицы измерения";
            // 
            // textBoxUnitU
            // 
            this.textBoxUnitU.Enabled = false;
            this.textBoxUnitU.Location = new System.Drawing.Point(210, 93);
            this.textBoxUnitU.Name = "textBoxUnitU";
            this.textBoxUnitU.Size = new System.Drawing.Size(82, 20);
            this.textBoxUnitU.TabIndex = 15;
            this.textBoxUnitU.WordWrap = false;
            // 
            // textBoxUnitI
            // 
            this.textBoxUnitI.Enabled = false;
            this.textBoxUnitI.Location = new System.Drawing.Point(210, 71);
            this.textBoxUnitI.Name = "textBoxUnitI";
            this.textBoxUnitI.Size = new System.Drawing.Size(82, 20);
            this.textBoxUnitI.TabIndex = 16;
            this.textBoxUnitI.WordWrap = false;
            // 
            // textBoxUnitPow
            // 
            this.textBoxUnitPow.Enabled = false;
            this.textBoxUnitPow.Location = new System.Drawing.Point(210, 49);
            this.textBoxUnitPow.Name = "textBoxUnitPow";
            this.textBoxUnitPow.Size = new System.Drawing.Size(82, 20);
            this.textBoxUnitPow.TabIndex = 15;
            this.textBoxUnitPow.WordWrap = false;
            // 
            // textBoxUnitEn
            // 
            this.textBoxUnitEn.Enabled = false;
            this.textBoxUnitEn.Location = new System.Drawing.Point(210, 27);
            this.textBoxUnitEn.Name = "textBoxUnitEn";
            this.textBoxUnitEn.Size = new System.Drawing.Size(82, 20);
            this.textBoxUnitEn.TabIndex = 14;
            this.textBoxUnitEn.WordWrap = false;
            // 
            // textBoxCoeffU
            // 
            this.textBoxCoeffU.Enabled = false;
            this.textBoxCoeffU.Location = new System.Drawing.Point(105, 94);
            this.textBoxCoeffU.Name = "textBoxCoeffU";
            this.textBoxCoeffU.Size = new System.Drawing.Size(99, 20);
            this.textBoxCoeffU.TabIndex = 13;
            this.textBoxCoeffU.WordWrap = false;
            // 
            // textBoxCoeffI
            // 
            this.textBoxCoeffI.Enabled = false;
            this.textBoxCoeffI.Location = new System.Drawing.Point(105, 72);
            this.textBoxCoeffI.Name = "textBoxCoeffI";
            this.textBoxCoeffI.Size = new System.Drawing.Size(99, 20);
            this.textBoxCoeffI.TabIndex = 12;
            this.textBoxCoeffI.WordWrap = false;
            // 
            // textBoxCoeffPow
            // 
            this.textBoxCoeffPow.Enabled = false;
            this.textBoxCoeffPow.Location = new System.Drawing.Point(105, 50);
            this.textBoxCoeffPow.Name = "textBoxCoeffPow";
            this.textBoxCoeffPow.Size = new System.Drawing.Size(99, 20);
            this.textBoxCoeffPow.TabIndex = 11;
            this.textBoxCoeffPow.WordWrap = false;
            // 
            // textBoxCoeffEn
            // 
            this.textBoxCoeffEn.Enabled = false;
            this.textBoxCoeffEn.Location = new System.Drawing.Point(105, 28);
            this.textBoxCoeffEn.Name = "textBoxCoeffEn";
            this.textBoxCoeffEn.Size = new System.Drawing.Size(99, 20);
            this.textBoxCoeffEn.TabIndex = 5;
            this.textBoxCoeffEn.WordWrap = false;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(19, 53);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(63, 13);
            this.label12.TabIndex = 10;
            this.label12.Text = "Мощности:";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(19, 31);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(52, 13);
            this.label11.TabIndex = 9;
            this.label11.Text = "Энергии:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(19, 97);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(74, 13);
            this.label10.TabIndex = 8;
            this.label10.Text = "Напряжения:";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(19, 75);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(35, 13);
            this.label9.TabIndex = 2;
            this.label9.Text = "Тока:";
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(12, 252);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 3;
            this.buttonOK.Text = "Сохранить";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Location = new System.Drawing.Point(507, 252);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(285, 159);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(160, 13);
            this.label13.TabIndex = 8;
            this.label13.Text = "Частота записи графика, мин";
            // 
            // numericInterval
            // 
            this.numericInterval.Location = new System.Drawing.Point(451, 157);
            this.numericInterval.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numericInterval.Name = "numericInterval";
            this.numericInterval.Size = new System.Drawing.Size(66, 20);
            this.numericInterval.TabIndex = 8;
            this.numericInterval.ValueChanged += new System.EventHandler(this.numericInterval_ValueChanged);
            // 
            // FormParams
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(594, 285);
            this.Controls.Add(this.numericInterval);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "FormParams";
            this.Text = "Настройка параметров";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericU2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericU1)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericZoneD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericZoneC)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericZoneB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericZoneA)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numericInterval)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.NumericUpDown numericU2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numericU1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.NumericUpDown numericZoneD;
        private System.Windows.Forms.NumericUpDown numericZoneC;
        private System.Windows.Forms.NumericUpDown numericZoneB;
        private System.Windows.Forms.NumericUpDown numericZoneA;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.TextBox textBoxUnitU;
        private System.Windows.Forms.TextBox textBoxUnitI;
        private System.Windows.Forms.TextBox textBoxUnitPow;
        private System.Windows.Forms.TextBox textBoxUnitEn;
        private System.Windows.Forms.TextBox textBoxCoeffU;
        private System.Windows.Forms.TextBox textBoxCoeffI;
        private System.Windows.Forms.TextBox textBoxCoeffPow;
        private System.Windows.Forms.TextBox textBoxCoeffEn;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.NumericUpDown numericInterval;
        private System.Windows.Forms.ComboBox comboboxI2w;
        private System.Windows.Forms.ComboBox comboboxI1w;
    }
}