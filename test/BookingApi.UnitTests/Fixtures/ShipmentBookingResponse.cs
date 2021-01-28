using System;
using System.Collections.Generic;
using System.Text;
using BookingApi.Core.Models.ShipmentBooking;

namespace BookingApi.UnitTests.Fixtures
{
    public class ShipmentBookingResponse
    {
        public string Barcode { get; set; }
        public byte[] Label { get; set; }
        public string NorskBarcode { get; set; }

       
        public List<ShipmentBookingItem> Items { get; set; }

      
        public List<ShipmentArchiveDocument> ArchiveDocuments { get; set; }
    }
}
