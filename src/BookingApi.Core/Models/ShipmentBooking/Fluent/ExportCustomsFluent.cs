using BookingApi.Abstractions.Models;
using BookingApi.Abstractions.Models.Fluent;
using BookingApi.Abstractions.Models.ShipmentBooking;
using BookingApi.Core.Models.Validation;

namespace BookingApi.Core.Models.ShipmentBooking.Fluent
{
    public class ExportCustomsFluent : FluentBuilder<ExportCustoms, IExportCustoms>
    {
        public ExportCustomsFluent(IExportCustoms model) : base(model)
        {
        }

        [NotBeEmpty]
        public ExportCustomsFluent InvoiceNumber(string invoiceNumber)
        {
            Model.InvoiceNumber = invoiceNumber;
            return this;
        }

        [BeBetweenLength(1, 35)]
        public ExportCustomsFluent PayeeOfGst(string payeeOfGst)
        {
            Model.PayeeOfGST = payeeOfGst;
            return this;
        }

        public ExportCustomsFluent InvoiceType(InvoiceType invoiceType)
        {
            Model.InvoiceType = invoiceType;
            return this;
        }

        [NotBeEmpty]
        public ExportCustomsFluent TermsOfPayment(string termsOfPayment)
        {
            Model.TermsOfPayment = termsOfPayment;
            return this;
        }

        [BeBetweenLength(3, 3)]
        public ExportCustomsFluent CurrencyCode(string currencyCode)
        {
            Model.CurrencyCode = currencyCode;
            return this;
        }

        public ExportCustomsFluent TypeOfExport(TypeOfExport typeOfExport)
        {
            Model.TypeOfExport = typeOfExport;
            return this;
        }

        [NotBeEmpty]
        public ExportCustomsFluent TermsOfTrade(string termsOfTrade)
        {
            Model.TermsOfTrade = termsOfTrade;
            return this;
        }

        [BeBetweenLength(1, 35)]
        public ExportCustomsFluent InvoiceConsignee(string consignee)
        {
            Model.InvoiceConsignee = consignee;
            return this;
        }

    }
}
