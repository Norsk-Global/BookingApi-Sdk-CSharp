namespace BookingApi.Abstractions.Api
{
    public class Endpoint<TRequest, TResponse>
    {
        public Endpoint(TRequest request, TResponse response)
        {
            Request = request;
            Response = response;
        }

        TRequest Request { get; }

        TResponse Response { get; }
    }
}
