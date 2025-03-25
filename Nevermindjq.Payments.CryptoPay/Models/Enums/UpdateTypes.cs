﻿// ReSharper disable InconsistentNaming

using System.Text.Json.Serialization;

#pragma warning disable CS1591
namespace Nevermindjq.Payments.CryptoPay.Models.Enums;

/// <summary>
///     Type of <see cref="Update" />.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum UpdateTypes {
	invoice_paid
}