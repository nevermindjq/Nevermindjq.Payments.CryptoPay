using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace CryptoPay.Types;

/// <inheritdoc />
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class Transfer : ITransfer
{
    /// <summary>
    ///     Unique ID for this transfer.
    /// </summary>
    [JsonProperty(Required = Required.Always)]
    public long TransferId { get; set; }

    /// <inheritdoc/>
    [JsonProperty(Required = Required.Always)]
    public long UserId { get; set; }

    /// <inheritdoc/>
    [JsonProperty(Required = Required.Always)]
    [JsonConverter(typeof(StringEnumConverter))]
    public Assets Asset { get; set; }

    /// <inheritdoc/>
    [JsonProperty(Required = Required.Always)]
    public double Amount { get; set; }

    /// <summary>
    /// Status of the transfer, can be “completed”.
    /// </summary>
    [JsonProperty(Required = Required.Always)]
    [JsonConverter(typeof(StringEnumConverter))]
    public TransferStatuses Status { get; set; }

    /// <summary>
    /// Date the transfer was completed in ISO 8601 format.
    /// </summary>
    [JsonProperty(Required = Required.Always)]
    public DateTime CompletedAt { get; set; }

    /// <inheritdoc/>
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string Comment { get; set; }
}