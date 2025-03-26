using System;
 

using Nevermindjq.Payments.CryptoPay.Models;
using Nevermindjq.Payments.CryptoPay.Requests.Abstractions;

namespace Nevermindjq.Payments.CryptoPay.Requests;

/// <summary>
///     Use this request to get application statistics. On success, returns <see cref="AppStats" />.
/// </summary>
public sealed class GetStatsRequest : RequestBase, IGetStats {
    /// <summary>
    ///     Initializes a new request to get <see cref="AppStats">application</see> statistics.
    /// </summary>
    /// <param name="startAt"></param>
    /// <param name="endAt"></param>
    public GetStatsRequest(DateTime? startAt, DateTime? endAt) : base("getStats") {
		var dt = DateTime.UtcNow;
		StartAt = startAt ?? dt.AddHours(-24);
		EndAt = endAt ?? dt;
	}

	[JsonRequired]
	public DateTime StartAt { get; set; }

	[JsonRequired]
	public DateTime EndAt { get; set; }
}