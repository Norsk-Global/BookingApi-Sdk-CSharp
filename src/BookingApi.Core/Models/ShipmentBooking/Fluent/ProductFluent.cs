using BookingApi.Abstractions.Models;
using BookingApi.Abstractions.Models.Fluent;
using BookingApi.Abstractions.Models.ShipmentBooking;
using BookingApi.Core.Models.Validation;

namespace BookingApi.Core.Models.ShipmentBooking.Fluent
{
    public class ProductFluent : FluentBuilder<Product, IProduct>
    {
        public ProductFluent(IProduct model) : base(model)
        {
        }

        [NotBeEmpty, BeBetweenLength(2, 35)]
        public ProductFluent ProductDescription(string productDescription)
        {
            Model.ProductDescription = Validate(productDescription);
            return this;
        }

        [NotBeEmpty, BeBetweenLength(2, 2)]
        public ProductFluent CountryOfManufacture(string countryOfManufacture)
        {
            Model.CountryOfManufacture = Validate(countryOfManufacture);
            return this;
        }

        [NotBeEmpty, BeBetweenLength(2, 10)]
        public ProductFluent HSCode(string hsCode)
        {
            Model.HSCode = Validate(hsCode);
            return this;
        }

        [GreaterThan(0)]
        public ProductFluent ProductValue(decimal productValue)
        {
            Model.ProductValue = Validate(productValue);
            return this;
        }

        [BeBetweenLength(3, 3)]
        public ProductFluent CurrencyCode(string currencyCode)
        {
            Model.Currency = Validate(currencyCode);
            return this;
        }

        [GreaterThan(0)]
        public ProductFluent ProductWeight(decimal productWeight)
        {
            Model.ProductWeight = Validate(productWeight);
            return this;
        }

        [GreaterThan(0)]
        public ProductFluent ProductQuantity(int productQuantity)
        {
            Model.ProductQuantity = Validate(productQuantity);
            return this;
        }
    }
}
