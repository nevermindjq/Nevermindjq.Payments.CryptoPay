using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;

using Nevermindjq.Payments.CryptoPay.Converters;

using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace Nevermindjq.Payments.CryptoPay.Helpers;

public static class JsonHelper {
	public static readonly JsonSerializerSettings Settings = new() {
		ContractResolver = new DefaultContractResolver {
			NamingStrategy = new SnakeCaseNamingStrategy()
		},
		NullValueHandling = NullValueHandling.Ignore,
		Converters = new List<JsonConverter> {
			new StringEnumConverter(),
			new NumberAsStringConverter()
		}
	};

	public static TResponse? Deserialize<TResponse>(Stream stream) {
		using (var reader = new StreamReader(stream, Encoding.UTF8)) {
			using (var json = new JsonTextReader(reader)) {
				var serializer = JsonSerializer.Create(Settings);

				return serializer.Deserialize<TResponse>(json);
			}
		}
	}

	public static TResponse? Deserialize<TResponse>(byte[] bytes) {
		using (var memory = new MemoryStream(bytes)) {
			return Deserialize<TResponse>(memory);
		}
	}

	public static HttpContent ToJsonContent(this object obj) {
		return new StringContent(JsonConvert.SerializeObject(obj, Settings), Encoding.UTF8, "application/json");
	}
}