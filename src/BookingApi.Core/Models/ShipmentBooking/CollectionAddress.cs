using System;
using BookingApi.Abstractions.Models;
using BookingApi.Abstractions.Models.ShipmentBooking;
using Newtonsoft.Json;

namespace BookingApi.Core.Models.ShipmentBooking
{
    public class CollectionAddress : ICollectionAddress
    {
        public string ContactName { get; set; }

        public string Company { get; set; }

        public string Address1 { get; set; }

        public string Address2 { get; set; }

        public string Address3 { get; set; }

        public string City { get; set; }

        public string Zipcode { get; set; }

        public string CountryCode { get; set; }

        public string Division { get; set; }

        public string DivisionCode { get; set; }

        public string PhoneNumber { get; set; }

        public string MobileNumber { get; set; }

        [JsonIgnore]
        public string Fax { get; set; }

        [JsonIgnore]
        public string Vat { get; set; }

        [JsonIgnore]
        public string Eori { get; set; }

        public string TaxId { get; set; }

        public string PackageLocation { get; set; }

        public TimeSpan CloseTime { get; set; }

        public PickupType PickupType { get; set; }
    }
}
