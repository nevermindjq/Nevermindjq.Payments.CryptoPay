using System;
using System.Net;

using Nevermindjq.Payments.CryptoPay.Models;
using Nevermindjq.Payments.CryptoPay.Requests;

using Xunit;

namespace Tests.TestData;

public class GetStatsData : TheoryData<HttpStatusCode, Error?, GetStatsRequest> {
	public GetStatsData() {
		Add(default, default, new GetStatsRequest(default, default));

		Add(HttpStatusCode.BadRequest, new Error(400, "INTERVAL_TOO_BIG"), new GetStatsRequest(DateTime.UtcNow.AddYears(-3), DateTime.UtcNow.AddMonths(-3)));

		Add(default, default, new GetStatsRequest(DateTime.UtcNow.AddYears(-2), DateTime.UtcNow.AddYears(-1)));
	}
}