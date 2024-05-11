using System.Diagnostics;
using System.Text.RegularExpressions;

namespace LogParser.Engine
{
    internal class ErrorsFileParser : IFileParser
    {

        const string SOURCE = "Errors";
        public async Task Parse(FileInfo fileInfo, CancellationToken token, Action<Event> callBack)
        {
            using (StreamReader reader = fileInfo.OpenText())
            {
                string? line;
                DateTime accDateTime = DateTime.MinValue;
                int? accTid = null;
                string? accLocation = null;
                LogLevel accLogLevel = LogLevel.None;
                List<string> acc = new List<string>();

                // Compile regex patterns outside the loop
                // Regular expression pattern to match the date and time format
                Regex dateTimeRegex = new Regex(@"^\d{4}/\d{2}/\d{2} \d{2}:\d{2}:\d{2}\.\d{3}");
                // Create regular expression pattern to match log level
                Regex logLevelRegex = new Regex(@"\-\-\[(.*?)\]\-\-");
                // TID Regex
                Regex tidRegex = new Regex(@"\[TID:(\d+)\]");

                // Read and process each line until the end of the file
                while ((line = await reader.ReadLineAsync(token)) != null)
                {
                    string subLine = line;

                    // Check if the line starts with a date and time
                    if (dateTimeRegex.IsMatch(line))
                    {
                        // Extract the date and time string
                        string dateTimeString = dateTimeRegex.Match(line).Value;

                        // Parse the date and time string into a DateTime object

                        if (!DateTime.TryParseExact(dateTimeString, "yyyy/MM/dd HH:mm:ss.fff", null, System.Globalization.DateTimeStyles.None, out DateTime dateTime))
                        {
                            if (accDateTime != DateTime.MinValue)
                                acc.Add(line);
                            continue;
                        }

                        subLine = line.Substring(dateTimeString.Length + 1);

                        string? location = null;

                        int idxLocationEnd = subLine.IndexOf('[');
                        if (idxLocationEnd > 0)
                        {
                            location = subLine.Substring(0, idxLocationEnd - 1);

                            subLine = subLine.Replace(location, string.Empty);
                        }

                        // Parse TID
                        // Use regular expression to find the number after "TID"
                        int? tid;
                        Match match = tidRegex.Match(subLine);
                        if (match.Success)
                        {
                            // Extract and print the number
                            tid = Convert.ToInt32(match.Groups[1].Value);
                            subLine = subLine.Substring(0, match.Index);
                        }
                        else
                            tid = null;


                        TryEmitEvent(fileInfo, callBack, ref accDateTime, ref accTid, ref accLocation, ref accLogLevel, acc);
                        accDateTime = dateTime;
                        accTid = tid;
                        accLocation = location;
                        acc.Add(subLine);
                    }
                    // If the line does not start with a date and time, you can handle it accordingly
                    else
                    {
                        // Use regular expression to find the log level
                        Match match = logLevelRegex.Match(line);
                        if (match.Success)
                        {

                            // Extract and print the log level
                            string logLevel = match.Groups[1].Value;
                            if (LogLevel.TryParse(typeof(LogLevel), logLevel, out var result))
                            {
                                accLogLevel = (LogLevel)result;
                            }
                            subLine = subLine.Substring(match.Index + match.Length + 1);
                        }


                        if (accDateTime != DateTime.MinValue)
                            acc.Add(subLine);
                    }
                }

                TryEmitEvent(fileInfo, callBack, ref accDateTime, ref accTid, ref accLocation, ref accLogLevel, acc);
            }
        }

        private static bool TryEmitEvent(FileInfo fileInfo, Action<Event> callBack, ref DateTime accDateTime, ref int? accTid, ref string? accLocation, ref LogLevel accLogLevel, List<string> acc)
        {
            if (acc.Count != 0)
            {
                Event ev = Event.Create(accDateTime, fileInfo, SOURCE, accLogLevel, accTid, accLocation, StringJoinHelper.JoinWithoutEmptyStrings(Environment.NewLine, acc));
                accDateTime = DateTime.MinValue;
                accTid = null;
                accLocation = null;
                accLogLevel = LogLevel.None;
                acc.Clear();
                callBack(ev);
                return true;
            }
            return false;
        }
    }
}