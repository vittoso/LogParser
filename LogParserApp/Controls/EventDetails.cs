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
using LogParser.Engine;

namespace LogParserApp.Controls
{
    public partial class EventDetails : UserControl
    {
        private readonly string defaultDateTimeFormatWithMilliseconds;

        public EventDetails()
        {
            InitializeComponent();

            // Get the default DateTime format for the current culture
            string defaultDateTimeFormat = CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern + " " + CultureInfo.CurrentCulture.DateTimeFormat.LongTimePattern;

            // Append milliseconds format specifier
            defaultDateTimeFormatWithMilliseconds = defaultDateTimeFormat.Replace("ss", "ss.fff");
        }


        public void ShowEvent(Event? ev)
        {
            if (ev == null)
            {
                this.lblIdValue.Text = null;
                this.lblTimestampValue.Text = null;
                this.lblMessageValue.Text = null;
                this.lblLogLevelValue.Text = null;
                this.lblLocationValue.Text = null;
                this.lblSourceValue.Text = null;
                this.lblTIDValue.Text = null;
                return;
            }
            this.lblIdValue.Text = ev.Id.ToString();
            this.lblTimestampValue.Text = ev.Id.DateTime.ToString(defaultDateTimeFormatWithMilliseconds);
            this.lblMessageValue.Text = ev.Message;
            this.lblLogLevelValue.Text = ev.LogLevel.ToString();
            this.lblLocationValue.Text = ev.Location;
            this.lblSourceValue.Text = ev.Source;
            this.lblTIDValue.Text = ev.TID.ToString();
        }
    }
}
