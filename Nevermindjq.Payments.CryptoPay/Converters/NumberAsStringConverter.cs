using System;

using Newtonsoft.Json;

namespace Nevermindjq.Payments.CryptoPay.Converters;

public class NumberAsStringConverter : JsonConverter {
	public override bool CanConvert(Type objectType) => objectType == typeof(int) || objectType == typeof(double) || objectType == typeof(float) || objectType == typeof(decimal);

	public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
		if (reader.TokenType == JsonToken.String) {
			var value = reader.Value.ToString();

			if (objectType == typeof(int) && int.TryParse(value, out var intValue)) {
				return intValue;
			}

			if (objectType == typeof(double) && double.TryParse(value, out var doubleValue)) {
				return doubleValue;
			}

			if (objectType == typeof(float) && float.TryParse(value, out var floatValue)) {
				return floatValue;
			}

			if (objectType == typeof(decimal) && decimal.TryParse(value, out var decimalValue)) {
				return decimalValue;
			}
		}
		else if (reader.TokenType == JsonToken.Integer || reader.TokenType == JsonToken.Float) {
			return Convert.ChangeType(reader.Value, objectType);
		}

		throw new JsonSerializationException($"Unexpected token {reader.TokenType} when parsing number.");
	}

	public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer) => writer.WriteValue(value.ToString());
}