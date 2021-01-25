namespace BookingApi.Abstractions.Models
{
    public interface IRequester
    {
        string Name { get; set; }

        string PhoneNumber { get; set; }
    }
}
