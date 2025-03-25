using System;
using System.Security.Cryptography;
using System.Text;

using Microsoft.AspNetCore.Http;

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
    /// <param name="body">Response</param>
    /// <returns><c>true</c> if the header parameter crypto-pay-api-signature equals hash of request body.</returns>
    public static bool CheckSignature(string signature, string token, byte[] body) {
		using var hmac = new HMACSHA256(SHA256.HashData(Encoding.UTF8.GetBytes(token)));

		var hashBytes = hmac.ComputeHash(body);
		var signatureBytes = Convert.FromHexString(signature);

		return CryptographicOperations.FixedTimeEquals(hashBytes, signatureBytes);
	}

	public static bool CheckSignature(IHeaderDictionary headers, string token, byte[] body) {
		if (!headers.TryGetValue("Crypto-Pay-Api-Signature", out var signature)) {
			return false;
		}

		return CheckSignature(signature, token, body);
	}
}