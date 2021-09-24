namespace BookingApi.Abstractions.Models.ShipmentBooking
{
    public interface IShipperAddress : IAddress
    {
        string Ioss { get; set; }
    }
}
