using LogParser.Engine;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogParserApp
{
    public class DataCache
    {

        private LogView logView;
        private List<Event> data;

        public DateTime End => logView.End;

        public DateTime Start => logView.Start;

        public int RowCount => data.Count;

        public DataCache(LogView logView)
        {
            this.logView = logView;
            this.data = logView.Values.SelectMany(a => a).ToList();
        }

        public Event GetEventAtRow(int rowIndex)
        {
            return data[rowIndex];
        }

      /*  public void Sort(DataGridViewColumn currentSortColumn, ListSortDirection currentSortDirection)
        {
            var query = logView.Values.SelectMany(a => a);


            switch (currentSortDirection)
            {
                case ListSortDirection.Descending:
                    query = query.OrderByDescending(a => a.Id.DateTime); break;
                case ListSortDirection.Ascending:
                    query = query.OrderBy(a => a.Id.DateTime); break;
            }

            this.data = query.ToList();
        }*/


        public void Sort<V>(Func<Event, V> fieldSelector, ListSortDirection sortDirection)
        {
            var query = logView.Values.SelectMany(a => a);


            switch (sortDirection)
            {
                case ListSortDirection.Descending:
                    query = query.OrderByDescending(fieldSelector); break;
                case ListSortDirection.Ascending:
                    query = query.OrderBy(fieldSelector); break;
            }

            this.data = query.ToList();


        }
    }
}
