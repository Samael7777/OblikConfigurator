namespace OblikConfigurator
{
    partial class FormEvents
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormEvents));
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonClose = new System.Windows.Forms.Button();
            this.dataGridEvents = new System.Windows.Forms.DataGridView();
            this.ColTimeStamp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ColEvent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEvents)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.dataGridEvents);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(800, 409);
            this.panel1.TabIndex = 0;
            // 
            // buttonClose
            // 
            this.buttonClose.Location = new System.Drawing.Point(713, 415);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(75, 23);
            this.buttonClose.TabIndex = 0;
            this.buttonClose.Text = "Закрыть";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // dataGridEvents
            // 
            this.dataGridEvents.AllowUserToAddRows = false;
            this.dataGridEvents.AllowUserToDeleteRows = false;
            this.dataGridEvents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridEvents.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ColTimeStamp,
            this.ColEvent});
            this.dataGridEvents.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridEvents.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dataGridEvents.Location = new System.Drawing.Point(0, 0);
            this.dataGridEvents.Name = "dataGridEvents";
            this.dataGridEvents.Size = new System.Drawing.Size(800, 409);
            this.dataGridEvents.TabIndex = 1;
            // 
            // ColTimeStamp
            // 
            this.ColTimeStamp.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.ColTimeStamp.DefaultCellStyle = dataGridViewCellStyle5;
            this.ColTimeStamp.FillWeight = 30F;
            this.ColTimeStamp.HeaderText = "Метка времени";
            this.ColTimeStamp.Name = "ColTimeStamp";
            // 
            // ColEvent
            // 
            this.ColEvent.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            this.ColEvent.DefaultCellStyle = dataGridViewCellStyle6;
            this.ColEvent.FillWeight = 70F;
            this.ColEvent.HeaderText = "Событие";
            this.ColEvent.Name = "ColEvent";
            // 
            // FormEvents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormEvents";
            this.Text = "Журнал событий";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridEvents)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.DataGridView dataGridEvents;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColTimeStamp;
        private System.Windows.Forms.DataGridViewTextBoxColumn ColEvent;
    }
}