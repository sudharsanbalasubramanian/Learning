using SharedProject.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureAndAlgorithm.DynamicProgramming
{
    public partial class DynamicProgrammingProblems
    {
        public static int GetMaximumSumOfNonAdjacentElements(List<int> numbers)
        {
            numbers.ThrowIfNullOrEmpty(nameof(numbers));

            int count = numbers.Count;

            int[] dp = new int[count];

            dp[0] = numbers[0];

            for (int i = 1; i < count; i++)
            {
                int includeCurrent = numbers[i];

                if (i > 1)
                {
                    includeCurrent += dp[i - 2];
                }

                int excludeCurrent = dp[i - 1];

                dp[i] = Math.Max(includeCurrent, excludeCurrent);
            }

            return dp[count - 1];
        }

    }
}
