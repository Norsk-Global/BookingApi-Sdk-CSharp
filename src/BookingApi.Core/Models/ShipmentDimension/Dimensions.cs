using System;
using System.Collections.Generic;
using System.Text;
using BookingApi.Abstractions.Models.ShipmentDimension;

namespace BookingApi.Core.Models.ShipmentDimension
{
    public class Dimensions : IDimensions
    {
        public string Barcode { get; set; }
        public decimal Depth { get; set; }
        public decimal Height { get; set; }
        public decimal Width { get; set; }
        public decimal Weight { get; set; }
        public decimal VolumeWeight { get; set; }
        public string ImageUrl { get; set; }
    }
}
