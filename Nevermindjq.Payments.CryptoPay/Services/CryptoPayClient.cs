﻿using System;
using System.IO;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

using Nevermindjq.Payments.CryptoPay.Extensions;
using Nevermindjq.Payments.CryptoPay.Requests.Abstractions;
using Nevermindjq.Payments.CryptoPay.Responses;
using Nevermindjq.Payments.CryptoPay.Services.Abstractions;

namespace Nevermindjq.Payments.CryptoPay.Services;

/// <inheritdoc />
public sealed class CryptoPayClient : ICryptoPayClient {
	private readonly HttpClient _http;
	private static string _api_url { get; } = "https://pay.crypt.bot/";

	/// <summary>
	///     Create <see cref="ICryptoPayClient" /> instance.
	/// </summary>
	/// <param name="token">Your application token from CryptoPay.</param>
	/// <param name="httpClient">Optional. <see cref="HttpClient" />.</param>
	/// <param name="apiUrl">
	///     Optional. Default value is <see cref="_api_url" /> main api url.
	///     Test api url is <code>https://testnet-pay.crypt.bot/</code>.
	/// </param>
	/// <exception cref="ArgumentNullException">If token is null.</exception>
	[Obsolete("Add this client using dependency injection. builder.Services.AddHttpClient<ICryptoPayClient, CryptoPayClient>(...) e.g.")]
	public CryptoPayClient(string token, HttpClient? httpClient = null, string? apiUrl = null) {
		_http = httpClient ?? new HttpClient();
		_http.BaseAddress = new Uri(apiUrl ?? _api_url);
		_http.DefaultRequestHeaders.Add("Crypto-Pay-API-Token", string.IsNullOrEmpty(token) ? throw new ArgumentNullException(nameof(token)) : token);
	}

	/// <summary>
	///     Create <see cref="ICryptoPayClient" /> instance.
	/// </summary>
	/// <param name="http">
	///     <see cref="HttpClient" />
	/// </param>
	public CryptoPayClient(HttpClient http) => _http = http;

	/// <inheritdoc />
	public async Task<TResponse> MakeRequestAsync<TResponse>(IRequest<TResponse> api_request, CancellationToken cancellationToken = default) {
		// Request
		using var request = new HttpRequestMessage(api_request.Method, Path.Combine(_http.BaseAddress.AbsolutePath, "api", api_request.MethodName)) {
			Content = api_request.ToHttpContent()
		};

		// Response
		using var response = await SendRequestAsync(request, cancellationToken).ConfigureAwait(false);

		// Process
		if (!response.IsSuccessStatusCode && await response.DeserializeContentAsync<ApiResponseWithError>(cancellationToken).ConfigureAwait(false) is { Ok: false } error) {
			throw new HttpRequestException($"{error.Error.Name} {error.Error.Code}");
		}

		if (await response.DeserializeContentAsync<ApiResponse<TResponse>>(cancellationToken).ConfigureAwait(false) is { Ok: true } content) {
			return content.Result;
		}

		throw new HttpRequestException($"Can't parse content of {nameof(ApiResponse<TResponse>)}");
	}

	private async Task<HttpResponseMessage> SendRequestAsync(HttpRequestMessage httpRequest, CancellationToken cancellationToken) {
		try {
			return await _http.SendAsync(httpRequest, cancellationToken).ConfigureAwait(false);
		}
		catch (TaskCanceledException exception) {
			if (cancellationToken.IsCancellationRequested) {
				throw;
			}

			throw new Exception("Request timed out", exception);
		}
		catch (Exception exception) {
			throw new Exception("Exception during making request", exception);
		}
	}
}