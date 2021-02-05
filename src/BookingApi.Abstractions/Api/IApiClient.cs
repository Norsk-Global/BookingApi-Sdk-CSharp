using System;
using System.Threading.Tasks;
using BookingApi.Abstractions.Api.Endpoints;

namespace BookingApi.Abstractions.Api
{
    public interface IApiClient
    {
        string Endpoint { get; }

        void UseLiveApi();

        void UseStagingApi();

        void Authentication(string secretKey, string privateKey);

        Task<IBookShipmentResponse> BookShipment(Action<IBookShipmentRequest> requestBuilder);

        Task<IShipmentTrackingResponse> TrackShipment(Action<IShipmentTrackingRequest> requestBuilder);

        Task<string> GetShimpentScanImage(Action<IBookShipmentImageRequest> requestBuilder);

        Task<IBookShipmentDimensionResponse> GetShipmentDimensions(Action<IBookShipmentDimensionRequest> requestBuilder);

    }
}
