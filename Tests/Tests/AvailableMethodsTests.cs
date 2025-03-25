using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

using Nevermindjq.Payments.CryptoPay;
using Nevermindjq.Payments.CryptoPay.Exceptions;
using Nevermindjq.Payments.CryptoPay.Extensions;
using Nevermindjq.Payments.CryptoPay.Models;
using Nevermindjq.Payments.CryptoPay.Models.Enums;
using Nevermindjq.Payments.CryptoPay.Requests;
using Nevermindjq.Payments.CryptoPay.Services;
using Nevermindjq.Payments.CryptoPay.Services.Abstractions;

using Tests.TestData;

using Xunit;

#pragma warning disable CS0618 // Type or member is obsolete
namespace Tests;

public class AvailableMethodsTests {
	#region Private Methods

	private static void AssertException(RequestException requestException, HttpStatusCode statusCode, Error error) {
		Assert.NotNull(requestException);
		Assert.Equal(statusCode, requestException.HttpStatusCode);

		var errorException = requestException.Error;
		Assert.NotNull(errorException);
		Assert.Equal(error.Code, errorException.Code);
		Assert.Equal(error.Name, errorException.Name);
	}

	#endregion

	#region Public Fields

	private readonly CancellationToken cancellationToken = new CancellationTokenSource().Token;

	private readonly ICryptoPayClient cryptoPayClient = new CryptoPayClient(new HttpClient {
		BaseAddress = new Uri(CryptoPayTestHelper.ApiUrl),
		DefaultRequestHeaders = { { "Crypto-Pay-API-Token", CryptoPayTestHelper.Token } }
	});

	#endregion

    /// Enter your own actual values in
    /// <see cref="CryptoPayTestHelper.Token" />
    /// <see cref="CryptoPayTestHelper.ApiUrl" />
    /// <see cref="CryptoPayTestHelper.UserId" />
    /// For test
    /// <see cref="TransferTest" />
    /// , you must have test TON coins in you application wallet.

    #region Tests

	[Theory, ClassData(typeof(CryptoPayClientData))]
	public async Task AuthorizationAndGetMeTest(HttpStatusCode statusCode, Error error, string token, string apiUrl) {
		try {
			var localCryptoPayClient = new CryptoPayClient(token, apiUrl: apiUrl);
			var application = await localCryptoPayClient.GetMeAsync(cancellationToken);

			Assert.NotNull(application);
			Assert.NotEmpty(application.Name);
			Assert.NotEmpty(application.PaymentProcessingBotUsername);
		}
		catch (ArgumentNullException argumentNullException) {
			Assert.NotNull(argumentNullException);
		}
		catch (RequestException requestException) {
			AssertException(requestException, statusCode, error);
		}
	}

	[Theory, ClassData(typeof(CreateInvoiceData))]
	public async Task CreateInvoiceTest(HttpStatusCode statusCode, Error error, CreateInvoiceRequest invoiceRequest) {
		try {
			var invoice = await cryptoPayClient.CreateInvoiceAsync(invoiceRequest.Amount, invoiceRequest.CurrencyType, invoiceRequest.Asset, invoiceRequest.Fiat, invoiceRequest.AcceptedAssets, invoiceRequest.Description, invoiceRequest.HiddenMessage, invoiceRequest.PaidBtnName, invoiceRequest.PaidBtnUrl, invoiceRequest.Payload, invoiceRequest.AllowComments!.Value, invoiceRequest.AllowAnonymous!.Value, invoiceRequest.ExpiresIn, cancellationToken);

			Assert.NotNull(invoice);
			Assert.NotNull(invoice.PayUrl);
			Assert.NotNull(invoice.Hash);
			Assert.NotNull(invoice.MiniAppInvoiceUrl);
			Assert.NotNull(invoice.WebAppInvoiceUrl);
			Assert.Equal(invoiceRequest.Amount, invoice.Amount);
			Assert.Equal(invoiceRequest.CurrencyType, invoice.CurrencyType);
			Assert.Equal(invoiceRequest.Asset, invoice.Asset);
			Assert.Equal(invoiceRequest.Fiat, invoice.Fiat);
			Assert.Equal(invoiceRequest.Description, invoice.Description);
			Assert.Equal(invoiceRequest.HiddenMessage, invoice.HiddenMessage);
			Assert.Equal(invoiceRequest.PaidBtnName, invoice.PaidBtnName);
			Assert.Equal(invoiceRequest.PaidBtnUrl, invoice.PaidBtnUrl);
			Assert.Equal(invoiceRequest.Payload, invoice.Payload);
			Assert.Equal(invoiceRequest.AllowComments!.Value, invoice.AllowComments);
			Assert.Equal(invoiceRequest.AllowAnonymous!.Value, invoice.AllowAnonymous);
			Assert.Equal(invoice.CreatedAt.AddSeconds(invoiceRequest.ExpiresIn).ToString("g"), invoice.ExpirationDate?.ToString("g"));

			if (invoiceRequest.CurrencyType == CurrencyTypes.fiat) {
				if (invoiceRequest.AcceptedAssets is null) {
					Assert.NotEmpty(invoice.AcceptedAssets);
				}
				else {
					Assert.Equal(invoiceRequest.AcceptedAssets, invoice.AcceptedAssets);
				}
			}
		}
		catch (RequestException requestException) {
			AssertException(requestException, statusCode, error);
		}
	}

	[Fact]
	public async Task GetBalanceTest() {
		var balance = await cryptoPayClient.GetBalanceAsync(cancellationToken);

		Assert.NotNull(balance);
		Assert.True(balance.Any());
	}

	[Fact]
	public async Task GetExchangeRatesTest() {
		var exchangeRates = await cryptoPayClient.GetExchangeRatesAsync(cancellationToken);

		Assert.NotNull(exchangeRates);
		Assert.True(exchangeRates.Any());
	}

	[Fact]
	public async Task GetCurrenciesTest() {
		var currencies = await cryptoPayClient.GetCurrenciesAsync(cancellationToken);

		Assert.NotNull(currencies);
		Assert.True(currencies.Any());
	}

    /// <summary>
    ///     For this test, you must have test coins.
    /// </summary>
    [Theory, ClassData(typeof(TransferData))]
	public async Task TransferTest(HttpStatusCode statusCode, Error error, TransferRequest transferRequest) {
		try {
			var transfer = await cryptoPayClient.TransferAsync(transferRequest.UserId, transferRequest.Asset, transferRequest.Amount, transferRequest.SpendId, transferRequest.Comment, transferRequest.DisableSendNotification, cancellationToken);

			Assert.NotNull(transfer);
			Assert.Equal(transferRequest.UserId, transfer.UserId);
			Assert.Equal(transferRequest.Asset, transfer.Asset);
			Assert.Equal(transferRequest.Amount, transfer.Amount);
			//Assert.Equal(transferRequest.Comment, transfer.Comment);
			Assert.Equal(transferRequest.DisableSendNotification, transferRequest.DisableSendNotification);
		}
		catch (RequestException requestException) {
			AssertException(requestException, statusCode, error);
		}
	}

    /// <summary>
    ///     For this test, you must have test coins.
    /// </summary>
    [Theory, ClassData(typeof(GetTransfersData))]
	public async Task GetTransfersTest(HttpStatusCode statusCode, Error error, TransferRequest transferRequest) {
		try {
			var transfer = await cryptoPayClient.TransferAsync(transferRequest.UserId, transferRequest.Asset, transferRequest.Amount, transferRequest.SpendId, transferRequest.Comment, transferRequest.DisableSendNotification, cancellationToken);

			var transfers = await cryptoPayClient.GetTransfersAsync(cancellationToken: cancellationToken);

			Assert.NotNull(transfer);

			Assert.NotNull(transfers);
			Assert.True(transfers.Items.Any());
		}
		catch (RequestException requestException) {
			AssertException(requestException, statusCode, error);
		}
	}

	[Theory, ClassData(typeof(GetInvoicesData))]
	public async Task GetInvoicesTest(HttpStatusCode statusCode, Error error, IList<string> assets, IList<long> invoiceIds, Statuses? status, int offset, int count) {
		try {
			var invoices = await cryptoPayClient.GetInvoicesAsync(assets, invoiceIds, status, offset, count, cancellationToken);

			Assert.NotNull(invoices);
		}
		catch (RequestException requestException) {
			AssertException(requestException, statusCode, error);
		}
	}

	[Theory, ClassData(typeof(DeleteInvoicesData))]
	public async Task DeleteInvoiceTest(HttpStatusCode statusCode, Error error, CreateInvoiceRequest invoiceRequest) {
		try {
			var invoice = await cryptoPayClient.CreateInvoiceAsync(invoiceRequest.Amount, invoiceRequest.CurrencyType, invoiceRequest.Asset, invoiceRequest.Fiat, invoiceRequest.AcceptedAssets, invoiceRequest.Description, invoiceRequest.HiddenMessage, invoiceRequest.PaidBtnName, invoiceRequest.PaidBtnUrl, invoiceRequest.Payload, invoiceRequest.AllowComments!.Value, invoiceRequest.AllowAnonymous!.Value, invoiceRequest.ExpiresIn, cancellationToken);

			var deleted = await cryptoPayClient.DeleteInvoiceAsync(invoice.InvoiceId, cancellationToken);

			Assert.NotNull(invoice);
			Assert.True(deleted);
		}
		catch (RequestException requestException) {
			AssertException(requestException, statusCode, error);
		}
	}

	[Theory, ClassData(typeof(CreateCheckData))]
	public async Task CreateCheckTest(HttpStatusCode statusCode, Error error, CreateCheckRequest createCheckRequest) {
		try {
			var check = await cryptoPayClient.CreateCheckAsync(createCheckRequest.Asset, createCheckRequest.Amount, createCheckRequest.PinToUserId, createCheckRequest.PinToUsername, cancellationToken);

			Assert.NotNull(check);
			Assert.Equal(createCheckRequest.Asset, check.Asset);
			Assert.Equal(createCheckRequest.Amount, check.Amount);
		}
		catch (RequestException requestException) {
			AssertException(requestException, statusCode, error);
		}
	}

	[Theory, ClassData(typeof(CreateCheckData))]
	public async Task DeleteCheckTest(HttpStatusCode statusCode, Error error, CreateCheckRequest createCheckRequest) {
		try {
			var check = await cryptoPayClient.CreateCheckAsync(createCheckRequest.Asset, createCheckRequest.Amount, createCheckRequest.PinToUserId, createCheckRequest.PinToUsername, cancellationToken);

			var deleted = await cryptoPayClient.DeleteCheckAsync(check.CheckId, cancellationToken);

			Assert.True(deleted);
		}
		catch (RequestException requestException) {
			AssertException(requestException, statusCode, error);
		}
	}

	[Theory, ClassData(typeof(CreateCheckData))]
	public async Task GetCheckTest(HttpStatusCode statusCode, Error error, CreateCheckRequest createCheckRequest) {
		try {
			var check = await cryptoPayClient.CreateCheckAsync(createCheckRequest.Asset, createCheckRequest.Amount, createCheckRequest.PinToUserId, createCheckRequest.PinToUsername, cancellationToken);

			Assert.NotNull(check);

			var assets = new[] { check.Asset, "BTC" };
			var checks = await cryptoPayClient.GetChecksAsync(assets, [check.CheckId], cancellationToken: cancellationToken);

			Assert.NotNull(checks);
			Assert.True(checks.Items.Any());
		}
		catch (RequestException requestException) {
			AssertException(requestException, statusCode, error);
		}
	}

	[Theory, ClassData(typeof(GetStatsData))]
	public async Task GetStatsTest(HttpStatusCode statusCode, Error error, GetStatsRequest getStatsRequest) {
		try {
			var stats = await cryptoPayClient.GetStatsAsync(getStatsRequest.StartAt, getStatsRequest.EndAt, cancellationToken);

			Assert.NotNull(stats);
			Assert.True(getStatsRequest.StartAt.IsCloseTo(stats.StartAt, TimeSpan.FromMilliseconds(100)));
			Assert.True(getStatsRequest.EndAt.IsCloseTo(stats.EndAt, TimeSpan.FromMilliseconds(100)));
		}
		catch (RequestException requestException) {
			AssertException(requestException, statusCode, error);
		}
	}

	#endregion
}