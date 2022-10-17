using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace CryptoPay.Types;

/// <summary>
///     Exchange rates of supported currencies.
/// </summary>
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class ExchangeRate
{
    /// <summary>
    ///     Is valid.
    /// </summary>
    [JsonProperty(Required = Required.Always)]
    public bool IsValid { get; set; }

    /// <summary>
    /// Suurce currency.
    /// </summary>
    [JsonProperty(Required = Required.Always)]
    [JsonConverter(typeof(StringEnumConverter))]
    public Assets Source { get; set; }

    /// <summary>
    ///     Target currency. 
    /// </summary>
    [JsonProperty(Required = Required.Always)]
    [JsonConverter(typeof(StringEnumConverter))]
    public Assets Target { get; set; }

    /// <summary>
    ///     Exchange rate.
    /// </summary>
    [JsonProperty(Required = Required.Always)]
    public double Rate { get; set; }
}
