using SharedProject.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureAndAlgorithm.DynamicProgramming
{
    public partial class DynamicProgrammingProblems
    {
        public static int MinFallingPathSum(List<List<int>> matrix)
        {
            var minimum = int.MaxValue;

            var rowCount = matrix.Count;
            var columnCount = matrix[0].Count;

            int[,] dp = new int[rowCount, columnCount];

            dp.Fill(-1);

            for (int j = 0; j < matrix[0].Count; j++)
            {
                minimum = Math.Min(minimum, MinFallingPathSum(matrix, 0, j, dp));
            }

            return minimum;
        }

        private static int MinFallingPathSum(List<List<int>> matrix, int i, int j, int[,] dp)
        {
            var rowCount = matrix.Count;
            var columnCount = matrix[0].Count;

            if (i == rowCount - 1)
            {
                return matrix[i][j];
            }

            if (dp[i, j] != -1)
            {
                return dp[i, j];
            }

            var down = matrix[i][j] + MinFallingPathSum(matrix, i + 1, j, dp);

            var rightDiagonal = int.MaxValue;
            if (j < columnCount - 1)
            {
                rightDiagonal = matrix[i][j] + MinFallingPathSum(matrix, i + 1, j + 1, dp);
            }

            var leftDiagonal = int.MaxValue;
            if (j > 0)
            {
                leftDiagonal = matrix[i][j] + MinFallingPathSum(matrix, i + 1, j - 1, dp);
            }

            return dp[i, j] = down.MinOfThree(rightDiagonal, leftDiagonal);
        }

    }
}
