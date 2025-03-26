using Nevermindjq.Payments.CryptoPay.Requests.Abstractions;
using Nevermindjq.Payments.CryptoPay.Requests.Checks.Abstractions;

namespace Nevermindjq.Payments.CryptoPay.Requests.Checks;

/// <summary>
///     Use this request to delete checks created by your app. Returns True on success.
/// </summary>
public sealed class DeleteCheckRequest(long checkId) : RequestBase("deleteCheck"), IDeleteCheck {
	public long CheckId { get; } = checkId;
}