using System.Collections.Generic;
using CryptoPay.Requests.Base;
using CryptoPay.Types;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CryptoPay.Requests;

/// <summary>
///     Use this class to create <see cref="Balance"/> request.
/// </summary>
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public sealed class GetBalanceRequest : ParameterlessRequest<List<Balance>>
{
    /// <summary>
    ///     Initializes a new request to get <see cref="Balance"/>.
    /// </summary>
    public GetBalanceRequest()
        : base("getBalance") { }
}