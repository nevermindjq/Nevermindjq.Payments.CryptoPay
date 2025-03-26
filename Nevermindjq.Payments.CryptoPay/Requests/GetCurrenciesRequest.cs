using Nevermindjq.Payments.CryptoPay.Models;
using Nevermindjq.Payments.CryptoPay.Requests.Abstractions;

namespace Nevermindjq.Payments.CryptoPay.Requests;

/// <summary>
///     Use this class to get list of <see cref="Currency" /> request.
/// </summary>
public sealed class GetCurrenciesRequest() : RequestBase("getCurrencies");