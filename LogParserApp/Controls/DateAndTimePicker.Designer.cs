namespace LogParserApp.Controls
{
    partial class DateAndTimePicker
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tableLayoutPanel1 = new TableLayoutPanel();
            dtpDate = new DateTimePicker();
            dtpTime = new DateTimePicker();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 3;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 60F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 6F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 40F));
            tableLayoutPanel1.Controls.Add(dtpDate, 0, 0);
            tableLayoutPanel1.Controls.Add(dtpTime, 2, 0);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 1;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Size = new Size(543, 32);
            tableLayoutPanel1.TabIndex = 0;
            // 
            // dtpDate
            // 
            dtpDate.Dock = DockStyle.Fill;
            dtpDate.Format = DateTimePickerFormat.Short;
            dtpDate.Location = new Point(3, 3);
            dtpDate.Name = "dtpDate";
            dtpDate.Size = new Size(316, 23);
            dtpDate.TabIndex = 0;
            // 
            // dtpTime
            // 
            dtpTime.Dock = DockStyle.Fill;
            dtpTime.Format = DateTimePickerFormat.Time;
            dtpTime.Location = new Point(331, 3);
            dtpTime.Name = "dtpTime";
            dtpTime.ShowUpDown = true;
            dtpTime.Size = new Size(209, 23);
            dtpTime.TabIndex = 1;
            // 
            // DateAndTimePicker
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tableLayoutPanel1);
            Name = "DateAndTimePicker";
            Size = new Size(543, 32);
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tableLayoutPanel1;
        private DateTimePicker dtpDate;
        private DateTimePicker dtpTime;
    }
}
