using System;
using BookingApi.Core.Models;
using BookingApi.Core.Models.Fluent;
using Shouldly;
using Xunit;

namespace BookingApi.UnitTests.Validation
{
    public class AddressFluentValidationTests
    {
        private readonly AddressFluent _addressFluent;

        public AddressFluentValidationTests()
        {
            _addressFluent = new AddressFluent(null);
        }

        [Fact]
        public void WhenApplyingStringWhichIsEmpty_ShouldNotApplyToModel_AndThrowException()
        {
            // Arrange
            const string misdeclaredValue = "";

            // Act
            var exception = Should.Throw<Exception>(() => _addressFluent.Vat(misdeclaredValue));
            Address address = _addressFluent;

            // Assert
            exception.Message.ShouldBe("The field Vat must not be empty.");
            address.Vat.ShouldBeNull();
        }

        [Fact]
        public void WhenApplyingWrongLengthValue_ShouldNotApply_AndShouldThrow()
        {
            // Arrange
            var misdeclaredValue = Guid.NewGuid().ToString("N") + Guid.NewGuid().ToString("N");

            // Act
            var exception = Should.Throw<Exception>(() => _addressFluent.Address1(misdeclaredValue));
            Address address = _addressFluent;

            // Assert
            exception.Message.ShouldContain("The field Address1 must between 2 and 35 characters.");
            address.Address1.ShouldBeNull();
        }
    }
}
