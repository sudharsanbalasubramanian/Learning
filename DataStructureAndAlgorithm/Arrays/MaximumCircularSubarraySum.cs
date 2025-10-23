using SharedProject.Extensions;

namespace DataStructureAndAlgorithm.Arrays
{
    public partial class ArrayProblems
    {
        public static int MaximumCircularSubarraySum(List<int> list)
        {
            list.ThrowIfNullOrEmpty(nameof(list));

            var maxSubarraySum = MaximumSubarraySum(list);

            var totalSum = 0;

            for (int i = 0; i < list.Count; i++)
            {
                totalSum += list[i];

                list[i] = -list[i];
            }

            var maximumCircularSubarraySum = totalSum - MaximumSubarraySum(list);

            if(maximumCircularSubarraySum == 0)
            {
                return maxSubarraySum;
            }

            return Math.Max(maximumCircularSubarraySum, maxSubarraySum);
        }
    }
}
