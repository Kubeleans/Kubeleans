using System;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Kubeleans.Kubernetes
{
    internal class WatchConverter : JsonConverterFactory
    {
        private const string TYPE_PROP = "type";
        private const string OBJECT_PROP = "object";

        public override bool CanConvert(Type typeToConvert)
        {
            if (!typeToConvert.IsGenericType) return false;
            if (typeToConvert.GetGenericTypeDefinition() != typeof(Watch<>)) return false;

            return true;
        }

        public override JsonConverter CreateConverter(Type typeToConvert, JsonSerializerOptions options)
        {
            Type objectType = typeToConvert.GetGenericArguments()[0];

            JsonConverter converter = (JsonConverter)Activator.CreateInstance(
                typeof(WatchConverterInner<>).MakeGenericType(new Type[] { objectType }),
                BindingFlags.Instance | BindingFlags.Public,
                binder: null,
                args: null, //new object[] { options },
                culture: null
            );

            return converter;
        }

        private class WatchConverterInner<TObject> : JsonConverter<Watch<TObject>>
        {
            private readonly JsonEncodedText TypeName = JsonEncodedText.Encode("Type");
            private readonly JsonEncodedText ObjectName = JsonEncodedText.Encode("Object");

            public override Watch<TObject> Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
            {
                if (reader.TokenType != JsonTokenType.StartObject)
                {
                    throw new JsonException();
                }

                string watchType = string.Empty;
                // object obj = default;

                while (reader.Read())
                {
                    if (reader.TokenType == JsonTokenType.EndObject)
                    {
                        break;
                    }

                    if (reader.TokenType == JsonTokenType.StartObject)
                    {
                        continue;
                    }

                    // Get the key.
                    if (reader.TokenType != JsonTokenType.PropertyName)
                    {
                        continue;
                    }

                    var propValue = reader.GetString();
                    if (string.Equals(propValue, TYPE_PROP, StringComparison.InvariantCultureIgnoreCase))
                    {
                        var read = reader.Read();
                        if (!read) throw new JsonException();

                        watchType = reader.GetString();
                    }
                    else if (string.Equals(propValue, OBJECT_PROP, StringComparison.InvariantCultureIgnoreCase))
                    {
                        var read = reader.Read();
                        if (!read) throw new JsonException();
                    }

                    // if (reader.ValueTextEquals(TypeName.EncodedUtf8Bytes))
                    // {
                    //     var t = ReadProperty(ref reader, options);
                    //     if (!Enum.TryParse(t, ignoreCase: false, out watchType) &&
                    //         !Enum.TryParse(t, ignoreCase: true, out watchType))
                    //     {
                    //         throw new JsonException(
                    //             $"Unable to convert Type to Enum \"{nameof(WatchTypes)}\".");
                    //     }
                    // }
                    // else if (reader.ValueTextEquals(ObjectName.EncodedUtf8Bytes))
                    // {
                    //     y = ReadProperty(ref reader, options);
                    //     ySet = true;
                    // }
                    // else
                    // {
                    //     throw new JsonException();
                    // }
                }
                return new Watch<TObject>();
            }

            private string ReadProperty(ref Utf8JsonReader reader, JsonSerializerOptions options)
            {
                reader.Read();
                return reader.GetString();
                // return _intConverter.Read(ref reader, typeof(int), options);
            }

            public override void Write(Utf8JsonWriter writer, Watch<TObject> value, JsonSerializerOptions options)
            {
                throw new NotImplementedException();
            }
        }
    }
}