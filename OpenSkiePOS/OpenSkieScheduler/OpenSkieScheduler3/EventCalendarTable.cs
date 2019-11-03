using System;
using System.Data;

//using System.Messaging;

namespace OpenSkieScheduler3
{
    public class EventCalendarTable: DataTable
    {
        public static string calendar_event_table_primary_key = "event_id";
        public static string calendar_event_table_name = "event_calendar";
        public EventCalendarTable()
        {
            TableName = calendar_event_table_name;
            DataColumn dc = Columns.Add(calendar_event_table_primary_key, typeof(int));
            Columns.Add("start", typeof(DateTime));
        }
    }
}
