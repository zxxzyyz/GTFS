using System;
using System.Collections.Generic;
using System.Text;
using ProtoGTFS.Common;

namespace ProtoGTFS.GTFS.Entity
{
    public class StopTimes : GTFSEntity
    {
        [Tag("Trip_id"), Key, Required]
        public string TripId { get; set; }

        [Tag("Arrival_time"), Required]
        public string ArrivalTime { get; set; }

        [Tag("Departure_time"), Required]
        public string DepartureTime { get; set; }

        [Tag("Stop_id"), Required]
        public string StopId { get; set; }

        [Tag("Stop_sequence"), Key, Required]
        public string StopSequence { get; set; }

        [Tag("Stop_headsign")]
        public string StopHeadsign { get; set; }

        [Tag("Pickup_type")]
        public string PickupType { get; set; }

        [Tag("Drop_off_type")]
        public string DropOffType { get; set; }

        [Tag("Shape_dist_traveled")]
        public string ShapeDistTraveled { get; set; }

        [Tag("Timepoint")]
        public string Timepoint { get; set; }
    }
}
