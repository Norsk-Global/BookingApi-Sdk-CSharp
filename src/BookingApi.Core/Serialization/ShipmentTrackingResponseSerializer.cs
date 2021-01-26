using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using BookingApi.Abstractions.Models.ShipmentTracking;
using BookingApi.Core.Models.ShipmentTracking;
using Newtonsoft.Json;

namespace BookingApi.Core.Serialization
{
    public class ShipmentTrackingNarrativeVMSerializer : JsonConverter<IList<INarrative>>
    {
        public override IList<INarrative> ReadJson(JsonReader reader, Type objectType, [AllowNull] IList<INarrative> existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var result = JsonSerializer.Create().Deserialize<List<Narrative>>(reader);
            return result.Cast<INarrative>().ToList();
        }

        public override void WriteJson(JsonWriter writer, [AllowNull] IList<INarrative> value, JsonSerializer serializer)
        {
            JsonSerializer.Create().Serialize(writer, value);
        }

    }

    public class ShipmentTrackingProofOfDeliverySerializer : JsonConverter<IProofOfDelivery>
    {
        public override IProofOfDelivery ReadJson(JsonReader reader, Type objectType, [AllowNull] IProofOfDelivery existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var result = JsonSerializer.Create().Deserialize<ProofOfDelivery>(reader);
            return result;
        }
        public override void WriteJson(JsonWriter writer, [AllowNull] IProofOfDelivery value, JsonSerializer serializer) => throw new NotImplementedException();

    }

    public class ShipmentTrackingNarrativeVMLatestSerializer : JsonConverter<INarrative>
    {
        public override INarrative ReadJson(JsonReader reader, Type objectType, [AllowNull] INarrative existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var result = JsonSerializer.Create().Deserialize<Narrative>(reader);
            return result;
        }

        public override void WriteJson(JsonWriter writer, [AllowNull] INarrative value, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
    }
}
