using System;
using System.Collections.Generic;

using Nevermindjq.Payments.CryptoPay.Models.Invoices.Abstractions;
using Nevermindjq.Payments.CryptoPay.Models.Invoices.Enums;

#pragma warning disable CS8618

namespace Nevermindjq.Payments.CryptoPay.Models.Invoices;

/// <inheritdoc cref="IInvoice" />
public sealed class Invoice : IInvoice, IInvoicePaid {
	/// <summary>
	///     Unique ID for this invoice.
	/// </summary>
	[JsonRequired]
	public long InvoiceId { get; set; }

	/// <summary>
	///     Hash of the invoice.
	/// </summary>
	[JsonRequired]
	public string Hash { get; set; }

	#region IInvoice

	public CurrencyTypes CurrencyType { get; set; }

	public string Asset { get; set; }

	public string Fiat { get; set; }

	[JsonRequired]
	public double Amount { get; set; }

	public bool? AllowComments { get; set; }

	public bool? AllowAnonymous { get; set; }

	public PaidButtonNames? PaidBtnName { get; set; }

	public string PaidBtnUrl { get; set; }

	[Obsolete("The field PayUrl is now deprecated, use the new field BotInvoiceUrl instead")]
	public string PayUrl { get; set; }

	public string Payload { get; set; }

	public string HiddenMessage { get; set; }

	public string Description { get; set; }

	public IEnumerable<string> AcceptedAssets { get; set; }

	#endregion

	#region IInvoicePaid

	[JsonRequired]
	public Statuses Status { get; set; }

	public string PaidAsset { get; set; }

	public string PaidAmount { get; set; }

	public string PaidFiatRate { get; set; }

	public string PaidUsdRate { get; set; }

	public string UsdRate { get; set; }

	public string FeeAsset { get; set; }

	public double FeeAmount { get; set; }

	public double FeeInUsd { get; set; }

	public string Fee { get; set; }

	[JsonRequired]
	public string BotInvoiceUrl { get; set; }

	[JsonRequired]
	public string MiniAppInvoiceUrl { get; set; }

	[JsonRequired]
	public string WebAppInvoiceUrl { get; set; }

	[JsonRequired]
	public DateTime CreatedAt { get; set; }

	public DateTime? ExpirationDate { get; set; }

	public DateTime? PaidAt { get; set; }

	public string Comment { get; set; }

	public bool? PaidAnonymously { get; set; }

	#endregion
}