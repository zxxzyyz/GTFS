using System;
using System.Collections.Generic;
using System.Text;
using ProtoGTFS.Common;

namespace ProtoGTFS.GTFS.Entity
{
    public class Shapes : GTFSEntity
    {
        [Tag("Shape_id"), Key, Required]
        public string ShapeId { get; set; }

        [Tag("Shape_pt_lat"), Required]
        public string ShapePtLat { get; set; }

        [Tag("Shape_pt_lon"), Required]
        public string ShapePtLon { get; set; }

        [Tag("Shape_pt_sequence"), Required]
        public string ShapePtSequence { get; set; }

        [Tag("Shape_dist_traveled")]
        public string ShapeDistTraveled { get; set; }
    }
}
