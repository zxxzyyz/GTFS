using System;
using System.Collections.Generic;
using System.Text;
using ProtoGTFS.Common;

namespace ProtoGTFS.GTFS.Entity
{
    public class Transfers : GTFSEntity
    {
        [Tag("From_stop_id"), Key, Required]
        public string FromStopId { get; set; }

        [Tag("To_stop_id"), Key, Required]
        public string ToStopId { get; set; }

        [Tag("Transfer_type"), Required]
        public string TransferType { get; set; }

        [Tag("Min_transfer_time")]
        public string MinTransferTime { get; set; }
    }
}
