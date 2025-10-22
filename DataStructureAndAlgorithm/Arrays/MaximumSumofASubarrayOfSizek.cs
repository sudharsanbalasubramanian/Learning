using SharedProject.Extensions;

namespace DataStructureAndAlgorithm.Arrays
{
    public partial class ArrayProblems
    {
        public static int MaximumSumofASubarrayOfSizek(List<int> array, int windowSize)
        {
            array.ThrowIfNullOrEmpty(nameof(array));

            ArgumentOutOfRangeException.ThrowIfGreaterThan(windowSize, array.Count, nameof(windowSize));

            int curWindowSum = 0;

            for (int i = 0; i < windowSize; i++)
            {
                curWindowSum += array[i];
            }

            var maxSum = curWindowSum;

            for(int i = windowSize; i < array.Count; i++)
            {
                curWindowSum = curWindowSum + array[i] - array[i - windowSize];

                maxSum = Math.Max(maxSum, curWindowSum);
            }

            return maxSum;
        }
    }
}
