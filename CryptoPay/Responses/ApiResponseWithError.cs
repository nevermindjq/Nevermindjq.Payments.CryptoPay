using CryptoPay.Types;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CryptoPay.Responses;

/// <summary>
///     Response with <see cref="Error"/>.
/// </summary>
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
internal sealed class ApiResponseWithError : IResponse
{
    /// <summary>
    ///     Initializes an instance of <see cref="ApiResponseWithError" />
    /// </summary>
    /// <param name="error">Instanse of <see cref="Error"/>.</param>
    public ApiResponseWithError(Error error)
    {
        this.Ok = false;
        this.Error = Error;
    }

    [JsonConstructor]
    private ApiResponseWithError() {}

    /// <inheritdoc cref="IResponse.Ok"/>
    [JsonProperty(Required = Required.Always)]
    public bool Ok { get; init; }
    
    /// <summary>
    ///     Instance of <see cref="Error"/>.
    /// </summary>
    [JsonProperty(Required = Required.Always)]
    public Error Error { get; init; } 
}