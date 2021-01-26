using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BookingApi.Core.Api;
using Xunit;
using Shouldly;

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
            client.Authentication("BDUOP27LZ7PZ6ZKZU2EIKYR6BILZNGBUCCYIAWFZO3AXHWYU", "TWXABEWZGLABHQIW");

            var response = await client.TrackShipment(builder => builder.Barcode = "703451258001");

            response.ShouldNotBeNull();
            response.NorskBarcode.ShouldBe("703451258001");
        }
    }
}
