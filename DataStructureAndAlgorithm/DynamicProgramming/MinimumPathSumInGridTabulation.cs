namespace DataStructureAndAlgorithm.DynamicProgramming
{
    public partial class DynamicProgrammingProblems
    {
        public static int MinimumPathSumInGridTabulation(List<List<int>> grid)
        {
            int row = grid.Count;
            int col = grid[0].Count;

            int[,] dp = new int[row, col];

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        dp[i, j] = grid[i][j];
                    }
                    else
                    {
                        int up = int.MaxValue;
                        int left = int.MaxValue;

                        if (i > 0)
                        {
                            up = grid[i][j] + dp[i - 1, j];
                        }

                        if (j > 0)
                        {
                            left = grid[i][j] + dp[i, j - 1];
                        }

                        dp[i, j] = Math.Min(up, left);
                    }
                }
            }

            return dp[row - 1, col - 1];
        }

    }
}
