﻿using System.Text.Json.Serialization;

namespace Nevermindjq.Payments.CryptoPay.Models;

/// <summary>
///     Error from response.
/// </summary>
public sealed class Error {
    /// <summary>
    ///     Create instance of <see cref="Error" />.
    /// </summary>
    /// <param name="code"></param>
    /// <param name="name"></param>
    public Error(int code, string name) {
		Code = code;
		Name = name;
	}

	[JsonConstructor]
	private Error() { }

    /// <summary>
    ///     Error code from response.
    /// </summary>
    [JsonRequired]
	public int Code { get; set; }

    /// <summary>
    ///     Error name from response.
    /// </summary>
    [JsonRequired]
	public string Name { get; set; }
}