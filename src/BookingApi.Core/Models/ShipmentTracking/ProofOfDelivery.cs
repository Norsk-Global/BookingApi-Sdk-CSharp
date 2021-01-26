using System;
using System.Collections.Generic;
using System.Text;
using BookingApi.Abstractions.Models.ShipmentTracking;

namespace BookingApi.Core.Models.ShipmentTracking
{
    public class ProofOfDelivery : IProofOfDelivery
    {
        public DateTime SignedOn { get; set; }
        public string SignedBy { get; set; }
    }
}
