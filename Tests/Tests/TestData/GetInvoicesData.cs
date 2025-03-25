using System.Collections.Generic;
using System.Net;

using Nevermindjq.Payments.CryptoPay.Models;
using Nevermindjq.Payments.CryptoPay.Models.Enums;

using Xunit;

namespace Tests.TestData;

public class GetInvoicesData : TheoryData<HttpStatusCode, Error?, IList<string>?, // assets
	IList<long>?,                                                                 // invoiceIds
	Statuses?,                                                                    //status
	int,                                                                          // offset 
	int>                                                                          // count
{
	public GetInvoicesData() {
		Add(default, default, default, default, default, 0, 100);
		Add(default, default, default, default, default, 10, 100);
		Add(default, default, default, default, Statuses.paid, 0, 10);
		Add(default, default, new List<string>(), default, Statuses.active, 5, 15);

		Add(default, default, new List<string> {
			"TON",
			"BNB"
		}, default, Statuses.active, 0, 10);

		Add(default, default, default, new List<long> {
			00000,
			11111
		}, default, 0, 100);

		Add(HttpStatusCode.InternalServerError, new Error(500, "APP_ERROR"), default, default, default, -10, 100);
		Add(HttpStatusCode.InternalServerError, new Error(500, "APP_ERROR"), default, default, default, 5, -30);
	}
}