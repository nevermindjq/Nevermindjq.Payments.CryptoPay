using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace CryptoPay.Types;

/// <inheritdoc />
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public sealed class Invoice : IInvoice
{
    /// <summary>
    ///     Unique ID for this invoice.
    /// </summary>
    [JsonProperty(Required = Required.Always)]
    public long InvoiceId { get; set; }

    /// <summary>
    ///     Status of the invoice, can be either “active”, “paid” or “expired”.
    /// </summary>
    [JsonProperty(Required = Required.Always)]
    [JsonConverter(typeof(StringEnumConverter))]
    public Statuses Status { get; set; }

    /// <summary>
    ///     Hash of the invoice.
    /// </summary>
    [JsonProperty(Required = Required.Always)]
    public string Hash { get; set; }

    /// <summary>
    ///     URL should be presented to the user to pay the invoice.
    /// </summary>
    [JsonProperty(Required = Required.Always)]
    public string PayUrl { get; set; }

    /// <summary>
    ///     Date the invoice was created in ISO 8601 format.
    /// </summary>
    [JsonProperty(Required = Required.Always)]
    public DateTime CreatedAt { get; set; }

    /// <summary>
    ///     True, if the user can pay the invoice anonymously.
    /// </summary>
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    public bool? AllowAnonymous { get; set; }

    /// <summary>
    ///     Optional. Date the invoice expires in Unix time.
    /// </summary>
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    public DateTime? ExpirationDate { get; set; }

    /// <summary>
    ///     Optional. Date the invoice was paid in Unix time.
    /// </summary>
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    public DateTime? PaidAt { get; set; }

    /// <summary>
    ///     True, if the invoice was paid anonymously.
    /// </summary>
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    public bool? PaidAnonymously { get; set; }

    /// <summary>
    ///     Optional. Comment to the payment from the user.
    /// </summary>
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string Comment { get; set; }

    /// <inheritdoc />
    [JsonProperty(Required = Required.Always)]
    [JsonConverter(typeof(StringEnumConverter))]
    public Assets Asset { get; set; }

    /// <inheritdoc />
    [JsonProperty(Required = Required.Always)]
    public double Amount { get; set; }

    /// <inheritdoc />
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string Description { get; set; }

    /// <inheritdoc />
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    public bool? AllowComments { get; set; }

    /// <inheritdoc />
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string HiddenMessage { get; set; }

    /// <inheritdoc />
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string Payload { get; set; }

    /// <inheritdoc />
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    public PaidButtonNames? PaidBtnName { get; set; }

    /// <inheritdoc />
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string PaidBtnUrl { get; set; }

    /// <summary>
    ///     Optional. Amount of charged service fees.
    /// </summary>
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string Fee { get; set; }

    /// <summary>
    ///     Optional. Price of the asset in USD at the time the invoice was paid.
    /// </summary>
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    public string UsdRate { get; set; }
}