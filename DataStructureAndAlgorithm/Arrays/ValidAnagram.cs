using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureAndAlgorithm.Arrays
{
    public partial class ArrayProblems
    {
        public bool IsAnagramByCount(string a, string b)
        {
            if (a == null || b == null)
            {
                return false;
            }

            if (a.Length != b.Length)
            {
                return false;
            }

            var counts = new Dictionary<char, int>();

            // Count chars in a
            foreach (var ch in a)
            {
                if (counts.TryGetValue(ch, out var c))
                {
                    counts[ch] = c + 1;
                }
                else
                {
                    counts[ch] = 1;
                }
            }

            // Subtract using b
            foreach (var ch in b)
            {
                if (!counts.TryGetValue(ch, out int c))
                {
                    return false; // char not present
                }

                if (c == 0)
                {
                    return false;
                }

                counts[ch] = c - 1;
            }

            // All counts should be zero (they will if lengths were equal and we never returned false)
            return true;
        }

    }
}
