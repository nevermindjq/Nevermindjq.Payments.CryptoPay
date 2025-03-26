﻿using System.Collections.Generic;

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
public sealed class CreateInvoiceRequest : RequestBase, IInvoice {
	#region Constructors

    /// <summary>
    ///     Initializes a new request to create <see cref="Invoice" />
    /// </summary>
    /// <param name="amount">Amount of the invoice in float. For example: 125.50</param>
    /// <param name="currencyType">
    ///     Optional. Type of the price, can be <see cref="CurrencyTypes.crypto" /> or
    ///     <see cref="CurrencyTypes.fiat" />. Defaults to crypto.
    /// </param>
    /// <param name="asset">
    ///     Currency code.
    ///     <remarks>
    ///         Due to the fact that the list of available currencies in the CryptoPay service is constantly changing,
    ///         utilizing assets becomes ineffective. However, you can resort to using Assets.BTC.ToString() instead.
    ///     </remarks>
    /// </param>
    /// <param name="fiat">Optional. Required if currencyType is <see cref="CurrencyTypes.fiat" />. Fiat currency code.</param>
    /// <param name="acceptedAssets">
    ///     Optional. List of cryptocurrency alphabetic codes. Assets which can be used to pay the invoice.
    ///     Available only if currencyType is <see cref="CurrencyTypes.fiat" />.
    ///     Defaults to all currencies.
    /// </param>
    /// <param name="description">
    ///     Optional. Description for the invoice. User will see this description when they pay the
    ///     invoice. Up to 1024 characters.
    /// </param>
    /// <param name="hiddenMessage">
    ///     Optional. Text of the message that will be shown to a user after the invoice is paid. Up to
    ///     2048 characters.
    /// </param>
    /// <param name="paidBtnName">
    ///     Optional. Name of the button that will be shown to a user after the invoice is paid.
    ///     <see cref="PaidButtonNames" />
    /// </param>
    /// <param name="paidBtnUrl">
    ///     Optional. Required if <see cref="PaidButtonNames">paidBtnName</see> is used. URL to be opened when the button is
    ///     pressed.
    ///     You can set any success link (for example, a link to your bot). Starts with https or http.
    /// </param>
    /// <param name="payload">
    ///     Optional.Any data you want to attach to the invoice (for example, user ID, payment ID, ect). Up
    ///     to 4kb.
    /// </param>
    /// <param name="allowComments">Optional. Allow a user to add a comment to the payment. Default is true.</param>
    /// <param name="allowAnonymous">Optional. Allow a user to pay the invoice anonymously. Default is <c>true</c>.</param>
    /// <param name="expiresIn">
    ///     You can set a payment time limit for the invoice in <b>seconds</b>. Values between 1-2678400
    ///     are accepted.
    /// </param>
    public CreateInvoiceRequest(double amount, CurrencyTypes currencyType = CurrencyTypes.crypto, string? asset = null, string? fiat = null, IEnumerable<string>? acceptedAssets = null, string? description = null, string? hiddenMessage = null, PaidButtonNames? paidBtnName = null, string? paidBtnUrl = null, string? payload = null, bool allowComments = true, bool allowAnonymous = true, int expiresIn = 2678400) : base("createInvoice") {
		CurrencyType = currencyType;
		Amount = amount;
		Asset = asset;
		Fiat = fiat;
		AcceptedAssets = acceptedAssets;
		Description = description;
		HiddenMessage = hiddenMessage;
		PaidBtnName = paidBtnName;
		PaidBtnUrl = paidBtnUrl;
		Payload = payload;
		AllowComments = allowComments;
		AllowAnonymous = allowAnonymous;
		ExpiresIn = expiresIn;
	}

	#endregion

	#region Public Fields

	/// <inheritdoc />
	public string Asset { get; set; }

	/// <inheritdoc />
	public string Fiat { get; set; }

	/// <inheritdoc />
	[JsonRequired]
	public double Amount { get; set; }

	/// <inheritdoc />
	public string Description { get; set; }

	/// <inheritdoc />
	public string HiddenMessage { get; set; }

	/// <inheritdoc />
	public PaidButtonNames? PaidBtnName { get; set; }

	/// <inheritdoc />
	public string PaidBtnUrl { get; set; }

	/// <inheritdoc />
	public string Payload { get; set; }

	/// <inheritdoc />
	public bool? AllowComments { get; set; }

	/// <inheritdoc />
	[JsonRequired]
	public CurrencyTypes CurrencyType { get; set; }

	/// <inheritdoc />
	[JsonConverter(typeof(ArrayToStringConverter))]
	public IEnumerable<string> AcceptedAssets { get; set; }

    /// <summary>
    ///     Optional. Allow a user to pay the invoice anonymously. Default is true.
    /// </summary>
    public bool? AllowAnonymous { get; set; }

    /// <summary>
    ///     Optional. You can set a payment time limit for the invoice in seconds. Values between 1-2678400 are accepted.
    /// </summary>
    public int ExpiresIn { get; set; }

	#endregion
}