using SharedProject.Extensions;

namespace DataStructureAndAlgorithm.Arrays
{
    public partial class ArrayProblems
    {
        public static int MinimumConsecutiveFlips(List<int> binaryArray)
        {
            binaryArray.ThrowIfNullOrEmpty(nameof(binaryArray));

            int n = binaryArray.Count;
            int flips = 0;

            for (int i = 1; i < n; i++)
            {
                // Check for transition
                if (binaryArray[i] != binaryArray[i - 1])
                {
                    flips++;
                }
            }

            // Minimum flips required is half the number of transitions rounded up
            // because flipping one segment may handle two transitions
            return (flips + 1) / 2;
        }

    }
}
