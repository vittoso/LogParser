using LogParser.Engine;

namespace LogParserApp
{
    public class LogParserSession
    {
        Parser p = new Parser();
        CancellationTokenSource parserCts = new CancellationTokenSource();
        public LogParserSession(string path)
        {
            this.FolderPath = path;
        }

        public string FolderPath { get; }

        public async Task StartAsync()
        {
            await Task.Run(() => p.StartParseFolder(FolderPath));
        }

        public Task CancelAsync()
        {
            return parserCts.CancelAsync();
        }

        public LogView GetView(DateTime start, DateTime end)
        {
            return p.GetView(start, end);
        }

        public (DateTime start, DateTime end) GetTotalDateTimeRange()
        {
            return p.GetTotalDateTimeRange();
        }
    }
}
