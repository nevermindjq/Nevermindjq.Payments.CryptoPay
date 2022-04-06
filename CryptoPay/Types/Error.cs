using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace CryptoPay.Types;

[JsonObject(MemberSerialization.OptIn, NamingStrategyType = typeof(SnakeCaseNamingStrategy))]
public class Error
{
    public Error(int code, string name)
    {
        this.Code = code;
        this.Name = name;
    }
    
    [JsonConstructor]
    private Error() {}

    [JsonProperty(Required = Required.Always)]
    public int Code { get; set; }

    [JsonProperty(Required = Required.Always)]
    public string Name { get; set; }
}