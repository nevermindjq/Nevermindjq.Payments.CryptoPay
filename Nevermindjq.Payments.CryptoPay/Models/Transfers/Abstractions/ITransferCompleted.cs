using System;

using Nevermindjq.Payments.CryptoPay.Models.Transfers.Enums;

namespace Nevermindjq.Payments.CryptoPay.Models.Transfers.Abstractions;

public interface ITransferCompleted : ITransfer {
	/// <summary>
	///     Unique ID for this transfer.
	/// </summary>
	public long TransferId { get; set; }

	/// <summary>
	///     Optional. Unique UTF-8 string.
	/// </summary>
	public string SpendId { get; set; }

	/// <summary>
	///     Status of the transfer, can be “completed”.
	/// </summary>
	public TransferStatuses Status { get; set; }

	/// <summary>
	///     Date the transfer was completed in ISO 8601 format.
	/// </summary>
	public DateTime CompletedAt { get; set; }
}