using System.Collections.Generic;

using Nevermindjq.Payments.CryptoPay.Converters;
using Nevermindjq.Payments.CryptoPay.Models.Invoices;
using Nevermindjq.Payments.CryptoPay.Models.Invoices.Abstractions;
using Nevermindjq.Payments.CryptoPay.Models.Invoices.Enums;
using Nevermindjq.Payments.CryptoPay.Requests.Abstractions;

#pragma warning disable CS8618
#pragma warning disable CS8601

namespace Nevermindjq.Payments.CryptoPay.Requests.Invoices;

/// <summary>
///     Use this class to create <see cref="Invoice" /> request.
/// </summary>
public sealed class CreateInvoiceRequest(double amount, CurrencyTypes currencyType = CurrencyTypes.crypto, string? asset = null, string? fiat = null, IEnumerable<string>? acceptedAssets = null, string? description = null, string? hiddenMessage = null, PaidButtonNames? paidBtnName = null, string? paidBtnUrl = null, string? payload = null, bool allowComments = true, bool allowAnonymous = true, int expiresIn = 2678400) : RequestBase("createInvoice"), IInvoice {

	public string Asset { get; set; } = asset;

	public string Fiat { get; set; } = fiat;

	[JsonRequired]
	public double Amount { get; set; } = amount;

	public string Description { get; set; } = description;

	public string HiddenMessage { get; set; } = hiddenMessage;

	public PaidButtonNames? PaidBtnName { get; set; } = paidBtnName;

	public string PaidBtnUrl { get; set; } = paidBtnUrl;

	public string Payload { get; set; } = payload;

	public bool? AllowComments { get; set; } = allowComments;

	[JsonRequired]
	public CurrencyTypes CurrencyType { get; set; } = currencyType;

	[JsonConverter(typeof(ArrayToStringConverter))]
	public IEnumerable<string> AcceptedAssets { get; set; } = acceptedAssets;

	public bool? AllowAnonymous { get; set; } = allowAnonymous;

	/// <summary>
	///     Optional. You can set a payment time limit for the invoice in seconds. Values between 1-2678400 are accepted.
	/// </summary>
	public int ExpiresIn { get; set; } = expiresIn;
}