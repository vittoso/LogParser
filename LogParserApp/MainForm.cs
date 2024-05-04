using System.ComponentModel;

namespace LogParserApp
{
    public partial class MainForm : Form
    {
        LogParserSession CurrentSession;

        public MainForm()
        {
            InitializeComponent();


            tsbOpen.Click += TsbOpen_Click;
            sessionView.Enabled = false;

            this.Text = "LogParser";
        }

        protected override async void OnClosing(CancelEventArgs e)
        {
            if (CurrentSession != null)
            {
                if (MessageBox.Show("Would you like to cancel current session?") == DialogResult.OK)
                {
                    await CurrentSession.CancelAsync();
                }
                e.Cancel = false;
            }

            base.OnClosing(e);
        }


        private async void TsbOpen_Click(object? sender, EventArgs e)
        {
            try
            {
                string selectedPath = null;
                using (FolderBrowserDialog dialog = new FolderBrowserDialog())
                {
                    if (dialog.ShowDialog() == DialogResult.OK)
                        selectedPath = dialog.SelectedPath;
                }

                if (selectedPath != null)
                {
                    if (CurrentSession != null)
                    {
                        if (MessageBox.Show("Would you like to cancel current session?") == DialogResult.OK)
                        {
                            await CurrentSession.CancelAsync();
                        }
                    }

                    CurrentSession = new LogParserSession(selectedPath);
                    this.Text = $"LogParser - [{selectedPath}]";
                    await CurrentSession.StartAsync();
                    sessionView.Init(CurrentSession);
                    sessionView.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
