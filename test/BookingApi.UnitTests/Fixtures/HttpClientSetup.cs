using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using AutoFixture;
using BookingApi.Abstractions.Api.Endpoints;
using BookingApi.Abstractions.Models.ShipmentBooking;
using BookingApi.Abstractions.Models.ShipmentDimension;
using BookingApi.Abstractions.Models.ShipmentTracking;
using BookingApi.Core.Api.Endpoints;
using BookingApi.Core.Models.ShipmentBooking;
using BookingApi.Core.Models.ShipmentDimensions;
using BookingApi.Core.Models.ShipmentTracking;
using Moq;
using Moq.Protected;

namespace BookingApi.UnitTests.Fixtures
{
    public static class HttpClientSetup
    {
        public  static HttpClient SetupHttpClient()
        {
            var httpMessageHandler = new Mock<HttpMessageHandler>();
            var fixture = new Fixture();


            httpMessageHandler.Protected()
                .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.IsAny<HttpRequestMessage>(),
                    ItExpr.IsAny<CancellationToken>()
                )
                .ReturnsAsync((HttpRequestMessage request, CancellationToken token) => {
                    var response = new HttpResponseMessage();
                    response.StatusCode = System.Net.HttpStatusCode.OK;
                    if (request.RequestUri.Segments[request.RequestUri.Segments.Length - 1] == "703451258001") {
                        response.Content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(new TrackShipmentResponse() {
                            NorskBarcode = "703451258001",
                            Barcode = "1641620934",
                            Hawb = "305670",
                            Status = new NarrativeVm() {
                                Location = "SCN LYS-France-FR-(Lyon)                          ",
                                Action = "Status Change",
                                Message = "Status changed to: POD",
                                StatusCode = "802",
                                RecordedOn = DateTime.Parse("2020-10-22T09:15:11.517")
                            },
                            Narrative = new List<INarrativeVm>() {
                            new NarrativeVm() {
                            Location = "SCN LYS-France-FR-(Lyon)                          ",
                            Action = "Status Change",
                            Message = "Status changed to: POD",
                            StatusCode = "802",
                            RecordedOn = DateTime.Parse("2020-10-22T09:15:11.517")
                        } },
                            ProofOfDelivery = new ProofOfDelivery() {
                                SignedOn = DateTime.Parse("2020-10-22T10:08:00"),
                                SignedBy = "MOURIER M"
                            }
                        }
                        ));
                    } else if (request.RequestUri.Segments[request.RequestUri.Segments.Length - 1] == "scanimage") {
                        response.Content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject("/9j/2wBDACAWGBwYFCAcGhwkIiAmMFA0MCwsMGJGSjpQdGZ6eHJmcG6AkLicgIiuim5woNqirr7EztDOfJri8uDI8LjKzsb//9wABBPo/9k="));
                    } else if (request.RequestUri.Segments[request.RequestUri.Segments.Length - 1] == "label") {
                        response.Content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(new byte[] {23,45,58 }), UTF8Encoding.UTF8, "application/pdf");
                    }else if (request.RequestUri.Segments[request.RequestUri.Segments.Length - 1] == "dimensions" &&
                              !(request.RequestUri.LocalPath.Contains("/bulk/shipment/dimensions"))
                              )
                              {
                                response.Content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(new ShipmentDimensionResponse() {
                                    NorskBarcode = "509125319001",
                                    Barcode = "1641620934",
                                    Pieces = new List<IDimensions>() {
                                        new Dimensions {
                                             ImageUrl = "api/1641620934/Image",
                                              Depth = 30.5000000000m,
                                              Height = 16.0m,
                                              VolumeWeight = 1.0m,
                                              Width = 2.0m,
                                              Weight = 1m
                                        }
                                    }
                                }
                                ));
                    } else if (request.RequestUri.LocalPath.Contains("/bulk/shipment/dimensions")) {
                        response.Content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(
                            new List<IBulkShipmentDimensionResponse> {
                             new BulkShipmentDimensionResponse(){
                                                                    Barcode="12334",
                                                                    NorskBarcode="212321",
                                                                    Pieces = new List<IDimensions> {
                                                                                                       new  Dimensions {
                                                                                                                        Depth=20.0m,
                                                                                                                        Height=10.0m,
                                                                                                                        VolumeWeight=45.0m,
                                                                                                                        Weight=4.5m,
                                                                                                                        Width=10.0m,
                                                                                                                        NorskBarcode="1"
                                                                                                                        },
                                                                                                        new Dimensions {
                                                                                                                        Depth=20.0m,
                                                                                                                        Height=10.0m,
                                                                                                                        VolumeWeight=45.0m,
                                                                                                                        Weight=4.5m,
                                                                                                                        Width=10.0m,
                                                                                                                        NorskBarcode="4"
                                                                                                                        }
                                                                                                    }
                                                                 }
                            })
                            );
                    } else {
                        response.Content = new StringContent(Newtonsoft.Json.JsonConvert.SerializeObject(new BookShipmentResponse() {
                            NorskBarcode = "703451258001",
                            Barcode = "1641620934",
                            Label = new byte[1] { 23 },
                            ArchiveDocuments = new List<IShipmentArchiveDocument>() {
                                new ShipmentArchiveDocument(){Contents = new byte[1] { 23 } }
                            },
                            Items = new List<IShipmentBookingItem>()
                            {
                                new ShipmentBookingItem{ Barcode = "1641620934", Label = new byte[1]{ 23 }, NorskBarcode="703451258001", ScanBarcode="XXXXX", Weight=0.78M }
                            }
                        }
                   ));
                    }
                    

                    response.Content.Headers.ContentType = response.Content.Headers.ContentType ?? new MediaTypeHeaderValue("application/json");
                    return response;
                });

            var httpClient = new HttpClient(httpMessageHandler.Object);
            httpClient.BaseAddress = fixture.Create<Uri>();
            return httpClient;
        }
    }
}
