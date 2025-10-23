using SharedProject.Extensions;

namespace DataStructureAndAlgorithm.Arrays
{
    public partial class ArrayProblems
    {
        public static int TrappingRainWater(List<int> heights)
        {
            heights.ThrowIfNullOrEmpty(nameof(heights));

            int n = heights.Count;

            if (n < 3)
            {
                return 0; // At least 3 bars needed
            }

            int[] lMax = new int[n];
            int[] rMax = new int[n];

            // Fill lMax
            lMax[0] = heights[0];
            for (int i = 1; i < n; i++)
            {
                lMax[i] = Math.Max(heights[i], lMax[i - 1]);
            }

            // Fill rMax
            rMax[n - 1] = heights[n - 1];
            for (int i = n - 2; i >= 0; i--)
            {
                rMax[i] = Math.Max(heights[i], rMax[i + 1]);
            }

            int trappedWater = 0;
            for (int i = 1; i < n - 1; i++)
            {
                trappedWater += Math.Min(lMax[i], rMax[i]) - heights[i];
            }

            return trappedWater;
        }

    }
}
