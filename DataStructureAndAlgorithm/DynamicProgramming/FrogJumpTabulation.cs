namespace DataStructureAndAlgorithm.DynamicProgramming
{
    public partial class DynamicProgrammingProblems
    {
        //https://www.geeksforgeeks.org/problems/geek-jump/1
        public static int FrogJumpTabulation(List<int> heights)
        {
            int n = heights.Count;
            int[] dp = new int[n];
            dp[0] = 0;

            for (int i = 1; i < n; i++)
            {
                int firstStep = dp[i - 1] + Math.Abs(heights[i] - heights[i - 1]);
                int secondStep = int.MaxValue;

                if (i > 1)
                {
                    secondStep = dp[i - 2] + Math.Abs(heights[i] - heights[i - 2]);
                }

                dp[i] = Math.Min(firstStep, secondStep);
            }

            return dp[n - 1];
        }
    }
}
