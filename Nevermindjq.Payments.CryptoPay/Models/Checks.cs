using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;

namespace Nevermindjq.Payments.CryptoPay.Models;

/// <summary>
///     Object include list of <see cref="Check" />.
/// </summary>
public sealed class Checks {
    /// <summary>
    ///     List of <see cref="Check" />.
    /// </summary>
    [JsonRequired]
	public IEnumerable<Check> Items { get; set; } = Enumerable.Empty<Check>();
}