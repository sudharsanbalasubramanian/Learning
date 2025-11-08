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
            int[] prev = new int[col];

            for (int i = 0; i < row; i++)
            {
                int[] curr = new int[col];
                for (int j = 0; j < col; j++)
                {
                    if (maze[i][j] == -1)
                    {
                        curr[j] = 0;
                    }
                    else if (i == 0 && j == 0)
                    {
                        curr[j] = 1;
                    }
                    else
                    {
                        int up = (i > 0) ? prev[j] : 0;
                        int left = (j > 0) ? curr[j - 1] : 0;
                        curr[j] = up + left;
                    }
                }
                prev = curr;
            }

            return prev[col - 1];
        }


    }
}
