using System.Collections.Generic;
using BookingApi.Abstractions.Models;

namespace BookingApi.Core.Models
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
