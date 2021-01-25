namespace BookingApi.Abstractions.Models
{
    public interface IAddress
    {
        string ContactName { get; set; }

        string Company { get; set; }

        string Address1 { get; set; }

        string Address2 { get; set; }

        string Address3 { get; set; }

        string City { get; set; }

        string Zipcode { get; set; }

        string CountryCode { get; set; }

        string Division { get; set; }

        string DivisionCode { get; set; }

        string PhoneNumber { get; set; }

        string MobileNumber { get; set; }

        string Fax { get; set; }

        string Vat { get; set; }

        string Eori { get; set; }

        string TaxId { get; set; }
    }
}
