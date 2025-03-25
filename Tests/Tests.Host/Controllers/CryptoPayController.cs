using Microsoft.AspNetCore.Mvc;

using Nevermindjq.Payments.CryptoPay.Extensions;

namespace Tests.Host.Controllers;

[ApiController, Route("webhooks/crypto-pay")]
public class CryptoPayController : ControllerBase {
	[HttpPost]
	public async Task<IActionResult> PostAsync() {
		var update = HttpContext.GetUpdate();

		// Process update here

		return Ok();
	}
}