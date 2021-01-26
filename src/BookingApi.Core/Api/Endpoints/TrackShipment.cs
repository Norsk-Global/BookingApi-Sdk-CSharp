using System.Collections.Generic;
using System.Net.Http;
using BookingApi.Abstractions.Api;
using BookingApi.Abstractions.Api.Endpoints;
using BookingApi.Abstractions.Models.ShipmentTracking;
using System.Linq;
using Newtonsoft.Json;
using BookingApi.Core.Serialization;

namespace BookingApi.Core.Api.Endpoints
{
    public class TrackShipmentRequest : EndpointMethod, IEndpointUrl, IShipmentTrackingRequest
    {
        public TrackShipmentRequest(string baseUrl) : base(HttpMethod.Get)
        {
            BaseUrl = baseUrl;
        }

        [JsonIgnore]
        public string BaseUrl { get; }


        [JsonIgnore]
        public string Endpoint => BaseUrl + $"/api/shipment/{Barcode}";

        public string Barcode { get; set; }
    }

    public class TrackShipmentResponse : IShipmentTrackingResponse
    {
        public string NorskBarcode { get; set; }
        public string Barcode { get; set; }
        public string Hawb { get; set; }

        [JsonProperty("Narrative")]
        [JsonConverter(typeof(ShipmentTrackingNarrativeVMSerializer))]
        public IList<INarrative> NarrativeVm { get; set; }

        [JsonConverter(typeof(ShipmentTrackingProofOfDeliverySerializer))]
        public IProofOfDelivery ProofOfDelivery { get; set; }

        [JsonConverter(typeof(ShipmentTrackingNarrativeVMLatestSerializer))]
        public INarrative Status { get; set; }

        
    }
}
