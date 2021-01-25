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
            _model.ProductDescription = Validate(productDescription);
            return this;
        }

        [NotBeEmpty, BeBetweenLength(2, 2)]
        public ProductFluent CountryOfManufacture(string countryOfManufacture)
        {
            _model.CountryOfManufacture = Validate(countryOfManufacture);
            return this;
        }

        [NotBeEmpty, BeBetweenLength(2, 10)]
        public ProductFluent HSCode(string hsCode)
        {
            _model.HSCode = Validate(hsCode);
            return this;
        }

        [GreaterThan(0)]
        public ProductFluent ProductValue(decimal productValue)
        {
            _model.ProductValue = Validate(productValue);
            return this;
        }

        [BeBetweenLength(3, 3)]
        public ProductFluent CurrencyCode(string currencyCode)
        {
            _model.Currency = Validate(currencyCode);
            return this;
        }

        [GreaterThan(0)]
        public ProductFluent ProductWeight(decimal productWeight)
        {
            _model.ProductWeight = Validate(productWeight);
            return this;
        }

        [GreaterThan(0)]
        public ProductFluent ProductQuantity(int productQuantity)
        {
            _model.ProductQuantity = Validate(productQuantity);
            return this;
        }
    }
}
