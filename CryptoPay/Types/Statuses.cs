// ReSharper disable InconsistentNaming
#pragma warning disable CS1591
namespace CryptoPay.Types;

/// <summary>
///     Status of invoices to be returned.
/// </summary>
public enum Statuses
{
    active,
    paid,
    expired
}