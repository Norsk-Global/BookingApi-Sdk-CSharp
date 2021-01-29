using System;
using System.Collections.Generic;
using System.Text;
using BookingApi.Abstractions.Models.ShipmentTracking;
using Newtonsoft.Json;

namespace BookingApi.Abstractions.Api.Endpoints
{
    public interface IShipmentTrackingResponse
    {
        string NorskBarcode { get; }
        string Barcode { get; }
        string Hawb { get; }

        INarrativeVm Status { get; set; }

        IList<INarrativeVm> Narrative { get; set; }

        IProofOfDelivery ProofOfDelivery { get; set; }

        
    }
}
