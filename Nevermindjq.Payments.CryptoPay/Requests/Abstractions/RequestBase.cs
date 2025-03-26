using System.Collections.Generic;
using System.Net.Http;
using System.Text;

using Nevermindjq.Payments.CryptoPay.Converters;

using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace Nevermindjq.Payments.CryptoPay.Requests.Abstractions;

/// <inheritdoc />
public abstract class RequestBase : IRequest {
	#region Public Methods

	/// <inheritdoc />
	public HttpContent ToHttpContent() {
		var payload = JsonConvert.SerializeObject(this, new JsonSerializerSettings {
			ContractResolver = new DefaultContractResolver {
				NamingStrategy = new SnakeCaseNamingStrategy()
			},
			NullValueHandling = NullValueHandling.Ignore,
			Converters = new List<JsonConverter> {
				new StringEnumConverter(),
				new NumberAsStringConverter()
			}
		});

		return new StringContent(payload, Encoding.UTF8, "application/json");
	}

	#endregion

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