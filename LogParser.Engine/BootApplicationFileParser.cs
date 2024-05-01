
using System.Text.RegularExpressions;

namespace LogParser.Engine
{
    internal class BootApplicationFileParser : IFileParser
    {
        public void Parse(FileInfo fileInfo, Action<Event> callBack)
        {
            using (StreamReader reader = fileInfo.OpenText())
            {
                string? line;
                DateTime accDateTime = DateTime.MinValue;
                List<string> acc = [];
                // Regular expression pattern to match the date and time format
                string pattern = @"^\d{4}-\d{2}-\d{2} \d{2}:\d{2}:\d{2}";

                // Read and process each line until the end of the file
                while ((line = reader.ReadLine()) != null)
                {
                    // Check if the line starts with a date and time
                    if (Regex.IsMatch(line, pattern))
                    {
                        // Extract the date and time string
                        string dateTimeString = Regex.Match(line, pattern).Value;

                        // Parse the date and time string into a DateTime object
      
                        if (!DateTime.TryParseExact(dateTimeString, "yyyy-MM-dd HH:mm:ss", null, System.Globalization.DateTimeStyles.None, out DateTime dateTime))
                        {
                            if (accDateTime != DateTime.MinValue)
                                acc.Add(line);
                            continue;
                        }


                        if (acc.Count != 0) 
                        {
                            Event ev = Event.Create(accDateTime, fileInfo, string.Join(Environment.NewLine, acc));
                            accDateTime = DateTime.MinValue;
                            acc.Clear();
                            callBack(ev);
                        }
                        accDateTime = dateTime;
                        acc.Add(line);
                    }
                    // If the line does not start with a date and time, you can handle it accordingly
                    else
                    {
                        if (accDateTime != DateTime.MinValue)
                            acc.Add(line);
                    }
                }


                if (acc.Count != 0)
                {
                    Event ev = Event.Create(accDateTime, fileInfo, string.Join(Environment.NewLine, acc));
                    accDateTime = DateTime.MinValue;
                    acc.Clear();
                    callBack(ev);
                }
            }
        }
    }
}