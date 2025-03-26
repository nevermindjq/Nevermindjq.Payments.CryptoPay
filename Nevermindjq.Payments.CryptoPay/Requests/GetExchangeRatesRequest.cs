﻿using Nevermindjq.Payments.CryptoPay.Models;
using Nevermindjq.Payments.CryptoPay.Requests.Abstractions;

namespace Nevermindjq.Payments.CryptoPay.Requests;

/// <summary>
///     Use this class to get list of <see cref="ExchangeRate" /> request.
/// </summary>
public sealed class GetExchangeRatesRequest() : RequestBase("getExchangeRates");