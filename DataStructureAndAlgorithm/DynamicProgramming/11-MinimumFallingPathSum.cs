using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureAndAlgorithm.DynamicProgramming
{
    public partial class DynamicProgrammingProblems
    {
        public static int MinFallingPathSum(int[][] matrix)
        {
            int rowCount = matrix.Length;
            int columnCount = matrix[0].Length;

            // Init dp
            int[][] dp = new int[rowCount][];
            for (int i = 0; i < rowCount; i++)
            {
                dp[i] = new int[columnCount];
                for (int j = 0; j < columnCount; j++)
                {
                    dp[i][j] = -1;
                }
            }

            int minimum = int.MaxValue;

            // Try all columns in first row
            for (int j = 0; j < columnCount; j++)
            {
                minimum = Math.Min(minimum, MinFallingPathSum(matrix, 0, j, dp));
            }

            return minimum;
        }

        private static int MinFallingPathSum(int[][] matrix, int i, int j, int[][] dp)
        {
            int rowCount = matrix.Length;
            int columnCount = matrix[0].Length;

            // Out of bounds
            if (j < 0 || j >= columnCount)
            {
                return int.MaxValue;
            }

            // Base case: last row
            if (i == rowCount - 1)
            {
                return matrix[i][j];
            }

            // Memoized result
            if (dp[i][j] != -1)
            {
                return dp[i][j];
            }

            int down = MinFallingPathSum(matrix, i + 1, j, dp);
            int downLeft = MinFallingPathSum(matrix, i + 1, j - 1, dp);
            int downRight = MinFallingPathSum(matrix, i + 1, j + 1, dp);

            return dp[i][j] = matrix[i][j] + Math.Min(down, Math.Min(downLeft, downRight));
        }

        public static int MinFallingPathSumTabulation(int[][] matrix)
        {
            int rowCount = matrix.Length;
            int columnCount = matrix[0].Length;

            // Initialize dp array properly
            int[][] dp = new int[rowCount][];
            for (int i = 0; i < rowCount; i++)
            {
                dp[i] = new int[columnCount];
            }

            // Base row
            for (int j = 0; j < columnCount; j++)
            {
                dp[rowCount - 1][j] = matrix[rowCount - 1][j];
            }

            // Fill DP bottom-up
            for (int i = rowCount - 2; i >= 0; i--)
            {
                for (int j = 0; j < columnCount; j++)
                {
                    int down = dp[i + 1][j];

                    int downLeft = j > 0
                        ? dp[i + 1][j - 1]
                        : int.MaxValue;

                    int downRight = j < columnCount - 1
                        ? dp[i + 1][j + 1]
                        : int.MaxValue;

                    dp[i][j] = matrix[i][j] + Math.Min(down, Math.Min(downLeft, downRight));
                }
            }

            // Final answer = min in first row
            int result = int.MaxValue;
            for (int j = 0; j < columnCount; j++)
            {
                result = Math.Min(result, dp[0][j]);
            }

            return result;
        }


    }
}
