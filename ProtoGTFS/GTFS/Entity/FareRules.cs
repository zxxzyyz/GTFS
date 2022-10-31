using ProtoGTFS.Common;

namespace ProtoGTFS.GTFS.Entity
{
    public class FareRules : GTFSEntity
    {
        [Tag("Fare_id"), Key, Required]
        public string FareId { get; set; }

        [Tag("Route_id")]
        public string RouteId { get; set; }

        [Tag("Origin_id")]
        public string OriginId { get; set; }

        [Tag("Destination_id")]
        public string DestinationId { get; set; }

        [Tag("Contains_id")]
        public string ContainsId { get; set; }
    }
}
