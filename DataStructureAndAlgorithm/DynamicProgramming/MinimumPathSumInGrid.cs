namespace DataStructureAndAlgorithm.DynamicProgramming
{
    public partial class DynamicProgrammingProblems
    {
        public static int MinimumPathSumInGrid(List<List<int>> weightedPaths, int i, int j, int[,] dp)
        {
            if(i == 0 && j == 0)
            {
                return weightedPaths[i][j];
            }

            if(j < 0 || i < 0)
            {
                return int.MaxValue;
            }

            if (dp[i, j] != -1)
            {
                return dp[i, j];
            }

            var up = weightedPaths[i][j] + MinimumPathSumInGrid(weightedPaths, i - 1, j, dp);

            var left = weightedPaths[i][j] + MinimumPathSumInGrid(weightedPaths, i, j - 1, dp);

            return dp[i, j] = Math.Min(up, left);   
        }
    }
}
