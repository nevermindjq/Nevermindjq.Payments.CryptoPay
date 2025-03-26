using System.Collections.Generic;

using Nevermindjq.Payments.CryptoPay.Models.Transfers;
using Nevermindjq.Payments.CryptoPay.Requests.Abstractions;
using Nevermindjq.Payments.CryptoPay.Requests.Transfers.Abstractions;

#pragma warning disable CS8618
#pragma warning disable CS8601

namespace Nevermindjq.Payments.CryptoPay.Requests.Transfers;

/// <summary>
///     Use this class to get list of <see cref="Transfer" /> request.
/// </summary>
public sealed class GetTransfersRequest(IEnumerable<string>? asset = null, IEnumerable<string>? transferIds = null, string? spendId = null, int offset = 0, int count = 100) : RequestBase("getTransfers"), IGetTransfers {
	public IEnumerable<string> Asset { get; set; } = asset;

	public IEnumerable<string> TransferIds { get; set; } = transferIds;

	public string SpendId { get; set; } = spendId;

	public int Offset { get; set; } = offset;

	public int Count { get; set; } = count;
}