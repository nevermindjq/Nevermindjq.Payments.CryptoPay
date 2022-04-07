// ReSharper disable InconsistentNaming

#pragma warning disable CS1591
namespace CryptoPay.Types;

/// <summary>
///     Buttons that will be shown to a user after the invoice is paid.
/// </summary>
public enum PaidButtonNames
{
    viewItem,
    openChannel,
    openBot,
    callback
}