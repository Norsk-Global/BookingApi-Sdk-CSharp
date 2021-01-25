using System.Collections.Generic;
using System.IO;
using BookingApi.Abstractions.Models.ShipmentBooking;

namespace BookingApi.Abstractions.Api.Endpoints
{
    public interface IBookShipmentResponse
    {
        string Barcode { get; set; }

        byte[] Label { get; set; }

        string NorskBarcode { get; set; }

        IList<IShipmentBookingItem> Items { get; set; }

        IList<IShipmentArchiveDocument> ArchiveDocuments { get; set; }

        string RawLabel();

        Stream LabelStream();
    }
}
