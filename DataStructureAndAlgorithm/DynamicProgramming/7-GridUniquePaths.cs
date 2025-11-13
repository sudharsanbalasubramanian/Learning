namespace DataStructureAndAlgorithm.DynamicProgramming
{
    public partial class DynamicProgrammingProblems
    {
        //https://takeuforward.org/plus/dsa/problems/grid-unique-paths
        public static int UniquePaths(int m, int n, int[][] dp)
        {
            if(m < 0 || n < 0)
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

            var top = UniquePaths(m - 1, n, dp);

            var left = UniquePaths(m, n - 1, dp);

            return dp[m][n] = top + left;
        }

        public static int UniquePaths(int m, int n)
        {
            int[][] dp = new int[m][];
            for (int i = 0; i < m; i++)
            {
                dp[i] = new int[n];
            }

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    // Base case: Starting cell
                    if (i == 0 && j == 0)
                    {
                        dp[i][j] = 1;
                        continue;
                    }

                    int up = 0;
                    int left = 0;

                    if (i > 0)
                    {
                        up = dp[i - 1][j];
                    }

                    if (j > 0)
                    {
                        left = dp[i][j - 1];
                    }

                    dp[i][j] = up + left;
                }
            }

            return dp[m - 1][n - 1];
        }

        public static int UniquePathsSpaceOptimized(int m, int n)
        {
            int[] prev = new int[n];


            for (int i = 0; i < m; i++)
            {
                int[] cur = new int[n];
                for (int j = 0; j < n; j++)
                {
                    // Base case: Starting cell
                    if (i == 0 && j == 0)
                    {
                        cur[j] = 1;
                        continue;
                    }

                    int up = 0;
                    int left = 0;

                    if (i > 0)
                    {
                        up = prev[j];
                    }

                    if (j > 0)
                    {
                        left = cur[j - 1];
                    }

                    cur[j] = up + left;
                }

                prev = cur;
            }

            return prev[n - 1];
        }
    }
}
