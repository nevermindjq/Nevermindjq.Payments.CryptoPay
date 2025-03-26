﻿using System.Collections.Generic;

using Nevermindjq.Payments.CryptoPay.Models.Transfers;
using Nevermindjq.Payments.CryptoPay.Requests.Abstractions;

#pragma warning disable CS8618
#pragma warning disable CS8601

namespace Nevermindjq.Payments.CryptoPay.Requests.Transfers;

/// <summary>
///     Use this class to get list of <see cref="Transfer" /> request.
/// </summary>
public sealed class GetTransfersRequest : ParameterlessRequest {
	#region Constructors

    /// <summary>
    ///     Initializes a new request to get list of <see cref="Transfer" />
    /// </summary>
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
    public GetTransfersRequest(IEnumerable<string>? asset = null, IEnumerable<string>? transferIds = null, string? spendId = null, int offset = 0, int count = 100) : base("getTransfers") {
		Asset = asset;
		TransferIds = transferIds;
		SpendId = spendId;
		Offset = offset;
		Count = count;
	}

	#endregion

	#region Public Fields

    /// <summary>
    ///     Optional. Cryptocurrency alphabetic code. Defaults to all currencies.
    /// </summary>
    public IEnumerable<string> Asset { get; private set; }

    /// <summary>
    ///     Optional. List of transfer IDs.
    /// </summary>
    public IEnumerable<string> TransferIds { get; private set; }

    /// <summary>
    ///     Optional. Unique UTF-8 transfer string.
    /// </summary>
    public string SpendId { get; set; }

    /// <summary>
    ///     Optional. Offset needed to return a specific subset of transfers. Defaults to 0.
    /// </summary>
    public int Offset { get; private set; }

    /// <summary>
    ///     Optional. Number of transfers to be returned. Values between 1-1000 are accepted. Defaults to 100.
    /// </summary>
    public int Count { get; private set; }

	#endregion
}