using ProtoGTFS.Common;

namespace ProtoGTFS.GTFS.Entity
{
    public class AgencyJp : GTFSEntity
    {
        [Tag("Agency_id"), Required]
        public string AgencyId { get; set; }

        [Tag("Agency_official_name")]
        public string AgencyOfficialName { get; set; }

        [Tag("Agency_zip_number")]
        public string AgencyZipNumber { get; set; }

        [Tag("Agency_address")]
        public string AgencyAddress { get; set; }

        [Tag("Agency_president_pos")]
        public string AgencyPresidentPos { get; set; }

        [Tag("Agency_president_name")]
        public string AgencyPresidentName { get; set; }
    }
}
