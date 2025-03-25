﻿using Nevermindjq.Payments.CryptoPay.Models;
using Nevermindjq.Payments.CryptoPay.Requests.Abstractions;

namespace Nevermindjq.Payments.CryptoPay.Requests;

/// <summary>
///     A simple method for testing your bot's auth token. Requires no parameters. Returns basic information
///     about the bot in form of a <see cref="CryptoPayApplication" /> object.
/// </summary>
internal sealed class GetMeRequest : ParameterlessRequest<CryptoPayApplication> {
	/// <summary>
	///     Initializes a new request to get a <see cref="CryptoPayApplication" />
	/// </summary>
	public GetMeRequest() : base("getMe") { }
}