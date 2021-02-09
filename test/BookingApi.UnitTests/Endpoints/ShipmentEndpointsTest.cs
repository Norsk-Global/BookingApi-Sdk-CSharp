using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using BookingApi.UnitTests.Fixtures;
using Shouldly;
using Xunit;
using BookingApi.Core.Api.Endpoints;
using BookingApi.Core.Api;
using System.IO;

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


        [Fact]

        public async Task Get_Booked_Shipment_Label_Valid()
        {

            var client = FakeAPIClient.ApiInstance;
            client.UseStagingApi();
            client.Authentication("xxxxxxx", "xxxx");
            var response = await client.GetShimpentLabel(builder =>
              builder.WithBarcode("703794488001").WithLabelFormat("Pdf").WithLabelSize("A4")
              );

            response.ShouldNotBeNull();
        }
        [Fact]
        public async Task Get_BulkShipment_Dimensions_Valid()
        {
            var client = FakeAPIClient.ApiInstance;
            client.UseStagingApi();
            client.Authentication("xxxxxxx", "xxxx");
            
            var _endDate = new DateTime(2020, 07, 08, 16, 30, 0);
            var _startDate = _endDate.AddMinutes(-15);
            var response = await client.GetBulkShipmentDimensions(builder => builder.WithStartDate(_startDate).WithEndDate(_endDate));
            
            response.ShouldNotBeNull();
            response[0].Pieces.ShouldNotBeNull();

        }
    }
}
