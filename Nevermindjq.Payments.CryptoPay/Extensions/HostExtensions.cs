using Microsoft.Extensions.DependencyInjection;

using Nevermindjq.Payments.CryptoPay.Services;
using Nevermindjq.Payments.CryptoPay.Services.Abstractions;

namespace Nevermindjq.Payments.CryptoPay.Extensions;

public static class HostExtensions {
	public static void AddCryptoPay(this IServiceCollection services, string token, string? api_url = null) {
		services.AddHttpClient<ICryptoPayClient, CryptoPayClient>(http => new CryptoPayClient(token, http, api_url));
	}
}