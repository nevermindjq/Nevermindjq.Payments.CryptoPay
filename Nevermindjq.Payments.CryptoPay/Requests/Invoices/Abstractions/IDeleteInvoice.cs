namespace Nevermindjq.Payments.CryptoPay.Requests.Invoices.Abstractions;

public interface IDeleteInvoice {
	/// <summary>
	///     Unique ID for this invoice.
	/// </summary>
	public long InvoiceId { get; }
}