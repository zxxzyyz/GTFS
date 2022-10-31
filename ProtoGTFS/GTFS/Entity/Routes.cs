using System;
using System.Collections.Generic;
using System.Text;
using ProtoGTFS.Common;

namespace ProtoGTFS.GTFS.Entity
{
    public class Routes : GTFSEntity
    {
        [Tag("Route_id")]
        public string RouteId { get; set; }

        [Tag("Agency_id")]
        public string AgencyId { get; set; }

        [Tag("Route_short_name")]
        public string RouteShortName { get; set; }

        [Tag("Route_long_name")]
        public string RouteLongName { get; set; }

        [Tag("Route_desc")]
        public string RouteDesc { get; set; }

        [Tag("Route_type")]
        public string RouteType { get; set; }

        [Tag("Route_url")]
        public string RouteUrl { get; set; }

        [Tag("Route_color")]
        public string RouteColor { get; set; }

        [Tag("Route_text_color")]
        public string RouteTextColor { get; set; }

        [Tag("Jp_parent_route_id")]
        public string JpParentRouteId { get; set; }
    }
}
