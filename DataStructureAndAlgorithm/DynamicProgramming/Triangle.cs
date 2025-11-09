using SharedProject.Extensions;

namespace DataStructureAndAlgorithm.DynamicProgramming
{
    public partial class DynamicProgrammingProblems
    {
        public static int MinimumTotal(IList<IList<int>> triangle)
        {
            int n = triangle.Count;
            int[,] dp = new int[n, n];

            // Initialize dp with -1 to indicate "not computed"
            dp.Fill(-1);

            return MinimumTotal(triangle, 0, 0, dp);
        }

        private static int MinimumTotal(IList<IList<int>> triangle, int i, int j, int[,] dp)
        {
            int n = triangle.Count;

            // Base case: last row
            if (i == n - 1)
            {
                return triangle[i][j];
            }

            // Memoized result
            if (dp[i, j] != -1)
            {
                return dp[i, j];
            }

            // Choose between the straight-down and diagonal-down paths
            int down = triangle[i][j] + MinimumTotal(triangle, i + 1, j, dp);
            int diagonal = triangle[i][j] + MinimumTotal(triangle, i + 1, j + 1, dp);

            // Store and return the minimum
            dp[i, j] = Math.Min(down, diagonal);
            return dp[i, j];
        }

    }
}
