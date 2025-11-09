using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureAndAlgorithm.DynamicProgramming
{
    public partial class DynamicProgrammingProblems
    {
        public static int MinimumTotalSpaceOptimized(IList<IList<int>> triangle)
        {
            int n = triangle.Count;
            int[] front = new int[n];
            int[] cur = new int[n];

            // Initialize with last row
            for (int j = 0; j < n; j++)
            {
                front[j] = triangle[n - 1][j];
            }

            // Bottom-up computation
            for (int i = n - 2; i >= 0; i--)
            {
                for (int j = 0; j <= i; j++)
                {
                    int down = triangle[i][j] + front[j];
                    int diagonal = triangle[i][j] + front[j + 1];
                    cur[j] = Math.Min(down, diagonal);
                }
                // Move up
                Array.Copy(cur, front, n);
            }

            return front[0];
        }
    }
}
