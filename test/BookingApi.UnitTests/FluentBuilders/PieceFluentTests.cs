using BookingApi.Core.Models;
using BookingApi.Core.Models.ShipmentBooking;
using BookingApi.Core.Models.ShipmentBooking.Fluent;
using Shouldly;
using Xunit;

namespace BookingApi.UnitTests.FluentBuilders
{
    public class PieceFluentTests
    {
        [Fact]
        public void WhenUsingValidData_ShouldCreateACompletePiece()
        {
            // Arrange
            var builder = new PieceFluent(null);

            // Act
            builder
                .Width(1.00m)
                .Depth(1.00m)
                .Height(1.00m)
                .Weight(1.00m)
                .NumberOfPieces(1)
                .Products(products =>
                    products.AddProduct(p => p
                        .CountryOfManufacture("GB")
                        .CurrencyCode("GBP")
                        .ProductDescription("test")
                        .ProductQuantity(1)
                        .ProductValue(2.5m)
                        .ProductWeight(1.0m)
                    ));
            Piece piece = builder;

            // Assert
            piece.Depth.ShouldBe(1.00m);
            piece.Height.ShouldBe(1.00m);
            piece.Weight.ShouldBe(1.00m);
            piece.Width.ShouldBe(1.00m);
            piece.NumberOfPieces.ShouldBe(1);
            piece.Products.ShouldNotBeEmpty();
        }
    }
}
