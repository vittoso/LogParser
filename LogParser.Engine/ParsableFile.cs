using System.Collections.Concurrent;

namespace LogParser.Engine
{

    internal class ParsableFile(IFileParser parser, FileInfo fileInfo)
    {
        public void Parse(ConcurrentDictionary<DateTime, ConcurrentBag<Event>> data)
        {
            void CallBack(Event ev)
            {

               if (! data.TryAdd(ev.Id.DateTime, new ConcurrentBag<Event>()))
                {     // Exists already
                    if (data.TryGetValue(ev.Id.DateTime, out var bag))
                        {
                        bag.Add(ev);
                    }
               

                }
                      }


            parser.Parse(fileInfo, CallBack);
        }
    }



}
