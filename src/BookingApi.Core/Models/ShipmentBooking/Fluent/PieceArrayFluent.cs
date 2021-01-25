using System;
using System.Collections.Generic;
using BookingApi.Abstractions.Models;
using BookingApi.Abstractions.Models.Fluent;
using BookingApi.Abstractions.Models.ShipmentBooking;

namespace BookingApi.Core.Models.ShipmentBooking.Fluent
{
    public class PieceArrayFluent : FluentBuilder<List<Piece>, List<Piece>>
    {
        public PieceArrayFluent(List<Piece> model) : base(model)
        {
        }

        public PieceArrayFluent AddProduct(Action<PieceFluent> builder) => AddProduct(null, builder);

        public PieceArrayFluent AddProduct(IPiece sourceProduct, Action<PieceFluent> builder)
        {
            var productFluent = new PieceFluent(sourceProduct);
            builder(productFluent);

            Piece product = productFluent;
            _model.Add(product);
            return this;
        }
    }
}
