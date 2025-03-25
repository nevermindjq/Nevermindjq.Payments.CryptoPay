﻿// ReSharper disable InconsistentNaming

using System.Text.Json.Serialization;

#pragma warning disable CS1591
namespace Nevermindjq.Payments.CryptoPay.Models.Enums;

/// <summary>
///     Status of the transfer.
/// </summary>
[JsonConverter(typeof(JsonStringEnumConverter))]
public enum TransferStatuses {
	completed
}