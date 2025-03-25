using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

using Nevermindjq.Payments.CryptoPay.Middlewares;
using Nevermindjq.Payments.CryptoPay.Services;
using Nevermindjq.Payments.CryptoPay.Services.Abstractions;

namespace Nevermindjq.Payments.CryptoPay.Extensions;

public static class HostExtensions {
	// Builder
	public static void AddCryptoPay(this IServiceCollection services, string token, string? api_url = null) {
		services.AddHttpClient<ICryptoPayClient, CryptoPayClient>(http => new CryptoPayClient(token, http, api_url));
		services.AddTransient<ValidationMiddleware>();
	}

	// IApplicationBuilder
	public static void UseCryptoPay(this IApplicationBuilder app) {
		app.UseMiddleware<ValidationMiddleware>();
	}
}