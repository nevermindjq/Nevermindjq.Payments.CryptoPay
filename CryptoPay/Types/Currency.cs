using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CryptoPay.Types;

/// <summary>
///     Supported currencies.
/// </summary>
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public sealed class Currency
{
    /// <summary>
    ///     Is blockchain.
    /// </summary>
    [JsonProperty(Required = Required.Always)]
    public bool IsBlockchain { get; set; }

    /// <summary>
    ///     Is stablecoin.
    /// </summary>
    [JsonProperty(Required = Required.Always)]
    // ReSharper disable once IdentifierTypo
    public bool IsStablecoin { get; set; }

    /// <summary>
    ///     Ordinary currency.
    /// </summary>
    [JsonProperty(Required = Required.Always)]
    public bool IsFiat { get; set; }

    /// <summary>
    ///     Name.
    /// </summary>
    [JsonProperty(Required = Required.Always)]
    public string Name { get; set; }

    /// <summary>
    ///     Code.
    /// </summary>
    [JsonProperty(Required = Required.Always)]
    public string Code { get; set; }

    /// <summary>
    ///     Url.
    /// </summary>
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string Url { get; set; }

    /// <summary>
    ///     Number of decimal places. 
    /// </summary>
    [JsonProperty(Required = Required.Always)]
    public int Decimals { get; set; }
}