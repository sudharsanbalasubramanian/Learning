namespace DataStructureAndAlgorithm.DynamicProgramming
{
    public partial class DynamicProgrammingProblems
    {
        public static int CherryPickupSpaceOptimized(int[][] grid)
        {
            int rowCount = grid.Length;
            int columnCount = grid[0].Length;

            // We only need two layers: current and next
            int[,] next = new int[columnCount, columnCount];
            int[,] curr = new int[columnCount, columnCount];

            // --- Base Case: fill for the last row ---
            for (int j1 = 0; j1 < columnCount; j1++)
            {
                for (int j2 = 0; j2 < columnCount; j2++)
                {
                    if (j1 == j2)
                    {
                        next[j1, j2] = grid[rowCount - 1][j1];
                    }
                    else
                    {
                        next[j1, j2] = grid[rowCount - 1][j1] + grid[rowCount - 1][j2];
                    }
                }
            }

            // --- Iterate from bottom to top ---
            for (int i = rowCount - 2; i >= 0; i--)
            {
                for (int j1 = 0; j1 < columnCount; j1++)
                {
                    for (int j2 = 0; j2 < columnCount; j2++)
                    {
                        int maxi = int.MinValue;

                        // Explore all 9 move combinations
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
                                value += next[nextJ1, nextJ2];

                                maxi = Math.Max(maxi, value);
                            }
                        }

                        curr[j1, j2] = maxi;
                    }
                }

                // Move current layer to next for next iteration
                for (int a = 0; a < columnCount; a++)
                {
                    for (int b = 0; b < columnCount; b++)
                    {
                        next[a, b] = curr[a, b];
                    }
                }
            }

            return next[0, columnCount - 1];
        }

    }
}
