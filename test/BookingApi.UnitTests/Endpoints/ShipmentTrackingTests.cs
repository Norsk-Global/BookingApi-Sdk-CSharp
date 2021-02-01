using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BookingApi.Core.Api;
using Xunit;
using Shouldly;
using BookingApi.Core.Api.Endpoints;
using Moq;
using System.Net.Http;
using AutoFixture;
using Moq.Protected;
using System.Threading;
using System.Net.Http.Headers;
using BookingApi.UnitTests.Fixtures;

namespace BookingApi.UnitTests.Endpoints
{
    public class ShipmentTrackingTests
    {
        [Fact]
        public async Task ShipmentTracking_WithBarcode_Returns_Results()
        {
            // Arrange
            var client = FakeAPIClient.ApiInstance;
           
            client.UseStagingApi();
            client.Authentication("xxx", "xxxxxx");
            var response = await client.TrackShipment(builder => builder.WithBarcode("703451258001"));

            response.ShouldNotBeNull();
            response.NorskBarcode.ShouldBe("703451258001");
        }
    }
}
