using System;
using BookingApi.Abstractions.Models;
using BookingApi.Abstractions.Models.Fluent;
using BookingApi.Abstractions.Models.ShipmentBooking;
using BookingApi.Core.Models.Validation;

namespace BookingApi.Core.Models.ShipmentBooking.Fluent
{
    public abstract class BaseAddressFluent<TAddress, TInterface> : FluentBuilder<TAddress, TInterface>
        where TAddress : class, TInterface, new() where TInterface : class, IAddress
    {
        public BaseAddressFluent(TInterface model) : base(model)
        {
        }

        [NotBeEmpty]
        public BaseAddressFluent<TAddress, TInterface> Vat(string vat)
        {
            Model.Vat = Validate(vat);
            return this;
        }

        [BeBetweenLength(2, 15)]
        public BaseAddressFluent<TAddress, TInterface> EoriNumber(string eori)
        {
            Model.Eori = Validate(eori);
            return this;
        }

        [BeBetweenLength(2, 15)]
        public BaseAddressFluent<TAddress, TInterface> TaxId(string taxId)
        {
            Model.TaxId = Validate(taxId);
            return this;
        }

        [NotBeEmpty, BeBetweenLength(2, 35)]
        public BaseAddressFluent<TAddress, TInterface> ContactName(string contactName)
        {
            Model.ContactName = Validate(contactName);
            return this;
        }

        [BeBetweenLength(2, 35)]
        public BaseAddressFluent<TAddress, TInterface> Company(string company)
        {
            Model.Company = Validate(company);
            return this;
        }

        public BaseAddressFluent<TAddress, TInterface> AddressLines(params string[] addressLines)
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
        public BaseAddressFluent<TAddress, TInterface> Address1(string addressLine1)
        {
            Model.Address1 = Validate(addressLine1);
            return this;
        }

        [BeBetweenLength(0, 35)]
        public BaseAddressFluent<TAddress, TInterface> Address2(string addressLine2)
        {
            Model.Address2 = Validate(addressLine2);
            return this;
        }

        [BeBetweenLength(0, 35)]
        public BaseAddressFluent<TAddress, TInterface> Address3(string addressLine3)
        {
            Model.Address3 = Validate(addressLine3);
            return this;
        }

        [NotBeEmpty, BeBetweenLength(2, 35)]
        public BaseAddressFluent<TAddress, TInterface> City(string city)
        {
            Model.City = Validate(city);
            return this;
        }

        [NotBeEmpty]
        public BaseAddressFluent<TAddress, TInterface> Zipcode(string zipcode)
        {
            Model.Zipcode = Validate(zipcode);
            return this;
        }

        [NotBeEmpty, BeBetweenLength(2, 2)]
        public BaseAddressFluent<TAddress, TInterface> CountryCode(string countryCode)
        {
            Model.CountryCode = Validate(countryCode);
            return this;
        }

        [BeBetweenLength(0, 35)]
        public BaseAddressFluent<TAddress, TInterface> Division(string division)
        {
            Model.Division = Validate(division);
            return this;
        }

        public BaseAddressFluent<TAddress, TInterface> DivisionCode(string divisionCode)
        {
            Model.DivisionCode = Validate(divisionCode);
            return this;
        }

        [BeBetweenLength(0, 20)]
        public BaseAddressFluent<TAddress, TInterface> PhoneNumber(string phoneNumber)
        {
            Model.PhoneNumber = Validate(phoneNumber);
            return this;
        }

        public BaseAddressFluent<TAddress, TInterface> MobileNumber(string mobileNumber)
        {
            Model.MobileNumber = Validate(mobileNumber);
            return this;
        }

        public BaseAddressFluent<TAddress, TInterface> Fax(string fax)
        {
            Model.Fax = Validate(fax);
            return this;
        }
    }

    public class AddressFluent : BaseAddressFluent<Address, IAddress>
    {
        public AddressFluent(IAddress model) : base(model)
        {
        }
    }
}
