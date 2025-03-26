using System.Collections.Generic;

using Nevermindjq.Payments.CryptoPay.Models.Invoices;
using Nevermindjq.Payments.CryptoPay.Models.Invoices.Enums;
using Nevermindjq.Payments.CryptoPay.Requests.Abstractions;
using Nevermindjq.Payments.CryptoPay.Requests.Invoices.Abstractions;

#pragma warning disable CS8618
#pragma warning disable CS8601

namespace Nevermindjq.Payments.CryptoPay.Requests.Invoices;

/// <summary>
///     Use this class to get <see cref="Invoices" /> request.
/// </summary>
public sealed class GetInvoicesRequest(IEnumerable<string>? assets = null, IEnumerable<long>? invoiceIds = null, Statuses? status = null, int offset = 0, int count = 100) : RequestBase("getInvoices"), IGetInvoices {
	public IEnumerable<string> Assets { get; set; }

	public IEnumerable<long> InvoiceIds { get; set; }

	public Statuses? Status { get; set; }

	[JsonRequired]
	public int Offset { get; set; }

	[JsonRequired]
	public int Count { get; set; }
}