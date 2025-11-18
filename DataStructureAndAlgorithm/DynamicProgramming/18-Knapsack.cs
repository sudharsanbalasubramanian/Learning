using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureAndAlgorithm.DynamicProgramming
{
    public partial class DynamicProgrammingProblems
    {
        //https://www.geeksforgeeks.org/dsa/0-1-knapsack-problem-dp-10/
        public static int KnapSackRec(Dictionary<int, int> dict, int capacity, int index)
        {
            int[] weights = dict.Keys.ToArray();
            int[] values = dict.Values.ToArray();

            return Solve(weights, values, index, capacity);
        }

        private static int Solve(int[] weights, int[] values, int idx, int capacity)
        {
            // Base case
            if (idx == 0)
            {
                return weights[0] <= capacity ? values[0] : 0;
            }

            // Not pick
            int notPick = Solve(weights, values, idx - 1, capacity);

            int pick = int.MinValue;
            if (weights[idx] <= capacity)
            {
                pick = values[idx] + Solve(weights, values, idx - 1, capacity - weights[idx]);
            }

            return Math.Max(pick, notPick);
        }

        public static int KnapSack(Dictionary<int, int> dict, int maxWeight)
        {
            int n = dict.Count;

            // Extract keys and values into arrays
            int[] weights = [.. dict.Keys];
            int[] values = [.. dict.Values];

            // dp[i, w] = maximum value using items[0..i] with weight limit w
            int[,] dp = new int[n, maxWeight + 1];

            // Base case: item 0
            for (int w = 0; w <= maxWeight; w++)
            {
                if (weights[0] <= w)
                {
                    dp[0, w] = values[0];
                }
            }

            // Fill DP table
            for (int i = 1; i < n; i++)
            {
                for (int w = 0; w <= maxWeight; w++)
                {
                    int notPick = dp[i - 1, w];
                    int pick = int.MinValue;

                    if (weights[i] <= w)
                    {
                        pick = values[i] + dp[i - 1, w - weights[i]];
                    }

                    dp[i, w] = Math.Max(pick, notPick);
                }
            }

            // Final answer
            return dp[n - 1, maxWeight];
        }
        public static int KnapSackSpaceOptimized(Dictionary<int, int> dict, int maxWeight)
        {
            int n = dict.Count;

            int[] weights = [.. dict.Keys];
            int[] values = dict.Values.ToArray();

            // dp[w] = max value with weight limit w (using items processed so far)
            int[] dp = new int[maxWeight + 1];

            // Base case for item 0
            for (int w = weights[0]; w <= maxWeight; w++)
            {
                dp[w] = values[0];
            }

            // Fill DP for items 1..n-1
            for (int i = 1; i < n; i++)
            {
                // traverse backwards to avoid overwriting earlier states
                for (int w = maxWeight; w >= 0; w--)
                {
                    int pick = int.MinValue;

                    if (weights[i] <= w)
                    {
                        pick = values[i] + dp[w - weights[i]];
                    }

                    dp[w] = Math.Max(dp[w], pick);
                }
            }

            return dp[maxWeight];
        }

    }
}
