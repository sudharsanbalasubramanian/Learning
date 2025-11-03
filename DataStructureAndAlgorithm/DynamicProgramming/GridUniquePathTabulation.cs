namespace DataStructureAndAlgorithm.DynamicProgramming
{
    public partial class DynamicProgrammingProblems 
    { 
        public static int GridUniquePathTabulation(int row, int col)
        {

            int[,] dp = new int[row, col];

            dp[0, 0] = 1;

            for(int i = 0; i < row; i++)
            {
                for(int j = 0; j < col; j++)
                {
                    if (i == 0 && j == 0)
                    {
                        continue;
                    }

                    int up = 0;
                    int left = 0;

                    if (i > 0)
                    {
                        up = dp[i - 1, j];
                    }

                    if (j > 0)
                    {
                        left = dp[i, j - 1];
                    }

                    dp[i, j] = up + left;
                }
            }

            return dp[row - 1, col - 1];
        }
    }
}
