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
    public class ShipmentTrackingNarrativeVMSerializer : JsonConverter<IList<INarrativeVm>>
    {
        public override IList<INarrativeVm> ReadJson(JsonReader reader, Type objectType, [AllowNull] IList<INarrativeVm> existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var result = JsonSerializer.Create().Deserialize<List<NarrativeVm>>(reader);
            return result.Cast<INarrativeVm>().ToList();
        }

        public override void WriteJson(JsonWriter writer, [AllowNull] IList<INarrativeVm> value, JsonSerializer serializer) => JsonSerializer.Create().Serialize(writer, value);


    }

    public class ShipmentTrackingProofOfDeliverySerializer : JsonConverter<IProofOfDelivery>
    {
        public override IProofOfDelivery ReadJson(JsonReader reader, Type objectType, [AllowNull] IProofOfDelivery existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var result = JsonSerializer.Create().Deserialize<ProofOfDelivery>(reader);
            return result;
        }
        public override void WriteJson(JsonWriter writer, [AllowNull] IProofOfDelivery value, JsonSerializer serializer) => JsonSerializer.Create().Serialize(writer, value);

    }

    public class ShipmentTrackingNarrativeVMLatestSerializer : JsonConverter<INarrativeVm>
    {
        public override INarrativeVm ReadJson(JsonReader reader, Type objectType, [AllowNull] INarrativeVm existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var result = JsonSerializer.Create().Deserialize<NarrativeVm>(reader);
            return result;
        }

        public override void WriteJson(JsonWriter writer, [AllowNull] INarrativeVm value, JsonSerializer serializer) => JsonSerializer.Create().Serialize(writer, value);

    }
}
