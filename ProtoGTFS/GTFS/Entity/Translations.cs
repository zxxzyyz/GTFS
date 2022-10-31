using System;
using System.Collections.Generic;
using System.Text;
using ProtoGTFS.Common;

namespace ProtoGTFS.GTFS.Entity
{
    public class Translations : GTFSEntity
    {
        [Tag("Trans_id"), Key, Required]
        public string TransId { get; set; }

        [Tag("Lang"), Key, Required]
        public string Lang { get; set; }

        [Tag("Translation"), Required]
        public string Translation { get; set; }
    }
}
