using System;
using System.Collections.Generic;
using System.Text;
using BookingApi.Abstractions.Models.ShipmentBooking;
using BookingApi.Abstractions.Models.ShipmentLabel;

namespace BookingApi.Abstractions.Api.Endpoints
{
    public interface IBookShipmentLabelRequest
    {
        string Barcode { get; set; }
        LabelFormat? LabelFormat { get; set; }

        LabelSize? LabelSize { get; set; }
    }
}
