using LogParser.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static LogParser.Engine.Event;

namespace LogParserApp.Controls
{
    public partial class SessionView : UserControl
    {
        private LogParserSession currentSession;
        private DataGridViewColumn colId;
        private DataGridViewColumn colTimestamp;
        private DataGridViewColumn colMessage;
        private DataGridViewColumn colSource;
        private DataGridViewColumn colTid;
        private DataGridViewColumn colLogLevel;
        private DataGridViewColumn colLocation;
        private DataGridViewColumn colCtx;
        private LogView view;
        private readonly string defaultDateTimeFormatWithMilliseconds;

        public SessionView()
        {
            InitializeComponent();

            var now = DateTime.Now;
            this.dtpStart.Value = now.AddHours(-1);
            this.dtpEnd.Value = now;

            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect; // Set selection mode to full row
            dataGridView1.MultiSelect = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.ReadOnly = true;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.CellFormatting += DataGridView1_CellFormatting;
            dataGridView1.RowPrePaint += DataGridView1_RowPrePaint;
            dataGridView1.SelectionChanged += DataGridView1_SelectionChanged;
            dtpStart.ValueChanged += DtpStart_ValueChanged;
            dtpEnd.ValueChanged += DtpEnd_ValueChanged;


            // Get the default DateTime format for the current culture
            string defaultDateTimeFormat = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern + " " + CultureInfo.CurrentCulture.DateTimeFormat.LongTimePattern;

            // Append milliseconds format specifier
            defaultDateTimeFormatWithMilliseconds = defaultDateTimeFormat.Replace("ss", "ss.fff");

            InitializeDataGridView();

        }

        private void DataGridView1_SelectionChanged(object? sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0 && (dataGridView1.SelectedRows[0].Cells[colCtx.Name].Value is Event ev))
                eventDetails.ShowEvent(ev);
            else
                eventDetails.ShowEvent(null);
        }

        private void DataGridView1_RowPrePaint(object? sender, DataGridViewRowPrePaintEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            DataGridViewCell cell = row.Cells[colLogLevel.Name];
            if (cell.Value == null || !(cell.Value is LogLevel logLevel))
                return;

            switch (logLevel)
            {
                case LogLevel.Fatal:
                    row.DefaultCellStyle.BackColor = Color.Red;
                    row.DefaultCellStyle.ForeColor = Color.White;
                    break;
                case LogLevel.Error:
                    row.DefaultCellStyle.BackColor = Color.Red;
                    row.DefaultCellStyle.ForeColor = Color.White;
                    break;
                case LogLevel.Warning:
                    row.DefaultCellStyle.BackColor = Color.Yellow; break;
            }
        }

        private void DataGridView1_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex < 0 || e.RowIndex < 0)
                return;

            var column = dataGridView1.Columns[e.ColumnIndex];

            if (column == colTimestamp)
            {
                if (e.Value != null && e.Value is DateTime)
                {
                    DateTime dateTimeValue = (DateTime)e.Value;
                    e.Value = dateTimeValue.ToString(defaultDateTimeFormatWithMilliseconds);
                    e.FormattingApplied = true;
                }
            }
        }

        public void Init(LogParserSession currentSession)
        {
            this.currentSession = currentSession;

            var view = currentSession.GetView(dtpStart.Value, dtpEnd.Value);
            ShowView(view);
        }

        private void InitializeDataGridView()
        {
            // Add columns to DataGridView
            dataGridView1.Columns.Add("Ctx", "Ctx");
            colCtx = dataGridView1.Columns["Ctx"];
            colCtx.Visible = false;
            dataGridView1.Columns.Add("Id", "Id");
            colId = dataGridView1.Columns["Id"];
            colId.Visible = false;
            dataGridView1.Columns.Add("Timestamp", "Timestamp");
            colTimestamp = dataGridView1.Columns["Timestamp"];
            colTimestamp.MinimumWidth = 140;
            dataGridView1.Columns.Add("LogLevel", "LogLevel");
            colLogLevel = dataGridView1.Columns["LogLevel"];
            colLogLevel.MinimumWidth = 70;
            colLogLevel.Width = 70;
            dataGridView1.Columns.Add("Source", "Source");
            colSource = dataGridView1.Columns["Source"];
            colSource.MinimumWidth = 120;
            dataGridView1.Columns.Add("Tid", "TID");
            colTid = dataGridView1.Columns["Tid"];
            colTid.MinimumWidth = 40;
            colTid.Width = 40;
            dataGridView1.Columns.Add("Location", "Location");
            colLocation = dataGridView1.Columns["Location"];
            colLocation.MinimumWidth = 60;
            dataGridView1.Columns.Add("Message", "Message");
            colMessage = dataGridView1.Columns["Message"];
            colMessage.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void DtpEnd_ValueChanged(object? sender, EventArgs e)
        {
            if (currentSession != null && dtpEnd.Value != this.view?.End)
            {
                this.view = currentSession.GetView(dtpStart.Value, dtpEnd.Value);
                ShowView(view);
            }
        }

        private void DtpStart_ValueChanged(object? sender, EventArgs e)
        {
            if (currentSession != null && dtpStart.Value != this.view?.Start)
            {
                this.view = currentSession.GetView(dtpStart.Value, dtpEnd.Value);
                ShowView(view);
            }
        }

        private void ShowView(LogView view)
        {
            dataGridView1.SuspendLayout(); // Suspend layout updates

            dataGridView1.Rows.Clear();
            List<DataGridViewRow> rowsToAdd = new List<DataGridViewRow>();
            foreach (var ev in view.Values.SelectMany(a => a))
            {
                rowsToAdd.Add(new DataGridViewRow
                {
                    Cells =
                    {
                        new DataGridViewTextBoxCell {Value = ev},
                        new DataGridViewTextBoxCell {Value = ev.Id},
                        new DataGridViewTextBoxCell {Value = ev.Id.DateTime},
                        new DataGridViewTextBoxCell {Value = ev.LogLevel},
                        new DataGridViewTextBoxCell {Value = ev.Source},
                        new DataGridViewTextBoxCell {Value = ev.TID},
                        new DataGridViewTextBoxCell {Value = ev.Location},
                        new DataGridViewTextBoxCell {Value = ev.Message}
                    }
                });
            }

            dataGridView1.Rows.AddRange(rowsToAdd.ToArray());

            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Sort(colTimestamp, ListSortDirection.Ascending);
                // Select the last row after sorting
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Selected = true;

                int index = dataGridView1.SelectedRows[0].Index;
                dataGridView1.FirstDisplayedScrollingRowIndex = index;
            }
            dataGridView1.ResumeLayout(); // Resume layout updates

        }
    }
}
