﻿using System.Collections.Generic;
using System.Linq;

namespace Nevermindjq.Payments.CryptoPay.Models.Checks;

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