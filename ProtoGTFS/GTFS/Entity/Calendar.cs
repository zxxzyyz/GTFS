using ProtoGTFS.Common;

namespace ProtoGTFS.GTFS.Entity
{
    public class Calendar : GTFSEntity
    {
        [Tag("Serviced_id"), Key, Required]
        public string ServicedId { get; set; }

        [Tag("Monday"), Required]
        public string Monday { get; set; }

        [Tag("Tuesday"), Required]
        public string Tuesday { get; set; }

        [Tag("Wednesday"), Required]
        public string Wednesday { get; set; }

        [Tag("Thursday"), Required]
        public string Thursday { get; set; }

        [Tag("Friday"), Required]
        public string Friday { get; set; }

        [Tag("Saturday"), Required]
        public string Saturday { get; set; }

        [Tag("Sunday"), Required]
        public string Sunday { get; set; }

        [Tag("Start_date"), Required]
        public string StartDate { get; set; }

        [Tag("End_date"), Required]
        public string EndDate { get; set; }
    }
}
