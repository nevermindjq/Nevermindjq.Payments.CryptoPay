using System.Collections.Generic;
using System.Linq;

namespace Nevermindjq.Payments.CryptoPay.Models.Transfers;

/// <summary>
///     Object include list of <see cref="Transfer" />.
/// </summary>
public sealed class Transfers {
    /// <summary>
    ///     List of <see cref="Transfer" />.
    /// </summary>
    [JsonRequired]
	public IEnumerable<Transfer> Items { get; set; } = Enumerable.Empty<Transfer>();
}