using System.Collections.Generic;
using BookingApi.Abstractions.Models;
using BookingApi.Abstractions.Models.ShipmentBooking;

namespace BookingApi.Core.Models.ShipmentBooking
{
    public class Piece : IPiece
    {
        public decimal Depth { get; set; }
        public decimal Height { get; set; }
        public decimal Width { get; set; }
        public decimal Weight { get; set; }
        public int NumberOfPieces { get; set; }
        public List<IProduct> Products { get; set; }
    }
}
