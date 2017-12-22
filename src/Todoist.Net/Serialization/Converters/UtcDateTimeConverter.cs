using System;

using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Todoist.Net.Serialization.Converters
{
    internal class UtcDateTimeConverter : IsoDateTimeConverter
    {
        public UtcDateTimeConverter()
        {
            DateTimeFormat = "yyyy-MM-ddTHH:mm";
        }

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            if (value is DateTime dateTime && dateTime.Kind != DateTimeKind.Utc)
            {
                value = dateTime.ToUniversalTime();
            }

            base.WriteJson(writer, value, serializer);
        }

        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            if (existingValue == null)
            {
                return null;
            }

            return base.ReadJson(reader, objectType, existingValue, serializer);
        }
    }
}
