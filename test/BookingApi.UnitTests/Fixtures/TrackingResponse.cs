using System;
using System.Collections.Generic;
using System.Text;
using BookingApi.Abstractions.Models.ShipmentTracking;
using BookingApi.Core.Models.ShipmentTracking;

namespace BookingApi.UnitTests.Fixtures
{
    public class TrackingResponse
    {
        public string NorskBarcode { get; set; }
        public string Barcode { get; set; }
        public string Hawb { get; set; }

       
        public List<Narrative> Narrative { get; set; }

       
        public ProofOfDelivery ProofOfDelivery { get; set; }

      
        public Narrative Status { get; set; }
    }
}
