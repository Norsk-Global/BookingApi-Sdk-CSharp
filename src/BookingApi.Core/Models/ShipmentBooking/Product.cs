using BookingApi.Abstractions.Models;
using BookingApi.Abstractions.Models.ShipmentBooking;

namespace BookingApi.Core.Models.ShipmentBooking
{
    public class Product : IProduct
    {
        public string ProductDescription { get; set; }
        public string CountryOfManufacture { get; set; }
        public string HSCode { get; set; }
        public decimal ProductValue { get; set; }
        public string Currency { get; set; }
        public decimal ProductWeight { get; set; }
        public int ProductQuantity { get; set; }
    }
}
