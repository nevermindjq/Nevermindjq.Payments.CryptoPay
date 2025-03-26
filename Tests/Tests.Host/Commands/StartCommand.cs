using Nevermindjq.Payments.CryptoPay.Extensions;
using Nevermindjq.Payments.CryptoPay.Models.Invoices.Enums;
using Nevermindjq.Payments.CryptoPay.Services.Abstractions;
using Nevermindjq.Telegram.Bot.Attributes;
using Nevermindjq.Telegram.Bot.Commands.Filtered;

using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;


namespace Tests.Host.Commands;

[Path("/start"), Lifetime(ServiceLifetime.Scoped)]
public class StartCommand(ITelegramBotClient bot, ICryptoPayClient client) : MessageCommand {
	public override async Task ExecuteAsync(Update update) {
		var invoice = await client.CreateInvoiceAsync(
			0.1,
			CurrencyTypes.crypto,
			"TON",
			acceptedAssets: [
				"TON",
				"USDT",
				"TRX"
			],
			paidBtnName: PaidButtonNames.openBot,
			paidBtnUrl: "https://t.me/tests_nmjq_robot",
			payload: update.Message.From.Id.ToString()
		);

		await bot.SendMessage(
			update.Message.From.Id,
			"Test",
			replyMarkup: new InlineKeyboardMarkup([
				[
					InlineKeyboardButton.WithUrl("URL", invoice.BotInvoiceUrl),
					InlineKeyboardButton.WithUrl("WebApp", invoice.WebAppInvoiceUrl),
					InlineKeyboardButton.WithUrl("MiniApp", invoice.MiniAppInvoiceUrl)
				]
			])
		);
	}
}