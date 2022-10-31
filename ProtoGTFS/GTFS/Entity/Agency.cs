using ProtoGTFS.Common;

namespace ProtoGTFS.GTFS.Entity
{
    [Tag("agency.txt")]
    public class Agency : GTFSEntity
    {
        [Tag("Agency_id"), Key, Required]
        public string AgencyId { get; set; }

        [Tag("Agency_name"), Required]
        public string AgencyName { get; set; }

        [Tag("Agency_url"), Required]
        public string AgencyUrl { get; set; }

        [Tag("Agency_timezone"), Required]
        public string AgencyTimezone { get; set; }

        [Tag("Agency_lang")]
        public string AgencyLang { get; set; }

        [Tag("Agency_phone")]
        public string AgencyPhone { get; set; }

        [Tag("Agency_fare_url")]
        public string AgencyFareUrl { get; set; }

        [Tag("Agency_email")]
        public string AgencyEmail { get; set; }
    }
}
