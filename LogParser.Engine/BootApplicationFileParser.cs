
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
                Regex patternRegex = new Regex(@"^\d{4}-\d{2}-\d{2} \d{2}:\d{2}:\d{2}");

                // Read and process each line until the end of the file
                while ((line = await reader.ReadLineAsync(token)) != null)
                {
                    // Check if the line starts with a date and time
                    if (patternRegex.IsMatch(line))
                    {
                        // Extract the date and time string
                        string dateTimeString = patternRegex.Match(line).Value;

                        // Parse the date and time string into a DateTime object
                        if (DateTime.TryParseExact(dateTimeString, "yyyy-MM-dd HH:mm:ss", null, System.Globalization.DateTimeStyles.None, out DateTime dateTime))
                        {
                            string subLine = line.Substring(dateTimeString.Length).TrimStart(':');

                            int locationEndIndex = subLine.IndexOf(';');
                            var location = locationEndIndex >= 0 ? subLine.Substring(0, locationEndIndex) : null;

                            if (locationEndIndex >= 0)
                                subLine = subLine.Substring(locationEndIndex + 1).TrimEnd(';');

                            TryEmitEvent(fileInfo, callBack, ref accDateTime, ref accLocation, acc);

                            accDateTime = dateTime;
                            accLocation = location;
                            acc.Add(subLine);
                        }
                        else
                        {
                            acc.Add(line);
                        }
                    }
                    // If the line does not start with a date and time, you can handle it accordingly
                    else if (accDateTime != DateTime.MinValue)
                        acc.Add(line);

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