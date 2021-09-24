using BookingApi.Abstractions.Models.ShipmentBooking;

namespace BookingApi.Core.Models.ShipmentBooking.Fluent
{
    public class ShipperAddressFluent : BaseAddressFluent<ShipperAddress, IShipperAddress>
    {
        public ShipperAddressFluent(IShipperAddress model) : base(model)
        {
        }

        public ShipperAddressFluent Ioss(string ioss)
        {
            Model.Ioss = Validate(ioss);
            return this;
        }
    }
}
