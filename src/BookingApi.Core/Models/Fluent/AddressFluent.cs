using System;
using BookingApi.Abstractions.Models;
using BookingApi.Abstractions.Models.Fluent;
using BookingApi.Core.Models.Validation;

namespace BookingApi.Core.Models.Fluent
{
    public class AddressFluent : FluentBuilder<Address, IAddress>
    {
        public AddressFluent(IAddress model) : base(model)
        {
        }

        [NotBeEmpty]
        public AddressFluent Vat(string vat)
        {
            _model.Vat = Validate(vat);
            return this;
        }

        [BeBetweenLength(2, 15)]
        public AddressFluent EoriNumber(string eori)
        {
            _model.Eori = Validate(eori);
            return this;
        }

        [BeBetweenLength(2, 15)]
        public AddressFluent TaxId(string taxId)
        {
            _model.TaxId = Validate(taxId);
            return this;
        }

        [NotBeEmpty, BeBetweenLength(2, 35)]
        public AddressFluent ContactName(string contactName)
        {
            _model.ContactName =Validate(contactName);
            return this;
        }

        [BeBetweenLength(2, 35)]
        public AddressFluent Company(string company)
        {
            _model.Company = Validate(company);
            return this;
        }

        public AddressFluent AddressLines(params string[] addressLines)
        {
            if (addressLines.Length == 0)
                throw new ArgumentException("Expected at least 1 AddressFluent line", nameof(addressLines));

            if (addressLines.Length < 2)
                Address1(addressLines[0]);

            if (addressLines.Length < 3)
                Address2(addressLines[1]);

            if (addressLines.Length < 4)
                Address3(addressLines[2]);

            return this;
        }

        [NotBeEmpty, BeBetweenLength(2, 35)]
        public AddressFluent Address1(string addressLine1)
        {
            _model.Address1 = Validate(addressLine1);
            return this;
        }

        [BeBetweenLength(0, 35)]
        public AddressFluent Address2(string addressLine2)
        {
            _model.Address2 = Validate(addressLine2);
            return this;
        }

        [BeBetweenLength(0, 35)]
        public AddressFluent Address3(string addressLine3)
        {
            _model.Address3 = Validate(addressLine3);
            return this;
        }

        [NotBeEmpty, BeBetweenLength(2, 35)]
        public AddressFluent City(string city)
        {
            _model.City = Validate(city);
            return this;
        }

        [NotBeEmpty]
        public AddressFluent Zipcode(string zipcode)
        {
            _model.Zipcode = Validate(zipcode);
            return this;
        }

        [NotBeEmpty, BeBetweenLength(2, 2)]
        public AddressFluent CountryCode(string countryCode)
        {
            _model.CountryCode = Validate(countryCode);
            return this;
        }

        [BeBetweenLength(0, 35)]
        public AddressFluent Division(string division)
        {
            _model.Division = Validate(division);
            return this;
        }

        public AddressFluent DivisionCode(string divisionCode)
        {
            _model.DivisionCode = Validate(divisionCode);
            return this;
        }

        [BeBetweenLength(0, 20)]
        public AddressFluent PhoneNumber(string phoneNumber)
        {
            _model.PhoneNumber = Validate(phoneNumber);
            return this;
        }

        public AddressFluent MobileNumber(string mobileNumber)
        {
            _model.MobileNumber = Validate(mobileNumber);
            return this;
        }

        public AddressFluent Fax(string fax)
        {
            _model.Fax = Validate(fax);
            return this;
        }
    }
}
