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
            tlpSelection = new TableLayoutPanel();
            dtpStart = new DateAndTimePicker();
            lblStart = new Label();
            lblEnd = new Label();
            dtpEnd = new DateAndTimePicker();
            dataGridView1 = new DataGridView();
            eventDetails = new EventDetails();
            splitter1 = new Splitter();
            splitContainerMain = new SplitContainer();
            splitContainerTop = new SplitContainer();
            tlpSelection.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)splitContainerMain).BeginInit();
            splitContainerMain.Panel1.SuspendLayout();
            splitContainerMain.Panel2.SuspendLayout();
            splitContainerMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)splitContainerTop).BeginInit();
            splitContainerTop.Panel1.SuspendLayout();
            splitContainerTop.Panel2.SuspendLayout();
            splitContainerTop.SuspendLayout();
            SuspendLayout();
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
            tlpSelection.Size = new Size(200, 240);
            tlpSelection.TabIndex = 0;
            // 
            // dtpStart
            // 
            dtpStart.Dock = DockStyle.Fill;
            dtpStart.Location = new Point(3, 23);
            dtpStart.Name = "dtpStart";
            dtpStart.Size = new Size(194, 24);
            dtpStart.TabIndex = 0;
            dtpStart.Value = new DateTime(2024, 5, 2, 15, 36, 0, 0);
            // 
            // lblStart
            // 
            lblStart.AutoSize = true;
            lblStart.Dock = DockStyle.Fill;
            lblStart.Location = new Point(3, 0);
            lblStart.Name = "lblStart";
            lblStart.Size = new Size(194, 20);
            lblStart.TabIndex = 1;
            lblStart.Text = "Start:";
            // 
            // lblEnd
            // 
            lblEnd.AutoSize = true;
            lblEnd.Dock = DockStyle.Fill;
            lblEnd.Location = new Point(3, 50);
            lblEnd.Name = "lblEnd";
            lblEnd.Size = new Size(194, 20);
            lblEnd.TabIndex = 2;
            lblEnd.Text = "End:";
            // 
            // dtpEnd
            // 
            dtpEnd.Dock = DockStyle.Fill;
            dtpEnd.Location = new Point(3, 73);
            dtpEnd.Name = "dtpEnd";
            dtpEnd.Size = new Size(194, 24);
            dtpEnd.TabIndex = 3;
            dtpEnd.Value = new DateTime(2024, 5, 4, 15, 48, 7, 12);
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Dock = DockStyle.Fill;
            dataGridView1.Location = new Point(0, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.ReadOnly = true;
            dataGridView1.Size = new Size(639, 240);
            dataGridView1.TabIndex = 2;
            // 
            // eventDetails
            // 
            eventDetails.Dock = DockStyle.Fill;
            eventDetails.Location = new Point(0, 0);
            eventDetails.Name = "eventDetails";
            eventDetails.Size = new Size(843, 179);
            eventDetails.TabIndex = 0;
            // 
            // splitter1
            // 
            splitter1.Location = new Point(0, 0);
            splitter1.Name = "splitter1";
            splitter1.Size = new Size(3, 423);
            splitter1.TabIndex = 1;
            splitter1.TabStop = false;
            // 
            // splitContainerMain
            // 
            splitContainerMain.Dock = DockStyle.Fill;
            splitContainerMain.Location = new Point(3, 0);
            splitContainerMain.Name = "splitContainerMain";
            splitContainerMain.Orientation = Orientation.Horizontal;
            // 
            // splitContainerMain.Panel1
            // 
            splitContainerMain.Panel1.Controls.Add(splitContainerTop);
            splitContainerMain.Panel1MinSize = 200;
            // 
            // splitContainerMain.Panel2
            // 
            splitContainerMain.Panel2.Controls.Add(eventDetails);
            splitContainerMain.Size = new Size(843, 423);
            splitContainerMain.SplitterDistance = 240;
            splitContainerMain.TabIndex = 2;
            // 
            // splitContainerTop
            // 
            splitContainerTop.Dock = DockStyle.Fill;
            splitContainerTop.Location = new Point(0, 0);
            splitContainerTop.Name = "splitContainerTop";
            // 
            // splitContainerTop.Panel1
            // 
            splitContainerTop.Panel1.Controls.Add(tlpSelection);
            splitContainerTop.Panel1MinSize = 200;
            // 
            // splitContainerTop.Panel2
            // 
            splitContainerTop.Panel2.Controls.Add(dataGridView1);
            splitContainerTop.Size = new Size(843, 240);
            splitContainerTop.SplitterDistance = 200;
            splitContainerTop.TabIndex = 0;
            // 
            // SessionView
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(splitContainerMain);
            Controls.Add(splitter1);
            Name = "SessionView";
            Size = new Size(846, 423);
            tlpSelection.ResumeLayout(false);
            tlpSelection.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            splitContainerMain.Panel1.ResumeLayout(false);
            splitContainerMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerMain).EndInit();
            splitContainerMain.ResumeLayout(false);
            splitContainerTop.Panel1.ResumeLayout(false);
            splitContainerTop.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)splitContainerTop).EndInit();
            splitContainerTop.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private TableLayoutPanel tlpSelection;
        private DateAndTimePicker dtpStart;
        private Label lblStart;
        private Label lblEnd;
        private DateAndTimePicker dtpEnd;
        private DataGridView dataGridView1;
        private EventDetails eventDetails;
        private Splitter splitter1;
        private SplitContainer splitContainerMain;
        private SplitContainer splitContainerTop;
    }
}
