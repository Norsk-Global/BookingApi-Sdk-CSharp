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
        public static IBookShipmentRequest WithPieces(this IBookShipmentRequest bookShipmentRequest, Action<PieceArrayFluent> builder)
        {
            var piecesArrayFluent = new PieceArrayFluent(new List<Piece>());
            builder(piecesArrayFluent);
            bookShipmentRequest.Pieces = ((List<Piece>)piecesArrayFluent).Cast<IPiece>().ToList();
            return bookShipmentRequest;
        }

        public static IBookShipmentRequest WithReadyByDate(this IBookShipmentRequest bookShipmentRequest,
            DateTime? currentDate = null)
        {
            if (currentDate == null) currentDate = DateTime.Now;
            bookShipmentRequest.ReadyByDate = currentDate.Value;
            return bookShipmentRequest;
        }

        public static IBookShipmentRequest WithHawb(this IBookShipmentRequest bookShipmentRequest, string hawb)
        {
            bookShipmentRequest.Hawb = hawb;
            return bookShipmentRequest;
        }

        public static IBookShipmentRequest WithDescription(this IBookShipmentRequest bookShipmentRequest,
            string description)
        {
            bookShipmentRequest.Description = description;
            return bookShipmentRequest;
        }

        public static IBookShipmentRequest WithDocuments(this IBookShipmentRequest bookShipmentRequest)
        {
            bookShipmentRequest.NonDox = false;
            bookShipmentRequest.Value = 0.00m;
            return bookShipmentRequest;
        }

        public static IBookShipmentRequest WithNonDocuments(this IBookShipmentRequest bookShipmentRequest,
            decimal shipmentValue)
        {
            bookShipmentRequest.NonDox = true;
            bookShipmentRequest.Value = shipmentValue;
            return bookShipmentRequest;
        }

        public static IBookShipmentRequest WithCurrency(this IBookShipmentRequest bookShipmentRequest,
            string currencyCode)
        {
            bookShipmentRequest.Currency = currencyCode;
            return bookShipmentRequest;
        }

        public static IBookShipmentRequest WithDdp(this IBookShipmentRequest bookShipmentRequest)
        {
            bookShipmentRequest.Ddp = true;
            return bookShipmentRequest;
        }

        public static IBookShipmentRequest WithPallet(this IBookShipmentRequest bookShipmentRequest)
        {
            bookShipmentRequest.Pallet = true;
            return bookShipmentRequest;
        }

        public static IBookShipmentRequest WithRequester(this IBookShipmentRequest bookShipmentRequest,
            string requesterName, string phoneNumber = "")
        {
            bookShipmentRequest.Requester = new Requester {Name = requesterName, PhoneNumber = phoneNumber};
            return bookShipmentRequest;
        }

        public static IBookShipmentRequest WithConsignee(this IBookShipmentRequest bookShipmentRequest,
            Action<AddressFluent> builder)
        {
            var consigneeBuilder = new AddressFluent(null);
            builder(consigneeBuilder);
            bookShipmentRequest.Consignee = (Address)consigneeBuilder;
            return bookShipmentRequest;
        }

        public static IBookShipmentRequest WithCollection(this IBookShipmentRequest bookShipmentRequest,
            Action<CollectionAddressFluent> builder)
        {
            var collectionBuilder = new CollectionAddressFluent(null);
            builder(collectionBuilder);
            bookShipmentRequest.CollectionAddress = (CollectionAddress)collectionBuilder;
            return bookShipmentRequest;
        }

        public static IBookShipmentRequest WithShipper(this IBookShipmentRequest bookShipmentRequest,
            Action<ShipperAddressFluent> builder)
        {
            var shipperBuilder = new ShipperAddressFluent(null);
            builder(shipperBuilder);
            bookShipmentRequest.Shipper = (ShipperAddress)shipperBuilder;
            return bookShipmentRequest;
        }

        public static IBookShipmentRequest WithServiceCode(this IBookShipmentRequest bookShipmentRequest,
            string serviceCode)
        {
            bookShipmentRequest.Service = new Service {Code = serviceCode};
            return bookShipmentRequest;
        }

        public static IBookShipmentRequest AsPdf(this IBookShipmentRequest bookShipmentRequest)
        {
            bookShipmentRequest.LabelFormat = LabelFormat.Pdf;
            return bookShipmentRequest;
        }

        public static IBookShipmentRequest AsEpl(this IBookShipmentRequest bookShipmentRequest)
        {
            bookShipmentRequest.LabelFormat = LabelFormat.Epl;
            return bookShipmentRequest;
        }

        public static IBookShipmentRequest AsZpl(this IBookShipmentRequest bookShipmentRequest)
        {
            bookShipmentRequest.LabelFormat = LabelFormat.Zpl;
            return bookShipmentRequest;
        }

        public static IBookShipmentRequest WithExportCustoms(this IBookShipmentRequest bookShipmentRequest,
            Action<ExportCustomsFluent> builder)
        {
            var exportCustomersBuilder = new ExportCustomsFluent(null);
            builder(exportCustomersBuilder);
            bookShipmentRequest.ExportCustoms = exportCustomersBuilder as IExportCustoms;
            return bookShipmentRequest;
        }
    }
}
