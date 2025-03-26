using Nevermindjq.Payments.CryptoPay.Models;
using Nevermindjq.Payments.CryptoPay.Requests.Abstractions;

namespace Nevermindjq.Payments.CryptoPay.Requests;

/// <summary>
///     Use this class to create <see cref="Balance" /> request.
/// </summary>
internal sealed class GetBalanceRequest : RequestBase {
	/// <summary>
	///     Initializes a new request to get <see cref="Balance" />.
	/// </summary>
	public GetBalanceRequest() : base("getBalance") { }
}