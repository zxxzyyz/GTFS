using ProtoGTFS.Common;

namespace ProtoGTFS.GTFS.Entity
{
    public class Frequencies : GTFSEntity
    {
        [Tag("Trip_id"), Required]
        public string TripId { get; set; }

        [Tag("Start_time"), Required]
        public string StartTime { get; set; }

        [Tag("End_time"), Required]
        public string EndTime { get; set; }

        [Tag("Headway_secs"), Required]
        public string HeadwaySecs { get; set; }

        [Tag("Exact_times")]
        public string ExactTimes { get; set; }
    }
}
