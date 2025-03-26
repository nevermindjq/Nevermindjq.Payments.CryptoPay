using Nevermindjq.Payments.CryptoPay.Models.Checks;
using Nevermindjq.Payments.CryptoPay.Requests.Abstractions;
using Nevermindjq.Payments.CryptoPay.Requests.Checks.Abstractions;

namespace Nevermindjq.Payments.CryptoPay.Requests.Checks;

/// <summary>
///     Use this method to create a new check. On success, returns an object of the created <see cref="Check" />.
/// </summary>
public sealed class CreateCheckRequest(string asset, double amount, long? pinToUserId = null, string? pinToUsername = null) : RequestBase("createCheck"), ICreateCheck {
	[JsonRequired]
	public string Asset { get; set; } = asset;

	[JsonRequired]
	public double Amount { get; set; } = amount;

	public long? PinToUserId { get; set; } = pinToUserId;

	public string? PinToUsername { get; set; } = pinToUsername;
}