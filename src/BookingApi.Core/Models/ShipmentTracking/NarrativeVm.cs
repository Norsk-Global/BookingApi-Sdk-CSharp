using System;
using System.Collections.Generic;
using System.Text;
using BookingApi.Abstractions.Models.ShipmentTracking;

namespace BookingApi.Core.Models.ShipmentTracking
{
    public class NarrativeVm : INarrativeVm
    {
        public string Location { get; set; }
        public string Action { get; set; }
        public string StatusCode { get; set; }
        public string Message { get; set; }
        public DateTime RecordedOn { get; set; }
    }
}
