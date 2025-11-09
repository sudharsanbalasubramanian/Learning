namespace DataStructureAndAlgorithm.DynamicProgramming
{
    public partial class DynamicProgrammingProblems
    {
        public static int CherryPickupTabulation(int[][] grid)
        {
            int rowCount = grid.Length;
            int columnCount = grid[0].Length;

            // 3D DP array: dp[i, j1, j2] = max cherries from row i with robots at j1 and j2
            int[,,] dp = new int[rowCount, columnCount, columnCount];

            // --- Base Case: fill for last row (bottom row) ---
            for (int j1 = 0; j1 < columnCount; j1++)
            {
                for (int j2 = 0; j2 < columnCount; j2++)
                {
                    if (j1 == j2)
                    {
                        dp[rowCount - 1, j1, j2] = grid[rowCount - 1][j1];
                    }
                    else
                    {
                        dp[rowCount - 1, j1, j2] = grid[rowCount - 1][j1] + grid[rowCount - 1][j2];
                    }
                }
            }

            // --- Fill table from bottom to top ---
            for (int i = rowCount - 2; i >= 0; i--)
            {
                for (int j1 = 0; j1 < columnCount; j1++)
                {
                    for (int j2 = 0; j2 < columnCount; j2++)
                    {
                        int maxi = int.MinValue;

                        // 9 possible moves for the two robots
                        for (int k = -1; k <= 1; k++)
                        {
                            for (int l = -1; l <= 1; l++)
                            {
                                int nextJ1 = j1 + k;
                                int nextJ2 = j2 + l;

                                if (nextJ1 < 0 || nextJ1 >= columnCount || nextJ2 < 0 || nextJ2 >= columnCount)
                                {
                                    continue;
                                }

                                int value = (j1 == j2) ? grid[i][j1] : grid[i][j1] + grid[i][j2];
                                value += dp[i + 1, nextJ1, nextJ2];

                                maxi = Math.Max(maxi, value);
                            }
                        }

                        dp[i, j1, j2] = maxi;
                    }
                }
            }

            // --- The answer is at the top row with robots starting at (0, 0) and (0, columnCount - 1) ---
            return dp[0, 0, columnCount - 1];
        }

    }
}
