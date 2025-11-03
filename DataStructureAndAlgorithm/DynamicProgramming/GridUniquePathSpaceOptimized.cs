using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureAndAlgorithm.DynamicProgramming
{
    public partial class DynamicProgrammingProblems
    {
        public static int MazeObstaclesSpaceOptimized(int row, int col, List<List<int>> maze)
        {
            int[] dp = new int[col]; // ✅ should be col, not row

            for (int i = 0; i < row; i++)
            {
                int[] current = new int[col]; // holds current row computation

                for (int j = 0; j < col; j++)
                {
                    if (maze[i][j] == -1)
                    {
                        current[j] = 0;
                        continue;
                    }

                    if (i == 0 && j == 0)
                    {
                        current[j] = 1;
                        continue;
                    }

                    int up = 0, left = 0;

                    if (i > 0)
                    {
                        up = dp[j];
                    }

                    if (j > 0)
                    {
                        left = current[j - 1];
                    }

                    current[j] = up + left;
                }

                dp = current; // move to next row
            }

            return dp[col - 1];
        }


    }
}
