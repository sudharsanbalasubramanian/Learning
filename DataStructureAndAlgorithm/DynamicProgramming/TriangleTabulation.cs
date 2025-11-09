namespace DataStructureAndAlgorithm.DynamicProgramming
{
    public partial class DynamicProgrammingProblems
    {
        public static int TriangleTabulation(List<List<int>> triangle)
        {
            var rowCount = triangle.Count;

            var columnCount = triangle[rowCount - 1].Count;

            int[,] dp = new int[rowCount, columnCount];

            for(int j = 0; j < columnCount; j++)
            {
                dp[rowCount - 1, j] = triangle[rowCount - 1][j];
            }

            for(int i = rowCount - 2; i >= 0; i--)
            {
                for(int j = 0; j <= i; j++)
                {
                    int down = triangle[i][j] + dp[i + 1, j];
                    int diagonal = triangle[i][j] + dp[i + 1, j + 1];
                    dp[i, j] = Math.Min(down, diagonal);
                }
            }

            return dp[0, 0];
        }
    }
}
