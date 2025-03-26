namespace Nevermindjq.Payments.CryptoPay.Requests.Checks.Abstractions;

public interface ICreateCheck {
	/// <summary>
	///     Cryptocurrency alphabetic code.
	/// </summary>
	public string Asset { get; }

	/// <summary>
	///     Amount of the invoice in float. For example: 125.50
	/// </summary>
	public double Amount { get; }

	/// <summary>
	///     Optional. A user with the specified username will be able to activate the check.
	/// </summary>
	public long? PinToUserId { get; }

	/// <summary>
	///     Optional. A user with the specified username will be able to activate the check.
	/// </summary>
	public string? PinToUsername { get; }
}