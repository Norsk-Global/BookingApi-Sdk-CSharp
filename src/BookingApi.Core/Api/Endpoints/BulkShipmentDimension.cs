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
    public class BulkShipmentDimensionRequest : EndpointMethod, IEndpointUrl, IBulkShipmentDimensionsRequest
    {
        [JsonIgnore]
        public string BaseUrl { get; }
        [JsonIgnore]
        public string Endpoint => BaseUrl + $"/api/bulk/shipment/dimensions?StartDateTime={StartDateTime:yyyy-MM-ddTHH:mm:ss}&EndDateTime={EndDateTime:yyyy-MM-ddTHH:mm:ss}";
        public BulkShipmentDimensionRequest(string BaseUrl) : base(HttpMethod.Get)
        {
            this.BaseUrl = BaseUrl;
        }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
    }

    public class BulkShipmentDimensionResponse : IBulkShipmentDimensionResponse
    {
        public string Barcode { get; set; }
        public string NorskBarcode { get; set; }
        [JsonConverter(typeof(BulkShipmentDimensionSerializer))]
        public IList<IDimensions> Pieces { get; set; }

       
    }
}
