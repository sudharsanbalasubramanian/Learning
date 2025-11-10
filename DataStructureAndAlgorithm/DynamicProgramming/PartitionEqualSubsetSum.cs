using SharedProject.Extensions;

namespace DataStructureAndAlgorithm.DynamicProgramming
{
    public partial class DynamicProgrammingProblems
    {
        public static bool PartitionEqualSubsetSum(List<int> list, int target)
        {
            var sum = list.Sum();

            if(sum.IsOdd())
            {
                return false;
            }
            return SubsetSumEqualsToTargetSpaceOptimized(list, sum / 2);
        }
    }
}
