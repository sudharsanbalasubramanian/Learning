using SharedProject.Extensions;

namespace DataStructureAndAlgorithm.Arrays
{
    public partial class ArrayProblems
    {
        public static int MaximumSubarraySum(List<int> list)
        {
            list.ThrowIfNullOrEmpty(nameof(list));

            int maxEnding = list[0];

            int res = maxEnding;

            for (int i = 1; i < list.Count; i++)
            {
                maxEnding = Math.Max(maxEnding + list[i], list[i]);

                res = Math.Max(res, maxEnding);
            }

            return res;
        }

    }
}
