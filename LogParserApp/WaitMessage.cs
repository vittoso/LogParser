using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogParserApp
{
    public class WaitMessage : Panel
    {
        private Label waitLabel;

        public WaitMessage()
        {
            this.BackColor = Color.FromArgb(100, Color.Gray); // Semi-transparent gray
            this.Dock = DockStyle.Fill;
            this.Visible = false;

            // Create a label to display the wait message
            waitLabel = new Label();
            waitLabel.Text = "Please wait...";
            waitLabel.Dock = DockStyle.Fill;
            waitLabel.AutoSize = false;
            waitLabel.Font = new Font(waitLabel.Font.FontFamily, 16, FontStyle.Bold);
            waitLabel.ForeColor = Color.Black;
            waitLabel.TextAlign = ContentAlignment.MiddleCenter;
         //   waitLabel.Location = new Point((ClientSize.Width - waitLabel.Width) / 2, (ClientSize.Height - waitLabel.Height) / 2);

            // Add the label to the overlay panel
            Controls.Add(waitLabel);

            // Set the control styles to enable transparency
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            SetStyle(ControlStyles.Opaque, true);
        }

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            base.OnPaintBackground(e);

            // Draw a semi-transparent gray rectangle to simulate transparency
            using (Brush brush = new SolidBrush(Color.FromArgb(100, Color.Gray)))
            {
                e.Graphics.FillRectangle(brush, ClientRectangle);
            }
        }

        public static void ShowWaitMessage(Control parent, string text)
        {
            var overlayPanel = parent.Controls.OfType<WaitMessage>().FirstOrDefault();
            if (overlayPanel == null)
            {
                overlayPanel = new WaitMessage();
                parent.Controls.Add(overlayPanel);

            }
            // Set the overlay panel's Z-order to be in front of other controls
            overlayPanel.BringToFront();
            overlayPanel.waitLabel.Text = text;
            overlayPanel.Visible = true;
  
        }
        public static void HideWaitMessage(Control parent)
        {
            var overlayPanel = parent.Controls.OfType<WaitMessage>().FirstOrDefault();
            if (overlayPanel == null)
            {
                return;
            }

            overlayPanel.Visible = false;


        }

    }
}
