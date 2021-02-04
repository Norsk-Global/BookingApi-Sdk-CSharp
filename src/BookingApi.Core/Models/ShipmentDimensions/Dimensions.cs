using System;
using System.Collections.Generic;
using System.Text;
using BookingApi.Abstractions.Models.ShipmentDimension;

namespace BookingApi.Core.Models.ShipmentDimensions
{
    public class Dimensions : IDimensions
    {
        public string NorskBarcode { get; set; }
        public decimal Depth { get; set; }
        public decimal Height { get; set; }
        public decimal Width { get; set; }
        public decimal Weight { get; set; }
        public decimal VolumeWeight { get; set; }
        public string ImageUrl { get; set; }
    }
}
