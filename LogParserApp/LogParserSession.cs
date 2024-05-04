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

        public Task StartAsync()
        {
            p.StartParseFolder(FolderPath);
            return Task.CompletedTask;
        }

        public Task CancelAsync()
        {
            return parserCts.CancelAsync();
        }

        public IReadOnlyDictionary<DateTime, IReadOnlyList<Event>> GetView(DateTime start, DateTime end)
        {
            return p.GetView(start, end);
        }
    }
}
