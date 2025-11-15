using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureAndAlgorithm.DynamicProgramming
{
    public partial class DynamicProgrammingProblems
    {
        public static int MinPathSum(int[][] matrix, int m, int n, int[][] dp)
        {
            if (m == 0 && n == 0)
            {
                return matrix[0][0];
            }

            if (m < 0 || n < 0)
            {
                return int.MaxValue; // invalid path
            }

            if (dp[m][n] != -1)
            {
                return dp[m][n];
            }

            int up = matrix[m][n] + MinPathSum(matrix, m - 1, n, dp);
            int left = matrix[m][n] + MinPathSum(matrix, m, n - 1, dp);

            return dp[m][n] = Math.Min(up, left);
        }

        public static int MinPathSumTabulation(int[][] matrix, int m, int n)
        {
            int[][] dp = new int[m][];
            for (int i = 0; i < m; i++)
            {
                dp[i] = new int[n];
            }

            dp[0][0] = matrix[0][0];

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        continue;
                    }

                    int up = int.MaxValue;
                    int left = int.MaxValue;

                    if (i > 0)
                    {
                        up = matrix[i][j] + dp[i - 1][j];
                    }

                    if (j > 0)
                    {
                        left = matrix[i][j] + dp[i][j - 1];
                    }

                    dp[i][j] = Math.Min(up, left);
                }
            }

            return dp[m - 1][n - 1];
        }

        public static int MinPathSumOptimized(int[][] matrix, int m, int n)
        {
            int[] prev = new int[n];

            prev[0] = matrix[0][0];

            for (int i = 0; i < m; i++)
            {
                int[] cur = new int[n];
                for (int j = 0; j < n; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        continue;
                    }

                    int up = int.MaxValue;
                    int left = int.MaxValue;

                    if (i > 0)
                    {
                        up = matrix[i][j] + prev[j];
                    }

                    if (j > 0)
                    {
                        left = matrix[i][j] + cur[j - 1];
                    }

                    cur[j] = Math.Min(up, left);
                }
                prev = cur;
            }

            return prev[n - 1];
        }
    }
}
