using System;

using Nevermindjq.Payments.CryptoPay.Models.Transfers.Abstractions;
using Nevermindjq.Payments.CryptoPay.Models.Transfers.Enums;

#pragma warning disable CS8618

namespace Nevermindjq.Payments.CryptoPay.Models.Transfers;

public sealed class Transfer : ITransferCompleted {
	[JsonRequired]
	public long UserId { get; set; }

	[JsonRequired]
	public string Asset { get; set; }

	[JsonRequired]
	public double Amount { get; set; }

	public string Comment { get; set; }

	[JsonRequired]
	public long TransferId { get; set; }

	public string SpendId { get; set; }

	[JsonRequired]
	public TransferStatuses Status { get; set; }

	[JsonRequired]
	public DateTime CompletedAt { get; set; }
}