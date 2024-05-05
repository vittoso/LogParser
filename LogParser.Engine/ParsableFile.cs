using System.Collections.Concurrent;

namespace LogParser.Engine
{

    internal class ParsableFile(IFileParser parser, FileInfo fileInfo)
    {
        public async Task Parse(ConcurrentDictionary<DateTime, ConcurrentBag<Event>> data, CancellationToken token = default(CancellationToken))
        {
            void CallBack(Event ev)
            {
                var addbag = new ConcurrentBag<Event>();
                addbag.Add(ev);
                if (!data.TryAdd(ev.Id.DateTime, addbag))
                {     // Exists already
                    if (data.TryGetValue(ev.Id.DateTime, out var bag))
                        bag.Add(ev);
                }
            }

            await parser.Parse(fileInfo, token, CallBack);
        }
    }



}
