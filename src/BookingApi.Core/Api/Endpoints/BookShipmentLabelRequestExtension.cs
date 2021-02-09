using System;
using System.Collections.Generic;
using System.Text;
using BookingApi.Abstractions.Api.Endpoints;
using BookingApi.Abstractions.Models.ShipmentBooking;
using BookingApi.Abstractions.Models.ShipmentLabel ;

namespace BookingApi.Core.Api.Endpoints
{
    public static class BookShipmentLabelRequestExtension
    {
        public static IBookShipmentLabelRequest WithBarcode(this IBookShipmentLabelRequest shipmentBarcodeRequest, string barcode)
        {
            shipmentBarcodeRequest.Barcode = barcode;
            return shipmentBarcodeRequest;
        }
        public static IBookShipmentLabelRequest WithLabelFormat(this IBookShipmentLabelRequest shipmentLabelRequest, string labelFormat)
        {
            if(!String.IsNullOrWhiteSpace(labelFormat))
                shipmentLabelRequest.LabelFormat = (LabelFormat)Enum.Parse(typeof(LabelFormat), labelFormat);
            return shipmentLabelRequest;
        }
        public static IBookShipmentLabelRequest WithLabelSize(this IBookShipmentLabelRequest shipmentLabelRequest, string labelSize)
        {
            if (!String.IsNullOrWhiteSpace(labelSize))
                shipmentLabelRequest.LabelSize = (LabelSize)Enum.Parse(typeof(LabelSize), labelSize);
            return shipmentLabelRequest;
        }
    }


}
