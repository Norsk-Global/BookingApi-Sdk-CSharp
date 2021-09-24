using System;
using BookingApi.Abstractions.Models.ShipmentBooking;
using BookingApi.Core.Models.Validation;

namespace BookingApi.Core.Models.ShipmentBooking.Fluent
{
    public class CollectionAddressFluent : BaseAddressFluent<CollectionAddress, ICollectionAddress>
    {
        public CollectionAddressFluent(ICollectionAddress model) : base(model)
        {
        }

        [NotBeEmpty]
        public CollectionAddressFluent PackageLocation(string packageLocation)
        {
            Model.PackageLocation = packageLocation;
            return this;
        }

        public CollectionAddressFluent CloseTime(TimeSpan closeTime)
        {
            Model.CloseTime = closeTime;
            return this;
        }

        public CollectionAddressFluent PickupType(PickupType pickupType)
        {
            Model.PickupType = pickupType;
            return this;
        }
    }
}
