using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedProject.Extensions
{
    public static class EnumerableExtensions
    {
        public static bool IsNullOrEmpty<T>(this IEnumerable<T>? source)
        {
            return source == null || !source.Any();
        }
        public static void ThrowIfNullOrEmpty<T>(this IEnumerable<T>? source, string paramName)
        {
            if (source == null)
                throw new ArgumentNullException(paramName, $"{paramName} cannot be null.");

            if (!source.Any())
                throw new ArgumentException($"{paramName} cannot be empty.", paramName);
        }
    }
}
