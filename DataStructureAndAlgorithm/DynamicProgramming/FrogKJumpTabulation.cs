namespace DataStructureAndAlgorithm.DynamicProgramming
{
    public partial class DynamicProgrammingProblems
    {
        public static int FrogKJumpTabulation(List<int> heights, int k)
        {
            int n = heights.Count;
            int[] dp = new int[k]; // Circular buffer of size k
            dp[0] = 0; // Base case

            for (int i = 1; i < n; i++)
            {
                int minEnergy = int.MaxValue;

                for (int j = 1; j <= k && i - j >= 0; j++)
                {
                    int prevIndex = (i - j) % k;
                    int jumpEnergy = dp[prevIndex] + Math.Abs(heights[i] - heights[i - j]);
                    minEnergy = Math.Min(minEnergy, jumpEnergy);
                }

                dp[i % k] = minEnergy;
            }

            return dp[(n - 1) % k];
        }

    }
}
