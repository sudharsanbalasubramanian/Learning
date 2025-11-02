using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureAndAlgorithm.DynamicProgramming
{
    public partial class DynamicProgrammingProblems
    {
        public static int GetUniquePathsMemo(int i, int j, int[,] dp)
        {
            // Base cases
            if (i < 0 || j < 0)
            {
                return 0;
            }

            if (i == 0 && j == 0)
            {
                return 1;
            }

            // If already computed, return memoized result
            if (dp[i, j] != -1)
            {
                return dp[i, j];
            }

            // Recursive calls
            var left = GetUniquePathsMemo(i - 1, j, dp);
            var up = GetUniquePathsMemo(i, j - 1, dp);

            // Store the computed result
            dp[i, j] = left + up;

            return dp[i, j];
        }

    }
}
