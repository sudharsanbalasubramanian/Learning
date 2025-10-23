using SharedProject.Extensions;

namespace DataStructureAndAlgorithm.Arrays
{
    public partial class ArrayProblems
    {
        public static int LongestEvenOddSubArray(List<int> list)
        {
            list.ThrowIfNullOrEmpty(nameof(list));

            int curCount = 1; // start with 1 because a single element is a valid subarray
            int maxCount = 1;

            for (int i = 1; i < list.Count; i++)
            {
                if ((list[i].IsEven() && list[i - 1].IsOdd()) || (list[i].IsOdd() && list[i - 1].IsEven()))
                {
                    curCount += 1;
                }
                else
                {
                    curCount = 1; // restart counting from current element
                }
                maxCount = Math.Max(maxCount, curCount);
            }

            return maxCount;
        }

    }
}
