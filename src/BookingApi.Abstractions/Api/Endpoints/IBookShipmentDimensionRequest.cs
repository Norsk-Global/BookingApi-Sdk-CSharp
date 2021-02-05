using System;
using System.Collections.Generic;
using System.Text;

namespace BookingApi.Abstractions.Api.Endpoints
{
    public interface IBookShipmentDimensionRequest
    {

        string Barcode { get; set; }

    }
}
