using ProtoGTFS.Common;

namespace ProtoGTFS.GTFS.Entity
{
    public class FeedInfo : GTFSEntity
    {
        [Tag("Feed_publisher_name"), Required]
        public string FeedPublisherName { get; set; }

        [Tag("Feed_publisher_url"), Required]
        public string FeedPublisherUrl { get; set; }

        [Tag("Feed_lang"), Required]
        public string FeedLang { get; set; }

        [Tag("Feed_start_date")]
        public string FeedStartDate { get; set; }

        [Tag("Feed_end_date")]
        public string FeedEndDate { get; set; }

        [Tag("Feed_version")]
        public string FeedVersion { get; set; }
    }
}
