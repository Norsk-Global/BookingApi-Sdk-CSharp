using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using BookingApi.Abstractions.Api;
using BookingApi.Abstractions.Api.Endpoints;
using BookingApi.Abstractions.Models.ShipmentBooking;
using BookingApi.Core.Models.ShipmentBooking;
using BookingApi.Core.Models.ShipmentBooking.Fluent;
using Newtonsoft.Json;

namespace BookingApi.Core.Api.Endpoints
{
    public class BookShipmentEndpoint : Endpoint<IBookShipmentRequest, IBookShipmentResponse>
    {
        public BookShipmentEndpoint(IBookShipmentRequest request, IBookShipmentResponse response) : base(request,
            response)
        {
        }
    }

    public class BookShipmentRequest : EndpointMethod, IEndpointUrl, IBookShipmentRequest
    {
        public BookShipmentRequest(string baseUrl) : base(HttpMethod.Post)
        {
            BaseUrl = baseUrl;
        }

        [JsonIgnore]
        public string BaseUrl { get; }

        [JsonIgnore]
        public string Endpoint => BaseUrl + "/api/shipment";

        public List<IPiece> Pieces { get; set; }

        public DateTime ReadyByDate { get; set; }

        public string Hawb { get; set; }

        public string Description { get; set; }

        public decimal Value { get; set; }

        public string Currency { get; set; }

        public bool NonDox { get; set; }

        [JsonProperty("DDP")]
        public bool Ddp { get; set; }

        public bool Pallet { get; set; }

        public string Invoice { get; set; }

        public IRequester Requester { get; set; }

        public IAddress Consignee { get; set; }

        public ICollectionAddress CollectionAddress { get; set; }

        public IAddress Shipper { get; set; }

        public IService Service { get; set; }

        public IPicking Picking { get; set; }

        public LabelFormat LabelFormat { get; set; }

        public ISiteDetails Site { get; set; }

        public IExportCustoms ExportCustoms { get; set; }
    }

    public class BookShipmentResponse : IBookShipmentResponse
    {

    }

    public static class BookShipmentRequestExtensions
    {
        public static BookShipmentRequest WithPieces(this BookShipmentRequest bookShipmentRequest, Action<PieceArrayFluent> builder)
        {
            var piecesArrayFluent = new PieceArrayFluent(new List<Piece>());
            builder(piecesArrayFluent);
            bookShipmentRequest.Pieces = ((List<Piece>)piecesArrayFluent).Cast<IPiece>().ToList();
            return bookShipmentRequest;
        }

        public static BookShipmentRequest WithReadyByDate(this BookShipmentRequest bookShipmentRequest,
            DateTime? currentDate = null)
        {
            if (currentDate == null) currentDate = DateTime.Now;
            bookShipmentRequest.ReadyByDate = currentDate.Value;
            return bookShipmentRequest;
        }

        public static BookShipmentRequest WithHawb(this BookShipmentRequest bookShipmentRequest, string hawb)
        {
            bookShipmentRequest.Hawb = hawb;
            return bookShipmentRequest;
        }

        public static BookShipmentRequest WithDescription(this BookShipmentRequest bookShipmentRequest,
            string description)
        {
            bookShipmentRequest.Description = description;
            return bookShipmentRequest;
        }

        public static BookShipmentRequest WithDocuments(this BookShipmentRequest bookShipmentRequest)
        {
            bookShipmentRequest.NonDox = false;
            bookShipmentRequest.Value = 0.00m;
            return bookShipmentRequest;
        }

        public static BookShipmentRequest WithNonDocuments(this BookShipmentRequest bookShipmentRequest,
            decimal shipmentValue)
        {
            bookShipmentRequest.NonDox = true;
            bookShipmentRequest.Value = shipmentValue;
            return bookShipmentRequest;
        }

        public static BookShipmentRequest WithCurrency(this BookShipmentRequest bookShipmentRequest,
            string currencyCode)
        {
            bookShipmentRequest.Currency = currencyCode;
            return bookShipmentRequest;
        }

        public static BookShipmentRequest WithDdp(this BookShipmentRequest bookShipmentRequest)
        {
            bookShipmentRequest.Ddp = true;
            return bookShipmentRequest;
        }

        public static BookShipmentRequest WithPallet(this BookShipmentRequest bookShipmentRequest)
        {
            bookShipmentRequest.Pallet = true;
            return bookShipmentRequest;
        }

        public static BookShipmentRequest WithRequester(this BookShipmentRequest bookShipmentRequest,
            string requesterName, string phoneNumber = "")
        {
            bookShipmentRequest.Requester = new Requester {Name = requesterName, PhoneNumber = phoneNumber};
            return bookShipmentRequest;
        }

        public static BookShipmentRequest WithConsignee(this BookShipmentRequest bookShipmentRequest,
            Action<AddressFluent> builder)
        {
            var consigneeBuilder = new AddressFluent(null);
            builder(consigneeBuilder);
            bookShipmentRequest.Consignee = consigneeBuilder as IAddress;
            return bookShipmentRequest;
        }

        public static BookShipmentRequest WithCollection(this BookShipmentRequest bookShipmentRequest,
            Action<CollectionAddressFluent> builder)
        {
            var collectionBuilder = new CollectionAddressFluent(null);
            builder(collectionBuilder);
            bookShipmentRequest.CollectionAddress = collectionBuilder as ICollectionAddress;
            return bookShipmentRequest;
        }

        public static BookShipmentRequest WithShipper(this BookShipmentRequest bookShipmentRequest,
            Action<AddressFluent> builder)
        {
            var shipperBuilder = new AddressFluent(null);
            builder(shipperBuilder);
            bookShipmentRequest.Shipper = shipperBuilder as IAddress;
            return bookShipmentRequest;
        }

        public static BookShipmentRequest WithServiceCode(this BookShipmentRequest bookShipmentRequest,
            string serviceCode)
        {
            bookShipmentRequest.Service = new Service {Code = serviceCode};
            return bookShipmentRequest;
        }

        public static BookShipmentRequest AsPdf(this BookShipmentRequest bookShipmentRequest)
        {
            bookShipmentRequest.LabelFormat = LabelFormat.Pdf;
            return bookShipmentRequest;
        }

        public static BookShipmentRequest AsEpl(this BookShipmentRequest bookShipmentRequest)
        {
            bookShipmentRequest.LabelFormat = LabelFormat.Epl;
            return bookShipmentRequest;
        }

        public static BookShipmentRequest AsZpl(this BookShipmentRequest bookShipmentRequest)
        {
            bookShipmentRequest.LabelFormat = LabelFormat.Zpl;
            return bookShipmentRequest;
        }

        public static BookShipmentRequest WithExportCustoms(this BookShipmentRequest bookShipmentRequest,
            Action<ExportCustomsFluent> builder)
        {
            var exportCustomersBuilder = new ExportCustomsFluent(null);
            builder(exportCustomersBuilder);
            bookShipmentRequest.ExportCustoms = exportCustomersBuilder as IExportCustoms;
            return bookShipmentRequest;
        }
    }
}
