using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using BookingApi.Abstractions.Api;
using BookingApi.Abstractions.Api.Endpoints;
using BookingApi.Core.Serialization;
using Newtonsoft.Json;

namespace BookingApi.Core.Api.Endpoints
{
    public class ShipmentImageRequest : EndpointMethod, IEndpointUrl, IBookShipmentImageRequest
    {


        public ShipmentImageRequest(string baseUrl) : base(HttpMethod.Get)
        {
            BaseUrl = baseUrl;
        }
        [JsonIgnore]
        public string BaseUrl { get; }

        [JsonIgnore]
        public string Endpoint => BaseUrl +  $"/api/package/{Barcode}/scanimage";
        

        
        public string Barcode { get ; set; }
    }

   
}
