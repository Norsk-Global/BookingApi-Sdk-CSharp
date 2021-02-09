using System;
using System.Collections.Generic;
using System.Text;

namespace BookingApi.Abstractions.Api.Endpoints
{
    public interface IBulkShipmentDimensionsRequest
    {
        DateTime StartDateTime { get; set; }
        DateTime EndDateTime { get; set; }
    }
}
