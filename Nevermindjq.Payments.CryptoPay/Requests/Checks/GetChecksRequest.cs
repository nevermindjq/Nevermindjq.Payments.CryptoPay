using System.Collections.Generic;

using Nevermindjq.Payments.CryptoPay.Models.Checks;
using Nevermindjq.Payments.CryptoPay.Models.Checks.Enums;
using Nevermindjq.Payments.CryptoPay.Models.Invoices.Enums;
using Nevermindjq.Payments.CryptoPay.Requests.Abstractions;
using Nevermindjq.Payments.CryptoPay.Requests.Checks.Abstractions;

#pragma warning disable CS8618
#pragma warning disable CS8601

namespace Nevermindjq.Payments.CryptoPay.Requests.Checks;

/// <summary>
///     Use this request to get checks created by your app. On success, returns array of <see cref="Check" />.
/// </summary>
public sealed class GetChecksRequest(IEnumerable<string>? assets = null, IEnumerable<long>? checkIds = null, IEnumerable<Statuses>? statuses = null, int offset = 0, int count = 100) : RequestBase("getChecks"), IGetChecks {
	public IEnumerable<string> Assets { get; } = assets;
	public IEnumerable<long> CheckIds { get; } = checkIds;
	public IEnumerable<Statuses> Statuses { get; } = statuses;
	public int Offset { get; } = offset;
	public int Count { get; } = count;
}