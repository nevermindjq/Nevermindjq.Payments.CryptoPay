using System.Threading;
using System.Threading.Tasks;

using Nevermindjq.Payments.CryptoPay.Exceptions;
using Nevermindjq.Payments.CryptoPay.Requests.Abstractions;

namespace Nevermindjq.Payments.CryptoPay.Services.Abstractions;

/// <summary>
///     Crypto Pay is a payment system based on <a href="https://t.me/CryptoBot">CryptoBot</a>
///     that allows you to accept payments in crypto and transfer coins to users using our API.
///     Official documentation see <a href="https://help.crypt.bot/crypto-pay-api">here</a>
/// </summary>
public interface ICryptoPayClient {
	/// <summary>
	///     Make Request to CryptoPay service.
	/// </summary>
	/// <param name="api_request">Type of request <see cref="IRequest" /></param>
	/// <param name="cancellationToken">
	///     A cancellation token that can be used by other objects or threads to receive notice of
	///     cancellation.
	/// </param>
	/// <typeparam name="TResponse">Type of response see child of <see cref="ParameterlessRequest{TResult}" /></typeparam>
	/// <returns>Instance type of TResponse</returns>
	/// <exception cref="RequestException">This exception can be thrown.</exception>
	Task<TResponse> MakeRequestAsync<TResponse>(IRequest api_request, CancellationToken cancellationToken = default);
}