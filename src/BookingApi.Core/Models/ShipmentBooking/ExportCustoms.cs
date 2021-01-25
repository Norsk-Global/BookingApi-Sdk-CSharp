using BookingApi.Abstractions.Models;
using BookingApi.Abstractions.Models.ShipmentBooking;

namespace BookingApi.Core.Models.ShipmentBooking
{
    public class ExportCustoms : IExportCustoms
    {
        public string InvoiceNumber { get; set; }
        public string PayeeOfGST { get; set; }
        public InvoiceType InvoiceType { get; set; }
        public string TermsOfPayment { get; set; }
        public string CurrencyCode { get; set; }
        public TypeOfExport TypeOfExport { get; set; }
        public string TermsOfTrade { get; set; }
        public string InvoiceConsignee { get; set; }
    }
}
