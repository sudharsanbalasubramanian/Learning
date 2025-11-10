namespace DataStructureAndAlgorithm.DynamicProgramming
{
    public partial class DynamicProgrammingProblems
    {
        public static bool SubsetSumEqualsToTargetTabulation(List<int> list, int target)
        {
            int n = list.Count;
            bool[,] dp = new bool[n, target + 1];

            // Base case: sum 0 is always possible
            for (int i = 0; i < n; i++)
            {
                dp[i, 0] = true;
            }

            // Base case: first element
            if (list[0] <= target)
            {
                dp[0, list[0]] = true;
            }

            // Fill the table
            for (int i = 1; i < n; i++)
            {
                for (int t = 1; t <= target; t++)
                {
                    bool notTake = dp[i - 1, t];
                    bool take = false;
                    if (t >= list[i])
                    {
                        take = dp[i - 1, t - list[i]];
                    }

                    dp[i, t] = notTake || take;
                }
            }

            return dp[n - 1, target];
        }

    }
}
