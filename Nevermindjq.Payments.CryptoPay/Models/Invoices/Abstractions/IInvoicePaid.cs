using System;

using Nevermindjq.Payments.CryptoPay.Models.Invoices.Enums;

namespace Nevermindjq.Payments.CryptoPay.Models.Invoices.Abstractions;

public interface IInvoicePaid {
	/// <summary>
	///     Status of the invoice, can be either “active”, “paid” or “expired”.
	/// </summary>
	public Statuses Status { get; set; }

	#region Payment information

	/// <summary>
	///     Optional. Cryptocurrency alphabetic code for which the invoice was paid.
	///     Available only if <see cref="CurrencyType" /> is <see cref="CurrencyTypes.fiat" /> and status is
	///     <see cref="Statuses.paid" />.
	/// </summary>
	public string PaidAsset { get; set; }

	/// <summary>
	///     Optional. Amount of the invoice for which the invoice was paid.
	///     Available only if <see cref="CurrencyType" /> is <see cref="CurrencyTypes.fiat" /> and status is
	///     <see cref="Statuses.paid" />.
	/// </summary>
	public string PaidAmount { get; set; }

	/// <summary>
	///     Optional. The rate of the paid_asset valued in the fiat currency.
	///     Available only if the value of the field <see cref="CurrencyType" /> is <see cref="CurrencyTypes.fiat" /> and the
	///     value of the field status is <see cref="Statuses.paid" />.
	/// </summary>
	public string PaidFiatRate { get; set; }

	/// <summary>
	///     Optional. Price of the asset in USD. Available only if status is <see cref="Statuses.paid" />.
	/// </summary>
	public string PaidUsdRate { get; set; }

	/// <summary>
	///     Optional. Price of the asset in USD at the time the invoice was paid.
	/// </summary>
	[Obsolete("The field UsdRate in the Webhook update payload is now deprecated, use the new field PaidUsdRate instead")]
	public string UsdRate { get; set; }

	#endregion

	#region Fee

	/// <summary>
	///     Optional. Asset of service fees charged when the invoice was paid.
	///     Available only if status is <see cref="Statuses.paid" />.
	/// </summary>
	public string FeeAsset { get; set; }

	/// <summary>
	///     Optional. Amount of service fees charged when the invoice was paid.
	///     Available only if status is <see cref="Statuses.paid" />.
	/// </summary>
	public double FeeAmount { get; set; }

	/// <summary>
	///		Optional. Amount in USD of service fees charged when the invoice was paid. Available only if status is “paid”.
	/// </summary>
	public double FeeInUsd { get; set; }

	/// <summary>
	///     Optional. Amount of charged service fees.
	/// </summary>
	[Obsolete("The field Fee in the Webhook update payload is now deprecated, use the new field FeeAmount instead")]
	public string Fee { get; set; }

	#endregion

	#region URLs

	/// <summary>
	///     URL should be presented to the user to pay the invoice.
	/// </summary>
	public string PayUrl { get; set; }

	/// <summary>
	///     URL should be provided to the user to pay the invoice.
	/// </summary>
	public string BotInvoiceUrl { get; set; }

	/// <summary>
	///     Use this URL to pay an invoice to the Telegram Mini App version.
	/// </summary>
	public string MiniAppInvoiceUrl { get; set; }

	/// <summary>
	///     Use this URL to pay an invoice to the Web version of Crypto Bot.
	/// </summary>
	public string WebAppInvoiceUrl { get; set; }

	#endregion

	/// <summary>
	///     Date the invoice was created in ISO 8601 format.
	/// </summary>
	public DateTime CreatedAt { get; set; }

	/// <summary>
	///     Optional. Date the invoice expires in Unix time.
	/// </summary>
	public DateTime? ExpirationDate { get; set; }

	/// <summary>
	///     Optional. Date the invoice was paid in Unix time.
	/// </summary>
	public DateTime? PaidAt { get; set; }

	#region

	/// <summary>
	///     Optional. Comment to the payment from the user.
	/// </summary>
	public string Comment { get; set; }

	/// <summary>
	///     True, if the invoice was paid anonymously.
	/// </summary>
	public bool? PaidAnonymously { get; set; }

	#endregion
}