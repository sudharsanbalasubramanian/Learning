namespace DataStructureAndAlgorithm.DynamicProgramming
{
    public partial class DynamicProgrammingProblems
    {
        //https://takeuforward.org/plus/dsa/problems/subset-sum-equals-to-target
        public static bool IsSubsetSum(int[] arr, int target)
        {
            int n = arr.Length;

            // dp[i][t] = nullable bool → true/false/unknown
            bool?[][] dp = new bool?[n][];
            for (int i = 0; i < n; i++)
            {
                dp[i] = new bool?[target + 1];
            }

            return IsSubsetSum(arr, target, n - 1, dp);
        }

        private static bool IsSubsetSum(int[] arr, int target, int i, bool?[][] dp)
        {
            // Base case 1: target achieved
            if (target == 0)
            {
                return true;
            }

            // Base case 2: no elements left OR target negative
            if (i < 0 || target < 0)
            {
                return false;
            }

            // Memoization lookup
            if (dp[i][target].HasValue)
            {
                return dp[i][target]!.Value;
            }

            // Option 1: pick element
            bool pick = IsSubsetSum(arr, target - arr[i], i - 1, dp);

            // Option 2: skip element
            bool skip = IsSubsetSum(arr, target, i - 1, dp);

            // Store result
            dp[i][target] = pick || skip;

            return dp[i][target]!.Value;
        }


        public static bool IsSubsetSum(int target, List<int> arr)
        {
            int n = arr.Count;

            // Create DP array: n x (target+1)
            bool[,] dp = new bool[n, target + 1];

            // Base case: target = 0 is always true
            for (int i = 0; i < n; i++)
            {
                dp[i, 0] = true;
            }

            // Base case for the first element
            if (arr[0] <= target)
            {
                dp[0, arr[0]] = true;
            }

            // Fill DP bottom-up
            for (int ind = 1; ind < n; ind++)
            {
                for (int t = 1; t <= target; t++)
                {
                    bool notTaken = dp[ind - 1, t];

                    bool taken = false;
                    if (arr[ind] <= t)
                    {
                        taken = dp[ind - 1, t - arr[ind]];
                    }

                    dp[ind, t] = taken || notTaken;
                }
            }

            return dp[n - 1, target];
        }

        public static bool IsSubsetSumOptimized(int target, List<int> arr)
        {
            int n = arr.Count;

            bool[] dp = new bool[target + 1];

            // Base case
            dp[0] = true;

            // First element
            if (arr[0] <= target)
            {
                dp[arr[0]] = true;
            }

            // Process each number
            for (int ind = 1; ind < n; ind++)
            {
                // IMPORTANT: go backwards
                for (int t = target; t >= 1; t--)
                {
                    bool notTaken = dp[t];

                    bool taken = false;
                    if (arr[ind] <= t)
                    {
                        taken = dp[t - arr[ind]];
                    }

                    dp[t] = taken || notTaken;
                }
            }

            return dp[target];
        }

    }
}
