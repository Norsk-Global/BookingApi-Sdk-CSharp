using System.Net.Http;
using Newtonsoft.Json;

namespace BookingApi.Abstractions.Api
{
    public abstract class EndpointMethod
    {
        [JsonIgnore]
        public virtual HttpMethod Method { get; }

        public EndpointMethod(HttpMethod method)
        {
            Method = method;
        }
    }
}
