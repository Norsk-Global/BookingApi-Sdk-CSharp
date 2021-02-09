using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using BookingApi.Abstractions.Models.ShipmentDimension;
using BookingApi.Core.Models.ShipmentDimensions;
using Newtonsoft.Json;

namespace BookingApi.Core.Serialization
{
    public class BookShipmentDimensionResponseSerializer : JsonConverter<IList<IDimensions>>
    {
        public override IList<IDimensions> ReadJson(JsonReader reader, Type objectType, [AllowNull] IList<IDimensions> existingValue, bool hasExistingValue, JsonSerializer serializer)
        {
            var result = JsonSerializer.Create().Deserialize<List<Dimensions>>(reader);
            return result.Cast<IDimensions>().ToList();
        }

        public override void WriteJson(JsonWriter writer, [AllowNull] IList<IDimensions> value, JsonSerializer serializer) => JsonSerializer.Create().Serialize(writer, value);
        
    }
}
