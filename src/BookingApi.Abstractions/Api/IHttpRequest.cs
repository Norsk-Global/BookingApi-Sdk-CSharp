using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace BookingApi.Abstractions.Api
{
    public interface IHttpRequest<out TRequest, out TError, out TResponse>
    {
        TRequest Request { get; }

        TResponse Response { get; }

        TError ErrorResponse { get; }

        Task SendAsync(HttpClient client);

        void ConstructRequest(Func<TRequest, HttpRequestMessage> requestPredicate);

        void ConstructRequest(Func<HttpRequestMessage> requestPredicate);
    }
}
