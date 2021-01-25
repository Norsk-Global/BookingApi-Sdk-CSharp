using System;

namespace BookingApi.Abstractions.Models.ShipmentBooking
{
    public interface ICollectionAddress : IAddress
    {
        string PackageLocation { get; set; }

        TimeSpan CloseTime { get; set; }

        PickupType PickupType { get; set; }
    }

    public enum PickupType
    {
        Pickup
    }
}
