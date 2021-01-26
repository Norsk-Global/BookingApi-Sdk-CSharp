using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BookingApi.Core.Api;
using Xunit;
using Shouldly;
using BookingApi.Core.Api.Endpoints;

namespace BookingApi.UnitTests.Endpoints
{
    public class ShipmentTrackingTests
    {
        [Fact]
        public async Task ShipmentTracking_WithBarcode_Returns_Results()
        {
            // Arrange
            var client = ApiClient.ApiInstance;
            client.UseStagingApi();
            client.Authentication("", "");

            var response = await client.TrackShipment(builder => builder.WithBarcode("703451258001"));

            response.ShouldNotBeNull();
            response.NorskBarcode.ShouldBe("703451258001");
        }
    }
}
