using System.Collections.Generic;

namespace BookingApi.Abstractions.Models
{
    public interface IPiece
    {
        decimal Depth { get; set; }

        decimal Height { get; set; }

        decimal Width { get; set; }

        decimal Weight { get; set; }

        int NumberOfPieces { get; set; }

        List<IProduct> Products { get; set; }
    }
}
