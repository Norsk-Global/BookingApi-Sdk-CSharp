using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BookingApi.UnitTests.Fixtures;
using Shouldly;
using Xunit;
using BookingApi.Core.Api.Endpoints;
using BookingApi.Core.Api;

namespace BookingApi.UnitTests.Endpoints
{
    public class ShipmentEndpointsTest
    {
        [Fact]
        public async Task Get_ScannedImage_Of_Booked_Shipment_Valid()
        {
            var client = FakeAPIClient.ApiInstance;
            client.UseStagingApi();
            client.Authentication("xxxxxxx", "xxxx");
            var response = await client.GetShimpentScanImage(builder => builder.WithBarcode("609898399001"));
            response.ShouldNotBeNull();
        }
    }
}
