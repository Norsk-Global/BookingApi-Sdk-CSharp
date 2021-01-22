namespace BookingApi.Abstractions.Api
{
    public interface IEndpointUrl
    {
        string BaseUrl { get; }

        string Endpoint { get; }
    }
}
