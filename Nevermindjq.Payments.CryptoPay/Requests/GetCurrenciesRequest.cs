using Nevermindjq.Payments.CryptoPay.Models;
using Nevermindjq.Payments.CryptoPay.Requests.Abstractions;

namespace Nevermindjq.Payments.CryptoPay.Requests;

/// <summary>
///     Use this class to get list of <see cref="Currency" /> request.
/// </summary>
internal sealed class GetCurrenciesRequest : RequestBase {
	/// <summary>
	///     Initializes a new request to get list of <see cref="Currency" />
	/// </summary>
	public GetCurrenciesRequest() : base("getCurrencies") { }
}