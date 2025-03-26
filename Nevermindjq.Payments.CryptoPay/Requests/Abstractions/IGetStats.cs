using System;

namespace Nevermindjq.Payments.CryptoPay.Requests.Abstractions;

public interface IGetStats {
	/// <summary>
	///     Optional. Date from which start calculating statistics in ISO 8601 format. Defaults is current date minus 24 hours.
	/// </summary>
	public DateTime StartAt { get; set; }

	/// <summary>
	///     Optional. The date on which to finish calculating statistics in ISO 8601 format. Defaults is current date.
	/// </summary>
	public DateTime EndAt { get; set; }
}