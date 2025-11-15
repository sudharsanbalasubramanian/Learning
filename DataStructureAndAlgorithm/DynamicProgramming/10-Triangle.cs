namespace DataStructureAndAlgorithm.DynamicProgramming
{
    public partial class DynamicProgrammingProblems
    {
        public static int MinTriangleSum(List<List<int>> matrix, int i, int j, int[][] dp)
        {
            var rowCount = matrix.Count;

            if(i == rowCount - 1)
            {
                return matrix[i][j];
            }

            if (dp[i][j] != 0)
            {
                return dp[i][j];
            }

            var bottom = matrix[i][j] + MinTriangleSum(matrix, i + 1, j, dp);

            var bottomDown = matrix[i][j] + MinTriangleSum(matrix, i + 1, j + 1, dp);

            return dp[i][j] = Math.Min(bottom, bottomDown);
        }

        public static int MinTriangleSum(List<List<int>> matrix)
        {
            int rowCount = matrix.Count;

            // Create DP array
            int[][] dp = new int[rowCount][];

            // Initialize DP with the last row (base case)
            dp[rowCount - 1] = [.. matrix[rowCount - 1]];

            // Fill from bottom to top
            for (int i = rowCount - 2; i >= 0; i--)
            {
                dp[i] = new int[matrix[i].Count];

                for (int j = 0; j < matrix[i].Count; j++)
                {
                    int bottom = dp[i + 1][j];
                    int bottomRight = dp[i + 1][j + 1];

                    dp[i][j] = matrix[i][j] + Math.Min(bottom, bottomRight);
                }
            }

            // Final answer at the top
            return dp[0][0];
        }


        public static int MinTriangleSumSpaceOptimized(List<List<int>> matrix)
        {
            int rowCount = matrix.Count;

            // Start from last row
            int[] dp = [.. matrix[rowCount - 1]];

            // Go upward
            for (int i = rowCount - 2; i >= 0; i--)
            {
                int[] cur = new int[matrix[i].Count];

                for (int j = 0; j < matrix[i].Count; j++)
                {
                    int bottom = dp[j];
                    int bottomRight = dp[j + 1];

                    cur[j] = matrix[i][j] + Math.Min(bottom, bottomRight);
                }

                dp = cur;
            }

            return dp[0];
        }

    }
}
