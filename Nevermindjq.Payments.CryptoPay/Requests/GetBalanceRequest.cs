using Nevermindjq.Payments.CryptoPay.Models;
using Nevermindjq.Payments.CryptoPay.Requests.Abstractions;

namespace Nevermindjq.Payments.CryptoPay.Requests;

/// <summary>
///     Use this class to create <see cref="Balance" /> request.
/// </summary>
public sealed class GetBalanceRequest() : RequestBase("getBalance");