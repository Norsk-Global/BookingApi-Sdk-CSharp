using BookingApi.Abstractions.Models.ShipmentBooking;

namespace BookingApi.Core.Models.ShipmentBooking
{
    public class ShipmentArchiveDocument : IShipmentArchiveDocument
    {
        public byte[] Contents { get; set; }
    }
}
