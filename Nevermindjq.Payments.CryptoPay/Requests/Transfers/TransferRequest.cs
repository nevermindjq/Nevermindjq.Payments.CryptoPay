using Nevermindjq.Payments.CryptoPay.Models.Transfers;
using Nevermindjq.Payments.CryptoPay.Models.Transfers.Abstractions;
using Nevermindjq.Payments.CryptoPay.Models.Transfers.Enums;
using Nevermindjq.Payments.CryptoPay.Requests.Abstractions;

#pragma warning disable CS8618
#pragma warning disable CS8601

namespace Nevermindjq.Payments.CryptoPay.Requests.Transfers;

/// <summary>
///     Use this class to get <see cref="Transfer" /> request.
/// </summary>
public sealed class TransferRequest(long userId, string asset, double amount, string spendId, string? comment = null, bool? disableSendNotification = null) : RequestBase("transfer"), ITransfer {

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
	public string SpendId { get; set; } = spendId;

	/// <summary>
	///     Optional. Pass true if the user should not receive a notification about the transfer.
	///     Default is false.
	/// </summary>
	public bool? DisableSendNotification { get; set; } = disableSendNotification;

	[JsonRequired]
	public long UserId { get; set; } = userId;

	[JsonRequired]
	public string Asset { get; set; } = asset;

	[JsonRequired]
	public double Amount { get; set; } = amount;

	public string Comment { get; set; } = comment;
}