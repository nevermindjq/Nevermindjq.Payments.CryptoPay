using System.Collections.Generic;

using Nevermindjq.Payments.CryptoPay.Models;
using Nevermindjq.Payments.CryptoPay.Requests.Abstractions;

namespace Nevermindjq.Payments.CryptoPay.Requests;

/// <summary>
///     Use this class to get list of <see cref="ExchangeRate" /> request.
/// </summary>
internal sealed class GetExchangeRatesRequest : ParameterlessRequest<List<ExchangeRate>> {
	/// <summary>
	///     Initializes a new request to get list of <see cref="ExchangeRate" />
	/// </summary>
	public GetExchangeRatesRequest() : base("getExchangeRates") { }
}