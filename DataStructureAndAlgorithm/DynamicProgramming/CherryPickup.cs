
namespace DataStructureAndAlgorithm.DynamicProgramming
{
    public partial class DynamicProgrammingProblems
    {
        public static int CherryPickup(int[][] grid)
        {
            int rowCount = grid.Length;
            int columnCount = grid[0].Length;

            // 3D DP array: dp[i, j1, j2] stores max cherries from row i with robots at (j1, j2)
            int[,,] dp = new int[rowCount, columnCount, columnCount];

            // Initialize with -1 to mark uncomputed states
            for (int i = 0; i < rowCount; i++)
            {
                for (int j1 = 0; j1 < columnCount; j1++)
                {
                    for (int j2 = 0; j2 < columnCount; j2++)
                    {
                        dp[i, j1, j2] = -1;
                    }
                }
            }

            return CherryPickup(grid, 0, 0, columnCount - 1, dp);
        }

        private static int CherryPickup(int[][] grid, int i, int j1, int j2, int[,,] dp)
        {
            int rowCount = grid.Length;
            int columnCount = grid[0].Length;

            // Out of bounds check
            if (j1 < 0 || j1 >= columnCount || j2 < 0 || j2 >= columnCount)
            {
                return int.MinValue;
            }

            // If already computed, return from memo
            if (dp[i, j1, j2] != -1)
            {
                return dp[i, j1, j2];
            }

            // Base case — last row
            if (i == rowCount - 1)
            {
                if (j1 == j2)
                {
                    return grid[i][j1];
                }
                else
                {
                    return grid[i][j1] + grid[i][j2];
                }
            }

            int maxi = int.MinValue;

            // Explore all 9 possible move combinations
            for (int k = -1; k <= 1; k++)
            {
                for (int l = -1; l <= 1; l++)
                {
                    int next = CherryPickup(grid, i + 1, j1 + k, j2 + l, dp);
                    if (next == int.MinValue)
                    {
                        continue;
                    }

                    int value = j1 == j2 ? grid[i][j1] : grid[i][j1] + grid[i][j2];
                    value += next;

                    maxi = Math.Max(maxi, value);
                }
            }

            // Store result in memo table
            dp[i, j1, j2] = maxi;
            return maxi;
        }

    }
}
