using System;
using System.Collections.Generic;
using System.Text;

namespace BookingApi.Abstractions.Api.Endpoints
{
    public interface IShipmentTrackingRequest
    {
        string Barcode { get; set; }
    }
}
