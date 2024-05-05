
using System.Text.RegularExpressions;

namespace LogParser.Engine
{
    internal class BootApplicationFileParser : IFileParser
    {

        const string SOURCE = "BootApplication";
        public async Task Parse(FileInfo fileInfo, CancellationToken token, Action<Event> callBack)
        {
            using (StreamReader reader = fileInfo.OpenText())
            {
                string? line;
                DateTime accDateTime = DateTime.MinValue;
                string? accLocation = null;
                List<string> acc = [];
                // Regular expression pattern to match the date and time format
                string? pattern = @"^\d{4}-\d{2}-\d{2} \d{2}:\d{2}:\d{2}";

                // Read and process each line until the end of the file
                while ((line = await reader.ReadLineAsync(token)) != null)
                {
                    // Check if the line starts with a date and time
                    if (Regex.IsMatch(line, pattern))
                    {
                        string subLine = line;
                        // Extract the date and time string
                        string dateTimeString = Regex.Match(line, pattern).Value;

                        // Parse the date and time string into a DateTime object

                        if (!DateTime.TryParseExact(dateTimeString, "yyyy-MM-dd HH:mm:ss", null, System.Globalization.DateTimeStyles.None, out DateTime dateTime))
                        {
                            if (accDateTime != DateTime.MinValue)
                                acc.Add(line);
                            continue;
                        }

                        string location = null;
                        if (line.Length > dateTimeString.Length + 1)
                        {
                            subLine = line.Substring(dateTimeString.Length + 1);

                            int idxLocationEnd = subLine.IndexOf(';');
                            if (idxLocationEnd > 0)
                                location = subLine.Substring(0, idxLocationEnd);

                            subLine = subLine.Substring(idxLocationEnd + 1);

                            if (subLine.EndsWith(';'))
                                subLine = subLine.Substring(0, subLine.Length - 1);
                        }

                        TryEmitEvent(fileInfo, callBack, ref accDateTime, ref accLocation, acc);

                        accDateTime = dateTime;
                        accLocation = location;
                        acc.Add(subLine);
                    }
                    // If the line does not start with a date and time, you can handle it accordingly
                    else
                    {
                        if (accDateTime != DateTime.MinValue)
                            acc.Add(line);
                    }
                }

                TryEmitEvent(fileInfo, callBack, ref accDateTime, ref accLocation, acc);
            }
        }

        private static bool TryEmitEvent(FileInfo fileInfo, Action<Event> callBack, ref DateTime accDateTime, ref string? accLocation, List<string> acc)
        {
            if (acc.Count != 0)
            {
                Event ev = Event.Create(accDateTime, fileInfo, SOURCE, LogLevel.Trace, null, accLocation, StringJoinHelper.JoinWithoutEmptyStrings(Environment.NewLine, acc));
                accDateTime = DateTime.MinValue;
                accLocation = null;
                acc.Clear();
                callBack(ev);
                return true;
            }
            return false;
        }
    }
}