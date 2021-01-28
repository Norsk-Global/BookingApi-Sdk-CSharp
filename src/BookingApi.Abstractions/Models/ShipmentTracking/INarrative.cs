using System;
using System.Collections.Generic;
using System.Text;

namespace BookingApi.Abstractions.Models.ShipmentTracking
{
    public interface INarrative
    {
        string Location { get; set; }
        string Action { get; set; }
        string StatusCode { get; set; }
        string Message { get; set; }
        DateTime RecordedOn { get; set; }
    }
}
