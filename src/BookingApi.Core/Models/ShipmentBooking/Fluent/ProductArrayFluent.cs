using System;
using System.Collections.Generic;
using BookingApi.Abstractions.Models;
using BookingApi.Abstractions.Models.Fluent;
using BookingApi.Abstractions.Models.ShipmentBooking;

namespace BookingApi.Core.Models.ShipmentBooking.Fluent
{
    public class ProductArrayFluent : FluentBuilder<List<Product>, List<Product>>
    {
        public ProductArrayFluent(List<Product> model) : base(model)
        {
        }

        public ProductArrayFluent AddProduct(Action<ProductFluent> builder) => AddProduct(null, builder);

        public ProductArrayFluent AddProduct(IProduct sourceProduct, Action<ProductFluent> builder)
        {
            var productFluent = new ProductFluent(sourceProduct);
            builder(productFluent);

            Product product = productFluent;
            _model.Add(product);
            return this;
        }
    }
}
