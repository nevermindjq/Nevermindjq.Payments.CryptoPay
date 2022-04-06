using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace CryptoPay.Types;

/// <summary>
///     All requests from Crypto Pay API has this JSON object.
///     <para/>
///     You can verify use method <see cref="CryptoPayHelper.CheckSignature" /> the received update and the integrity of the received data by comparing the header parameter crypto-pay-api-signature
///     and the hexadecimal representation of HMAC-SHA-256 signature used to sign the entire request body (unparsed JSON string)
///     with a secret key that is SHA256 hash of your app's token.
/// </summary>
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class Update
{
    /// <summary>
    ///     Non-unique update ID.
    /// </summary>
    [JsonProperty(Required = Required.Always)]
    public long UpdateId { get; set; }

    /// <summary>
    ///     Webhook update type.Supported update types:
    ///     <see cref="UpdateTypes.invoice_paid" /> – the update sent after an invoice is paid.
    /// </summary>
    [JsonProperty(Required = Required.Always)]
    [JsonConverter(typeof(StringEnumConverter))]
    public UpdateTypes UpdateType { get; set; }

    /// <summary>
    ///     Date the request was sent in ISO 8601 format.
    /// </summary>
    [JsonProperty(Required = Required.Always)]
    public DateTime RequestDate { get; set; }

    /// <summary>
    ///     Payload of the update.
    /// </summary>
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    public JObject Payload { get; set; }

    public override string ToString()
    {
        return JsonConvert.SerializeObject(this);
    }
}