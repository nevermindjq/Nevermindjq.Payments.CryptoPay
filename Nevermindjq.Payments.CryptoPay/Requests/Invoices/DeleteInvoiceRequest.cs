 

using Nevermindjq.Payments.CryptoPay.Requests.Abstractions;

namespace Nevermindjq.Payments.CryptoPay.Requests.Invoices;

/// <summary>
///     Use this method to delete invoices created by your app.
/// </summary>
public sealed class DeleteInvoiceRequest : RequestBase {
	#region Constructors

    /// <summary>
    ///     Initializes a new request delete invoices created by your app.
    /// </summary>
    /// <param name="invoiceId">Invoice ID to be deleted.</param>
    public DeleteInvoiceRequest(long invoiceId) : base("deleteInvoice") => InvoiceId = invoiceId;

	#endregion

    /// <summary>
    ///     Unique ID for this invoice.
    /// </summary>
    [JsonRequired]
	public long InvoiceId { get; set; }
}