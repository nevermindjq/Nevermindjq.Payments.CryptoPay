using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

using Nevermindjq.Payments.CryptoPay.Converters;

using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace Nevermindjq.Payments.CryptoPay.Extensions;

internal static class HttpResponseMessageExtensions {
	public static async Task<TResponse?> DeserializeContentAsync<TResponse>(this HttpResponseMessage response, CancellationToken cancellationToken = default) where TResponse : class {
		await using var stream = await response.Content.ReadAsStreamAsync(cancellationToken).ConfigureAwait(false);

		using (var reader = new StreamReader(stream, Encoding.UTF8)) {
			using (var json = new JsonTextReader(reader)) {
				var serializer = JsonSerializer.Create(new JsonSerializerSettings {
					ContractResolver = new DefaultContractResolver
					{
						NamingStrategy = new SnakeCaseNamingStrategy()
					},
					NullValueHandling = NullValueHandling.Ignore,
					Converters = new List<JsonConverter>
					{
						new StringEnumConverter(),
						new NumberAsStringConverter()
					}
				});

				return serializer.Deserialize<TResponse>(json);
			}
		}
	}
}