using System.Collections.Generic;

using Nevermindjq.Payments.CryptoPay.Models.Invoices;
using Nevermindjq.Payments.CryptoPay.Models.Invoices.Enums;
using Nevermindjq.Payments.CryptoPay.Requests.Abstractions;

#pragma warning disable CS8618
#pragma warning disable CS8601

namespace Nevermindjq.Payments.CryptoPay.Requests;

/// <summary>
///     Use this class to get <see cref="Invoices" /> request.
/// </summary>
internal sealed class GetInvoicesRequest : ParameterlessRequest {
	#region Constructors

    /// <summary>
    ///     Initializes a new request to get <see cref="Invoices" />
    /// </summary>
    /// <param name="assets">Optional. Currency codes.</param>
    /// <param name="invoiceIds">Optional. Invoice IDs.</param>
    /// <param name="status">
    ///     Optional. Status of invoices to be returned. Available statuses: <see cref="Statuses.active" />
    ///     and <see cref="Statuses.paid" />. Defaults to all statuses.
    /// </param>
    /// <param name="offset">Optional. Offset needed to return a specific subset of invoices. Default is 0.</param>
    /// <param name="count">Optional. Number of invoices to be returned. Values between 1-1000 are accepted. Defaults to 100.</param>
    public GetInvoicesRequest(IEnumerable<string>? assets = null, IEnumerable<long>? invoiceIds = null, Statuses? status = null, int offset = 0, int count = 100) : base("getInvoices") {
		Assets = assets;
		InvoiceIds = invoiceIds;
		Status = status;
		Offset = offset;
		Count = count;
	}

	#endregion

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
    [JsonRequired]
	public int Offset { get; set; }

    /// <summary>
    ///     Optional. Number of invoices to be returned. Values between 1-1000 are accepted.
    ///     Defaults to 100.
    /// </summary>
    [JsonRequired]
	public int Count { get; set; }
}