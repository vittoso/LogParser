using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogParserApp.Controls
{
    public partial class DateAndTimePicker : UserControl
    {
        public event EventHandler? ValueChanged;

        public DateAndTimePicker()
        {
            InitializeComponent();


            dtpDate.ValueChanged += DtpDate_ValueChanged;
            dtpTime.ValueChanged += DtpTime_ValueChanged;

            dtpDate.CloseUp += DtpDate_CloseUp;
        }

        private void DtpDate_CloseUp(object? sender, EventArgs e)
        {
            ValueChanged?.Invoke(this, e);
        }

        private void DtpTime_ValueChanged(object? sender, EventArgs e)
        {
            ValueChanged?.Invoke(this, e);
        }

        private void DtpDate_ValueChanged(object? sender, EventArgs e)
        {
            if (dtpDate.Value.Date.Year < 2000)
                return;

            ValueChanged?.Invoke(this, e);
        }

        public DateTime Value
        {
            get { return dtpDate.Value.Date + dtpTime.Value.TimeOfDay; }
            set { dtpDate.Value = value; dtpTime.Value = value; }
        }
    }
}
