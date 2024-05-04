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
        private DataGridViewColumn colData;
        private DataGridViewColumn colSource;
        private DataGridViewColumn colTid;
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
            dataGridView1.CellFormatting += DataGridView1_CellFormatting;
            dtpStart.ValueChanged += DtpStart_ValueChanged;
            dtpEnd.ValueChanged += DtpEnd_ValueChanged;


            // Get the default DateTime format for the current culture
            string defaultDateTimeFormat = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern + " " + CultureInfo.CurrentCulture.DateTimeFormat.LongTimePattern;

            // Append milliseconds format specifier
            defaultDateTimeFormatWithMilliseconds = defaultDateTimeFormat.Replace("ss", "ss.fff");

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
            InitializeDataGridView();

            var view = currentSession.GetView(dtpStart.Value, dtpEnd.Value);
            ShowView(view);
        }

        private void InitializeDataGridView()
        {

            // Add columns to DataGridView
            dataGridView1.Columns.Add("Id", "Id");
            colId = dataGridView1.Columns["Id"];
            colId.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells; ;
            dataGridView1.Columns.Add("Timestamp", "Timestamp");
            colTimestamp = dataGridView1.Columns["Timestamp"];
            colTimestamp.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns.Add("Source", "Source");
            colSource = dataGridView1.Columns["Source"];
            colSource.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns.Add("Tid", "TID");
            colTid = dataGridView1.Columns["Tid"];
            colTid.AutoSizeMode = DataGridViewAutoSizeColumnMode.AllCells;
            dataGridView1.Columns.Add("Data", "Data");
            colData = dataGridView1.Columns["Data"];
            colData.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
        }

        private void DtpEnd_ValueChanged(object? sender, EventArgs e)
        {
            if (currentSession != null)
            {
                var view = currentSession.GetView(dtpStart.Value, dtpEnd.Value);
                ShowView(view);
            }
        }

        private void DtpStart_ValueChanged(object? sender, EventArgs e)
        {
            if (currentSession != null)
            {
                var view = currentSession.GetView(dtpStart.Value, dtpEnd.Value);
                ShowView(view);
            }
        }

        private void ShowView(IReadOnlyDictionary<DateTime, IReadOnlyList<Event>> view)
        {
            dataGridView1.Rows.Clear();
            foreach (var ev in view.Values.SelectMany(a => a))
            {
                dataGridView1.Rows.Add(ev.Id, ev.Id.DateTime, ev.Source, ev.TID,  ev.Data);
            }
            if (dataGridView1.Rows.Count > 0)
            {
                dataGridView1.Sort(colTimestamp, ListSortDirection.Ascending);
                // Select the last row after sorting
                dataGridView1.Rows[dataGridView1.Rows.Count - 1].Selected = true;

                int index = dataGridView1.SelectedRows[0].Index;
                dataGridView1.FirstDisplayedScrollingRowIndex = index;
            }

        }
    }
}
