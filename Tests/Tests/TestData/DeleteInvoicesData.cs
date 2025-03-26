using System.Net;

using Nevermindjq.Payments.CryptoPay.Models;
using Nevermindjq.Payments.CryptoPay.Models.Invoices.Enums;
using Nevermindjq.Payments.CryptoPay.Requests.Invoices;

using Xunit;

namespace Tests.TestData;

public sealed class DeleteInvoicesData : TheoryData<HttpStatusCode, Error?, CreateInvoiceRequest> {
	public DeleteInvoicesData() {
		Add(default, default, new CreateInvoiceRequest(5.105, asset: "TON", description: "description", hiddenMessage: "hiddenMessage", paidBtnName: PaidButtonNames.callback, paidBtnUrl: "https://t.me/paidBtnUrl", payload: "payload", allowComments: false, allowAnonymous: false, expiresIn: 1800));

		Add(default, default, new CreateInvoiceRequest(2.35, CurrencyTypes.fiat, default, "EUR", default, "description", "hiddenMessage", PaidButtonNames.callback, "https://t.me/paidBtnUrl", "payload", true, false, 360));
	}
}