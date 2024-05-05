namespace LogParserApp.Controls
{
    partial class EventDetails
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
            lblId = new Label();
            lblIdValue = new Label();
            lblTimeStamp = new Label();
            lblTimestampValue = new Label();
            lblMessage = new Label();
            panel1 = new Panel();
            lblMessageValue = new TextBox();
            lblTID = new Label();
            lblTIDValue = new Label();
            lblLocation = new Label();
            lblLocationValue = new Label();
            lblLogLevel = new Label();
            lblLogLevelValue = new Label();
            lblSource = new Label();
            lblSourceValue = new Label();
            tlpMain.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // tlpMain
            // 
            tlpMain.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            tlpMain.ColumnCount = 4;
            tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 120F));
            tlpMain.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 50F));
            tlpMain.Controls.Add(lblId, 0, 0);
            tlpMain.Controls.Add(lblIdValue, 1, 0);
            tlpMain.Controls.Add(lblTimeStamp, 0, 1);
            tlpMain.Controls.Add(lblTimestampValue, 1, 1);
            tlpMain.Controls.Add(lblMessage, 0, 4);
            tlpMain.Controls.Add(panel1, 1, 4);
            tlpMain.Controls.Add(lblTID, 0, 2);
            tlpMain.Controls.Add(lblTIDValue, 1, 2);
            tlpMain.Controls.Add(lblLocation, 0, 3);
            tlpMain.Controls.Add(lblLocationValue, 1, 3);
            tlpMain.Controls.Add(lblLogLevel, 2, 1);
            tlpMain.Controls.Add(lblLogLevelValue, 3, 1);
            tlpMain.Controls.Add(lblSource, 2, 2);
            tlpMain.Controls.Add(lblSourceValue, 3, 2);
            tlpMain.Dock = DockStyle.Fill;
            tlpMain.Location = new Point(0, 0);
            tlpMain.Name = "tlpMain";
            tlpMain.RowCount = 5;
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 24F));
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlpMain.RowStyles.Add(new RowStyle(SizeType.Absolute, 20F));
            tlpMain.Size = new Size(825, 431);
            tlpMain.TabIndex = 0;
            // 
            // lblId
            // 
            lblId.AutoSize = true;
            lblId.Dock = DockStyle.Fill;
            lblId.Location = new Point(4, 1);
            lblId.Name = "lblId";
            lblId.Size = new Size(114, 24);
            lblId.TabIndex = 0;
            lblId.Text = "ID:";
            lblId.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblIdValue
            // 
            lblIdValue.AutoSize = true;
            tlpMain.SetColumnSpan(lblIdValue, 3);
            lblIdValue.Dock = DockStyle.Fill;
            lblIdValue.Location = new Point(125, 1);
            lblIdValue.Name = "lblIdValue";
            lblIdValue.Size = new Size(696, 24);
            lblIdValue.TabIndex = 1;
            lblIdValue.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTimeStamp
            // 
            lblTimeStamp.AutoSize = true;
            lblTimeStamp.Dock = DockStyle.Fill;
            lblTimeStamp.Location = new Point(4, 26);
            lblTimeStamp.Name = "lblTimeStamp";
            lblTimeStamp.Size = new Size(114, 24);
            lblTimeStamp.TabIndex = 2;
            lblTimeStamp.Text = "Timestamp:";
            lblTimeStamp.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTimestampValue
            // 
            lblTimestampValue.AutoSize = true;
            lblTimestampValue.Dock = DockStyle.Fill;
            lblTimestampValue.Location = new Point(125, 26);
            lblTimestampValue.Name = "lblTimestampValue";
            lblTimestampValue.Size = new Size(284, 24);
            lblTimestampValue.TabIndex = 3;
            lblTimestampValue.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblMessage
            // 
            lblMessage.AutoSize = true;
            lblMessage.Dock = DockStyle.Fill;
            lblMessage.Location = new Point(4, 101);
            lblMessage.Name = "lblMessage";
            lblMessage.Size = new Size(114, 329);
            lblMessage.TabIndex = 4;
            lblMessage.Text = "Message:";
            // 
            // panel1
            // 
            panel1.AutoScroll = true;
            tlpMain.SetColumnSpan(panel1, 3);
            panel1.Controls.Add(lblMessageValue);
            panel1.Dock = DockStyle.Fill;
            panel1.Location = new Point(125, 104);
            panel1.Name = "panel1";
            panel1.Size = new Size(696, 323);
            panel1.TabIndex = 5;
            // 
            // lblMessageValue
            // 
            lblMessageValue.BackColor = SystemColors.Control;
            lblMessageValue.BorderStyle = BorderStyle.None;
            lblMessageValue.Dock = DockStyle.Fill;
            lblMessageValue.ForeColor = SystemColors.ControlText;
            lblMessageValue.Location = new Point(0, 0);
            lblMessageValue.Multiline = true;
            lblMessageValue.Name = "lblMessageValue";
            lblMessageValue.ReadOnly = true;
            lblMessageValue.ScrollBars = ScrollBars.Vertical;
            lblMessageValue.Size = new Size(696, 323);
            lblMessageValue.TabIndex = 0;
            // 
            // lblTID
            // 
            lblTID.AutoSize = true;
            lblTID.Dock = DockStyle.Fill;
            lblTID.Location = new Point(4, 51);
            lblTID.Name = "lblTID";
            lblTID.Size = new Size(114, 24);
            lblTID.TabIndex = 6;
            lblTID.Text = "TID:";
            lblTID.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblTIDValue
            // 
            lblTIDValue.AutoSize = true;
            lblTIDValue.Dock = DockStyle.Fill;
            lblTIDValue.Location = new Point(125, 51);
            lblTIDValue.Name = "lblTIDValue";
            lblTIDValue.Size = new Size(284, 24);
            lblTIDValue.TabIndex = 7;
            lblTIDValue.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblLocation
            // 
            lblLocation.AutoSize = true;
            lblLocation.Dock = DockStyle.Fill;
            lblLocation.Location = new Point(4, 76);
            lblLocation.Name = "lblLocation";
            lblLocation.Size = new Size(114, 24);
            lblLocation.TabIndex = 8;
            lblLocation.Text = "Location";
            lblLocation.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblLocationValue
            // 
            lblLocationValue.AutoSize = true;
            tlpMain.SetColumnSpan(lblLocationValue, 3);
            lblLocationValue.Dock = DockStyle.Fill;
            lblLocationValue.Location = new Point(125, 76);
            lblLocationValue.Name = "lblLocationValue";
            lblLocationValue.Size = new Size(696, 24);
            lblLocationValue.TabIndex = 9;
            lblLocationValue.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblLogLevel
            // 
            lblLogLevel.AutoSize = true;
            lblLogLevel.Dock = DockStyle.Fill;
            lblLogLevel.Location = new Point(416, 26);
            lblLogLevel.Name = "lblLogLevel";
            lblLogLevel.Size = new Size(114, 24);
            lblLogLevel.TabIndex = 10;
            lblLogLevel.Text = "LogLevel:";
            lblLogLevel.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblLogLevelValue
            // 
            lblLogLevelValue.AutoSize = true;
            lblLogLevelValue.Dock = DockStyle.Fill;
            lblLogLevelValue.Location = new Point(537, 26);
            lblLogLevelValue.Name = "lblLogLevelValue";
            lblLogLevelValue.Size = new Size(284, 24);
            lblLogLevelValue.TabIndex = 11;
            lblLogLevelValue.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblSource
            // 
            lblSource.AutoSize = true;
            lblSource.Dock = DockStyle.Fill;
            lblSource.Location = new Point(416, 51);
            lblSource.Name = "lblSource";
            lblSource.Size = new Size(114, 24);
            lblSource.TabIndex = 12;
            lblSource.Text = "Source:";
            lblSource.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // lblSourceValue
            // 
            lblSourceValue.AutoSize = true;
            lblSourceValue.Dock = DockStyle.Fill;
            lblSourceValue.Location = new Point(537, 51);
            lblSourceValue.Name = "lblSourceValue";
            lblSourceValue.Size = new Size(284, 24);
            lblSourceValue.TabIndex = 13;
            lblSourceValue.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // EventDetails
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(tlpMain);
            Name = "EventDetails";
            Size = new Size(825, 431);
            tlpMain.ResumeLayout(false);
            tlpMain.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TableLayoutPanel tlpMain;
        private Label lblId;
        private Label lblIdValue;
        private Label lblTimeStamp;
        private Label lblTimestampValue;
        private Label lblMessage;
        private Panel panel1;
        private TextBox lblMessageValue;
        private Label lblTID;
        private Label lblTIDValue;
        private Label lblLocation;
        private Label lblLocationValue;
        private Label lblLogLevel;
        private Label lblLogLevelValue;
        private Label lblSource;
        private Label lblSourceValue;
    }
}
