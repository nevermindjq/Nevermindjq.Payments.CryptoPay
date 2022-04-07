#pragma warning disable CS1591
namespace CryptoPay.Types;

// ReSharper disable InconsistentNaming
// ReSharper disable IdentifierTypo

/// <summary>
///     Available currencies.
/// </summary>
public enum Assets
{
    // Crypto
    BTC,
    TON,
    ETH, //(testnet only)
    BNB,
    USDT,
    USDC,
    BUSD,

    //Fiat
    RUB = 100,
    USD = 101,
    EUR = 102
}