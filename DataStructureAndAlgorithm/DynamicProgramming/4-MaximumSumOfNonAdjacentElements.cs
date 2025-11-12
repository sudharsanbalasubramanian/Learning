
namespace DataStructureAndAlgorithm.DynamicProgramming
{
    public partial class DynamicProgrammingProblems
    {
        //https://takeuforward.org/plus/dsa/problems/maximum-sum-of-non-adjacent-elements
        public static int NonAdjacent(int[] nums)
        {
            return NonAdjacent(nums, nums.Length - 1);
        }

        private static int NonAdjacent(int[] nums, int i)
        {
            if (i < 0)
            {
                return 0;
            }

            if (i == 0)
            {
                return nums[i];
            }

            var chooseCurrentElement = nums[i] + NonAdjacent(nums, i - 2);

            var notChooseCurrentElement = NonAdjacent(nums, i - 1);

            return Math.Max(chooseCurrentElement, notChooseCurrentElement);
        }

        public static int NonAdjacentTabulation(int[] nums)
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

            int[] dp = new int[n];
            dp[0] = nums[0];
            dp[1] = Math.Max(nums[0], nums[1]);

            for (int i = 2; i < n; i++)
            {
                int pick = nums[i] + dp[i - 2];
                int notPick = dp[i - 1];
                dp[i] = Math.Max(pick, notPick);
            }

            return dp[n - 1];
        }

        public static int NonAdjacentOptimized(int[] nums)
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

            var prev = nums[0];
            var cur = Math.Max(nums[0], nums[1]);

            for (int i = 2; i < n; i++)
            {
                int pick = nums[i] + prev;
                int notPick = cur;

                var next = Math.Max(pick, notPick);

                prev = cur;
                cur = next;
            }

            return cur;
        }

    }
}
