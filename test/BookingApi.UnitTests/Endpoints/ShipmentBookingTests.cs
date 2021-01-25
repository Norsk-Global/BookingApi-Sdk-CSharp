using System;
using System.Threading.Tasks;
using BookingApi.Core.Api.Endpoints;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Shouldly;
using Xunit;

namespace BookingApi.UnitTests.Endpoints
{
    public class ShipmentBookingTests
    {
        [Fact]
        public async Task WhenCreatingRequest_ShouldMatchApproved()
        {
            // Arrange
            var request = new BookShipmentRequest("/")
                .WithReadyByDate(new DateTime(2021, 01, 25, 14, 0, 0))
                .WithHawb("123123123")
                .WithDescription("test Clothing")
                .WithDocuments()
                .WithPieces(pieces => pieces
                    .AddPiece(piece => piece
                        .Depth(1.00m)
                        .Height(1.00m)
                        .Width(1.00m)
                        .Weight(1.00m)
                        .NumberOfPieces(1)))
                .WithConsignee(consignee => consignee
                    .ContactName("Test")
                    .Company("Test")
                    .Address1("2 Willow Road")
                    .Zipcode("SL3 0BS")
                    .City("Slough")
                    .CountryCode("GB"))
                .WithServiceCode("IEL");

            // Act
            var bookingJson = JsonConvert.SerializeObject(request, Formatting.Indented, new JsonSerializerSettings
            {
                NullValueHandling = NullValueHandling.Ignore,
                Converters = new [] {
                    new StringEnumConverter()
                }
            });

            // Assert
            bookingJson.ShouldMatchApproved();
        }
    }
}
