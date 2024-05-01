namespace LogParser.Engine
{
    public class Event
    {

        protected Event()
        {
                
        }

        public EventId Id { get; set; }
        public FileInfo FileInfo { get; private set; }
        public string Data { get; private set; }

        public static Event Create(DateTime dateTime, FileInfo fileInfo, string eventData)
        {
            Event e = new Event();

            e.Id = new EventId(dateTime, Guid.NewGuid());
            e.FileInfo = fileInfo;
            e.Data = eventData;

            return e;
        }

        public class EventId
        {
            private readonly DateTime dateTime;
            private readonly Guid guid;

            public EventId(DateTime dateTime, Guid guid)
            {
                this.dateTime = dateTime;
                this.guid = guid;
            }

            public DateTime DateTime => dateTime;

            public Guid Guid => guid;

            public override string ToString()
            {
                return string.Concat(DateTime.ToString("yyyyMMdd_HHmmss.fff"), "||", Guid.ToString());
            }
        }
    }

}
