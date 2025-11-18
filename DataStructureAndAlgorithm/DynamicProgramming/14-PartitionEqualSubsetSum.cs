using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureAndAlgorithm.DynamicProgramming
{
    public partial class DynamicProgrammingProblems
    {
        public static bool PartitionEqualSubsetSum(int[] arr)
        {
            int total = arr.Sum();

            // If total is odd → cannot split equally
            if (total % 2 != 0)
            {
                return false;
            }

            int target = total / 2;

            return IsSubsetSumOptimized(target, [.. arr]);
        }
    }
}
