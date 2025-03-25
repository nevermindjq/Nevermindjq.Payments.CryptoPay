using Nevermindjq.Payments.CryptoPay.Extensions;

namespace Nevermindjq.Payments.CryptoPay.Models.Abstractions;

/// <summary>
///     Transfer. You can get invoice use <see cref="CryptoPayExtensions.TransferAsync" />
/// </summary>
public interface ITransfer {
    /// <summary>
    ///     Telegram user ID the transfer was sent to.
    /// </summary>
    public long UserId { get; set; }

    /// <summary>
    ///     Currency code. Currently, can be assets.
    /// </summary>
    public string Asset { get; set; }

    /// <summary>
    ///     Amount of the transfer.
    /// </summary>
    public double Amount { get; set; }

    /// <summary>
    ///     Optional. Comment for this transfer.
    /// </summary>
    public string Comment { get; set; }
}