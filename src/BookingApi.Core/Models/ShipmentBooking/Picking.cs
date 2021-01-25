using BookingApi.Abstractions.Models.ShipmentBooking;

namespace BookingApi.Core.Models.ShipmentBooking
{
    public class Picking : IPicking
    {
        public string Instructions { get; set; }
    }
}
