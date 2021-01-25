using BookingApi.Abstractions.Models.ShipmentBooking;

namespace BookingApi.Core.Models.ShipmentBooking
{
    public class SiteDetails : ISiteDetails
    {
        public string Location { get; set; }
        public string ContainerReference { get; set; }
    }
}
