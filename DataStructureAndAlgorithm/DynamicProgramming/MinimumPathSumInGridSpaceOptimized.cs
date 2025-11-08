using System.Runtime.Intrinsics.Arm;

namespace DataStructureAndAlgorithm.DynamicProgramming
{
    public partial class DynamicProgrammingProblems
    {
        public static int MinimumPathSumSpaceOptimized(List<List<int>> grid)
        {
            int rowCount = grid.Count;
            int columnCount = grid[0].Count;

            int[] prev = new int[columnCount];

            for (int i = 0; i < rowCount; i++)
            {
                int[] cur = new int[columnCount];

                for (int j = 0; j < columnCount; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        cur[j] = grid[i][j];
                    }
                    else
                    {
                        int up = int.MaxValue;
                        int left = int.MaxValue;

                        if (i > 0)
                        {
                            up = grid[i][j] + prev[j];
                        }

                        if (j > 0)
                        {
                            left = grid[i][j] + cur[j - 1];
                        }

                        cur[j] = Math.Min(up, left);
                    }
                }

                prev = cur; 
            }

            return prev[columnCount - 1];
        }

    }
}
