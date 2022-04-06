using System.Net.Http;
using System.Text;
using Newtonsoft.Json;

namespace CryptoPay.Requests.Base;

public class RequestBase<TResponse> : IRequest<TResponse>
{
    #region Public Methods

    /// <inheritdoc />
    public virtual HttpContent ToHttpContent()
    {
        var payload = JsonConvert.SerializeObject(this);
        return new StringContent(payload, Encoding.UTF8, "application/json");
    }

    #endregion

    #region Constructors

    /// <summary>
    ///     Initializes an instance of request.
    /// </summary>
    /// <param name="methodName">Bot API method</param>
    protected RequestBase(string methodName)
        : this(methodName, HttpMethod.Post) {}

    /// <summary>
    ///     Initializes an instance of request.
    /// </summary>
    /// <param name="methodName">Bot API method.</param>
    /// <param name="method">HTTP method to use.</param>
    protected RequestBase(string methodName, HttpMethod method)
    {
        this.MethodName = methodName;
        this.Method = method;
    }

    #endregion

    #region Public Fields

    /// <inheritdoc />
    public HttpMethod Method { get; }

    /// <inheritdoc />
    public string MethodName { get; }

    #endregion
}