namespace OblikConfigurator
{
    partial class frmConnect
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
            this.lblPort = new System.Windows.Forms.Label();
            this.lblAddr = new System.Windows.Forms.Label();
            this.cbPort = new System.Windows.Forms.ComboBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.numAddr = new System.Windows.Forms.NumericUpDown();
            this.tcConnect = new System.Windows.Forms.TabControl();
            this.tDirect = new System.Windows.Forms.TabPage();
            this.btnUpdate = new System.Windows.Forms.Button();
            this.tDB = new System.Windows.Forms.TabPage();
            this.tSettings = new System.Windows.Forms.TabPage();
            this.tbPassword = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbAccess = new System.Windows.Forms.ComboBox();
            this.lAccess = new System.Windows.Forms.Label();
            this.nRepeats = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.nTimeout = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.cbBaudrate = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numAddr)).BeginInit();
            this.tcConnect.SuspendLayout();
            this.tDirect.SuspendLayout();
            this.tSettings.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nRepeats)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nTimeout)).BeginInit();
            this.SuspendLayout();
            // 
            // lblPort
            // 
            this.lblPort.AutoSize = true;
            this.lblPort.Location = new System.Drawing.Point(43, 28);
            this.lblPort.Name = "lblPort";
            this.lblPort.Size = new System.Drawing.Size(32, 13);
            this.lblPort.TabIndex = 0;
            this.lblPort.Text = "Порт";
            // 
            // lblAddr
            // 
            this.lblAddr.AutoSize = true;
            this.lblAddr.Location = new System.Drawing.Point(9, 52);
            this.lblAddr.Name = "lblAddr";
            this.lblAddr.Size = new System.Drawing.Size(66, 13);
            this.lblAddr.TabIndex = 1;
            this.lblAddr.Text = "Адрес(HEX)";
            // 
            // cbPort
            // 
            this.cbPort.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPort.FormattingEnabled = true;
            this.cbPort.Location = new System.Drawing.Point(81, 26);
            this.cbPort.Name = "cbPort";
            this.cbPort.Size = new System.Drawing.Size(82, 21);
            this.cbPort.TabIndex = 2;
            this.cbPort.SelectedIndexChanged += new System.EventHandler(this.cbPort_SelectedIndexChanged);
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(168, 237);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(151, 23);
            this.btnConnect.TabIndex = 3;
            this.btnConnect.Text = "Соединение";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(325, 237);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(151, 23);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Отмена";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // numAddr
            // 
            this.numAddr.Hexadecimal = true;
            this.numAddr.Location = new System.Drawing.Point(81, 52);
            this.numAddr.Maximum = new decimal(new int[] {
            255,
            0,
            0,
            0});
            this.numAddr.Name = "numAddr";
            this.numAddr.Size = new System.Drawing.Size(82, 20);
            this.numAddr.TabIndex = 6;
            this.numAddr.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numAddr.ValueChanged += new System.EventHandler(this.numAddr_ValueChanged);
            // 
            // tcConnect
            // 
            this.tcConnect.Controls.Add(this.tDirect);
            this.tcConnect.Controls.Add(this.tDB);
            this.tcConnect.Controls.Add(this.tSettings);
            this.tcConnect.Location = new System.Drawing.Point(12, 12);
            this.tcConnect.Name = "tcConnect";
            this.tcConnect.SelectedIndex = 0;
            this.tcConnect.Size = new System.Drawing.Size(468, 219);
            this.tcConnect.TabIndex = 7;
            // 
            // tDirect
            // 
            this.tDirect.Controls.Add(this.btnUpdate);
            this.tDirect.Controls.Add(this.cbPort);
            this.tDirect.Controls.Add(this.numAddr);
            this.tDirect.Controls.Add(this.lblPort);
            this.tDirect.Controls.Add(this.lblAddr);
            this.tDirect.Location = new System.Drawing.Point(4, 22);
            this.tDirect.Name = "tDirect";
            this.tDirect.Padding = new System.Windows.Forms.Padding(3);
            this.tDirect.Size = new System.Drawing.Size(460, 193);
            this.tDirect.TabIndex = 0;
            this.tDirect.Text = "Прямое соединение";
            this.tDirect.UseVisualStyleBackColor = true;
            // 
            // btnUpdate
            // 
            this.btnUpdate.BackgroundImage = global::OblikConfigurator.Properties.Resources.refresh_23x23;
            this.btnUpdate.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnUpdate.Location = new System.Drawing.Point(169, 25);
            this.btnUpdate.Margin = new System.Windows.Forms.Padding(0);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.Size = new System.Drawing.Size(23, 23);
            this.btnUpdate.TabIndex = 7;
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // tDB
            // 
            this.tDB.Location = new System.Drawing.Point(4, 22);
            this.tDB.Name = "tDB";
            this.tDB.Padding = new System.Windows.Forms.Padding(3);
            this.tDB.Size = new System.Drawing.Size(460, 193);
            this.tDB.TabIndex = 1;
            this.tDB.Text = "БД Облик";
            this.tDB.UseVisualStyleBackColor = true;
            // 
            // tSettings
            // 
            this.tSettings.Controls.Add(this.tbPassword);
            this.tSettings.Controls.Add(this.label4);
            this.tSettings.Controls.Add(this.cbAccess);
            this.tSettings.Controls.Add(this.lAccess);
            this.tSettings.Controls.Add(this.nRepeats);
            this.tSettings.Controls.Add(this.label2);
            this.tSettings.Controls.Add(this.nTimeout);
            this.tSettings.Controls.Add(this.label3);
            this.tSettings.Controls.Add(this.cbBaudrate);
            this.tSettings.Controls.Add(this.label1);
            this.tSettings.Location = new System.Drawing.Point(4, 22);
            this.tSettings.Name = "tSettings";
            this.tSettings.Size = new System.Drawing.Size(460, 193);
            this.tSettings.TabIndex = 2;
            this.tSettings.Text = "Параметры соединения";
            this.tSettings.UseVisualStyleBackColor = true;
            // 
            // tbPassword
            // 
            this.tbPassword.Location = new System.Drawing.Point(169, 110);
            this.tbPassword.MaxLength = 8;
            this.tbPassword.Name = "tbPassword";
            this.tbPassword.PasswordChar = '*';
            this.tbPassword.Size = new System.Drawing.Size(100, 20);
            this.tbPassword.TabIndex = 11;
            this.tbPassword.UseSystemPasswordChar = true;
            this.tbPassword.WordWrap = false;
            this.tbPassword.TextChanged += new System.EventHandler(this.tbPassword_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 113);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Пароль";
            // 
            // cbAccess
            // 
            this.cbAccess.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAccess.FormattingEnabled = true;
            this.cbAccess.Items.AddRange(new object[] {
            "Пользователь",
            "Администратор",
            "Энергонадзор",
            "Служебный пользователь"});
            this.cbAccess.Location = new System.Drawing.Point(168, 83);
            this.cbAccess.Name = "cbAccess";
            this.cbAccess.Size = new System.Drawing.Size(209, 21);
            this.cbAccess.TabIndex = 9;
            this.cbAccess.SelectedIndexChanged += new System.EventHandler(this.cbAccess_SelectedIndexChanged);
            // 
            // lAccess
            // 
            this.lAccess.AutoSize = true;
            this.lAccess.Location = new System.Drawing.Point(3, 86);
            this.lAccess.Name = "lAccess";
            this.lAccess.Size = new System.Drawing.Size(94, 13);
            this.lAccess.TabIndex = 8;
            this.lAccess.Text = "Уровень доступа";
            // 
            // nRepeats
            // 
            this.nRepeats.Location = new System.Drawing.Point(169, 57);
            this.nRepeats.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.nRepeats.Name = "nRepeats";
            this.nRepeats.Size = new System.Drawing.Size(120, 20);
            this.nRepeats.TabIndex = 6;
            this.nRepeats.ValueChanged += new System.EventHandler(this.nRepeats_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Повторы соединения";
            // 
            // nTimeout
            // 
            this.nTimeout.Location = new System.Drawing.Point(169, 31);
            this.nTimeout.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.nTimeout.Name = "nTimeout";
            this.nTimeout.Size = new System.Drawing.Size(120, 20);
            this.nTimeout.TabIndex = 4;
            this.nTimeout.ValueChanged += new System.EventHandler(this.nTimeout_ValueChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 33);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Таймаут, мс";
            // 
            // cbBaudrate
            // 
            this.cbBaudrate.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbBaudrate.FormattingEnabled = true;
            this.cbBaudrate.Location = new System.Drawing.Point(169, 6);
            this.cbBaudrate.Name = "cbBaudrate";
            this.cbBaudrate.Size = new System.Drawing.Size(121, 21);
            this.cbBaudrate.TabIndex = 1;
            this.cbBaudrate.SelectedIndexChanged += new System.EventHandler(this.cbBaudrate_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Скорость соединения, бод";
            // 
            // frmConnect
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(491, 270);
            this.ControlBox = false;
            this.Controls.Add(this.tcConnect);
            this.Controls.Add(this.btnConnect);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "frmConnect";
            this.Text = "Соединение";
            ((System.ComponentModel.ISupportInitialize)(this.numAddr)).EndInit();
            this.tcConnect.ResumeLayout(false);
            this.tDirect.ResumeLayout(false);
            this.tDirect.PerformLayout();
            this.tSettings.ResumeLayout(false);
            this.tSettings.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.nRepeats)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nTimeout)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label lblPort;
        private System.Windows.Forms.Label lblAddr;
        private System.Windows.Forms.ComboBox cbPort;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.NumericUpDown numAddr;
        private System.Windows.Forms.TabControl tcConnect;
        private System.Windows.Forms.TabPage tDirect;
        private System.Windows.Forms.TabPage tDB;
        private System.Windows.Forms.TabPage tSettings;
        private System.Windows.Forms.ComboBox cbBaudrate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown nTimeout;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox tbPassword;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbAccess;
        private System.Windows.Forms.Label lAccess;
        private System.Windows.Forms.NumericUpDown nRepeats;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnUpdate;
    }
}

