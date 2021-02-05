using System;
using System.Collections.Generic;
using System.Text;

namespace BookingApi.Abstractions.Models.ShipmentDimension
{
    public interface IDimensions
    {

        string NorskBarcode { get; set; }
        decimal Depth { get; set; }
        decimal Height { get; set; }
        decimal Width { get; set; }
        decimal Weight { get; set; }
        decimal VolumeWeight { get; set; }
        string ImageUrl { get; set; }
    }
}
