using System;
using System.Security.Cryptography;
using System.Text;

using Nevermindjq.Payments.CryptoPay.Models;
using Nevermindjq.Payments.CryptoPay.Services;

// ReSharper disable once CheckNamespace
namespace Nevermindjq.Payments.CryptoPay;

/// <summary>
///     Helper for main <see cref="CryptoPayClient" />.
/// </summary>
public static class CryptoPayHelper {
    /// <summary>
    ///     This method verifies the integrity of the received data.
    /// </summary>
    /// <param name="signature">String from header parameter<c>crypto-pay-api-signature</c>.</param>
    /// <param name="token">Your application token from CryptoPay.</param>
    /// <param name="body">Response <see cref="Update">body</see>.</param>
    /// <returns><c>true</c> if the header parameter crypto-pay-api-signature equals hash of request body.</returns>
    [Obsolete("Use CheckSignature(string, string, byte[]). For more information, visit https://github.com/WinoGarcia/CryptoPay/pull/21")]
	public static bool CheckSignature(string signature, string token, Update body) {
		using var hmac = new HMACSHA256(SHA256.HashData(Encoding.UTF8.GetBytes(token)));

		var hashBytes = hmac.ComputeHash(Encoding.UTF8.GetBytes(body.ToString()));
		var signatureBytes = Convert.FromHexString(signature);

		return CryptographicOperations.FixedTimeEquals(hashBytes, signatureBytes);
	}

    /// <summary>
    ///     This method verifies the integrity of the received data.
    /// </summary>
    /// <param name="signature">String from header parameter<c>crypto-pay-api-signature</c>.</param>
    /// <param name="token">Your application token from CryptoPay.</param>
    /// <param name="body">Response</param>
    /// <returns><c>true</c> if the header parameter crypto-pay-api-signature equals hash of request body.</returns>
    public static bool CheckSignature(string signature, string token, byte[] body) {
		using var hmac = new HMACSHA256(SHA256.HashData(Encoding.UTF8.GetBytes(token)));

		var hashBytes = hmac.ComputeHash(body);
		var signatureBytes = Convert.FromHexString(signature);

		return CryptographicOperations.FixedTimeEquals(hashBytes, signatureBytes);
	}
}