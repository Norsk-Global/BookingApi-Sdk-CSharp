using System;
using System.IO;
using BookingApi.Abstractions.Models.ShipmentBooking;

namespace BookingApi.Core.Models.ShipmentBooking
{
    public class ShipmentBookingItem : IShipmentBookingItem
    {
        public string NorskBarcode { get; set; }

        public string Barcode { get; set; }

        public byte[] Label { get; set; }

        public string ScanBarcode { get; set; }

        public decimal Weight { get; set; }

        public string RawLabel() => Convert.ToBase64String(Label);

        public Stream LabelStream() => new MemoryStream(Label);
    }
}
