using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureAndAlgorithm.DynamicProgramming
{
    public partial class DynamicProgrammingProblems
    {
        //https://leetcode.com/problems/minimum-falling-path-sum/
        public static int MinimumFallingPathSumTabulation(List<List<int>> matrix)
        {
            var rowCount = matrix.Count;
            var columnCount = matrix[0].Count;

            int[,] dp = new int[rowCount, columnCount];

            for(var j = 0; j < columnCount; j++)
            {
                dp[rowCount - 1, j] = matrix[rowCount - 1][j];
            }

            for(var i = rowCount - 2;  i >= 0; i--)
            {
                for(var j = 0;j < columnCount; j++)
                {
                    int down = matrix[i][j] + dp[i + 1, j];

                    int leftDiagonal = int.MaxValue;
                    int rightDiagonal = int.MaxValue;

                    if (j - 1 >= 0)
                        leftDiagonal = matrix[i][j] + dp[i + 1, j - 1];

                    if (j + 1 < columnCount)
                        rightDiagonal = matrix[i][j] + dp[i + 1, j + 1];

                    dp[i, j] = Math.Min(down, Math.Min(leftDiagonal, rightDiagonal));
                }
            }

            return Enumerable.Range(0, columnCount).Min(j => dp[0, j]);
        }
    }
}
