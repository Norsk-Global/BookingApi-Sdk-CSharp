using System;
using System.Collections.Generic;
using System.Linq;
using BookingApi.Abstractions.Api.Endpoints;
using BookingApi.Abstractions.Models.ShipmentBooking;
using BookingApi.Core.Api.Endpoints;
using BookingApi.Core.Models.ShipmentBooking;
using Newtonsoft.Json;

namespace BookingApi.Core.Serialization
{
    public class ShipmentArchiveDocumentSerializer : JsonConverter<IList<IShipmentArchiveDocument>>
    {
        public override void WriteJson(JsonWriter writer, IList<IShipmentArchiveDocument> value, JsonSerializer serializer) => JsonSerializer.Create().Serialize(writer, value);

        public override IList<IShipmentArchiveDocument> ReadJson(JsonReader reader, Type objectType,
            IList<IShipmentArchiveDocument> existingValue,
            bool hasExistingValue, JsonSerializer serializer)
        {
            var result = JsonSerializer.Create().Deserialize<List<ShipmentArchiveDocument>>(reader);
            return result.Cast<IShipmentArchiveDocument>().ToList();
        }
    }

    public class ShipmentBookingItemSerializer : JsonConverter<IList<IShipmentBookingItem>>
    {
        public override void WriteJson(JsonWriter writer, IList<IShipmentBookingItem> value, JsonSerializer serializer) => JsonSerializer.Create().Serialize(writer, value);

        public override IList<IShipmentBookingItem> ReadJson(JsonReader reader, Type objectType,
            IList<IShipmentBookingItem> existingValue,
            bool hasExistingValue, JsonSerializer serializer)
        {
            var result = JsonSerializer.Create().Deserialize<List<ShipmentBookingItem>>(reader);
            return result.Cast<IShipmentBookingItem>().ToList();
        }
    }
}
