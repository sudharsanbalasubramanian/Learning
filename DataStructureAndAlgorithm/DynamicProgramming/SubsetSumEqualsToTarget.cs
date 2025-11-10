
using SharedProject.Extensions;

namespace DataStructureAndAlgorithm.DynamicProgramming
{
    public partial class DynamicProgrammingProblems
    {
        public static bool SubsetSumEqualsToTarget(List<int> list, int target)
        {
            int n = list.Count;
            bool?[,] dp = new bool?[n, target + 1]; // index x target

            return SubsetSumEqualsToTarget(list, target, n - 1, dp);
        }

        private static bool SubsetSumEqualsToTarget(List<int> list, int target, int index, bool?[,] dp)
        {
            if (target == 0)
            {
                return true;
            }

            if (index == 0)
            {
                return list[0] == target;
            }

            if (dp[index, target].HasValue)
            {
                return dp[index, target]!.Value;
            }

            bool takeCurrent = false;
            if (target >= list[index])
            {
                takeCurrent = SubsetSumEqualsToTarget(list, target - list[index], index - 1, dp);
            }

            bool notTakeCurrent = SubsetSumEqualsToTarget(list, target, index - 1, dp);

            dp[index, target] = takeCurrent || notTakeCurrent;

            return dp[index, target]!.Value;
        }

    }
}
