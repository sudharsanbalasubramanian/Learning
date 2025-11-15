
namespace DataStructureAndAlgorithm.DynamicProgramming
{
    public partial class DynamicProgrammingProblems
    {
        //https://takeuforward.org/plus/dsa/problems/frog-jump
        public static int FrogJump(int[] heights)
        {
            int n = heights.Length;
            int[] dp = new int[n];

            Array.Fill(dp, -1);

            return FrogJump(heights, n - 1, dp);
        }

        private static int FrogJump(int[] heights, int n, int[] dp)
        {
            if (n == 0)
            {
                return 0;
            }

            if (dp[n] != -1)
            {
                return dp[n];
            }

            int oneJump = FrogJump(heights, n - 1, dp) + Math.Abs(heights[n] - heights[n - 1]);
            int twoJump = int.MaxValue;

            if (n > 1)
            {
                twoJump = FrogJump(heights, n - 2, dp) + Math.Abs(heights[n] - heights[n - 2]);
            }

            return dp[n] = Math.Min(oneJump, twoJump);
        }

        public static int FrogJumpTabulation(int[] heights)
        {
            int n = heights.Length;
            int[] dp = new int[n];

            dp[0] = 0;
            if (n > 1)
            {
                dp[1] = Math.Abs(heights[1] - heights[0]);
            }

            for (int i = 2; i < n; i++)
            {
                int oneJump = dp[i - 1] + Math.Abs(heights[i] - heights[i - 1]);
                int twoJump = dp[i - 2] + Math.Abs(heights[i] - heights[i - 2]);
                dp[i] = Math.Min(oneJump, twoJump);
            }

            return dp[n - 1];
        }


        public static int FrogJumpSpaceOptimized(int[] heights)
        {
            int n = heights.Length;

            int prev = 0;
            int cur = Math.Abs(heights[1] - heights[0]);

            for (int i = 2; i < n; i++)
            {
                int oneJump = cur + Math.Abs(heights[i] - heights[i - 1]);
                int twoJump = prev + Math.Abs(heights[i] - heights[i - 2]);
                int next = Math.Min(oneJump, twoJump);

                prev = cur;
                cur = next;
            }

            return cur;
        }
    }
}
