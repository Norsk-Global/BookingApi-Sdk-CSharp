using System;
using BookingApi.Abstractions.Models;
using BookingApi.Abstractions.Models.Fluent;
using BookingApi.Abstractions.Models.ShipmentBooking;
using BookingApi.Core.Models.Validation;

namespace BookingApi.Core.Models.ShipmentBooking.Fluent
{
    public class CollectionAddressFluent : FluentBuilder<CollectionAddress, ICollectionAddress>
    {
        public CollectionAddressFluent(ICollectionAddress model) : base(model)
        {
        }

        [NotBeEmpty]
        public CollectionAddressFluent PackageLocation(string packageLocation)
        {
            _model.PackageLocation = packageLocation;
            return this;
        }

        public CollectionAddressFluent CloseTime(TimeSpan closeTime)
        {
            _model.CloseTime = closeTime;
            return this;
        }

        public CollectionAddressFluent PickupType(PickupType pickupType)
        {
            _model.PickupType = pickupType;
            return this;
        }

        [NotBeEmpty, BeBetweenLength(2, 35)]
        public CollectionAddressFluent ContactName(string contactName)
        {
            _model.ContactName = contactName;
            return this;
        }

        [BeBetweenLength(2, 35)]
        public CollectionAddressFluent Company(string company)
        {
            _model.Company = company;
            return this;
        }

        public CollectionAddressFluent AddressLines(params string[] addressLines)
        {
            if (addressLines.Length == 0)
                throw new ArgumentException("Expected at least 1 CollectionAddressFluent line", nameof(addressLines));

            if (addressLines.Length < 2)
                Address1(addressLines[0]);

            if (addressLines.Length < 3)
                Address2(addressLines[1]);

            if (addressLines.Length < 4)
                Address3(addressLines[2]);

            return this;
        }

        [NotBeEmpty, BeBetweenLength(2, 35)]
        public CollectionAddressFluent Address1(string addressLine1)
        {
            _model.Address1 = addressLine1;
            return this;
        }

        [BeBetweenLength(0, 35)]
        public CollectionAddressFluent Address2(string addressLine2)
        {
            _model.Address2 = addressLine2;
            return this;
        }

        [BeBetweenLength(0, 35)]
        public CollectionAddressFluent Address3(string addressLine3)
        {
            _model.Address3 = addressLine3;
            return this;
        }

        [NotBeEmpty, BeBetweenLength(2, 35)]
        public CollectionAddressFluent City(string city)
        {
            _model.City = city;
            return this;
        }

        [NotBeEmpty]
        public CollectionAddressFluent Zipcode(string zipcode)
        {
            _model.Zipcode = zipcode;
            return this;
        }

        [NotBeEmpty, BeBetweenLength(2, 2)]
        public CollectionAddressFluent CountryCode(string countryCode)
        {
            _model.CountryCode = countryCode;
            return this;
        }

        [BeBetweenLength(0, 35)]
        public CollectionAddressFluent Division(string division)
        {
            _model.Division = division;
            return this;
        }

        public CollectionAddressFluent DivisionCode(string divisionCode)
        {
            _model.DivisionCode = divisionCode;
            return this;
        }

        [BeBetweenLength(0, 20)]
        public CollectionAddressFluent PhoneNumber(string phoneNumber)
        {
            _model.PhoneNumber = phoneNumber;
            return this;
        }

        public CollectionAddressFluent MobileNumber(string mobileNumber)
        {
            _model.MobileNumber = mobileNumber;
            return this;
        }

        public CollectionAddressFluent Fax(string fax)
        {
            _model.Fax = fax;
            return this;
        }
    }
}
