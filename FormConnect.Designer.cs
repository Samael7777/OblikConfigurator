namespace OblikConfigurator
{
    partial class FormConnect
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.PortLabel = new System.Windows.Forms.Label();
            this.AddrLabel = new System.Windows.Forms.Label();
            this.PortCombobox = new System.Windows.Forms.ComboBox();
            this.ConnectButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.AddressNumeric = new System.Windows.Forms.NumericUpDown();
            this.ConnectTabControl = new System.Windows.Forms.TabControl();
            this.DirectPage = new System.Windows.Forms.TabPage();
            this.PasswordTextbox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.AccessCombobox = new System.Windows.Forms.ComboBox();
            this.AccessLabel = new System.Windows.Forms.Label();
            this.RepeatsNumeric = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.TimeoutNumeric = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.BaudrateCombobox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Prot232Radiobutton = new System.Windows.Forms.RadioButton();
            this.Prot485Radiobutton = new System.Windows.Forms.RadioButton();
            this.UpdateButton = new System.Windows.Forms.Button();
            this.DBPage = new System.Windows.Forms.TabPage();
            ((System.ComponentModel.ISupportInitialize)(this.AddressNumeric)).BeginInit();
            this.ConnectTabControl.SuspendLayout();
            this.DirectPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RepeatsNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TimeoutNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // PortLabel
            // 
            this.PortLabel.AutoSize = true;
            this.PortLabel.Location = new System.Drawing.Point(24, 96);
            this.PortLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.PortLabel.Name = "PortLabel";
            this.PortLabel.Size = new System.Drawing.Size(60, 25);
            this.PortLabel.TabIndex = 0;
            this.PortLabel.Text = "Порт";
            // 
            // AddrLabel
            // 
            this.AddrLabel.AutoSize = true;
            this.AddrLabel.Location = new System.Drawing.Point(24, 142);
            this.AddrLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.AddrLabel.Name = "AddrLabel";
            this.AddrLabel.Size = new System.Drawing.Size(124, 25);
            this.AddrLabel.TabIndex = 1;
            this.AddrLabel.Text = "Адрес(HEX)";
            // 
            // PortCombobox
            // 
            this.PortCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PortCombobox.FormattingEnabled = true;
            this.PortCombobox.Location = new System.Drawing.Point(156, 90);
            this.PortCombobox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.PortCombobox.Name = "PortCombobox";
            this.PortCombobox.Size = new System.Drawing.Size(147, 32);
            this.PortCombobox.TabIndex = 2;
            // 
            // ConnectButton
            // 
            this.ConnectButton.Location = new System.Drawing.Point(22, 438);
            this.ConnectButton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(277, 42);
            this.ConnectButton.TabIndex = 3;
            this.ConnectButton.Text = "Соединение";
            this.ConnectButton.UseVisualStyleBackColor = true;
            this.ConnectButton.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(737, 438);
            this.CancelButton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(277, 42);
            this.CancelButton.TabIndex = 5;
            this.CancelButton.Text = "Отмена";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // AddressNumeric
            // 
            this.AddressNumeric.Hexadecimal = true;
            this.AddressNumeric.Location = new System.Drawing.Point(156, 138);
            this.AddressNumeric.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.AddressNumeric.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.AddressNumeric.Name = "AddressNumeric";
            this.AddressNumeric.Size = new System.Drawing.Size(150, 29);
            this.AddressNumeric.TabIndex = 6;
            this.AddressNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // ConnectTabControl
            // 
            this.ConnectTabControl.Controls.Add(this.DirectPage);
            this.ConnectTabControl.Controls.Add(this.DBPage);
            this.ConnectTabControl.Location = new System.Drawing.Point(22, 22);
            this.ConnectTabControl.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.ConnectTabControl.Name = "ConnectTabControl";
            this.ConnectTabControl.SelectedIndex = 0;
            this.ConnectTabControl.Size = new System.Drawing.Size(999, 404);
            this.ConnectTabControl.TabIndex = 7;
            // 
            // DirectPage
            // 
            this.DirectPage.Controls.Add(this.PasswordTextbox);
            this.DirectPage.Controls.Add(this.label4);
            this.DirectPage.Controls.Add(this.AccessCombobox);
            this.DirectPage.Controls.Add(this.AccessLabel);
            this.DirectPage.Controls.Add(this.RepeatsNumeric);
            this.DirectPage.Controls.Add(this.label2);
            this.DirectPage.Controls.Add(this.TimeoutNumeric);
            this.DirectPage.Controls.Add(this.label3);
            this.DirectPage.Controls.Add(this.BaudrateCombobox);
            this.DirectPage.Controls.Add(this.label1);
            this.DirectPage.Controls.Add(this.label5);
            this.DirectPage.Controls.Add(this.Prot232Radiobutton);
            this.DirectPage.Controls.Add(this.Prot485Radiobutton);
            this.DirectPage.Controls.Add(this.UpdateButton);
            this.DirectPage.Controls.Add(this.PortCombobox);
            this.DirectPage.Controls.Add(this.AddressNumeric);
            this.DirectPage.Controls.Add(this.PortLabel);
            this.DirectPage.Controls.Add(this.AddrLabel);
            this.DirectPage.Location = new System.Drawing.Point(4, 33);
            this.DirectPage.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.DirectPage.Name = "DirectPage";
            this.DirectPage.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.DirectPage.Size = new System.Drawing.Size(991, 367);
            this.DirectPage.TabIndex = 0;
            this.DirectPage.Text = "Прямое соединение";
            this.DirectPage.UseVisualStyleBackColor = true;
            // 
            // PasswordTextbox
            // 
            this.PasswordTextbox.Location = new System.Drawing.Point(207, 242);
            this.PasswordTextbox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.PasswordTextbox.MaxLength = 8;
            this.PasswordTextbox.Name = "PasswordTextbox";
            this.PasswordTextbox.PasswordChar = '*';
            this.PasswordTextbox.Size = new System.Drawing.Size(180, 29);
            this.PasswordTextbox.TabIndex = 20;
            this.PasswordTextbox.UseSystemPasswordChar = true;
            this.PasswordTextbox.WordWrap = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 247);
            this.label4.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 25);
            this.label4.TabIndex = 19;
            this.label4.Text = "Пароль";
            // 
            // AccessCombobox
            // 
            this.AccessCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AccessCombobox.FormattingEnabled = true;
            this.AccessCombobox.Items.AddRange(new object[] {
            "Пользователь",
            "Администратор",
            "Энергонадзор",
            "Служебный пользователь"});
            this.AccessCombobox.Location = new System.Drawing.Point(207, 192);
            this.AccessCombobox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.AccessCombobox.Name = "AccessCombobox";
            this.AccessCombobox.Size = new System.Drawing.Size(380, 32);
            this.AccessCombobox.TabIndex = 18;
            // 
            // AccessLabel
            // 
            this.AccessLabel.AutoSize = true;
            this.AccessLabel.Location = new System.Drawing.Point(24, 198);
            this.AccessLabel.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.AccessLabel.Name = "AccessLabel";
            this.AccessLabel.Size = new System.Drawing.Size(168, 25);
            this.AccessLabel.TabIndex = 17;
            this.AccessLabel.Text = "Уровень доступа";
            // 
            // RepeatsNumeric
            // 
            this.RepeatsNumeric.Location = new System.Drawing.Point(741, 126);
            this.RepeatsNumeric.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.RepeatsNumeric.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.RepeatsNumeric.Name = "RepeatsNumeric";
            this.RepeatsNumeric.Size = new System.Drawing.Size(220, 29);
            this.RepeatsNumeric.TabIndex = 16;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(436, 129);
            this.label2.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(210, 25);
            this.label2.TabIndex = 15;
            this.label2.Text = "Повторы соединения";
            // 
            // TimeoutNumeric
            // 
            this.TimeoutNumeric.Location = new System.Drawing.Point(741, 78);
            this.TimeoutNumeric.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.TimeoutNumeric.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.TimeoutNumeric.Name = "TimeoutNumeric";
            this.TimeoutNumeric.Size = new System.Drawing.Size(220, 29);
            this.TimeoutNumeric.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(436, 81);
            this.label3.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(130, 25);
            this.label3.TabIndex = 13;
            this.label3.Text = "Таймаут, мс";
            // 
            // BaudrateCombobox
            // 
            this.BaudrateCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BaudrateCombobox.FormattingEnabled = true;
            this.BaudrateCombobox.Location = new System.Drawing.Point(739, 28);
            this.BaudrateCombobox.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.BaudrateCombobox.Name = "BaudrateCombobox";
            this.BaudrateCombobox.Size = new System.Drawing.Size(218, 32);
            this.BaudrateCombobox.TabIndex = 12;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(436, 33);
            this.label1.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(259, 25);
            this.label1.TabIndex = 11;
            this.label1.Text = "Скорость соединения, бод";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 33);
            this.label5.Margin = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 25);
            this.label5.TabIndex = 10;
            this.label5.Text = "Протокол";
            // 
            // Prot232Radiobutton
            // 
            this.Prot232Radiobutton.AutoSize = true;
            this.Prot232Radiobutton.Location = new System.Drawing.Point(279, 30);
            this.Prot232Radiobutton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Prot232Radiobutton.Name = "Prot232Radiobutton";
            this.Prot232Radiobutton.Size = new System.Drawing.Size(104, 29);
            this.Prot232Radiobutton.TabIndex = 9;
            this.Prot232Radiobutton.TabStop = true;
            this.Prot232Radiobutton.Text = "RS-232";
            this.Prot232Radiobutton.UseVisualStyleBackColor = true;
            this.Prot232Radiobutton.CheckedChanged += new System.EventHandler(this.rb232_CheckedChanged);
            // 
            // Prot485Radiobutton
            // 
            this.Prot485Radiobutton.AutoSize = true;
            this.Prot485Radiobutton.Location = new System.Drawing.Point(156, 30);
            this.Prot485Radiobutton.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.Prot485Radiobutton.Name = "Prot485Radiobutton";
            this.Prot485Radiobutton.Size = new System.Drawing.Size(104, 29);
            this.Prot485Radiobutton.TabIndex = 8;
            this.Prot485Radiobutton.TabStop = true;
            this.Prot485Radiobutton.Text = "RS-485";
            this.Prot485Radiobutton.UseVisualStyleBackColor = true;
            this.Prot485Radiobutton.CheckedChanged += new System.EventHandler(this.rb485_CheckedChanged);
            // 
            // UpdateButton
            // 
            this.UpdateButton.BackgroundImage = global::OblikConfigurator.Properties.Resources.refresh_23x23;
            this.UpdateButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.UpdateButton.Location = new System.Drawing.Point(317, 89);
            this.UpdateButton.Margin = new System.Windows.Forms.Padding(0);
            this.UpdateButton.Name = "UpdateButton";
            this.UpdateButton.Size = new System.Drawing.Size(42, 42);
            this.UpdateButton.TabIndex = 7;
            this.UpdateButton.UseVisualStyleBackColor = true;
            this.UpdateButton.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // DBPage
            // 
            this.DBPage.Location = new System.Drawing.Point(4, 33);
            this.DBPage.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.DBPage.Name = "DBPage";
            this.DBPage.Padding = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.DBPage.Size = new System.Drawing.Size(991, 367);
            this.DBPage.TabIndex = 1;
            this.DBPage.Text = "БД Облик";
            this.DBPage.UseVisualStyleBackColor = true;
            // 
            // FormConnect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1036, 498);
            this.Controls.Add(this.ConnectTabControl);
            this.Controls.Add(this.ConnectButton);
            this.Controls.Add(this.CancelButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(6, 6, 6, 6);
            this.MaximizeBox = false;
            this.Name = "FormConnect";
            this.Text = "Соединение";
            ((System.ComponentModel.ISupportInitialize)(this.AddressNumeric)).EndInit();
            this.ConnectTabControl.ResumeLayout(false);
            this.DirectPage.ResumeLayout(false);
            this.DirectPage.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RepeatsNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.TimeoutNumeric)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label PortLabel;
        private System.Windows.Forms.Label AddrLabel;
        private System.Windows.Forms.ComboBox PortCombobox;
        private System.Windows.Forms.Button ConnectButton;
        private new System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.NumericUpDown AddressNumeric;
        private System.Windows.Forms.TabControl ConnectTabControl;
        private System.Windows.Forms.TabPage DirectPage;
        private System.Windows.Forms.TabPage DBPage;
        private System.Windows.Forms.Button UpdateButton;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.RadioButton Prot232Radiobutton;
        private System.Windows.Forms.RadioButton Prot485Radiobutton;
        private System.Windows.Forms.NumericUpDown RepeatsNumeric;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown TimeoutNumeric;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox BaudrateCombobox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox PasswordTextbox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox AccessCombobox;
        private System.Windows.Forms.Label AccessLabel;
    }
}

