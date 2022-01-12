namespace OblikConfigurator
{
    partial class ConnectForm
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
            this.PasswordTextbox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.AccessCombobox = new System.Windows.Forms.ComboBox();
            this.AccessLabel = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.AddressNumeric)).BeginInit();
            this.ConnectTabControl.SuspendLayout();
            this.DirectPage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.RepeatsNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.TimeoutNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPort
            // 
            this.PortLabel.AutoSize = true;
            this.PortLabel.Location = new System.Drawing.Point(13, 52);
            this.PortLabel.Name = "lblPort";
            this.PortLabel.Size = new System.Drawing.Size(32, 13);
            this.PortLabel.TabIndex = 0;
            this.PortLabel.Text = "Порт";
            // 
            // lblAddr
            // 
            this.AddrLabel.AutoSize = true;
            this.AddrLabel.Location = new System.Drawing.Point(13, 77);
            this.AddrLabel.Name = "lblAddr";
            this.AddrLabel.Size = new System.Drawing.Size(66, 13);
            this.AddrLabel.TabIndex = 1;
            this.AddrLabel.Text = "Адрес(HEX)";
            // 
            // cbPort
            // 
            this.PortCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.PortCombobox.FormattingEnabled = true;
            this.PortCombobox.Location = new System.Drawing.Point(85, 49);
            this.PortCombobox.Name = "cbPort";
            this.PortCombobox.Size = new System.Drawing.Size(82, 21);
            this.PortCombobox.TabIndex = 2;
            // 
            // btnConnect
            // 
            this.ConnectButton.Location = new System.Drawing.Point(12, 237);
            this.ConnectButton.Name = "btnConnect";
            this.ConnectButton.Size = new System.Drawing.Size(151, 23);
            this.ConnectButton.TabIndex = 3;
            this.ConnectButton.Text = "Соединение";
            this.ConnectButton.UseVisualStyleBackColor = true;
            this.ConnectButton.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.CancelButton.Location = new System.Drawing.Point(173, 237);
            this.CancelButton.Name = "btnCancel";
            this.CancelButton.Size = new System.Drawing.Size(151, 23);
            this.CancelButton.TabIndex = 5;
            this.CancelButton.Text = "Отмена";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // numAddr
            // 
            this.AddressNumeric.Hexadecimal = true;
            this.AddressNumeric.Location = new System.Drawing.Point(85, 75);
            this.AddressNumeric.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.AddressNumeric.Name = "numAddr";
            this.AddressNumeric.Size = new System.Drawing.Size(82, 20);
            this.AddressNumeric.TabIndex = 6;
            this.AddressNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});

            // 
            // tcConnect
            // 
            this.ConnectTabControl.Controls.Add(this.DirectPage);
            this.ConnectTabControl.Controls.Add(this.DBPage);
            this.ConnectTabControl.Location = new System.Drawing.Point(12, 12);
            this.ConnectTabControl.Name = "tcConnect";
            this.ConnectTabControl.SelectedIndex = 0;
            this.ConnectTabControl.Size = new System.Drawing.Size(545, 219);
            this.ConnectTabControl.TabIndex = 7;
            // 
            // tDirect
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
            this.DirectPage.Location = new System.Drawing.Point(4, 22);
            this.DirectPage.Name = "tDirect";
            this.DirectPage.Padding = new System.Windows.Forms.Padding(3);
            this.DirectPage.Size = new System.Drawing.Size(537, 193);
            this.DirectPage.TabIndex = 0;
            this.DirectPage.Text = "Прямое соединение";
            this.DirectPage.UseVisualStyleBackColor = true;
            // 
            // nRepeats
            // 
            this.RepeatsNumeric.Location = new System.Drawing.Point(404, 68);
            this.RepeatsNumeric.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.RepeatsNumeric.Name = "nRepeats";
            this.RepeatsNumeric.Size = new System.Drawing.Size(120, 20);
            this.RepeatsNumeric.TabIndex = 16;

            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(238, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 13);
            this.label2.TabIndex = 15;
            this.label2.Text = "Повторы соединения";
            // 
            // nTimeout
            // 
            this.TimeoutNumeric.Location = new System.Drawing.Point(404, 42);
            this.TimeoutNumeric.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.TimeoutNumeric.Name = "nTimeout";
            this.TimeoutNumeric.Size = new System.Drawing.Size(120, 20);
            this.TimeoutNumeric.TabIndex = 14;

            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(238, 44);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Таймаут, мс";
            // 
            // cbBaudrate
            // 
            this.BaudrateCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.BaudrateCombobox.FormattingEnabled = true;
            this.BaudrateCombobox.Location = new System.Drawing.Point(403, 15);
            this.BaudrateCombobox.Name = "cbBaudrate";
            this.BaudrateCombobox.Size = new System.Drawing.Size(121, 21);
            this.BaudrateCombobox.TabIndex = 12;
           
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(238, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 13);
            this.label1.TabIndex = 11;
            this.label1.Text = "Скорость соединения, бод";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(13, 18);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Протокол";
            // 
            // rb232
            // 
            this.Prot232Radiobutton.AutoSize = true;
            this.Prot232Radiobutton.Location = new System.Drawing.Point(152, 16);
            this.Prot232Radiobutton.Name = "rb232";
            this.Prot232Radiobutton.Size = new System.Drawing.Size(61, 17);
            this.Prot232Radiobutton.TabIndex = 9;
            this.Prot232Radiobutton.TabStop = true;
            this.Prot232Radiobutton.Text = "RS-232";
            this.Prot232Radiobutton.UseVisualStyleBackColor = true;
            this.Prot232Radiobutton.CheckedChanged += new System.EventHandler(this.rb232_CheckedChanged);
            // 
            // rb485
            // 
            this.Prot485Radiobutton.AutoSize = true;
            this.Prot485Radiobutton.Location = new System.Drawing.Point(85, 16);
            this.Prot485Radiobutton.Name = "rb485";
            this.Prot485Radiobutton.Size = new System.Drawing.Size(61, 17);
            this.Prot485Radiobutton.TabIndex = 8;
            this.Prot485Radiobutton.TabStop = true;
            this.Prot485Radiobutton.Text = "RS-485";
            this.Prot485Radiobutton.UseVisualStyleBackColor = true;
            this.Prot485Radiobutton.CheckedChanged += new System.EventHandler(this.rb485_CheckedChanged);
            // 
            // btnUpdate
            // 
            this.UpdateButton.BackgroundImage = global::OblikConfigurator.Properties.Resources.refresh_23x23;
            this.UpdateButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.UpdateButton.Location = new System.Drawing.Point(173, 48);
            this.UpdateButton.Margin = new System.Windows.Forms.Padding(0);
            this.UpdateButton.Name = "btnUpdate";
            this.UpdateButton.Size = new System.Drawing.Size(23, 23);
            this.UpdateButton.TabIndex = 7;
            this.UpdateButton.UseVisualStyleBackColor = true;
            this.UpdateButton.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // tDB
            // 
            this.DBPage.Location = new System.Drawing.Point(4, 22);
            this.DBPage.Name = "tDB";
            this.DBPage.Padding = new System.Windows.Forms.Padding(3);
            this.DBPage.Size = new System.Drawing.Size(537, 193);
            this.DBPage.TabIndex = 1;
            this.DBPage.Text = "БД Облик";
            this.DBPage.UseVisualStyleBackColor = true;
            // 
            // tbPassword
            // 
            this.PasswordTextbox.Location = new System.Drawing.Point(113, 131);
            this.PasswordTextbox.MaxLength = 8;
            this.PasswordTextbox.Name = "tbPassword";
            this.PasswordTextbox.PasswordChar = '*';
            this.PasswordTextbox.Size = new System.Drawing.Size(100, 20);
            this.PasswordTextbox.TabIndex = 20;
            this.PasswordTextbox.UseSystemPasswordChar = true;
            this.PasswordTextbox.WordWrap = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(13, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 19;
            this.label4.Text = "Пароль";
            // 
            // cbAccess
            // 
            this.AccessCombobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.AccessCombobox.FormattingEnabled = true;
            this.AccessCombobox.Items.AddRange(new object[] {
            "Пользователь",
            "Администратор",
            "Энергонадзор",
            "Служебный пользователь"});
            this.AccessCombobox.Location = new System.Drawing.Point(113, 104);
            this.AccessCombobox.Name = "cbAccess";
            this.AccessCombobox.Size = new System.Drawing.Size(209, 21);
            this.AccessCombobox.TabIndex = 18;
          
            // 
            // lAccess
            // 
            this.AccessLabel.AutoSize = true;
            this.AccessLabel.Location = new System.Drawing.Point(13, 107);
            this.AccessLabel.Name = "lAccess";
            this.AccessLabel.Size = new System.Drawing.Size(94, 13);
            this.AccessLabel.TabIndex = 17;
            this.AccessLabel.Text = "Уровень доступа";
            // 
            // frmConnect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 270);
            this.ControlBox = false;
            this.Controls.Add(this.ConnectTabControl);
            this.Controls.Add(this.ConnectButton);
            this.Controls.Add(this.CancelButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmConnect";
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

