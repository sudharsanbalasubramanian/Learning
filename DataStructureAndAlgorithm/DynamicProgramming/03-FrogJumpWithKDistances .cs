
namespace DataStructureAndAlgorithm.DynamicProgramming
{
    public partial class DynamicProgrammingProblems
    {
        //https://takeuforward.org/plus/dsa/problems/frog-jump-with-k-distances
        public static int FrogJumpWithKDistance(int[] heights, int kDistance)
        {
            return FrogJumpWithKDistance(heights, kDistance, heights.Length - 1);
        }

        private static int FrogJumpWithKDistance(int[] heights, int kDistance, int n)
        {
            if (n == 0)
            {
                return 0;
            }

            int minEnergyFrogJumpK = int.MaxValue;

            for (int i = 1; i <= kDistance; i++)
            {
                if (n - i >= 0)
                {
                    int jump = FrogJumpWithKDistance(heights, kDistance, n - i)
                               + Math.Abs(heights[n] - heights[n - i]);

                    minEnergyFrogJumpK = Math.Min(minEnergyFrogJumpK, jump);
                }
            }

            return minEnergyFrogJumpK;
        }

        public static int FrogJumpWithKDistanceTabulation(int[] heights, int kDistance)
        {
            int n = heights.Length;
            int[] dp = new int[n];
            dp[0] = 0; // Base case: no cost to stay on the first stone

            for (int i = 1; i < n; i++)
            {
                int minCost = int.MaxValue;

                // Try all jumps from 1 to kDistance
                for (int j = 1; j <= kDistance; j++)
                {
                    if (i - j >= 0)
                    {
                        int cost = dp[i - j] + Math.Abs(heights[i] - heights[i - j]);
                        minCost = Math.Min(minCost, cost);
                    }
                }

                dp[i] = minCost;
            }

            return dp[n - 1]; // Minimum cost to reach the last stone
        }
        public static int FrogJumpWithKDistanceOptimized(int[] heights, int kDistance)
        {
            int n = heights.Length;
            int[] dp = new int[kDistance];
            dp[0] = 0;

            for (int i = 1; i < n; i++)
            {
                int minCost = int.MaxValue;

                // check last kDistance jumps
                for (int j = 1; j <= kDistance; j++)
                {
                    if (i - j >= 0)
                    {
                        int prevIndex = (i - j) % kDistance;
                        int cost = dp[prevIndex] + Math.Abs(heights[i] - heights[i - j]);
                        minCost = Math.Min(minCost, cost);
                    }
                }

                dp[i % kDistance] = minCost;
            }

            return dp[(n - 1) % kDistance];
        }
    }
}
