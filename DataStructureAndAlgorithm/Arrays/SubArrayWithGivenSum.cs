using SharedProject.Extensions;

namespace DataStructureAndAlgorithm.Arrays
{
    public partial class ArrayProblems
    {
        public static (int leftIndex, int rightIndex) SubArrayWithGivenSum(List<int> arr, int sum)
        {
            arr.ThrowIfNullOrEmpty(nameof(arr));

            int left = 0;
            int curSum = 0;

            for (int right = 0; right < arr.Count; right++)
            {
                curSum += arr[right];

                // shrink window if current sum > target
                while (curSum > sum && left <= right)
                {
                    curSum -= arr[left];
                    left++;
                }

                // check for target match
                if (curSum == sum)
                {
                    return (left, right);
                }
            }

            // not found
            return (-1, -1);
        }

    }
}
