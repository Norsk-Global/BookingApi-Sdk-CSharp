using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using BookingApi.Abstractions.Api;
using BookingApi.Abstractions.Api.Endpoints;
using BookingApi.Core.Api.Endpoints;
using BookingApi.Core.Models.ShipmentBooking;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using AutoFixture;
using BookingApi.Core.Api;
using Moq;
using Moq.Protected;
using System.Collections.Generic;
using BookingApi.Abstractions.Models.ShipmentTracking;
using BookingApi.Core.Models.ShipmentTracking;
using BookingApi.Abstractions.Models.ShipmentBooking;
using BookingApi.Abstractions.Models.ShipmentDimension;

namespace BookingApi.UnitTests.Fixtures
{
    public class FakeAPIClient : IApiClient
    {
        public static volatile IApiClient ApiInstance = new FakeAPIClient();

        public static volatile HttpClient _httpClient;
        

        private bool _isTestingMode = false;
        private string _secretKey = null;
        private string _privateKey = null;
        public FakeAPIClient()
        {

            _serializerSettings = new JsonSerializerSettings {
                NullValueHandling = NullValueHandling.Ignore,
                Formatting = Formatting.Indented,
                Converters = new JsonConverter[] {
                    new StringEnumConverter()
                }
            };

		_httpClient = HttpClientSetup.SetupHttpClient();
        }
		
        private readonly JsonSerializerSettings _serializerSettings;

        public string Endpoint => _isTestingMode ? "http://dev-api.norsk-global.com" : "http://api.norsk-global.com";

        public void Authentication(string secretKey, string privateKey)
        {
            _secretKey = secretKey;
            _privateKey = privateKey;
        }


        public async Task<IBookShipmentDimensionResponse> GetShipmentDimensions(Action<IBookShipmentDimensionRequest> requestBuilder)
        {
            if (string.IsNullOrEmpty(_secretKey) || string.IsNullOrEmpty(_privateKey))
                throw new NotImplementedException();

            var request = new ShipmentDimensionRequest(_httpClient.BaseAddress.ToString());
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

            return await SendRequest(httpRequest);
        }


        public async Task<IBookShipmentResponse> BookShipment(Action<IBookShipmentRequest> requestBuilder)
        {
           
            if (string.IsNullOrEmpty(_secretKey) || string.IsNullOrEmpty(_privateKey))
                throw new NotImplementedException();

            var request = new BookShipmentRequest(_httpClient.BaseAddress.ToString());
            requestBuilder(request);

            var rawJson = JsonConvert.SerializeObject(request, _serializerSettings);
            var httpRequest = new HttpRequest<BookShipmentRequest, BookShipmentResponse>(request);

            httpRequest.ConstructRequest(() => {
                var requestDateTime = DateTime.Now;

                var message = new HttpRequestMessage(request.Method, request.Endpoint) {
                    Content = new StringContent(rawJson)
                };

                message.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

                var authentication = SignRequest(request.Method, rawJson, message.Content.Headers.ContentType.ToString(),
                    "/api/shipment/", requestDateTime);

                message.Headers.TryAddWithoutValidation("Authorization", $"{_privateKey}:{authentication}");
                message.Headers.Date = requestDateTime;
                return message;
            });
            return await SendRequest(httpRequest);
        }

        public async Task<IShipmentTrackingResponse> TrackShipment(Action<IShipmentTrackingRequest> requestBuilder)
        {
           
            if (string.IsNullOrEmpty(_secretKey) || string.IsNullOrEmpty(_privateKey))
                throw new NotImplementedException();

            var request = new TrackShipmentRequest(_httpClient.BaseAddress.ToString());
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

            return await SendRequest(httpRequest);
        }

        public void UseLiveApi() => _isTestingMode = false;

        public void UseStagingApi() => _isTestingMode = true;
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

            var hmacsha1 = new HMACSHA1 { Key = Encoding.UTF8.GetBytes(_secretKey) };
            var signBytes = Encoding.UTF8.GetBytes(authBuilder.ToString());
            var hashResult = hmacsha1.ComputeHash(signBytes);

            return Convert.ToBase64String(hashResult);
        }

        private static async Task<TResponse> SendRequest<TRequest, TResponse>(IHttpRequest<TRequest, ErrorResponse, TResponse> httpRequest)
        {
            await httpRequest.SendAsync(_httpClient).ConfigureAwait(false);

            if (httpRequest.Response != null)
                return httpRequest.Response;

          
            throw new NotImplementedException();
        }

        public async Task<string> GetShimpentScanImage(Action<IBookShipmentImageRequest> requestBuilder)
        {
            if (string.IsNullOrEmpty(_secretKey) || string.IsNullOrEmpty(_privateKey))
                throw new NotImplementedException();

            var request = new ShipmentImageRequest(_httpClient.BaseAddress.ToString());
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

            return await SendRequest(httpRequest);
        }


        public async Task<byte[]> GetShimpentLabel(Action<IBookShipmentLabelRequest> requestBuilder)
        {
            if (string.IsNullOrEmpty(_secretKey) || string.IsNullOrEmpty(_privateKey))
                throw new NotImplementedException();

            var request = new ShipmentLabelRequest(_httpClient.BaseAddress.ToString());
            requestBuilder(request);

            var rawJson = JsonConvert.SerializeObject(request, _serializerSettings);
            var httpRequest = new HttpRequest<ShipmentLabelRequest, byte[]>(request);

            httpRequest.ConstructRequest(() => {
                var requestDateTime = DateTime.Now;

                var message = new HttpRequestMessage(request.Method, request.Endpoint) {
                    Content = new StringContent(rawJson)
                };

                message.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

                var authentication = SignRequest(request.Method, rawJson, message.Content.Headers.ContentType.ToString(),
                    $"/api/shipment/{request.Barcode}/label", requestDateTime);

                message.Headers.TryAddWithoutValidation("Authorization", $"{_privateKey}:{authentication}");
                message.Headers.Date = requestDateTime;
                return message;
            });
            return await SendRequest(httpRequest);
        }

        public async Task<List<IBulkShipmentDimensionResponse>> GetBulkShipmentDimensions(Action<IBulkShipmentDimensionsRequest> requestBuilder)
        {
            if(string.IsNullOrEmpty(_secretKey) || string.IsNullOrEmpty(_privateKey))
                throw new NotImplementedException();

            var request = new BulkShipmentDimensionRequest(_httpClient.BaseAddress.ToString());
            requestBuilder(request);

            var rawJson = JsonConvert.SerializeObject(request, _serializerSettings);
            var httpRequest = new HttpRequest<BulkShipmentDimensionRequest, List<BulkShipmentDimensionResponse>>(request);

            httpRequest.ConstructRequest(() => {
                var requestDateTime = DateTime.Now;

                var message = new HttpRequestMessage(request.Method, request.Endpoint) {
                    Content = new StringContent(rawJson)
                };

                message.Content.Headers.ContentType = MediaTypeHeaderValue.Parse("application/json");

                var authentication = SignRequest(request.Method, rawJson, message.Content.Headers.ContentType.ToString(),
                    $"/api/bulk/shipment/dimensions",
                    requestDateTime);
                message.Headers.TryAddWithoutValidation("Authorization", $"{_privateKey}:{authentication}");
                message.Headers.Date = requestDateTime;
                return message;
            });
            return new List<IBulkShipmentDimensionResponse>(await SendRequest(httpRequest));
        }
    }
}
