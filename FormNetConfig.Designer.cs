namespace OblikConfigurator
{
    partial class FormNetConfig
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
            this.BaudrateCombobox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.AddressNumeric = new System.Windows.Forms.NumericUpDown();
            this.AddrLabel = new System.Windows.Forms.Label();
            this.SaveButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.AddressNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // BaudrateCombobox
            // 
            this.BaudrateCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BaudrateCombobox.FormattingEnabled = true;
            this.BaudrateCombobox.Location = new System.Drawing.Point(158, 49);
            this.BaudrateCombobox.Name = "BaudrateCombobox";
            this.BaudrateCombobox.Size = new System.Drawing.Size(121, 21);
            this.BaudrateCombobox.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 13);
            this.label1.TabIndex = 15;
            this.label1.Text = "Скорость соединения, бод";
            // 
            // AddressNumeric
            // 
            this.AddressNumeric.Hexadecimal = true;
            this.AddressNumeric.Location = new System.Drawing.Point(158, 12);
            this.AddressNumeric.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.AddressNumeric.Name = "AddressNumeric";
            this.AddressNumeric.Size = new System.Drawing.Size(82, 20);
            this.AddressNumeric.TabIndex = 14;
            this.AddressNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // AddrLabel
            // 
            this.AddrLabel.AutoSize = true;
            this.AddrLabel.Location = new System.Drawing.Point(10, 14);
            this.AddrLabel.Name = "AddrLabel";
            this.AddrLabel.Size = new System.Drawing.Size(66, 13);
            this.AddrLabel.TabIndex = 13;
            this.AddrLabel.Text = "Адрес(HEX)";
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(12, 88);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(75, 23);
            this.SaveButton.TabIndex = 17;
            this.SaveButton.Text = "Сохранить";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(93, 88);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 18;
            this.CancelButton.Text = "Отмена";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // NetConfigForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(286, 121);
            this.ControlBox = false;
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.BaudrateCombobox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AddressNumeric);
            this.Controls.Add(this.AddrLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "NetConfigForm";
            this.Text = "Настройка сети счетчика";
            ((System.ComponentModel.ISupportInitialize)(this.AddressNumeric)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox BaudrateCombobox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown AddressNumeric;
        private System.Windows.Forms.Label AddrLabel;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button CancelButton;
    }
}