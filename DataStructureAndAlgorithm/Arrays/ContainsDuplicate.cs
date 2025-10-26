using SharedProject.Extensions;

namespace DataStructureAndAlgorithm.Arrays
{
    public partial class ArrayProblems
    {
        //https://leetcode.com/problems/contains-duplicate/description/
        public static bool ContainsDuplicate(int[] nums)
        {
            nums.ThrowIfNullOrEmpty(nameof(nums));

            HashSet<int> visited = [];

            for (int i = 0; i < nums.Length; i++)
            {
                if (!visited.Add(nums[i]))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
