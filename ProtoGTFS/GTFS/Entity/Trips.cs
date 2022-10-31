using System;
using System.Collections.Generic;
using System.Text;
using ProtoGTFS.Common;

namespace ProtoGTFS.GTFS.Entity
{
    public class Trips : GTFSEntity
    {
        [Tag("Route_id"), Key, Required]
        public string RouteId { get; set; }

        [Tag("Service_id"), Required]
        public string ServiceId { get; set; }

        [Tag("Trip_id"), Required]
        public string TripId { get; set; }

        [Tag("Trip_headsign")]
        public string TripHeadsign { get; set; }

        [Tag("Trip_short_name")]
        public string TripShortName { get; set; }

        [Tag("Direction_id")]
        public string DirectionId { get; set; }

        [Tag("Block_id")]
        public string BlockId { get; set; }

        [Tag("Shape_id")]
        public string ShapeId { get; set; }

        [Tag("Jp_trip_desc")]
        public string JpTripDesc { get; set; }

        [Tag("Jp_trip_desc_symbol")]
        public string JpTripDescSymbol { get; set; }

        [Tag("Jp_offcie_id")]
        public string JpOffcieId { get; set; }
    }
}
