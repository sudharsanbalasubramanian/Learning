using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureAndAlgorithm.DynamicProgramming
{
    public partial class DynamicProgrammingProblems
    {
        public static int GridUniquePathSpaceOptimized(int row, int col)
        {
            int[] prev = new int[col];

            for (int i = 0; i < row; i++)
            {
                int[] curr = new int[col];
                for (int j = 0; j < col; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        curr[j] = 1;
                    }
                    else
                    {
                        int up = 0, left = 0;
                        if (i > 0)
                        {
                            up = prev[j];
                        }
                        if (j > 0)
                        {
                            left = curr[j - 1];
                        }
                        curr[j] = up + left;
                    }
                }
                prev = curr;
            }

            return prev[col - 1];
        }

    }
}
