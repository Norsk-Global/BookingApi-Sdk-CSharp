namespace BookingApi.Abstractions.Models.ShipmentBooking
{
    public interface ISiteDetails
    {
        string Location { get; set; }

        string ContainerReference { get; set; }
    }
}
