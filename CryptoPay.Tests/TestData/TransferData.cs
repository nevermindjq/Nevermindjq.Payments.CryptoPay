using System;
using System.Net;
using CryptoPay.Requests;
using CryptoPay.Types;
using Xunit;

namespace CryptoPay.Tests.TestData;

/// <summary>
///     For this test, you must have test coins.
/// </summary>
public class TransferData : TheoryData<HttpStatusCode, Error?, TransferRequest>
{
    public TransferData()
    {
        this.Add(
            default,
            default,
            new TransferRequest(
                CryptoPayTestHelper.UserId,
                Assets.TON,
                0.1,
                Guid.NewGuid().ToString(),
                "comment"
                // The CryptoPay service handles this flag incorrectly.
                // Will be fixed later.
                /*disableSendNotification: true*/)
        );

        this.Add(
            HttpStatusCode.BadRequest,
            new Error(400, "AMOUNT_TOO_BIG"),
            new TransferRequest(
                CryptoPayTestHelper.UserId,
                Assets.BTC,
                1000,
                Guid.NewGuid().ToString())
        );
    }
}