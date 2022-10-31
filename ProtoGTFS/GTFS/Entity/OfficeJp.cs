using ProtoGTFS.Common;

namespace ProtoGTFS.GTFS.Entity
{
    public class OfficeJp : GTFSEntity
    {
        [Tag("Office_id"), Key, Required]
        public string OfficeId { get; set; }

        [Tag("Office_name"), Required]
        public string OfficeName { get; set; }

        [Tag("Office_url")]
        public string OfficeUrl { get; set; }

        [Tag("Office_phone")]
        public string OfficePhone { get; set; }
    }
}
