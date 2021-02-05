using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BookingApi.Core.Api;
using BookingApi.UnitTests.Fixtures;
using BookingApi.Core.Http.Extensions;
using Shouldly;
using Xunit;

namespace BookingApi.UnitTests.Endpoints
{
    public class ShipmentDimensionTests
    {
        [Fact]
        public async Task GetShipmentDimension_WithBarcode_ShouldReturn_Result()
        {
            // Arrange
            var client = FakeAPIClient.ApiInstance;
            client.UseStagingApi();
            client.Authentication("xxxx", "xxxx");
            var response = await client.GetShipmentDimensions(builder => builder.WithBarcode("509125319001"));

            response.ShouldNotBeNull();
            response.NorskBarcode.ShouldBe("509125319001");
            response.Pieces[0].Depth.ShouldBe(30.5m);
        }
    }
}
