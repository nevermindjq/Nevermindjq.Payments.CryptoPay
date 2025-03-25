using System;
using System.Net;

using Nevermindjq.Payments.CryptoPay.Models;
using Nevermindjq.Payments.CryptoPay.Requests;

using Xunit;

namespace Tests.TestData;

/// <summary>
///     For this test, you must have test coins.
/// </summary>
public class TransferData : TheoryData<HttpStatusCode, Error?, TransferRequest> {
	public TransferData() {
		Add(default, default, new TransferRequest(CryptoPayTestHelper.UserId, "TON", 0.5, Guid.NewGuid().ToString(), disableSendNotification: true));

		Add(default, default, new TransferRequest(CryptoPayTestHelper.UserId, "TON", 0.5, Guid.NewGuid().ToString(), Guid.NewGuid().ToString(), false));

		Add(default, default, new TransferRequest(CryptoPayTestHelper.UserId, "BNB", 0.0123, Guid.NewGuid().ToString(), disableSendNotification: false));

		Add(HttpStatusCode.BadRequest, new Error(400, "AMOUNT_TOO_BIG"), new TransferRequest(CryptoPayTestHelper.UserId, "BTC", 1000, Guid.NewGuid().ToString()));
		Add(HttpStatusCode.InternalServerError, new Error(500, "APP_ERROR"), new TransferRequest(CryptoPayTestHelper.UserId, "Unknown", 10, Guid.NewGuid().ToString()));
	}
}