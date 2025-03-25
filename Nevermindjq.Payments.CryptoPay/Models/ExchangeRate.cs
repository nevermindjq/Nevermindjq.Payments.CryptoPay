﻿ 

namespace Nevermindjq.Payments.CryptoPay.Models;

/// <summary>
///     Exchange rates of supported currencies.
/// </summary>
public sealed class ExchangeRate {
    /// <summary>
    ///     Is valid.
    /// </summary>
    [JsonRequired]
	public bool IsValid { get; set; }

    /// <summary>
    ///     True, if the source is the cryptocurrency.
    /// </summary>
    [JsonRequired]
	public bool IsCrypto { get; set; }

    /// <summary>
    ///     True, if the source is the fiat currency.
    /// </summary>
    [JsonRequired]
	public bool IsFiat { get; set; }

    /// <summary>
    ///     Source currency.
    /// </summary>
    [JsonRequired]
	public string Source { get; set; }

    /// <summary>
    ///     Target currency.
    /// </summary>
    [JsonRequired]
	public string Target { get; set; }

    /// <summary>
    ///     Exchange rate.
    /// </summary>
    [JsonRequired]
	public double Rate { get; set; }
}