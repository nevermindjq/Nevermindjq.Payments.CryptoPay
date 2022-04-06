using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CryptoPay.Types;

/// <summary>
///     List of <see cref="Invoice"/>. You can get invoices use <see cref="CryptoPay.CryptoPayExtensions.GetInvoicesAsync"/>
/// </summary>
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class Invoices
{
    /// <summary>
    ///     List of <see cref="Invoice"/>.
    /// </summary>
    [JsonProperty(DefaultValueHandling = DefaultValueHandling.Ignore)]
    public List<Invoice> Items { get; set; }
}