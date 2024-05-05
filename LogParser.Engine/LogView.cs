using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogParser.Engine
{
    public class LogView : IReadOnlyDictionary<DateTime, IReadOnlyList<Event>>
    {
        private readonly Dictionary<DateTime, IReadOnlyList<Event>> d;

        public DateTime Start { get; }
        public DateTime End { get; }

        public LogView(Dictionary<DateTime, IReadOnlyList<Event>> d, DateTime start, DateTime end)
        {
            this.d = d;
            this.Start = start;
            this.End = end;
        }

        public IReadOnlyList<Event> this[DateTime key] => ((IReadOnlyDictionary<DateTime, IReadOnlyList<Event>>)d)[key];

        public IEnumerable<DateTime> Keys => ((IReadOnlyDictionary<DateTime, IReadOnlyList<Event>>)d).Keys;

        public IEnumerable<IReadOnlyList<Event>> Values => ((IReadOnlyDictionary<DateTime, IReadOnlyList<Event>>)d).Values;

        public int Count => ((IReadOnlyCollection<KeyValuePair<DateTime, IReadOnlyList<Event>>>)d).Count;

        public bool ContainsKey(DateTime key)
        {
            return ((IReadOnlyDictionary<DateTime, IReadOnlyList<Event>>)d).ContainsKey(key);
        }

        public IEnumerator<KeyValuePair<DateTime, IReadOnlyList<Event>>> GetEnumerator()
        {
            return ((IEnumerable<KeyValuePair<DateTime, IReadOnlyList<Event>>>)d).GetEnumerator();
        }

        public bool TryGetValue(DateTime key, [MaybeNullWhen(false)] out IReadOnlyList<Event> value)
        {
            return ((IReadOnlyDictionary<DateTime, IReadOnlyList<Event>>)d).TryGetValue(key, out value);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)d).GetEnumerator();
        }
    }
}
