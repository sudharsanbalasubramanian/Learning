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
            int[] dp = new int[col];

            dp[0] = maze[0][0] == -1 ? 0 : 1;

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    if (maze[i][j] == -1)
                    {
                        dp[j] = 0;
                    }
                    if(j > 0)
                    {
                        dp[j] += dp[j - 1];
                    }
                }
            }

            return dp[col - 1];
        }
    }
}
