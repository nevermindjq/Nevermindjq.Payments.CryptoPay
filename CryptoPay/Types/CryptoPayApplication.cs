using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CryptoPay.Types;

/// <summary>
///     Basic information about an application.
/// </summary>
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class CryptoPayApplication
{
    /// <summary>
    ///     Your application Id.
    /// </summary>
    [JsonProperty(Required = Required.Always)]
    public long AppId { get; set; }

    /// <summary>
    ///     Your application Name.
    /// </summary>
    [JsonProperty(Required = Required.Always)]
    public string Name { get; set; }

    /// <summary>
    ///     Payment processing bot username, main or test bot username.
    /// </summary>
    [JsonProperty(Required = Required.Default)]
    public string PaymentProcessingBotUsername { get; set; }
}