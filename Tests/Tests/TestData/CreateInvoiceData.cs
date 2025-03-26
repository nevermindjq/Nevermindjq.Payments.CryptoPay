using System.Net;

using Nevermindjq.Payments.CryptoPay.Models;
using Nevermindjq.Payments.CryptoPay.Models.Invoices.Enums;
using Nevermindjq.Payments.CryptoPay.Requests.Invoices;

using Xunit;

namespace Tests.TestData;

public class CreateInvoiceData : TheoryData<HttpStatusCode, Error?, CreateInvoiceRequest> {
	public CreateInvoiceData() {
		Add(default, default, new CreateInvoiceRequest(5.105, asset: "TON"));
		Add(default, default, new CreateInvoiceRequest(1.105, CurrencyTypes.fiat, fiat: "USD"));
		Add(default, default, new CreateInvoiceRequest(5.105, asset: "TON", description: "description", hiddenMessage: "hiddenMessage", paidBtnName: PaidButtonNames.callback, paidBtnUrl: "https://t.me/paidBtnUrl", payload: "payload", allowComments: false, allowAnonymous: false, expiresIn: 1800));
		Add(default, default, new CreateInvoiceRequest(2.35, CurrencyTypes.fiat, default, "EUR", default, "description", "hiddenMessage", PaidButtonNames.callback, "https://t.me/paidBtnUrl", "payload", true, false, 360));

		Add(default, default, new CreateInvoiceRequest(0.0234, CurrencyTypes.crypto, "BNB", default, default, "description", "hiddenMessage", PaidButtonNames.callback, "https://t.me/paidBtnUrl", "payload", true, false, 360));

		Add(default, default, new CreateInvoiceRequest(1.23, CurrencyTypes.fiat, default, "EUR", new[] { "TON", "USDT" }, "description", "hiddenMessage"));

		Add(HttpStatusCode.BadRequest, new Error(400, "PAID_BTN_URL_REQUIRED"), new CreateInvoiceRequest(0.105, asset: "TON", paidBtnName: PaidButtonNames.callback));
		Add(HttpStatusCode.BadRequest, new Error(400, "UNSUPPORTED_ASSET"), new CreateInvoiceRequest(0.123, asset: "FFF", paidBtnName: PaidButtonNames.callback));
	}
}