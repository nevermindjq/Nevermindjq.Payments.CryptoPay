using System.Collections.Generic;

using Nevermindjq.Payments.CryptoPay.Models.Invoices.Enums;

namespace Nevermindjq.Payments.CryptoPay.Requests.Invoices.Abstractions;

public interface IGetInvoices {
	/// <summary>
	///     Optional. Currency codes.
	///     Defaults to all assets.
	/// </summary>
	public IEnumerable<string> Assets { get; set; }

	/// <summary>
	///     Optional. Invoice IDs.
	/// </summary>
	public IEnumerable<long> InvoiceIds { get; set; }

	/// <summary>
	///     Optional. Status of invoices to be returned. Available statuses: <see cref="Statuses" />.
	///     Defaults to all statuses.
	/// </summary>
	public Statuses? Status { get; set; }

	/// <summary>
	///     Optional. Offset needed to return a specific subset of invoices.
	///     Default is 0.
	/// </summary>
	public int Offset { get; set; }

	/// <summary>
	///     Optional. Number of invoices to be returned. Values between 1-1000 are accepted.
	///     Defaults to 100.
	/// </summary>
	public int Count { get; set; }
}