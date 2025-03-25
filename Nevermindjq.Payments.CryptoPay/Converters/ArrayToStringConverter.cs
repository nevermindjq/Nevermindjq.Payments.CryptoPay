using System;
using System.Collections.Generic;

namespace Nevermindjq.Payments.CryptoPay.Converters;

/// <summary>
///     Custom JSON converter to serialize an array of strings as a single comma-separated string and deserialize it back
///     to an array.
/// </summary>
public class ArrayToStringConverter : JsonConverter<IEnumerable<string>> {
	/// <inheritdoc />
	public override void WriteJson(JsonWriter writer, IEnumerable<string>? value, JsonSerializer serializer) {
		if (value is null) {
			return;
		}

		writer.WriteValue(string.Join(",", value));
	}

	/// <inheritdoc />
	public override IEnumerable<string>? ReadJson(JsonReader reader, Type objectType, IEnumerable<string>? existingValue, bool hasExistingValue, JsonSerializer serializer) {
		return JsonSerializer.Create().Deserialize<List<string>>(reader);
	}
}