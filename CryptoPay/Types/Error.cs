using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CryptoPay.Types;

/// <summary>
///     Error from response.
/// </summary>
[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public sealed class Error
{
    /// <summary>
    ///     Create instance of <see cref="Error"/>.
    /// </summary>
    /// <param name="code"></param>
    /// <param name="name"></param>
    public Error(int code, string name)
    {
        this.Code = code;
        this.Name = name;
    }
    
    [JsonConstructor]
    private Error() {}

    /// <summary>
    ///     Error code from response.
    /// </summary>
    [JsonProperty(Required = Required.Always)]
    public int Code { get; set; }

    /// <summary>
    ///     Error name from response.
    /// </summary>
    [JsonProperty(Required = Required.Always)]
    public string Name { get; set; }
}