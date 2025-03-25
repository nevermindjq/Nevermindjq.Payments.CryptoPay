using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

using Nevermindjq.Payments.CryptoPay.Helpers;
using Nevermindjq.Payments.CryptoPay.Models;
using Nevermindjq.Payments.CryptoPay.Models.Enums;

namespace Nevermindjq.Payments.CryptoPay.Middlewares;

public class ValidationMiddleware(IConfiguration config) : IMiddleware {
	public async Task InvokeAsync(HttpContext context, RequestDelegate next) {
		if (context.Request.Path is not { HasValue: true, Value: var path } || !path.Contains("crypto-pay")) {
			return;
		}

		var bytes = new byte[context.Request.ContentLength!.Value];
		await context.Request.Body.ReadExactlyAsync(bytes);

		var update = JsonHelper.Deserialize<Update>(bytes);

		context.Items.Add(typeof(Update), update);

		if (update is { UpdateType: UpdateTypes.invoice_paid } && CryptoPayHelper.CheckSignature(context.Request.Headers, config["Payments:CryptoPay:Token"]!, bytes)) {
			await next.Invoke(context);
		}
		else {
			context.Response.StatusCode = StatusCodes.Status400BadRequest;
		}
	}
}