using CryptoPay.Types;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CryptoPay.Responses;

[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class ApiResponseWithError : IResponse
{
    /// <summary>
    ///     Initializes an instance of <see cref="ApiResponseWithError" />
    /// </summary>
    /// <param name="description">Error message</param>
    public ApiResponseWithError(
        string description)
    {
        this.Ok = false;
    }

    [JsonConstructor]
    private ApiResponseWithError() {}

    /// <inheritdoc />
    [JsonProperty(Required = Required.Always)]
    public bool Ok { get; init; }
    
    [JsonProperty(Required = Required.Always)]
    public Error Error { get; set; } 
}