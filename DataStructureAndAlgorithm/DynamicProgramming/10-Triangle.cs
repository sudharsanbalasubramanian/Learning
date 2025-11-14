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
            var rowCount = matrix.Count;

            var lastColumnCount = matrix[rowCount - 1].Count;

            int[][] dp = new int[rowCount][];

            for(int i = 0; i < rowCount; i++)
            {
                for(int j = 0; j <= i; j++)
                {
                    if(i == rowCount - 1)
                    {
                        dp[i][j] = matrix[i][j];
                        continue;
                    }

                    var bottom = matrix[i][j] + dp[i + 1][j];
                    var bottomRight = matrix[i][j] + dp[i + 1][j + 1];

                    dp[i][j] = Math.Min(bottom, bottomRight);
                }
            }

            return dp[rowCount - 1][lastColumnCount - 1];
        }
    }
}
