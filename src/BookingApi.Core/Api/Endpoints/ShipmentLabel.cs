using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using BookingApi.Abstractions.Api;
using BookingApi.Abstractions.Api.Endpoints;
using BookingApi.Abstractions.Models.ShipmentBooking;
using BookingApi.Abstractions.Models.ShipmentLabel;

namespace BookingApi.Core.Api.Endpoints
{
    public class ShipmentLabelRequest : EndpointMethod, IEndpointUrl, IBookShipmentLabelRequest
    {


        public ShipmentLabelRequest(string BaseUrl) : base(HttpMethod.Get)
        {
            this.BaseUrl = BaseUrl;
        }
        public string Barcode { get; set; }
        public LabelFormat? LabelFormat { get; set; }
        public LabelSize? LabelSize { get; set; }

        public string BaseUrl { get; }

        public string Endpoint => BaseUrl + _getEndPoint();

        private string _getEndPoint()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append($"/api/shipment/{Barcode}/label?");
            if(LabelFormat.HasValue) {
                sb.Append($"format={LabelFormat.GetValueOrDefault()}");
            }
            if (LabelSize.HasValue) {
                sb.Append($"&size={LabelSize.GetValueOrDefault()}");
            }
            return sb.ToString();
        }
    }
}
