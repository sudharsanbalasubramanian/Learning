namespace DataStructureAndAlgorithm.DynamicProgramming
{
    public partial class DynamicProgrammingProblems
    {
        public static int MazeObstacles(int i, int j, List<List<int>> maze, int[,] dp)
        {
            if(i < 0 || j < 0)
            {
                return 0;
            }

            if (maze[i][j] == -1)
            {
                return 0;
            }

            if (i == 0 && j == 0)
            {
                return 1;
            }

            if (dp[i, j] != -1)
            {
                return dp[i, j];
            }

            var up = MazeObstacles(i - 1, j, maze, dp);

            var left = MazeObstacles(i, j - 1, maze, dp);

            return dp[i, j] = up + left;
        }
    }
}
