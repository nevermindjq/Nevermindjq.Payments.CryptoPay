using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CryptoPay.Extensions;

public static class EnumerableExtension
{
    public static string Join<T>(this IEnumerable<T> self, string delimiter)
    {
        if (self is not null && self.Any())
        {
            var sb = new StringBuilder();
            sb.AppendJoin(delimiter, self);
            return sb.ToString();
        }
        return default;
    }
}