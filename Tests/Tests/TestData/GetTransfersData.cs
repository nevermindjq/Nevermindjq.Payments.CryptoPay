using System;
using System.Net;

using Nevermindjq.Payments.CryptoPay.Models;
using Nevermindjq.Payments.CryptoPay.Requests.Transfers;

using Xunit;

namespace Tests.TestData;

/// <summary>
///     For this test, you must have test coins.
/// </summary>
public sealed class GetTransfersData : TheoryData<HttpStatusCode, Error?, TransferRequest> {
	public GetTransfersData() => Add(default, default, new TransferRequest(CryptoPayTestHelper.UserId, "BNB", 0.0123, Guid.NewGuid().ToString(), disableSendNotification: true));
}