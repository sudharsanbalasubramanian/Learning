namespace DataStructureAndAlgorithm.DynamicProgramming
{
    public partial class DynamicProgrammingProblems
    {
        public static int HouseRobber(int[] nums)
        {
            int n = nums.Length;

            if (n == 0)
            {
                return 0;
            }

            if (n == 1)
            {
                return nums[0];
            }

            // Exclude first house
            int excludeFirstHouse = NonAdjacentOptimized(nums[1..]);

            // Exclude last house
            int excludeLastHouse = NonAdjacentOptimized(nums[..^1]);

            return Math.Max(excludeFirstHouse, excludeLastHouse);
        }

    }
}
