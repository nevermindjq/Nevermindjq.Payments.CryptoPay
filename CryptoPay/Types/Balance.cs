using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace CryptoPay.Types;

/// <summary>
///     Balance of your application.
/// </summary>
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public sealed class Balance
{
    /// <summary>
    ///     Current currency.
    /// </summary>
    [JsonProperty(Required = Required.Always)]
    [JsonConverter(typeof(StringEnumConverter))]
    public Assets CurrencyCode { get; set; }

    /// <summary>
    ///     Number of available coins.
    /// </summary>
    [JsonProperty(Required = Required.Always)]
    public double Available { get; set; }
}