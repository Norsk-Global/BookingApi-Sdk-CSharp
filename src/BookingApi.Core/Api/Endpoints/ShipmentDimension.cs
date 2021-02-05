using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using BookingApi.Abstractions.Api;
using BookingApi.Abstractions.Api.Endpoints;
using BookingApi.Abstractions.Models.ShipmentDimension;
using BookingApi.Core.Serialization;
using Newtonsoft.Json;

namespace BookingApi.Core.Api.Endpoints
{
    public class ShipmentDimensionResponse : IBookShipmentDimensionResponse
    {
        public string Barcode { get; set; }
        public string NorskBarcode { get; set; }
        [JsonConverter(typeof(BookShipmentDimensionResponseSerializer))]
        public IList<IDimensions> Pieces { get; set; }
    }
    public class ShipmentDimensionRequest : EndpointMethod, IEndpointUrl, IBookShipmentDimensionRequest
    {

        public ShipmentDimensionRequest(string baseUrl) : base(HttpMethod.Get)
        {
            BaseUrl = baseUrl;
        }
        [JsonIgnore]
        public string BaseUrl { get; }

        [JsonIgnore]
        public string Endpoint => BaseUrl + $"/api/shipment/{Barcode}/dimensions";

        public string Barcode { get; set; }
    }

   
}
