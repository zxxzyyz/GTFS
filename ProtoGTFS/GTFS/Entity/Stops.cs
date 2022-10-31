using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using ProtoGTFS.Common;

namespace ProtoGTFS.GTFS.Entity
{
    public class Stops : GTFSEntity
    {
        [Tag("Stops_id"), Key, Required]
        public string StopsId { get; set; }

        [Tag("Stop_code")]
        public string StopCode { get; set; }

        [Tag("Stop_name"), Required]
        public string StopName { get; set; }

        [Tag("Stop_desc")]
        public string StopDesc { get; set; }

        [Tag("Stop_lat"), Required]
        public string StopLat { get; set; }

        [Tag("Stop_lon"), Required]
        public string StopLon { get; set; }

        [Tag("Zone_id")]
        public string ZoneId { get; set; }

        [Tag("Stop_url")]
        public string StopUrl { get; set; }

        [Tag("Location_type")]
        public string LocationType { get; set; }

        [Tag("Parernt_station")]
        public string ParerntStation { get; set; }

        [Tag("Stop_timezone")]
        public string StopTimezone { get; set; }

        [Tag("Wheelchair_boarding")]
        public string WheelchairBoarding { get; set; }

        [Tag("Platform_code")]
        public string PlatformCode { get; set; }
    }
}
