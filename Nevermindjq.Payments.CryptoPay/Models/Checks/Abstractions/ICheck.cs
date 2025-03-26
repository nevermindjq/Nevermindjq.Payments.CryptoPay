using System;

using Nevermindjq.Payments.CryptoPay.Models.Checks.Enums;

namespace Nevermindjq.Payments.CryptoPay.Models.Checks.Abstractions;

public interface ICheck {
	/// <summary>
	///     Unique ID for this check.
	/// </summary>
	public long CheckId { get; set; }

	/// <summary>
	///     Hash of the check.
	/// </summary>
	public string Hash { get; set; }

	/// <summary>
	///     Cryptocurrency alphabetic code. Currently, can be one of assets.
	/// </summary>
	public string Asset { get; set; }

	/// <summary>
	///     Amount of the check in float.
	/// </summary>
	public double Amount { get; set; }

	/// <summary>
	///     URL should be provided to the user to activate the check.
	/// </summary>
	public string BotCheckUrl { get; set; }

	/// <summary>
	///     Status of the check, can be <see cref="CheckStatus.active" /> or <see cref="CheckStatus.activated" />.
	/// </summary>
	public CheckStatus Status { get; set; }

	/// <summary>
	///     Date the check was created in ISO 8601 format.
	/// </summary>
	public DateTime CreatedAt { get; set; }

	/// <summary>
	///     Date the check was activated in ISO 8601 format.
	/// </summary>
	public DateTime? ActivatedAt { get; set; }
}