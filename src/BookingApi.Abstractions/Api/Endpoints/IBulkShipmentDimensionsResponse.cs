using System;
using System.Collections.Generic;
using System.Text;
using BookingApi.Abstractions.Models.ShipmentDimension;

namespace BookingApi.Abstractions.Api.Endpoints
{

    public interface IBulkShipmentDimensionResponse
    {
        string Barcode { get; set; }

        string NorskBarcode { get; set; }
        IList<IDimensions> Pieces { get; set; }
    }
    
}
