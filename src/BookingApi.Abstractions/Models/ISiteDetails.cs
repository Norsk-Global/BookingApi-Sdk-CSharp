namespace BookingApi.Abstractions.Models
{
    public interface ISiteDetails
    {
        string Location { get; set; }

        string ContainerReference { get; set; }
    }
}
