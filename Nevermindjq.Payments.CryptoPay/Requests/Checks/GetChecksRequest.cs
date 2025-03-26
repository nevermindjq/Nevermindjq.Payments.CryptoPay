using System.Collections.Generic;

using Nevermindjq.Payments.CryptoPay.Models.Checks;
using Nevermindjq.Payments.CryptoPay.Models.Checks.Enums;
using Nevermindjq.Payments.CryptoPay.Models.Invoices.Enums;
using Nevermindjq.Payments.CryptoPay.Requests.Abstractions;

#pragma warning disable CS8618
#pragma warning disable CS8601

namespace Nevermindjq.Payments.CryptoPay.Requests.Checks;

/// <summary>
///     Use this request to get checks created by your app. On success, returns array of <see cref="Check" />.
/// </summary>
public sealed class GetChecksRequest : ParameterlessRequest {
	#region Constructors

    /// <summary>
    ///     Initializes a new request to get list of <see cref="Check" />
    /// </summary>
    /// <param name="assets">Optional. Cryptocurrency alphabetic code. Defaults to all currencies.</param>
    /// <param name="checkIds">Optional. List of check IDs.</param>
    /// <param name="statuses">
    ///     Optional. Status of check to be returned. Available statuses: <see cref="CheckStatus" />.
    ///     Defaults to all statuses.
    /// </param>
    /// <param name="offset">Optional. Offset needed to return a specific subset of check. Defaults to 0.</param>
    /// <param name="count">Optional. Number of check to be returned. Values between 1-1000 are accepted. Defaults to 100.</param>
    public GetChecksRequest(IEnumerable<string>? assets = null, IEnumerable<long>? checkIds = null, IEnumerable<Statuses>? statuses = null, int offset = 0, int count = 100) : base("getChecks") {
		Assets = assets;
		CheckIds = checkIds;
		Statuses = statuses;
		Offset = offset;
		Count = count;
	}

	#endregion

    /// <summary>
    ///     Optional. Cryptocurrency alphabetic code. Defaults to all currencies.
    /// </summary>
    public IEnumerable<string> Assets { get; private set; }

    /// <summary>
    ///     Optional. List of check IDs.
    /// </summary>
    public IEnumerable<long> CheckIds { get; private set; }

    /// <summary>
    ///     Optional. Offset needed to return a specific subset of check. Defaults to 0.
    /// </summary>
    public IEnumerable<Statuses> Statuses { get; private set; }

    /// <summary>
    ///     Optional. Offset needed to return a specific subset of check. Defaults to 0.
    /// </summary>
    public int Offset { get; private set; }

    /// <summary>
    ///     Optional. Number of check to be returned. Values between 1-1000 are accepted. Defaults to 100.
    /// </summary>
    public int Count { get; private set; }
}