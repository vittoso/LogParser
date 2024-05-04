using System.Collections.Concurrent;
using System.Collections.Frozen;
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

        public void StartParseFolder(string folderPath, CancellationToken token = default(CancellationToken))
        {
            if (parsingStarted)
                throw new Exception("Parsing already started");

            string[] files = Directory.GetFiles(folderPath);

            List<FileInfo> fileInfos = new List<FileInfo>(files.Length);
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
                throw new Exception($"Invalid folder '{folderPath}': no files recognized");

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
                foreach (var parsableFile in parsableFiles)
                {
                    parsableFile.Parse(data);


                    if (token.IsCancellationRequested)
                        return;
                }
            }
        }

        public IReadOnlyDictionary<DateTime, IReadOnlyList<Event>> GetView(DateTime start, DateTime end)
        {
            Dictionary<DateTime, IReadOnlyList<Event>> d = new();

            foreach (var item in data)
            {
                if (item.Key < start || item.Key > end)
                    continue;
                d[item.Key] = new List<Event>(item.Value).AsReadOnly();
            }

            return d.AsReadOnly();
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
