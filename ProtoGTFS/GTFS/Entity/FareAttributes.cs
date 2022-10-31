using ProtoGTFS.Common;

namespace ProtoGTFS.GTFS.Entity
{
    public class FareAttributes : GTFSEntity
    {
        [Tag("Fare_id"), Key, Required]
        public string FareId { get; set; }

        [Tag("Price"), Required]
        public string Price { get; set; }

        [Tag("Currency_type"), Key, Required]
        public string CurrencyType { get; set; }

        [Tag("Payment_method"), Required]
        public string PaymentMethod { get; set; }

        [Tag("Transfers"), Required]
        public string Transfers { get; set; }

        [Tag("Transfer_duration"), Required]
        public string TransferDuration { get; set; }
    }
}
