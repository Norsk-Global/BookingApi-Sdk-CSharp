using System;
using System.Collections.Generic;
using System.Text;
using BookingApi.Abstractions.Api.Endpoints;

namespace BookingApi.Core.Api.Endpoints
{
    public static class ShipmentTrackingExtensions
    {
        public static IShipmentTrackingRequest WithBarcode(this IShipmentTrackingRequest shipmentTrackingRequest, string barcode)
        {
            shipmentTrackingRequest.Barcode = barcode;
            return shipmentTrackingRequest;
        }
    }
}
