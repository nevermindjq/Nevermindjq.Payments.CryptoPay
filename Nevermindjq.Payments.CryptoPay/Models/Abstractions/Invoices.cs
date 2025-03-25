using System.Collections.Generic;
using System.Linq;

using Nevermindjq.Payments.CryptoPay.Extensions;

namespace Nevermindjq.Payments.CryptoPay.Models.Abstractions;

/// <summary>
///     List of <see cref="Invoice" />. You can get invoices use
///     <see cref="CryptoPayExtensions.GetInvoicesAsync" />
/// </summary>
public sealed class Invoices {
    /// <summary>
    ///     List of <see cref="Invoice" />.
    /// </summary>
    public IEnumerable<Invoice> Items { get; set; } = Enumerable.Empty<Invoice>();
}