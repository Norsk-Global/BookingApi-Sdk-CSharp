using BookingApi.Abstractions.Models.ShipmentBooking;
using BookingApi.Core.Models.Validation;

namespace BookingApi.Core.Models.ShipmentBooking.Fluent
{
    public class ShipperAddressFluent : BaseAddressFluent<ShipperAddress, IShipperAddress>
    {
        public ShipperAddressFluent(IShipperAddress model) : base(model)
        {
        }

        [Matches(@"^IM[0-9]{3}[a-zA-Z0-9]{7}",
            "Should conform the IOSS standard of: 12 Characters long, starting with IM and followed by 3 digits from the associated EU member state.")]
        public ShipperAddressFluent Ioss(string ioss)
        {
            Model.Ioss = Validate(ioss);
            return this;
        }
    }
}
