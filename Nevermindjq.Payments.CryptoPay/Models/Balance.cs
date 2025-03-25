#pragma warning disable CS8618

namespace Nevermindjq.Payments.CryptoPay.Models;

/// <summary>
///     Balance of your application.
/// </summary>
public sealed class Balance {
    /// <summary>
    ///     Current currency.
    /// </summary>
    [JsonRequired]
	public string CurrencyCode { get; set; }

    /// <summary>
    ///     Number of available coins.
    /// </summary>
    [JsonRequired]
	public double Available { get; set; }

    /// <summary>
    ///     Unavailable amount currently is on hold in float.
    /// </summary>
    [JsonRequired]
	public string Onhold { get; set; }
}