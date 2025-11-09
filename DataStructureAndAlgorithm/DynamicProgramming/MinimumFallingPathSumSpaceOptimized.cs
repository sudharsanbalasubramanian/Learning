namespace DataStructureAndAlgorithm.DynamicProgramming
{
    public partial class DynamicProgrammingProblems
    {
        //https://leetcode.com/problems/minimum-falling-path-sum/
        public static int MinimumFallingPathSumSpaceOptimized(List<List<int>> matrix)
        {
            var rowCount = matrix.Count;
            var columnCount = matrix[0].Count;

            int[] prev = new int[columnCount];

            // Base case: last row
            for (var j = 0; j < columnCount; j++)
            {
                prev[j] = matrix[rowCount - 1][j];
            }

            // Bottom-up iteration
            for (var i = rowCount - 2; i >= 0; i--)
            {
                int[] cur = new int[columnCount];

                for (var j = 0; j < columnCount; j++)
                {
                    int down = matrix[i][j] + prev[j];

                    int leftDiagonal = int.MaxValue;
                    int rightDiagonal = int.MaxValue;

                    if (j - 1 >= 0)
                        leftDiagonal = matrix[i][j] + prev[j - 1];

                    if (j + 1 < columnCount)
                        rightDiagonal = matrix[i][j] + prev[j + 1];

                    cur[j] = Math.Min(down, Math.Min(leftDiagonal, rightDiagonal));
                }

                // Move current row up for next iteration
                prev = cur;
            }

            // Minimum among all possible starting columns in top row
            return Enumerable.Range(0, columnCount).Min(j => prev[j]);
        }

    }
}
