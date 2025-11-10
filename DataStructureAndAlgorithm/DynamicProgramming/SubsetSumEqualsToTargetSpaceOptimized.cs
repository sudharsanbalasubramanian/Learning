using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureAndAlgorithm.DynamicProgramming
{
    public partial class DynamicProgrammingProblems
    {
        public static bool SubsetSumEqualsToTargetSpaceOptimized(List<int> list, int target)
        {
            int n = list.Count;
            bool[] prev = new bool[target + 1];

            // Base case: sum 0 is always possible
            prev[0] = true;

            // Base case: first element
            if (list[0] <= target)
            {
                prev[list[0]] = true;
            }

            for (int i = 1; i < n; i++)
            {
                bool[] curr = new bool[target + 1];
                curr[0] = true; // sum 0 is always possible

                for (int t = 1; t <= target; t++)
                {
                    bool notTake = prev[t];

                    bool take = t >= list[i] && prev[t - list[i]];

                    curr[t] = notTake || take;
                }

                prev = curr; // move current row to previous for next iteration
            }

            return prev[target];
        }

    }
}
