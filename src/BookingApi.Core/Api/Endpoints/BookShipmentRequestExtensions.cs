using System;
using System.Collections.Generic;
using System.Linq;
using BookingApi.Abstractions.Api.Endpoints;
using BookingApi.Abstractions.Models.ShipmentBooking;
using BookingApi.Core.Models.ShipmentBooking;
using BookingApi.Core.Models.ShipmentBooking.Fluent;

namespace BookingApi.Core.Api.Endpoints
{
    public static class BookShipmentRequestExtensions
    {
        public static IBookShipmentRequest WithPieces(this IBookShipmentRequest IBookShipmentRequest, Action<PieceArrayFluent> builder)
        {
            var piecesArrayFluent = new PieceArrayFluent(new List<Piece>());
            builder(piecesArrayFluent);
            IBookShipmentRequest.Pieces = ((List<Piece>)piecesArrayFluent).Cast<IPiece>().ToList();
            return IBookShipmentRequest;
        }

        public static IBookShipmentRequest WithReadyByDate(this IBookShipmentRequest IBookShipmentRequest,
            DateTime? currentDate = null)
        {
            if (currentDate == null) currentDate = DateTime.Now;
            IBookShipmentRequest.ReadyByDate = currentDate.Value;
            return IBookShipmentRequest;
        }

        public static IBookShipmentRequest WithHawb(this IBookShipmentRequest IBookShipmentRequest, string hawb)
        {
            IBookShipmentRequest.Hawb = hawb;
            return IBookShipmentRequest;
        }

        public static IBookShipmentRequest WithDescription(this IBookShipmentRequest IBookShipmentRequest,
            string description)
        {
            IBookShipmentRequest.Description = description;
            return IBookShipmentRequest;
        }

        public static IBookShipmentRequest WithDocuments(this IBookShipmentRequest IBookShipmentRequest)
        {
            IBookShipmentRequest.NonDox = false;
            IBookShipmentRequest.Value = 0.00m;
            return IBookShipmentRequest;
        }

        public static IBookShipmentRequest WithNonDocuments(this IBookShipmentRequest IBookShipmentRequest,
            decimal shipmentValue)
        {
            IBookShipmentRequest.NonDox = true;
            IBookShipmentRequest.Value = shipmentValue;
            return IBookShipmentRequest;
        }

        public static IBookShipmentRequest WithCurrency(this IBookShipmentRequest IBookShipmentRequest,
            string currencyCode)
        {
            IBookShipmentRequest.Currency = currencyCode;
            return IBookShipmentRequest;
        }

        public static IBookShipmentRequest WithDdp(this IBookShipmentRequest IBookShipmentRequest)
        {
            IBookShipmentRequest.Ddp = true;
            return IBookShipmentRequest;
        }

        public static IBookShipmentRequest WithPallet(this IBookShipmentRequest IBookShipmentRequest)
        {
            IBookShipmentRequest.Pallet = true;
            return IBookShipmentRequest;
        }

        public static IBookShipmentRequest WithRequester(this IBookShipmentRequest IBookShipmentRequest,
            string requesterName, string phoneNumber = "")
        {
            IBookShipmentRequest.Requester = new Requester {Name = requesterName, PhoneNumber = phoneNumber};
            return IBookShipmentRequest;
        }

        public static IBookShipmentRequest WithConsignee(this IBookShipmentRequest IBookShipmentRequest,
            Action<AddressFluent> builder)
        {
            var consigneeBuilder = new AddressFluent(null);
            builder(consigneeBuilder);
            IBookShipmentRequest.Consignee = (Address)consigneeBuilder;
            return IBookShipmentRequest;
        }

        public static IBookShipmentRequest WithCollection(this IBookShipmentRequest IBookShipmentRequest,
            Action<CollectionAddressFluent> builder)
        {
            var collectionBuilder = new CollectionAddressFluent(null);
            builder(collectionBuilder);
            IBookShipmentRequest.CollectionAddress = (CollectionAddress)collectionBuilder;
            return IBookShipmentRequest;
        }

        public static IBookShipmentRequest WithShipper(this IBookShipmentRequest IBookShipmentRequest,
            Action<AddressFluent> builder)
        {
            var shipperBuilder = new AddressFluent(null);
            builder(shipperBuilder);
            IBookShipmentRequest.Shipper = (Address)shipperBuilder;
            return IBookShipmentRequest;
        }

        public static IBookShipmentRequest WithServiceCode(this IBookShipmentRequest IBookShipmentRequest,
            string serviceCode)
        {
            IBookShipmentRequest.Service = new Service {Code = serviceCode};
            return IBookShipmentRequest;
        }

        public static IBookShipmentRequest AsPdf(this IBookShipmentRequest IBookShipmentRequest)
        {
            IBookShipmentRequest.LabelFormat = LabelFormat.Pdf;
            return IBookShipmentRequest;
        }

        public static IBookShipmentRequest AsEpl(this IBookShipmentRequest IBookShipmentRequest)
        {
            IBookShipmentRequest.LabelFormat = LabelFormat.Epl;
            return IBookShipmentRequest;
        }

        public static IBookShipmentRequest AsZpl(this IBookShipmentRequest IBookShipmentRequest)
        {
            IBookShipmentRequest.LabelFormat = LabelFormat.Zpl;
            return IBookShipmentRequest;
        }

        public static IBookShipmentRequest WithExportCustoms(this IBookShipmentRequest IBookShipmentRequest,
            Action<ExportCustomsFluent> builder)
        {
            var exportCustomersBuilder = new ExportCustomsFluent(null);
            builder(exportCustomersBuilder);
            IBookShipmentRequest.ExportCustoms = exportCustomersBuilder as IExportCustoms;
            return IBookShipmentRequest;
        }
    }
}
