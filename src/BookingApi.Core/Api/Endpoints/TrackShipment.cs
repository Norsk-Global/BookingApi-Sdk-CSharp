using System.Net.Http;
using BookingApi.Abstractions.Api;

namespace BookingApi.Core.Api.Endpoints
{
    public class TrackShipmentRequest : EndpointMethod, IEndpointUrl
    {
        public TrackShipmentRequest(string baseUrl) : base(HttpMethod.Get)
        {
            BaseUrl = baseUrl;
        }

        public string BaseUrl { get; }


        //TODO Change Endpoint
        public string Endpoint => BaseUrl + "/";
    }

    public class TrackShipmentResponse
    {}
}
