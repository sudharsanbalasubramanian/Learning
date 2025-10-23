using SharedProject.Extensions;

namespace DataStructureAndAlgorithm.Arrays
{
    public partial class ArrayProblems
    {
        public static void LeftRotate<T>(List<T> values, int d)
        {
            values.ThrowIfNullOrEmpty(nameof(values));

            int n = values.Count;
            d = d % n; // handle d > n

            // Step 1: Reverse first d elements
            values.Reverse(0, d);

            // Step 2: Reverse remaining n - d elements
            values.Reverse(d, n - d);

            // Step 3: Reverse the whole list
            values.Reverse();
        }

    }
}
