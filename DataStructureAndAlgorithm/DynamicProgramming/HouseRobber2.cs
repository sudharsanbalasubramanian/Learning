using SharedProject.Extensions;

namespace DataStructureAndAlgorithm.DynamicProgramming
{
    public partial class DynamicProgrammingProblems
    {
        public static int HouseRobber(List<int> moneys)
        {
            moneys.ThrowIfNullOrEmpty(nameof(moneys));


            var maxAmountExcludingLastHome = GetMaximumSumOfNonAdjacentElementsOptimized(moneys[..^1]);

            var maxAmountExcludingFirstHome = GetMaximumSumOfNonAdjacentElementsOptimized(moneys[1..]);

            return Math.Max(maxAmountExcludingFirstHome, maxAmountExcludingLastHome);
        }

    }
}
