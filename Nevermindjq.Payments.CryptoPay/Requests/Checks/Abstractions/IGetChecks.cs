using System.Collections.Generic;

using Nevermindjq.Payments.CryptoPay.Models.Invoices.Enums;

namespace Nevermindjq.Payments.CryptoPay.Requests.Checks.Abstractions;

public interface IGetChecks {
	/// <summary>
	///     Optional. Cryptocurrency alphabetic code. Defaults to all currencies.
	/// </summary>
	public IEnumerable<string> Assets { get; }

	/// <summary>
	///     Optional. List of check IDs.
	/// </summary>
	public IEnumerable<long> CheckIds { get; }

	/// <summary>
	///     Optional. Offset needed to return a specific subset of check. Defaults to 0.
	/// </summary>
	public IEnumerable<Statuses> Statuses { get; }

	/// <summary>
	///     Optional. Offset needed to return a specific subset of check. Defaults to 0.
	/// </summary>
	public int Offset { get; }

	/// <summary>
	///     Optional. Number of check to be returned. Values between 1-1000 are accepted. Defaults to 100.
	/// </summary>
	public int Count { get; }
}