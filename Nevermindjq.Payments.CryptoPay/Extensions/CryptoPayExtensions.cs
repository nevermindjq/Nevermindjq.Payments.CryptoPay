﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

using Nevermindjq.Payments.CryptoPay.Exceptions;
using Nevermindjq.Payments.CryptoPay.Models;
using Nevermindjq.Payments.CryptoPay.Models.Checks;
using Nevermindjq.Payments.CryptoPay.Models.Checks.Enums;
using Nevermindjq.Payments.CryptoPay.Models.Invoices;
using Nevermindjq.Payments.CryptoPay.Models.Invoices.Enums;
using Nevermindjq.Payments.CryptoPay.Models.Transfers;
using Nevermindjq.Payments.CryptoPay.Requests;
using Nevermindjq.Payments.CryptoPay.Services;
using Nevermindjq.Payments.CryptoPay.Services.Abstractions;

#pragma warning disable CS8604
#pragma warning disable CS8601

namespace Nevermindjq.Payments.CryptoPay.Extensions;

/// <summary>
///     Crypto Pay Allowed methods.
/// </summary>
public static class CryptoPayExtensions {
    /// <summary>
    ///     Use this method to test your app's authentication token.
    /// </summary>
    /// <param name="cryptoPayClientClient">
    ///     <see cref="CryptoPayClient" />
    /// </param>
    /// <param name="cancellationToken">
    ///     A cancellation token that can be used by other objects or threads to receive notice of
    ///     cancellation.
    /// </param>
    /// <returns>Returns basic information about the bot in form of a <see cref="CryptoPayApplication" /> object.</returns>
    public static async Task<CryptoPayApplication> GetMeAsync(this ICryptoPayClient cryptoPayClientClient, CancellationToken cancellationToken = default) =>
		await cryptoPayClientClient.MakeRequestAsync<CryptoPayApplication>(new GetMeRequest(), cancellationToken).ConfigureAwait(false);

    /// <summary>
    ///     Use this method to create a new invoice. On success, returns an object of the created <see cref="Invoice" />.
    /// </summary>
    /// <param name="cryptoPayClientClient">
    ///     <see cref="CryptoPayClient" />
    /// </param>
    /// <param name="amount">Amount of the invoice in float. For example: 125.50.</param>
    /// <param name="currencyType">
    ///     Optional. Type of the price, can be <see cref="CurrencyTypes.crypto" /> or
    ///     <see cref="CurrencyTypes.fiat" />. Defaults to <see cref="CurrencyTypes.crypto" />.
    /// </param>
    /// <param name="asset">
    ///     Optional. Required if currencyType is <see cref="CurrencyTypes.crypto" />. Cryptocurrency alphabetic code.
    ///     <remarks>
    ///         Due to the fact that the list of available currencies in the CryptoPay service is constantly changing,
    ///         utilizing assets becomes ineffective. However, you can resort to using Assets.BTC.ToString() instead.
    ///     </remarks>
    /// </param>
    /// <param name="fiats">Optional. Required if currencyType is <see cref="CurrencyTypes.fiat" />. Fiat currency code.</param>
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
    ///     Optional. You can set a payment time limit for the invoice in seconds. Values between 1-2678400
    ///     are accepted.
    /// </param>
    /// <param name="cancellationToken">
    ///     A cancellation token that can be used by other objects or threads to receive notice of
    ///     cancellation.
    /// </param>
    /// <returns>
    ///     <see cref="Invoice" />
    /// </returns>
    /// <exception cref="RequestException">This exception can be thrown.</exception>
    public static async Task<Invoice> CreateInvoiceAsync(this ICryptoPayClient cryptoPayClientClient, double amount, CurrencyTypes currencyType = CurrencyTypes.crypto, string? asset = null, string? fiats = null, IEnumerable<string>? acceptedAssets = null, string? description = null, string? hiddenMessage = null, PaidButtonNames? paidBtnName = null, string? paidBtnUrl = null, string? payload = null, bool allowComments = true, bool allowAnonymous = true, int expiresIn = 2678400, CancellationToken cancellationToken = default) =>
		await cryptoPayClientClient.MakeRequestAsync<Invoice>(new CreateInvoiceRequest(amount, currencyType, asset, fiats, acceptedAssets, description, hiddenMessage, paidBtnName, paidBtnUrl, payload, allowComments, allowAnonymous, expiresIn), cancellationToken).ConfigureAwait(false);

    /// <summary>
    ///     Use this method to get a balance of your app. Returns array of <see cref="Balance" />.
    /// </summary>
    /// <param name="cryptoPayClientClient">
    ///     <see cref="CryptoPayClient" />
    /// </param>
    /// <param name="cancellationToken">
    ///     A cancellation token that can be used by other objects or threads to receive notice of
    ///     cancellation.
    /// </param>
    /// <returns>List of <see cref="Balance" /></returns>
    /// <exception cref="RequestException">This exception can be thrown.</exception>
    public static async Task<List<Balance>> GetBalanceAsync(this ICryptoPayClient cryptoPayClientClient, CancellationToken cancellationToken = default) =>
		await cryptoPayClientClient.MakeRequestAsync<List<Balance>>(new GetBalanceRequest(), cancellationToken).ConfigureAwait(false);

    /// <summary>
    ///     Use this method to get exchange rates of supported currencies. Returns array of <see cref="ExchangeRate" />
    /// </summary>
    /// <param name="cryptoPayClientClient">
    ///     <see cref="CryptoPayClient" />
    /// </param>
    /// <param name="cancellationToken">
    ///     A cancellation token that can be used by other objects or threads to receive notice of
    ///     cancellation.
    /// </param>
    /// <returns>List of <see cref="ExchangeRate" /></returns>
    /// <exception cref="RequestException">This exception can be thrown.</exception>
    public static async Task<List<ExchangeRate>> GetExchangeRatesAsync(this ICryptoPayClient cryptoPayClientClient, CancellationToken cancellationToken = default) =>
		await cryptoPayClientClient.MakeRequestAsync<List<ExchangeRate>>(new GetExchangeRatesRequest(), cancellationToken).ConfigureAwait(false);

    /// <summary>
    ///     Use this method to get a list of supported currencies. Returns array of <see cref="Currency" />
    /// </summary>
    /// <param name="cryptoPayClientClient">
    ///     <see cref="CryptoPayClient" />
    /// </param>
    /// <param name="cancellationToken">
    ///     A cancellation token that can be used by other objects or threads to receive notice of
    ///     cancellation.
    /// </param>
    /// <returns>List of <see cref="Currency" /></returns>
    /// <exception cref="RequestException">This exception can be thrown.</exception>
    public static async Task<List<Currency>> GetCurrenciesAsync(this ICryptoPayClient cryptoPayClientClient, CancellationToken cancellationToken = default) =>
		await cryptoPayClientClient.MakeRequestAsync<List<Currency>>(new GetCurrenciesRequest(), cancellationToken).ConfigureAwait(false);

    /// <summary>
    ///     Use this method to send coins from your app's balance to a user. On success, returns object of completed
    ///     <see cref="Transfer" />.
    /// </summary>
    /// <param name="cryptoPayClientClient">
    ///     <see cref="CryptoPayClient" />
    /// </param>
    /// <param name="userId">
    ///     Telegram user ID. User must have previously used <c>@CryptoBot</c> (<c>@CryptoTestnetBot</c> for
    ///     testnet).
    /// </param>
    /// <param name="asset">
    ///     Currency code.
    ///     <remarks>
    ///         Due to the fact that the list of available currencies in the CryptoPay service is constantly changing,
    ///         utilizing assets becomes ineffective. However, you can resort to using Assets.BTC.ToString() instead.
    ///     </remarks>
    /// </param>
    /// <param name="amount">Amount of the transfer in float. Values between $0.1-500 are accepted.</param>
    /// <param name="spendId">
    ///     Unique ID to make your request idempotent and ensure that only one of the transfers with the same <c>spendId</c>
    ///     will be accepted by Crypto Pay API.
    ///     This parameter is useful when the transfer should be retried (i.e. request timeout, connection reset, 500 HTTP
    ///     status, etc).
    ///     It can be some unique withdrawal identifier for example. Up to 64 symbols.
    /// </param>
    /// <param name="comment">
    ///     Optional. Comment for the transfer. Users will see this comment when they receive a notification
    ///     about the transfer. Up to 1024 symbols.
    /// </param>
    /// <param name="disableSendNotification">
    ///     Optional. Pass true if the user should not receive a notification about the
    ///     transfer. Default is <c>false</c>.
    /// </param>
    /// <param name="cancellationToken">
    ///     A cancellation token that can be used by other objects or threads to receive notice of
    ///     cancellation.
    /// </param>
    /// <returns>
    ///     <see cref="Transfer" />Optional. Pass true if the user should not receive a notification about the transfer.
    ///     Default is false.
    /// </returns>
    /// <exception cref="RequestException">This exception can be thrown.</exception>
    public static async Task<Transfer> TransferAsync(this ICryptoPayClient cryptoPayClientClient, long userId, string asset, double amount, string spendId, string? comment = null, bool? disableSendNotification = null, CancellationToken cancellationToken = default) =>
		await cryptoPayClientClient.MakeRequestAsync<Transfer>(new TransferRequest(userId, asset, amount, spendId, comment, disableSendNotification), cancellationToken).ConfigureAwait(false);

    /// <summary>
    ///     Use this method to get transfers created by your app. On success, returns array of <see cref="Transfer" />.
    /// </summary>
    /// <param name="cryptoPayClientClient">
    ///     <see cref="CryptoPayClient" />
    /// </param>
    /// <param name="asset">
    ///     Optional. Cryptocurrency alphabetic code. Defaults to all currencies.
    ///     <remarks>
    ///         Due to the fact that the list of available currencies in the CryptoPay service is constantly changing,
    ///         utilizing assets becomes ineffective. However, you can resort to using Assets.BTC.ToString() instead.
    ///     </remarks>
    /// </param>
    /// <param name="transferIds">Optional. List of transfer IDs.</param>
    /// <param name="spendId">Optional. Unique UTF-8 transfer string.</param>
    /// <param name="offset">Optional. Offset needed to return a specific subset of transfers. Defaults to 0.</param>
    /// <param name="count">Optional. Number of transfers to be returned. Values between 1-1000 are accepted. Defaults to 100.</param>
    /// <param name="cancellationToken">
    ///     A cancellation token that can be used by other objects or threads to receive notice of
    ///     cancellation.
    /// </param>
    /// <returns>
    ///     <see cref="Transfer" />Optional. Pass true if the user should not receive a notification about the transfer.
    ///     Default is false.
    /// </returns>
    /// <exception cref="RequestException">This exception can be thrown.</exception>
    public static async Task<Transfers> GetTransfersAsync(this ICryptoPayClient cryptoPayClientClient, IEnumerable<string>? asset = null, IEnumerable<string>? transferIds = null, string? spendId = null, int offset = 0, int count = 100, CancellationToken cancellationToken = default) =>
		await cryptoPayClientClient.MakeRequestAsync<Transfers>(new GetTransfersRequest(asset, transferIds, spendId, offset, count), cancellationToken).ConfigureAwait(false);

    /// <summary>
    ///     Use this method to get invoices of your app. On success, returns array of <see cref="Invoice" />.
    /// </summary>
    /// <param name="cryptoPayClientClient">
    ///     <see cref="CryptoPayClient" />
    /// </param>
    /// <param name="assets">
    ///     Optional. List of assets.
    ///     <remarks>
    ///         Due to the fact that the list of available currencies in the CryptoPay service is constantly changing,
    ///         utilizing assets becomes ineffective. However, you can resort to using Assets.BTC.ToString() instead.
    ///     </remarks>
    /// </param>
    /// <param name="invoiceIds">Optional. List of Invoice IDs.</param>
    /// <param name="status">
    ///     Optional. Status of invoices to be returned. Available statuses: “active” and “paid”. Defaults to
    ///     all statuses.
    /// </param>
    /// <param name="offset">Optional. Offset needed to return a specific subset of invoices. Default is 0.</param>
    /// <param name="count">Optional. Number of invoices to be returned. Values between 1-1000 are accepted. Defaults to 100.</param>
    /// <param name="cancellationToken">
    ///     A cancellation token that can be used by other objects or threads to receive notice of
    ///     cancellation.
    /// </param>
    /// <returns>
    ///     <see cref="Invoice" />
    /// </returns>
    /// <exception cref="RequestException">This exception can be thrown.</exception>
    public static async Task<Invoices> GetInvoicesAsync(this ICryptoPayClient cryptoPayClientClient, IEnumerable<string>? assets = null, IEnumerable<long>? invoiceIds = null, Statuses? status = null, int offset = 0, int count = 100, CancellationToken cancellationToken = default) =>
		await cryptoPayClientClient.MakeRequestAsync<Invoices>(new GetInvoicesRequest(assets, invoiceIds, status, offset, count), cancellationToken).ConfigureAwait(false);

    /// <summary>
    /// </summary>
    /// <param name="cryptoPayClientClient">
    ///     <see cref="CryptoPayClient" />
    /// </param>
    /// <param name="invoiceId"></param>
    /// <param name="cancellationToken">
    ///     A cancellation token that can be used by other objects or threads to receive notice of
    ///     cancellation.
    /// </param>
    /// <returns>
    ///     <see cref="Invoice" />
    /// </returns>
    /// <exception cref="RequestException">This exception can be thrown.</exception>
    public static async Task<bool> DeleteInvoiceAsync(this ICryptoPayClient cryptoPayClientClient, long invoiceId, CancellationToken cancellationToken = default) =>
		await cryptoPayClientClient.MakeRequestAsync<bool>(new DeleteInvoiceRequest(invoiceId), cancellationToken).ConfigureAwait(false);

    /// <summary>
    ///     Use this method to create a new <see cref="Check" />.
    /// </summary>
    /// <param name="cryptoPayClientClient">
    ///     <see cref="CryptoPayClient" />
    /// </param>
    /// <param name="asset">
    ///     Cryptocurrency alphabetic code.
    ///     <remarks>
    ///         Due to the fact that the list of available currencies in the CryptoPay service is constantly changing,
    ///         utilizing assets becomes ineffective. However, you can resort to using Assets.BTC.ToString() instead.
    ///     </remarks>
    /// </param>
    /// <param name="amount">Amount of the invoice in float. For example: 125.50</param>
    /// <param name="pinToUsername"></param>
    /// <param name="cancellationToken">
    ///     A cancellation token that can be used by other objects or threads to receive notice of
    ///     cancellation.
    /// </param>
    /// <param name="pinToUserId"></param>
    /// <returns><see cref="Check" />On success, returns an <see cref="Check" /> of the created.</returns>
    /// <exception cref="RequestException">This exception can be thrown.</exception>
    public static async Task<Check> CreateCheckAsync(this ICryptoPayClient cryptoPayClientClient, string asset, double amount, long? pinToUserId = null, string? pinToUsername = null, CancellationToken cancellationToken = default) =>
		await cryptoPayClientClient.MakeRequestAsync<Check>(new CreateCheckRequest(asset, amount, pinToUserId, pinToUsername), cancellationToken).ConfigureAwait(false);

    /// <summary>
    ///     Use this method to delete checks created by your app.
    /// </summary>
    /// <param name="cryptoPayClientClient">
    ///     <see cref="CryptoPayClient" />
    /// </param>
    /// <param name="checkId"></param>
    /// <param name="cancellationToken">
    ///     A cancellation token that can be used by other objects or threads to receive notice of
    ///     cancellation.
    /// </param>
    /// <returns>Returns True on success.</returns>
    /// <exception cref="RequestException">This exception can be thrown.</exception>
    public static async Task<bool> DeleteCheckAsync(this ICryptoPayClient cryptoPayClientClient, long checkId, CancellationToken cancellationToken = default) =>
		await cryptoPayClientClient.MakeRequestAsync<bool>(new DeleteCheckRequest(checkId), cancellationToken).ConfigureAwait(false);

    /// <summary>
    ///     Use this method to get checks created by your app.
    /// </summary>
    /// <param name="cryptoPayClientClient">
    ///     <see cref="CryptoPayClient" />
    /// </param>
    /// <param name="assets">
    ///     Optional. Cryptocurrency alphabetic code.Defaults to all currencies.
    ///     <remarks>
    ///         Due to the fact that the list of available currencies in the CryptoPay service is constantly changing,
    ///         utilizing assets becomes ineffective. However, you can resort to using Assets.BTC.ToString() instead.
    ///     </remarks>
    /// </param>
    /// <param name="checkIds">Optional. List of check IDs.</param>
    /// <param name="status">
    ///     Optional. Status of check to be returned. Available statuses: <see cref="CheckStatus" />. Defaults
    ///     to all statuses.
    /// </param>
    /// <param name="offset">Optional. Offset needed to return a specific subset of check. Defaults to 0.</param>
    /// <param name="count">Optional. Number of check to be returned. Values between 1-1000 are accepted. Defaults to 100.</param>
    /// <param name="cancellationToken">
    ///     A cancellation token that can be used by other objects or threads to receive notice of
    ///     cancellation.
    /// </param>
    /// <returns><see cref="Check" />On success, returns array of <see cref="Check" /></returns>
    /// <exception cref="RequestException">This exception can be thrown.</exception>
    public static async Task<Checks> GetChecksAsync(this ICryptoPayClient cryptoPayClientClient, IEnumerable<string>? assets = null, IEnumerable<long>? checkIds = null, IEnumerable<Statuses>? status = null, int offset = 0, int count = 100, CancellationToken cancellationToken = default) =>
		await cryptoPayClientClient.MakeRequestAsync<Checks>(new GetChecksRequest(assets, checkIds, status, offset, count), cancellationToken).ConfigureAwait(false);

    /// <summary>
    ///     Use this method to get app statistics. On success, returns <see cref="AppStats" />.
    /// </summary>
    /// <param name="cryptoPayClientClient">
    ///     <see cref="CryptoPayClient" />
    /// </param>
    /// <param name="startAt">Optional. Date from which start calculating statistics. Defaults is current date minus 24 hours.</param>
    /// <param name="endAt">
    ///     Optional. The date on which to finish calculating statistics in ISO 8601 format. Defaults is
    ///     current date.
    /// </param>
    /// <param name="cancellationToken">
    ///     A cancellation token that can be used by other objects or threads to receive notice of
    ///     cancellation.
    /// </param>
    /// <returns>On success, returns <see cref="AppStats" /></returns>
    /// <exception cref="RequestException">This exception can be thrown.</exception>
    public static async Task<AppStats> GetStatsAsync(this ICryptoPayClient cryptoPayClientClient, DateTime? startAt = null, DateTime? endAt = null, CancellationToken cancellationToken = default) =>
		await cryptoPayClientClient.MakeRequestAsync<AppStats>(new GetStatsRequest(startAt, endAt), cancellationToken).ConfigureAwait(false);
}