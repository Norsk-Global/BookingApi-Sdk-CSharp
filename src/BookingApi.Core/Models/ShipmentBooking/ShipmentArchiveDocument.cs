using System;
using System.IO;
using BookingApi.Abstractions.Models.ShipmentBooking;

namespace BookingApi.Core.Models.ShipmentBooking
{
    public class ShipmentArchiveDocument : IShipmentArchiveDocument
    {
        public byte[] Contents { get; set; }
        public string RawLabel() => Convert.ToBase64String(Contents);

        public Stream LabelStream() => new MemoryStream(Contents);
    }
}
