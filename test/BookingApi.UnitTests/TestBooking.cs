using System;
using System.Threading.Tasks;
using BookingApi.Core.Api;
using BookingApi.Core.Api.Endpoints;
using BookingApi.UnitTests.Fixtures;
using Shouldly;
using Xunit;

namespace BookingApi.UnitTests
{
    public class TestBooking
    {
        [Fact]
        public async Task GivenValidDataAndKeys_ShouldBookShipment()
        {
            // Arrange
          
            var client = FakeAPIClient.ApiInstance;
            client.UseStagingApi();
          
            client.Authentication("xxxxx", "xxxxxxx");

            var response = await client.BookShipment(builder => builder
                .WithReadyByDate(DateTime.Now)
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
                    .Zipcode("10001")
                    .City("Paris")
                    .PhoneNumber("00000000000")
                    .MobileNumber("00000000000")
                    .CountryCode("FR"))
                .WithServiceCode("USV"));
            response.ShouldNotBeNull();
        }
    }
}
