using System.Collections.Generic;

namespace Nevermindjq.Payments.CryptoPay.Requests.Transfers.Abstractions;

public interface IGetTransfers {
	/// <summary>
	///     Optional. Cryptocurrency alphabetic code. Defaults to all currencies.
	/// </summary>
	public IEnumerable<string> Asset { get; }

	/// <summary>
	///     Optional. List of transfer IDs.
	/// </summary>
	public IEnumerable<string> TransferIds { get; }

	/// <summary>
	///     Optional. Unique UTF-8 transfer string.
	/// </summary>
	public string SpendId { get; }

	/// <summary>
	///     Optional. Offset needed to return a specific subset of transfers. Defaults to 0.
	/// </summary>
	public int Offset { get; }

	/// <summary>
	///     Optional. Number of transfers to be returned. Values between 1-1000 are accepted. Defaults to 100.
	/// </summary>
	public int Count { get; }
}