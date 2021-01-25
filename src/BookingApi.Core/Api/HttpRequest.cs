using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using BookingApi.Abstractions.Api;
using BookingApi.Core.Http.Extensions;
using BookingApi.Core.Models.ShipmentBooking;

namespace BookingApi.Core.Api
{
    public class HttpRequest<TRequest, TResponse> : IHttpRequest<TRequest, ErrorResponse, TResponse>
    {
        public TRequest Request { get; }
        public TResponse Response { get; private set; }
        public ErrorResponse ErrorResponse { get; private set; }

        private HttpRequestMessage _requestMessage;

        public HttpRequest(TRequest request)
        {
            Request = request;
        }

        public async Task SendAsync(HttpClient client)
        {
            var responseMessage = await client.SendAsync(_requestMessage);

            if (responseMessage.StatusCode == HttpStatusCode.Unauthorized)
                throw new UnauthorizedAccessException();
            if (!responseMessage.IsSuccessStatusCode)
                ErrorResponse = await responseMessage.Content.ReadAsAsync<ErrorResponse>();
            else Response = await responseMessage.Content.ReadAsAsync<TResponse>();
        }

        public void ConstructRequest(Func<TRequest, HttpRequestMessage> requestPredicate) =>
            _requestMessage = requestPredicate(Request);

        public void ConstructRequest(Func<HttpRequestMessage> requestPredicate) => _requestMessage = requestPredicate();
    }
}
