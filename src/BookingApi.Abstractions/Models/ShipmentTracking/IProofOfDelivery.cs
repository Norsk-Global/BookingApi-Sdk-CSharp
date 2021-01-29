using System;
using System.Collections.Generic;
using System.Text;

namespace BookingApi.Abstractions.Models.ShipmentTracking
{
    public interface IProofOfDelivery
    {
        DateTime SignedOn { get; set; }
        string SignedBy { get; set; }
    }
}
