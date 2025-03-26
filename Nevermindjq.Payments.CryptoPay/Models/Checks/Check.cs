using System;

using Nevermindjq.Payments.CryptoPay.Models.Checks.Abstractions;
using Nevermindjq.Payments.CryptoPay.Models.Checks.Enums;

#pragma warning disable CS8618

namespace Nevermindjq.Payments.CryptoPay.Models.Checks;

/// <summary>
///     This class have to manage checks by using the app.
/// </summary>
public sealed class Check : ICheck {
	[JsonRequired]
	public long CheckId { get; set; }

	[JsonRequired]
	public string Hash { get; set; }

	[JsonRequired]
	public string Asset { get; set; }

	[JsonRequired]
	public double Amount { get; set; }

	[JsonRequired]
	public string BotCheckUrl { get; set; }

	[JsonRequired]
	public CheckStatus Status { get; set; }

	[JsonRequired]
	public DateTime CreatedAt { get; set; }

	[JsonRequired]
	public DateTime? ActivatedAt { get; set; }
}