using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Infrastructure.Extensions
{
    public static class EnumerableExtensions
    {
        public static ReadOnlyCollection<TItem> ToReadOnlyCollection<TItem>(this IEnumerable<TItem> items) =>
            items.ToList().AsReadOnly();
    }
}
