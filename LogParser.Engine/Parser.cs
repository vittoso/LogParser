using System.Collections.Concurrent;
using System.Collections.Frozen;
using System.IO;
using System.Xml.Serialization;

namespace LogParser.Engine
{
    public class Parser
    {
        ConcurrentDictionary<DateTime, ConcurrentBag<Event>> data;
        private bool parsingStarted = false;

        public bool HasStarted { get; set; }

        public Parser()
        {

            data = new ConcurrentDictionary<DateTime, ConcurrentBag<Event>>();
        }
        public async Task StartParseFolder(string folderPath, CancellationToken token = default(CancellationToken))
        {
            if (parsingStarted)
                throw new Exception("Parsing already started");

            if (parsingStarted)
                throw new Exception("Parsing already started");

            string[] files = Directory.GetFiles(folderPath);

            if (!files.Any())
                throw new Exception($"Invalid folder '{folderPath}': no files recognized");

            await StartParseFiles(files, token);
        }

        public async Task StartParseFiles(IEnumerable<string> files, CancellationToken token = default(CancellationToken))
        {
            List<FileInfo> fileInfos = new List<FileInfo>();
            foreach (string file in files)
            {
                FileInfo f = new FileInfo(file);

                switch (f.Extension.ToUpperInvariant())
                {
                    case ".LOG":
                    case ".TXT":

                        fileInfos.Add(f);
                        break;
                    default:
                        continue;
                }
            }

            if (!fileInfos.Any())
                throw new Exception($"No files recognized");

            parsingStarted = true;

            List<ParsableFile> parsableFiles = new List<ParsableFile>(fileInfos.Count);
            foreach (var fileInfo in fileInfos)
            {
                var parser = FindParser(fileInfo);

                if (parser != null)
                {
                    parsableFiles.Add(new ParsableFile(parser, fileInfo));
                }

            }

            if (token.IsCancellationRequested)
                return;


            if (parsableFiles.Any())
            {
                List<Task> taskList = new List<Task>(parsableFiles.Count);
                foreach (var parsableFile in parsableFiles)
                {
                    taskList.Add(Task.Run(() => parsableFile.Parse(data, token), token));

                    if (token.IsCancellationRequested)
                        return;
                }

                await Task.WhenAll(taskList);
            }
        }

        public (DateTime start, DateTime end) GetTotalDateTimeRange()
        {
            if (data == null || data.Count <= 0)
                return (DateTime.MinValue, DateTime.MaxValue);

            DateTime start = DateTime.MaxValue;
            DateTime end = DateTime.MinValue;
            foreach (var item in data.Keys)
            {
                if (start > item) start = item;
                if (end < item) end = item;
            }

            return (start, end);
        }


        public LogView GetView(DateTime start, DateTime end)
        {
            Dictionary<DateTime, IReadOnlyList<Event>> d = new();

            foreach (var item in data)
            {
                if (item.Key < start || item.Key > end)
                    continue;
                d[item.Key] = new List<Event>(item.Value).AsReadOnly();
            }

            return new LogView(d, start, end);
        }


        private IFileParser FindParser(FileInfo fileInfo)
        {
            switch (fileInfo.Extension.ToUpperInvariant())
            {
                case ".LOG":
                    if (fileInfo.Name.ToUpperInvariant().StartsWith("BOOTAPPLICATION"))
                        return new BootApplicationFileParser();
                    if (fileInfo.Name.ToUpperInvariant().StartsWith("ERRORS"))
                        return new ErrorsFileParser();
                    return null;
                case ".TXT":
                    return null;
                    break;
                default:
                    return null;
            }
        }
    }

}
