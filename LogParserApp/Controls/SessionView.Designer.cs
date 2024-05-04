namespace LogParserApp.Controls
{
    partial class SessionView
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
            tlpMain = new TableLayoutPanel();
            pnlSelection = new Panel();
            tlpSelection = new TableLayoutPanel();
            dtpStart = new DateAndTimePicker();
            lblStart = new Label();
            lblEnd = new Label();
            dtpEnd = new DateAndTimePicker();
            dataGridView1 = new DataGridView();
            pblDetails = new Panel();
            tlpMain.SuspendLayout();
            pnlSelection.SuspendLayout();
            tlpSelection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // tlpMain
            // 
            tlpMain.ColumnCount = 2;
            tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 23.9952717F));
            tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 76.00473F));
            tlpMain.Controls.Add(pnlSelection, 0, 0);
            tlpMain.Controls.Add(dataGridView1, 1, 0);
            tlpMain.Controls.Add(pblDetails, 0, 1);
            tlpMain.Dock = DockStyle.Fill;
            tlpMain.Location = new Point(0, 0);
            tlpMain.Name = "tlpMain";
            tlpMain.RowCount = 2;
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 50F));
            tlpMain.Size = new Size(846, 423);
            tlpMain.TabIndex = 0;
            // 
            // pnlSelection
            // 
            pnlSelection.Controls.Add(tlpSelection);
            pnlSelection.Dock = DockStyle.Fill;
            pnlSelection.Location = new Point(3, 3);
            pnlSelection.Name = "pnlSelection";
            pnlSelection.Size = new Size(197, 205);
            pnlSelection.TabIndex = 1;
            // 
            // tlpSelection
            // 
            tlpSelection.ColumnCount = 1;
            tlpSelection.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tlpSelection.Controls.Add(dtpStart, 0, 1);
            tlpSelection.Controls.Add(lblStart, 0, 0);
            tlpSelection.Controls.Add(lblEnd, 0, 2);
            tlpSelection.Controls.Add(dtpEnd, 0, 3);
            tlpSelection.Dock = DockStyle.Fill;
            tlpSelection.Location = new Point(0, 0);
            tlpSelection.Name = "tlpSelection";
            tlpSelection.RowCount = 5;
            tlpSelection.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlpSelection.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tlpSelection.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlpSelection.RowStyles.Add(new RowStyle(SizeType.Absolute, 30F));
            tlpSelection.RowStyles.Add(new RowStyle());
            tlpSelection.Size = new Size(197, 205);
            tlpSelection.TabIndex = 0;
            // 
            // dtpStart
            // 
            dtpStart.Dock = DockStyle.Fill;
            dtpStart.Location = new Point(3, 23);
            dtpStart.Name = "dtpStart";
            dtpStart.Size = new Size(191, 24);
            dtpStart.TabIndex = 0;
            dtpStart.Value = new DateTime(2024, 5, 2, 15, 36, 0, 0);
            // 
            // lblStart
            // 
            lblStart.AutoSize = true;
            lblStart.Dock = DockStyle.Fill;
            lblStart.Location = new Point(3, 0);
            lblStart.Name = "lblStart";
            lblStart.Size = new Size(191, 20);
            lblStart.TabIndex = 1;
            lblStart.Text = "Start:";
            // 
            // lblEnd
            // 
            lblEnd.AutoSize = true;
            lblEnd.Dock = DockStyle.Fill;
            lblEnd.Location = new Point(3, 50);
            lblEnd.Name = "lblEnd";
            lblEnd.Size = new Size(191, 20);
            lblEnd.TabIndex = 2;
            lblEnd.Text = "End:";
            // 
            // dtpEnd
            // 
            dtpEnd.Dock = DockStyle.Fill;
            dtpEnd.Location = new Point(3, 73);
            dtpEnd.Name = "dtpEnd";
            dtpEnd.Size = new Size(191, 24);
            dtpEnd.TabIndex = 3;
            dtpEnd.Value = new DateTime(2024, 5, 4, 15, 48, 7, 12);
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(206, 3);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.Size = new Size(637, 205);
            dataGridView1.TabIndex = 2;
            // 
            // pblDetails
            // 
            tlpMain.SetColumnSpan(pblDetails, 2);
            pblDetails.Dock = DockStyle.Fill;
            pblDetails.Location = new Point(3, 214);
            pblDetails.Name = "pblDetails";
            pblDetails.Size = new Size(840, 206);
            pblDetails.TabIndex = 3;
            // 
            // SessionView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tlpMain);
            Name = "SessionView";
            Size = new Size(846, 423);
            tlpMain.ResumeLayout(false);
            pnlSelection.ResumeLayout(false);
            tlpSelection.ResumeLayout(false);
            tlpSelection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlpMain;
        private Panel pnlSelection;
        private TableLayoutPanel tlpSelection;
        private DateAndTimePicker dtpStart;
        private Label lblStart;
        private Label lblEnd;
        private DateAndTimePicker dtpEnd;
        private DataGridView dataGridView1;
        private Panel pblDetails;
    }
}
