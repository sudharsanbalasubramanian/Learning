namespace DataStructureAndAlgorithm.DynamicProgramming
{
    public partial class DynamicProgrammingProblems
    {
        public static int NinjaTraining(int[][] matrix)
        {
            int days = matrix.Length;
            int tasks = matrix[0].Length;

            // Allocate dp array with 4 columns (0..3)
            int[][] dp = new int[days][];
            for (int i = 0; i < days; i++)
            {
                dp[i] = new int[tasks + 1]; // +1 for 'no previous task' (3)
                Array.Fill(dp[i], -1);
            }

            // Start recursion with 'no previous task' = 3
            return NinjaTraining(matrix, days - 1, 3, dp);
        }

        private static int NinjaTraining(int[][] matrix, int index, int prevChosen, int[][] dp)
        {
            int taskCount = matrix[0].Length;

            if (dp[index][prevChosen] != -1)
            {
                return dp[index][prevChosen];
            }

            // Base case: first day
            if (index == 0)
            {
                int maxPoint = int.MinValue;
                for (int i = 0; i < taskCount; i++)
                {
                    if (i != prevChosen)
                    {
                        maxPoint = Math.Max(maxPoint, matrix[0][i]);
                    }
                }
                return dp[index][prevChosen] = maxPoint;
            }

            int maxMerit = int.MinValue;

            // Try all tasks except the one done previously
            for (int i = 0; i < taskCount; i++)
            {
                if (i != prevChosen)
                {
                    int points = matrix[index][i] + NinjaTraining(matrix, index - 1, i, dp);
                    maxMerit = Math.Max(maxMerit, points);
                }
            }

            return dp[index][prevChosen] = maxMerit;
        }
    }
}
