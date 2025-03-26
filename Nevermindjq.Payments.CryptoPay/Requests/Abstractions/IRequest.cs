using System.Net.Http;

namespace Nevermindjq.Payments.CryptoPay.Requests.Abstractions;

/// <summary>
///     Represents a request to CryptoPay API.
/// </summary>
public interface IRequest {
    /// <summary>
    ///     HTTP method of request.
    /// </summary>
    public HttpMethod Method { get; }

    /// <summary>
    ///     API method name.
    /// </summary>
    public string MethodName { get; }
}