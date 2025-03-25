using Microsoft.AspNetCore.Http;

using Nevermindjq.Payments.CryptoPay.Models;

namespace Nevermindjq.Payments.CryptoPay.Extensions;

public static class HttpContextExtensions {
	public static Update GetUpdate(this HttpContext httpContext) {
		return (Update)httpContext.Items[nameof(Update)];
	}
}