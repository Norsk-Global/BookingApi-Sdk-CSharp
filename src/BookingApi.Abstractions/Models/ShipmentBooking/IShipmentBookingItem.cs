using System.IO;

namespace BookingApi.Abstractions.Models.ShipmentBooking
{
    public interface IShipmentBookingItem
    {
        string NorskBarcode { get; set; }

        string Barcode { get; set; }

        byte[] Label { get; set; }

        string ScanBarcode { get; set; }

        decimal Weight { get; set; }

        string RawLabel();

        Stream LabelStream();
    }
}
