using System;
using System.Collections.Generic;
using System.Net.Http;
using BookingApi.Abstractions.Api;
using BookingApi.Abstractions.Api.Endpoints;
using BookingApi.Abstractions.Models.ShipmentBooking;
using BookingApi.Core.Serialization;
using Newtonsoft.Json;

namespace BookingApi.Core.Api.Endpoints
{
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
        public string Barcode { get; set; }
        public byte[] Label { get; set; }
        public string NorskBarcode { get; set; }

        [JsonConverter(typeof(ShipmentBookingItemSerializer))]
        public IList<IShipmentBookingItem> Items { get; set; }

        [JsonConverter(typeof(ShipmentArchiveDocumentSerializer))]
        public IList<IShipmentArchiveDocument> ArchiveDocuments { get; set; }
    }
}
