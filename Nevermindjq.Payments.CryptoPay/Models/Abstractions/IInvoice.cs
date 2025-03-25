﻿using System.Collections.Generic;

using Nevermindjq.Payments.CryptoPay.Extensions;
using Nevermindjq.Payments.CryptoPay.Models.Enums;

namespace Nevermindjq.Payments.CryptoPay.Models.Abstractions;

/// <summary>
///     Invoice. You can get invoice use <see cref="CryptoPayExtensions.CreateInvoiceAsync" />
/// </summary>
public interface IInvoice {
    /// <summary>
    ///     Currency code. Currently, can be one of assets.
    /// </summary>
    public string Asset { get; set; }

    /// <summary>
    ///     Optional. Fiat currency code. Available only if the value of the field <see cref="CurrencyType" /> is
    ///     <see cref="CurrencyTypes.fiat" />.
    /// </summary>
    public string Fiat { get; set; }

    /// <summary>
    ///     Amount of the invoice.
    /// </summary>
    public double Amount { get; set; }

    /// <summary>
    ///     Optional. Description for this invoice.
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    ///     True, if the user can add comment to the payment.
    /// </summary>
    public bool? AllowComments { get; set; }

    /// <summary>
    ///     Optional. Text of the hidden message for this invoice.
    /// </summary>
    public string HiddenMessage { get; set; }

    /// <summary>
    ///     Optional. Previously provided data for this invoice.
    /// </summary>
    public string Payload { get; set; }

    /// <summary>
    ///     Optional. Name of the button, can be one of <see cref="PaidButtonNames" />.
    /// </summary>
    public PaidButtonNames? PaidBtnName { get; set; }

    /// <summary>
    ///     Optional. URL of the button.
    /// </summary>
    public string PaidBtnUrl { get; set; }

    /// <summary>
    ///     Type of the price, can be one of <see cref="CurrencyTypes" />.
    /// </summary>
    public CurrencyTypes CurrencyType { get; set; }

    /// <summary>
    ///     Optional. List of assets which can be used to pay the invoice.
    ///     Available only if <see cref="CurrencyType" /> is <see cref="CurrencyTypes.fiat" />.
    ///     Currently, can be one of crypto from assets.
    /// </summary>
    public IEnumerable<string> AcceptedAssets { get; set; }
}