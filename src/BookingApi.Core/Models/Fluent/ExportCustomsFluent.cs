using System;
using BookingApi.Abstractions.Models;
using BookingApi.Abstractions.Models.Fluent;
using BookingApi.Core.Models.Validation;

namespace BookingApi.Core.Models.Fluent
{
    public class ExportCustomsFluent : FluentBuilder<ExportCustoms, IExportCustoms>
    {
        public ExportCustomsFluent(IExportCustoms model) : base(model)
        {
        }

        [NotBeEmpty]
        public ExportCustomsFluent InvoiceNumber(string invoiceNumber)
        {
            _model.InvoiceNumber = invoiceNumber;
            return this;
        }

        [BeBetweenLength(1, 35)]
        public ExportCustomsFluent PayeeOfGst(string payeeOfGst)
        {
            _model.PayeeOfGST = payeeOfGst;
            return this;
        }

        public ExportCustomsFluent InvoiceType(InvoiceType invoiceType)
        {
            _model.InvoiceType = invoiceType;
            return this;
        }

        [NotBeEmpty]
        public ExportCustomsFluent TermsOfPayment(string termsOfPayment)
        {
            _model.TermsOfPayment = termsOfPayment;
            return this;
        }

        [BeBetweenLength(3, 3)]
        public ExportCustomsFluent CurrencyCode(string currencyCode)
        {
            _model.CurrencyCode = currencyCode;
            return this;
        }

        public ExportCustomsFluent TypeOfExport(TypeOfExport typeOfExport)
        {
            _model.TypeOfExport = typeOfExport;
            return this;
        }

        [NotBeEmpty]
        public ExportCustomsFluent TermsOfTrade(string termsOfTrade)
        {
            _model.TermsOfTrade = termsOfTrade;
            return this;
        }

        [BeBetweenLength(1, 35)]
        public ExportCustomsFluent InvoiceConsignee(string consignee)
        {
            _model.InvoiceConsignee = consignee;
            return this;
        }

    }
}
