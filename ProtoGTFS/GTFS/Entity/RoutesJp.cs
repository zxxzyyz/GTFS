using ProtoGTFS.Common;

namespace ProtoGTFS.GTFS.Entity
{
    public class RoutesJp : GTFSEntity
    {
        [Tag("Route_id"), Required]
        public string RouteId { get; set; }

        [Tag("Route_update_date")]
        public string RouteUpdateDate { get; set; }

        [Tag("Origin_stop")]
        public string OriginStop { get; set; }

        [Tag("Via_stop")]
        public string ViaStop { get; set; }

        [Tag("Destination_stop")]
        public string DestinationStop { get; set; }

    }
}
