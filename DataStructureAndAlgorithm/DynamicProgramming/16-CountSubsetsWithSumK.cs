using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureAndAlgorithm.DynamicProgramming
{
    public partial class DynamicProgrammingProblems
    {
        public static int CountSubsetsWithSumK(int[] arr, int target, int index, int[,] dp)
        {
            if(target == 0)
            {
                return 1;
            }

            if(index < 0 || target < 0)
            {
                return 0;
            }

            if(dp[index, target] != -1)
            {
                return dp[index, target];
            }

            var pick = CountSubsetsWithSumK(arr, target - arr[index], index - 1, dp);
            
            var skip = CountSubsetsWithSumK(arr, target, index - 1, dp);

            return dp[index, target] = pick + skip;
        }

        public static int CountSubsetsWithSumK(int[] arr, int target)
        {
            int n = arr.Length;

            // dp[i, t] = number of subsets using arr[0..i] that sum to t
            int[,] dp = new int[n, target + 1];

            // Base case 1: target == 0 → always 1 way (empty subset)
            for (int i = 0; i < n; i++)
            {
                dp[i, 0] = 1;
            }

            // Base case 2: only 1 element (i = 0)
            // Only one subset can form arr[0]
            if (arr[0] <= target)
            {
                dp[0, arr[0]] = 1;
            }

            // Fill the DP table
            for (int i = 1; i < n; i++)
            {
                for (int t = 1; t <= target; t++)
                {
                    int skip = dp[i - 1, t];     // do not take arr[i]
                    int pick = 0;

                    if (arr[i] <= t)
                    {
                        pick = dp[i - 1, t - arr[i]];  // take arr[i]
                    }

                    dp[i, t] = pick + skip;
                }
            }

            // Final answer: using all elements, number of ways to reach target
            return dp[n - 1, target];
        }

        public static int CountSubsetsWithSumKSpaceOptimized(int[] arr, int target)
        {
            int n = arr.Length;

            int[] dp = new int[target + 1];

            dp[0] = 1;

            if (arr[0] <= target)
            {
                dp[arr[0]] = 1;
            }

            for (int i = 1; i < n; i++)
            {
                int[] cur = new int[target + 1];

                cur[0] = 1;   // IMPORTANT: empty subset always possible

                for (int t = 1; t <= target; t++)
                {
                    int skip = dp[t];
                    int pick = 0;

                    if (arr[i] <= t)
                    {
                        pick = dp[t - arr[i]];
                    }

                    cur[t] = pick + skip;
                }

                dp = cur;
            }

            return dp[target];
        } 

    }
}
