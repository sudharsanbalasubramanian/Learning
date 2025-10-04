using SharedProject.Extensions;

namespace DataStructureAndAlgorithm
{
    public partial class ArrayProblems
    {
        public static int TrappingWater(List<int> values)
        {
            values.ThrowIfNullOrEmpty();

            int n = values.Count;
            if (n < 3)
                return 0;

            var lmax = new int[n];
            var rmax = new int[n];

            // initialize both ends
            lmax[0] = values[0];
            rmax[^1] = values[^1];

            // single loop to fill both arrays
            for (int i = 1; i < n; i++)
            {
                lmax[i] = Math.Max(lmax[i - 1], values[i]);
                rmax[^(i + 1)] = Math.Max(rmax[^i], values[^(i + 1)]);
            }

            // compute trapped water
            int water = 0;
            for (int i = 0; i < n; i++)
            {
                water += Math.Min(lmax[i], rmax[i]) - values[i];
            }

            return water;
        }

    }
}