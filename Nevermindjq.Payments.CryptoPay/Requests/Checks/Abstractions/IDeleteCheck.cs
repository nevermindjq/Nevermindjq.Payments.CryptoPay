namespace Nevermindjq.Payments.CryptoPay.Requests.Checks.Abstractions;

public interface IDeleteCheck {
	/// <summary>
	///     Unique ID for this check.
	/// </summary>
	public long CheckId { get; }
}