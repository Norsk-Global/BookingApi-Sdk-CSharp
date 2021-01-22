using System.Net.Http;

namespace BookingApi.Abstractions.Api
{
    public abstract class EndpointMethod
    {
        public virtual HttpMethod Method { get; }

        public EndpointMethod(HttpMethod method)
        {
            Method = method;
        }
    }
}
