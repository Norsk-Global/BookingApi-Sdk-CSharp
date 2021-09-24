using System;
using System.Collections.Generic;
using System.Linq;
using BookingApi.Abstractions.Models;
using BookingApi.Abstractions.Models.Fluent;
using BookingApi.Abstractions.Models.ShipmentBooking;
using BookingApi.Core.Models.Validation;

namespace BookingApi.Core.Models.ShipmentBooking.Fluent
{
    public class PieceFluent : FluentBuilder<Piece, IPiece>
    {
        public PieceFluent(IPiece model) : base(model)
        {
        }

        [NotBeEmpty, GreaterThan(0)]
        public PieceFluent Depth(decimal depth)
        {
            Model.Depth = Validate(depth);
            return this;
        }

        [NotBeEmpty, GreaterThan(0)]
        public PieceFluent Height(decimal height)
        {
            Model.Height = Validate(height);
            return this;
        }

        [NotBeEmpty, GreaterThan(0)]
        public PieceFluent Width(decimal width)
        {
            Model.Width = Validate(width);
            return this;
        }

        [NotBeEmpty, GreaterThan(0)]
        public PieceFluent Weight(decimal weight)
        {
            Model.Weight = Validate(weight);
            return this;
        }

        [NotBeEmpty, GreaterThan(0)]
        public PieceFluent NumberOfPieces(int numberOfPieces)
        {
            Model.NumberOfPieces = Validate(numberOfPieces);
            return this;
        }

        public PieceFluent Products(Action<ProductArrayFluent> builder)
        {
            var productArrayFluent = new ProductArrayFluent(new List<Product>());
            builder(productArrayFluent);
            Model.Products = ((List<Product>)productArrayFluent).Cast<IProduct>().ToList();

            return this;
        }
    }
}
