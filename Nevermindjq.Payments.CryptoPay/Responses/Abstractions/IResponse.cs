namespace Nevermindjq.Payments.CryptoPay.Responses.Abstractions;

/// <summary>
///     Response from service CryptoPay.
/// </summary>
public interface IResponse {
    /// <summary>
    ///     Gets a value indicating whether the request was successful.
    /// </summary>
    bool Ok { get; init; }
}