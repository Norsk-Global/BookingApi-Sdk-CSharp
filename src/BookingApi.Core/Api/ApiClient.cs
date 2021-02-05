using System;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BookingApi.Abstractions.Api;
using BookingApi.Abstractions.Api.Endpoints;
using BookingApi.Abstractions.Models.ShipmentDimension;
using BookingApi.Core.Api.Endpoints;
using BookingApi.Core.Models.ShipmentBooking;
using BookingApi.Core.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace BookingApi.Core.Api
{
    public class ApiClient : IApiClient
    {
        public static volatile IApiClient ApiInstance = new ApiClient();

        private static volatile HttpClient _httpClient = new HttpClient();
        private static volatile SemaphoreSlim _lock = new SemaphoreSlim(1, 1);

        private bool _isTestingMode = false;
        private string _secretKey = null;
        private string _privateKey = null;

        private readonly JsonSerializerSettings _serializerSettings;

        public ApiClient()
        {
            _serializerSettings = new JsonSerializerSettings {
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented,
                Converters = new JsonConverter[] {
                    new StringEnumConverter()
                }
            };
        }

        public string Endpoint => _isTestingMode ? "http://dev-api.norsk-global.com" : "http://api.norsk-global.com";

        public void UseLiveApi() => _isTestingMode = false;

        public void UseStagingApi() => _isTestingMode = true;

        public void Authentication(string secretKey, string privateKey)
        {
            _secretKey = secretKey;
            _privateKey = privateKey;
        }

        public async Task<IShipmentTrackingResponse> TrackShipment(Action<IShipmentTrackingRequest> requestBuilder)
        {
            if (string.IsNullOrEmpty(_secretKey) || string.IsNullOrEmpty(_privateKey))
                throw new NotImplementedException();

            var request = new TrackShipmentRequest(Endpoint);
            requestBuilder(request);

            var rawJson = JsonConvert.SerializeObject(request, _serializerSettings);
            var httpRequest = new HttpRequest<TrackShipmentRequest, TrackShipmentResponse>(request);

            httpRequest.ConstructRequest(() => {
                var requestDateTime = DateTime.Now;

                var message = new HttpRequestMessage(request.Method, request.Endpoint) {
                    Content = new StringContent(rawJson)
                };

                message.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

                var authentication = SignRequest(request.Method, rawJson, message.Content.Headers.ContentType.ToString(),
                    $"/api/shipment/{request.Barcode}", requestDateTime);

                message.Headers.TryAddWithoutValidation("Authorization", $"{_privateKey}:{authentication}");
                message.Headers.Date = requestDateTime;
                return message;
            });

            return await SendWithLock(httpRequest);
        }
        public async Task<IBookShipmentResponse> BookShipment(Action<IBookShipmentRequest> requestBuilder)
        {
            if (string.IsNullOrEmpty(_secretKey) || string.IsNullOrEmpty(_privateKey))
                throw new NotImplementedException();

            var request = new BookShipmentRequest(Endpoint);
            requestBuilder(request);

            var rawJson = JsonConvert.SerializeObject(request, _serializerSettings);
            var httpRequest = new HttpRequest<BookShipmentRequest, BookShipmentResponse>(request);

            httpRequest.ConstructRequest(() => {
                var requestDateTime = DateTime.Now;

                var message = new HttpRequestMessage(request.Method, request.Endpoint)
                {
                    Content = new StringContent(rawJson)
                };

                message.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

                var authentication = SignRequest(request.Method, rawJson, message.Content.Headers.ContentType.ToString(),
                    "/api/shipment/", requestDateTime);

                message.Headers.TryAddWithoutValidation("Authorization", $"{_privateKey}:{authentication}");
                message.Headers.Date = requestDateTime;
                return message;
            });

            return await SendWithLock(httpRequest);
        }



        public async Task<string> GetShimpentScanImage(Action<IBookShipmentImageRequest> requestBuilder)
        {
            if (string.IsNullOrEmpty(_secretKey) || string.IsNullOrEmpty(_privateKey))
                throw new NotImplementedException();

            var request = new ShipmentImageRequest(Endpoint);
            requestBuilder(request);

            var rawJson = JsonConvert.SerializeObject(request, _serializerSettings);
            var httpRequest = new HttpRequest<ShipmentImageRequest, string>(request);

            httpRequest.ConstructRequest(() => {
                var requestDateTime = DateTime.Now;

                var message = new HttpRequestMessage(request.Method, request.Endpoint) {
                    Content = new StringContent(rawJson)
                };

                message.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

                var authentication = SignRequest(request.Method, rawJson, message.Content.Headers.ContentType.ToString(),
                    $"/api/package/{request.Barcode}/scanimage", requestDateTime);

                message.Headers.TryAddWithoutValidation("Authorization", $"{_privateKey}:{authentication}");
                message.Headers.Date = requestDateTime;
                return message;
            });

            return await SendWithLock(httpRequest);
        }

        public async Task<IBookShipmentDimensionResponse> GetShipmentDimensions(Action<IBookShipmentDimensionRequest> requestBuilder)

        {
            if (string.IsNullOrEmpty(_secretKey) || string.IsNullOrEmpty(_privateKey))
                throw new NotImplementedException();


            var request = new ShipmentImageRequest(Endpoint);
            requestBuilder(request);

            var rawJson = JsonConvert.SerializeObject(request, _serializerSettings);
            var httpRequest = new HttpRequest<ShipmentImageRequest, string>(request);

            var request = new ShipmentDimensionRequest(Endpoint);
            requestBuilder(request);

            var rawJson = JsonConvert.SerializeObject(request, _serializerSettings);
            var httpRequest = new HttpRequest<ShipmentDimensionRequest, ShipmentDimensionResponse>(request);


            httpRequest.ConstructRequest(() => {
                var requestDateTime = DateTime.Now;

                var message = new HttpRequestMessage(request.Method, request.Endpoint) {
                    Content = new StringContent(rawJson)
                };

                message.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

                var authentication = SignRequest(request.Method, rawJson, message.Content.Headers.ContentType.ToString(),

                    $"/api/shipment/{request.Barcode}/dimensions", requestDateTime);

                message.Headers.TryAddWithoutValidation("Authorization", $"{_privateKey}:{authentication}");
                message.Headers.Date = requestDateTime;
                return message;
            });

            return await SendWithLock(httpRequest);
        }

        private string SignRequest(HttpMethod method, string rawJson, string contentType, string endpoint, DateTime dateTime)
        {
            var md5 = MD5.Create();

            var authBuilder = new StringBuilder();
            authBuilder.Append(method).Append("\n");
            authBuilder.Append(BitConverter.ToString(md5.ComputeHash(Encoding.UTF8.GetBytes(rawJson)))
                .Replace("-", "").ToLowerInvariant()).Append("\n");
            authBuilder.Append(contentType).Append("\n");
            authBuilder.Append(dateTime.ToUniversalTime().ToString("r")).Append("\n");
            authBuilder.Append(endpoint);

            var hmacsha1 = new HMACSHA1 {Key = Encoding.UTF8.GetBytes(_secretKey)};
            var signBytes = Encoding.UTF8.GetBytes(authBuilder.ToString());
            var hashResult = hmacsha1.ComputeHash(signBytes);

            return Convert.ToBase64String(hashResult);
        }

        private static async Task<TResponse> SendWithLock<TRequest, TResponse>(IHttpRequest<TRequest, ErrorResponse, TResponse> httpRequest)
        {
            await _lock.WaitAsync();

            await httpRequest.SendAsync(_httpClient).ConfigureAwait(false);

            _lock.Release();

            if (httpRequest.Response != null)
                return httpRequest.Response;

            // TODO Handle Error responses
            throw new NotImplementedException();
        }

       
    }
}
