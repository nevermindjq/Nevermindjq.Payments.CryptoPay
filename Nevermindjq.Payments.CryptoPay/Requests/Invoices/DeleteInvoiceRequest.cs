 

using Nevermindjq.Payments.CryptoPay.Requests.Abstractions;
using Nevermindjq.Payments.CryptoPay.Requests.Invoices.Abstractions;

namespace Nevermindjq.Payments.CryptoPay.Requests.Invoices;

/// <summary>
///     Use this method to delete invoices created by your app.
/// </summary>
public sealed class DeleteInvoiceRequest(long invoiceId) : RequestBase("deleteInvoice"), IDeleteInvoice {
	public long InvoiceId { get; } = invoiceId;
}