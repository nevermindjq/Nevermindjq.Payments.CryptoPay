﻿using Nevermindjq.Payments.CryptoPay.Models;
using Nevermindjq.Payments.CryptoPay.Models.Abstractions;
using Nevermindjq.Payments.CryptoPay.Models.Enums;
using Nevermindjq.Payments.CryptoPay.Requests.Abstractions;

#pragma warning disable CS8618
#pragma warning disable CS8601

namespace Nevermindjq.Payments.CryptoPay.Requests;

/// <summary>
///     Use this class to get <see cref="Transfer" /> request.
/// </summary>
public sealed class TransferRequest : ParameterlessRequest<Transfer>, ITransfer {
    /// <summary>
    ///     Initializes a new request to get a <see cref="Transfer" />
    /// </summary>
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
    public TransferRequest(long userId, string asset, double amount, string spendId, string? comment = null, bool? disableSendNotification = null) : base("transfer") {
		UserId = userId;
		Asset = asset;
		Amount = amount;
		SpendId = spendId;
		Comment = comment;
		DisableSendNotification = disableSendNotification;
	}

    /// <summary>
    ///     One of the <see cref="TransferStatuses" />
    /// </summary>
    public TransferStatuses? Status { get; set; }

    /// <summary>
    ///     Unique ID to make your request idempotent and ensure that only one of the transfers with the same spend_id will be
    ///     accepted by Crypto Pay API.
    ///     This parameter is useful when the transfer should be retried (i.e. request timeout, connection reset, 500 HTTP
    ///     status, etc).
    ///     It can be some unique withdrawal identifier for example. Up to 64 symbols.
    /// </summary>
    [JsonRequired]
	public string SpendId { get; set; }

    /// <summary>
    ///     Optional. Pass true if the user should not receive a notification about the transfer.
    ///     Default is false.
    /// </summary>
    public bool? DisableSendNotification { get; set; }

	/// <inheritdoc />
	[JsonRequired]
	public long UserId { get; set; }

	/// <inheritdoc />
	[JsonRequired]
	public string Asset { get; set; }

	/// <inheritdoc />
	[JsonRequired]
	public double Amount { get; set; }

	/// <inheritdoc />
	public string Comment { get; set; }
}