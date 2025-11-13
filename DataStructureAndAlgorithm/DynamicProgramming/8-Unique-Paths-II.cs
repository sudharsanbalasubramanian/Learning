using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureAndAlgorithm.DynamicProgramming
{
    public partial class DynamicProgrammingProblems
    {
        //https://takeuforward.org/plus/dsa/problems/unique-paths-ii
        public static int UniquePathsWithObstacles(int[][] matrix, int m, int n, int[][] dp)
        {

            if (m < 0 || n < 0)
            {
                return 0;
            }

            if (matrix[m][n] == 1)
            {
                return 0;
            }

            if(m == 0 && n == 0)
            {
                return 1;
            }


            if (dp[m][n] != -1)
            {
                return dp[m][n];
            }

            var bottom = UniquePathsWithObstacles(matrix, m - 1, n, dp);
            
            var left = UniquePathsWithObstacles(matrix, m, n - 1, dp);

            return dp[m][n] = bottom + left;
        }

        public static int UniquePathsWithObstacles(int[][] matrix)
        {

            var row = matrix.Length;

            var column = matrix[0].Length;

            int[][] dp = new int[row][];

            for(int i = 0; i < row; i++)
            {
                for(int j = 0; j < column; j++)
                {


                    if(matrix[i][j] == 1)
                    {
                        dp[i][j] = 0;
                        continue;
                    }

                    if (i == 0 && j == 0)
                    {
                        dp[i][j] = 1;
                        continue;
                    }

                    var up = 0;
                    var right = 0;

                    if(i > 0)
                    {
                        up = dp[i - 1][j];
                    }

                    if(j > 0)
                    {
                        right = dp[i][j - 1];
                    }

                    dp[i][j] = up + right;
                }
            }

            return dp[row - 1][column - 1];
        }

        public static int UniquePathsWithObstaclesOptimized(int[][] matrix)
        {
            var row = matrix.Length;

            var column = matrix[0].Length;

            int[] prev = new int[column];
            for (int i = 0; i < row; i++)
            {
                int[] cur = new int[column];
                for (int j = 0; j < column; j++)
                {
                    if (matrix[i][j] == 1)
                    {
                        cur[j] = 0;
                        continue;
                    }

                    if (i == 0 && j == 0)
                    {
                        cur[j] = 1;
                        continue;
                    }

                    var up = 0;
                    var right = 0;

                    if (i > 0)
                    {
                        up = prev[j];
                    }

                    if (j > 0)
                    {
                        right = cur[j - 1];
                    }

                    cur[j] = up + right;
                }

                prev = cur;
            }

            return prev[column - 1];
        }
    }
}
