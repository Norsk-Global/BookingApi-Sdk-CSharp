using System.IO;

namespace BookingApi.Abstractions.Models.ShipmentBooking
{
    public interface IShipmentArchiveDocument
    {
        byte[] Contents { get; set; }

        string RawLabel();

        Stream LabelStream();
    }
}
