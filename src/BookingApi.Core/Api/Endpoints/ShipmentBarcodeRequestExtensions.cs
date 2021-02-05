using System;
using System.Collections.Generic;
using System.Text;
using BookingApi.Abstractions.Api.Endpoints;

namespace BookingApi.Core.Api.Endpoints
{
    public static class ShipmentBarcodeRequestExtensions
    {
        public static IBookShipmentImageRequest WithBarcode(this IBookShipmentImageRequest shipmentBarcodeRequest, string barcode)
        {
            shipmentBarcodeRequest.Barcode = barcode;
            return shipmentBarcodeRequest;
        }
    }
}
