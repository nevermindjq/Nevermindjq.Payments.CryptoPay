using System.Collections.Generic;

using Nevermindjq.Payments.CryptoPay.Models;
using Nevermindjq.Payments.CryptoPay.Requests.Abstractions;

namespace Nevermindjq.Payments.CryptoPay.Requests;

/// <summary>
///     Use this class to get list of <see cref="Currency" /> request.
/// </summary>
internal sealed class GetCurrenciesRequest : ParameterlessRequest<List<Currency>> {
	/// <summary>
	///     Initializes a new request to get list of <see cref="Currency" />
	/// </summary>
	public GetCurrenciesRequest() : base("getCurrencies") { }
}