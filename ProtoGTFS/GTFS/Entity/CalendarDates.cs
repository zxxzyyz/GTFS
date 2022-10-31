using ProtoGTFS.Common;

namespace ProtoGTFS.GTFS.Entity
{
    public class CalendarDates : GTFSEntity
    {
        [Tag("Service_id"), Key, Required]
        public string ServiceId { get; set; }

        [Tag("Date"), Key, Required]
        public string Date { get; set; }

        [Tag("Exception_type"), Required]
        public string ExceptionType { get; set; }
    }
}
