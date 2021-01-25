namespace BookingApi.Abstractions.Models.ShipmentBooking
{
    public interface IProduct
    {
        string ProductDescription { get; set; }

        string CountryOfManufacture { get; set; }

        string HSCode { get; set; }

        decimal ProductValue { get; set; }

        string Currency { get; set; }

        decimal ProductWeight { get; set; }

        int ProductQuantity { get; set; }
    }
}
