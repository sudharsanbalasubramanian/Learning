using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedProject.Extensions
{
    public static class ListExtensions
    {
        public static void Swap<T>(this IList<T> list, int firstIndex, int secondIndex)
        {
            ArgumentNullException.ThrowIfNull(list);

            if (firstIndex < 0 || firstIndex >= list.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(firstIndex));
            }

            if (secondIndex < 0 || secondIndex >= list.Count)
            {
                throw new ArgumentOutOfRangeException(nameof(secondIndex));
            }

            if (firstIndex == secondIndex)
            {
                return;
            }

            (list[firstIndex], list[secondIndex]) = (list[secondIndex], list[firstIndex]);
        }
    }
}
