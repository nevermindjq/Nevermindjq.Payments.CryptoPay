using Microsoft.AspNetCore.Mvc;

using Nevermindjq.Payments.CryptoPay.Extensions;

using Telegram.Bot;

namespace Tests.Host.Controllers;

[ApiController, Route("webhooks/crypto-pay")]
public class CryptoPayController(ITelegramBotClient bot) : ControllerBase {
	[HttpPost]
	public async Task<IActionResult> PostAsync() {
		var update = HttpContext.GetUpdate();
		var userId = long.Parse(update.Payload.Payload);

		await bot.SendMessage(userId, "Your payment was successful processed.");

		return Ok();
	}
}