using System;
using System.Collections.Generic;
using System.Text;
using BookingApi.Abstractions.Api.Endpoints;

namespace BookingApi.Core.Http.Extensions
{
    public static class BookShipmentDimensionsRequestExtension
    {
        public static IBookShipmentDimensionRequest WithBarcode(this IBookShipmentDimensionRequest bookShipmentDimensionRequest, string value)
        {
            bookShipmentDimensionRequest.Barcode = value;
            return bookShipmentDimensionRequest;
        }
    }
}
