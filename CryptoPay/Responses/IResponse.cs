namespace CryptoPay.Responses;

public interface IResponse
{
    /// <summary>
    ///     Gets a value indicating whether the request was successful.
    /// </summary>
    bool Ok { get; init; }
}