using System.Net.Http;
using BookingApi.Abstractions.Api;

namespace BookingApi.Core.Api.Endpoints
{
    public class BookShipmentEndpoint : Endpoint<BookShipmentRequest, BookShipmentResponse>
    {
        public BookShipmentEndpoint(BookShipmentRequest request, BookShipmentResponse response) : base(request,
            response)
        {
        }
    }

    public class BookShipmentRequest : EndpointMethod, IEndpointUrl
    {
        public BookShipmentRequest(string baseUrl) : base(HttpMethod.Post)
        {
            BaseUrl = baseUrl;
        }

        public string BaseUrl { get; }
        public string Endpoint => BaseUrl + "/api/shipment";
    }

    public class BookShipmentResponse
    {

    }
}
