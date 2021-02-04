using System;
using System.Collections.Generic;
using System.Text;
using BookingApi.Abstractions.Api.Endpoints;

namespace BookingApi.Core.Api.Endpoints
{
    public static class BulkShipmentDimensionsRequestExtensions 
    {
        public static IBulkShipmentDimensionsRequest WithStartDate(this IBulkShipmentDimensionsRequest IBulkShipmentDimensionRequest, DateTime startDate)
        {
            IBulkShipmentDimensionRequest.StartDateTime = startDate;
            return IBulkShipmentDimensionRequest;
        }
        public static IBulkShipmentDimensionsRequest WithEndDate(this IBulkShipmentDimensionsRequest IBulkShipmentDimensionRequest, DateTime endDate)
        {
            IBulkShipmentDimensionRequest.EndDateTime = endDate;
            return IBulkShipmentDimensionRequest;
        }
    }
}
