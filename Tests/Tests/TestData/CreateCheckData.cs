using System.Net;

using Nevermindjq.Payments.CryptoPay.Models;
using Nevermindjq.Payments.CryptoPay.Requests.Checks;

using Xunit;

namespace Tests.TestData;

/// <summary>
///     For this test, you must have test coins.
/// </summary>
public sealed class CreateCheckData : TheoryData<HttpStatusCode, Error?, CreateCheckRequest> {
	public CreateCheckData() {
		Add(default, default, new CreateCheckRequest("BNB", 0.0123, default, default));

		Add(default, default, new CreateCheckRequest("BNB", 0.0121, CryptoPayTestHelper.UserId, default));

		Add(default, default, new CreateCheckRequest("BNB", 0.0122, default, "@userName"));

		Add(HttpStatusCode.BadRequest, new Error(400, "NOT_ENOUGH_COINS"), new CreateCheckRequest("TON", 100.2345, default, default));

		Add(HttpStatusCode.BadRequest, new Error(400, "ASSET_INVALID"), new CreateCheckRequest("FFF", 0.0123, default, default));
	}
}