﻿using System.Text.Json.Serialization;

using Nevermindjq.Payments.CryptoPay.Models;
using Nevermindjq.Payments.CryptoPay.Requests.Abstractions;

namespace Nevermindjq.Payments.CryptoPay.Requests;

/// <summary>
///     Use this method to create a new check. On success, returns an object of the created <see cref="Check" />.
/// </summary>
public sealed class CreateCheckRequest : ParameterlessRequest<Check> {
	#region Constructors

    /// <summary>
    ///     Initializes a new request to create <see cref="Check" />
    /// </summary>
    /// <param name="asset">
    ///     Cryptocurrency alphabetic code.
    ///     <remarks>
    ///         Due to the fact that the list of available currencies in the CryptoPay service is constantly changing,
    ///         utilizing assets becomes ineffective. However, you can resort to using Assets.BTC.ToString() instead.
    ///     </remarks>
    /// </param>
    /// <param name="amount">Amount of the invoice in float. For example: 125.50</param>
    /// <param name="pinToUserId">Optional. ID of the user who will be able to activate the check.</param>
    /// <param name="pinToUsername">Optional. A user with the specified username will be able to activate the check.</param>
    public CreateCheckRequest(string asset, double amount, long? pinToUserId, string pinToUsername) : base("createCheck") {
		Asset = asset;
		Amount = amount;
		PinToUserId = pinToUserId;
		PinToUsername = pinToUsername;
	}

	#endregion

	#region Public Fields

    /// <summary>
    ///     Cryptocurrency alphabetic code.
    /// </summary>
    [JsonRequired]
	public string Asset { get; set; }

    /// <summary>
    ///     Amount of the invoice in float. For example: 125.50
    /// </summary>
    [JsonRequired]
	public double Amount { get; set; }

    /// <summary>
    ///     Optional. A user with the specified username will be able to activate the check.
    /// </summary>
    public long? PinToUserId { get; set; }

    /// <summary>
    ///     Optional. A user with the specified username will be able to activate the check.
    /// </summary>
    public string PinToUsername { get; set; }

	#endregion
}