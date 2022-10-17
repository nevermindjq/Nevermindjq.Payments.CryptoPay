using System.Collections.Generic;
using CryptoPay.Requests.Base;
using CryptoPay.Types;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CryptoPay.Requests;

/// <summary>
///     Use this class to get list of <see cref="Currency"/> request.
/// </summary>
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public sealed class GetCurrenciesRequest : ParameterlessRequest<List<Currency>>
{
    /// <summary>
    ///     Initializes a new request to get list of <see cref="Currency"/>
    /// </summary>
    public GetCurrenciesRequest()
        : base("getCurrencies") {}
}