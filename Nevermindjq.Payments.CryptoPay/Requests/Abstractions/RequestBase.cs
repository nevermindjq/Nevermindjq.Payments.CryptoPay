using System.Net.Http;

namespace Nevermindjq.Payments.CryptoPay.Requests.Abstractions;

/// <inheritdoc />
public abstract class RequestBase : IRequest {
	#region Constructors

    /// <summary>
    ///     Initializes an instance of request.
    /// </summary>
    /// <param name="methodName">Bot API method</param>
    protected RequestBase(string methodName) : this(methodName, HttpMethod.Post) { }

    /// <summary>
    ///     Initializes an instance of request.
    /// </summary>
    /// <param name="methodName">Bot API method.</param>
    /// <param name="method">HTTP method to use.</param>
    protected RequestBase(string methodName, HttpMethod method) {
		MethodName = methodName;
		Method = method;
	}

	#endregion

	#region Public Fields

	/// <inheritdoc />
	public HttpMethod Method { get; }

	/// <inheritdoc />
	public string MethodName { get; }

	#endregion
}