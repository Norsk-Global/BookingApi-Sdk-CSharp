using System.Collections.Generic;
using BookingApi.Abstractions.Models;
using BookingApi.Abstractions.Models.ShipmentBooking;

namespace BookingApi.Core.Models.ShipmentBooking
{
    public class Service : IService
    {
        public string Code { get; set; }
        public List<IEnhancement> Enhancements { get; set; }
        public string Supplier { get; set; }
        public string Route { get; set; }
    }
}
