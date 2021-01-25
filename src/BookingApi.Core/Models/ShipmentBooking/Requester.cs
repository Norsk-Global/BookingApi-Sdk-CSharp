using BookingApi.Abstractions.Models.ShipmentBooking;

namespace BookingApi.Core.Models.ShipmentBooking
{
    public class Requester : IRequester
    {
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
    }
}
