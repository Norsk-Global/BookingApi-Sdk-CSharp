namespace BookingApi.Abstractions.Models.ShipmentBooking
{
    public interface IExportCustoms
    {
        string InvoiceNumber { get; set; }

        string PayeeOfGST { get; set; }

        InvoiceType InvoiceType { get; set; }

        string TermsOfPayment { get; set; }

        string CurrencyCode { get; set; }

        TypeOfExport TypeOfExport { get; set; }

        string TermsOfTrade { get; set; }

        string InvoiceConsignee { get; set; }
    }
}
