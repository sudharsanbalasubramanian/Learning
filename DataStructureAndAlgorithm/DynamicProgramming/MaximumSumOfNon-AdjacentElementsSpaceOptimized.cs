using SharedProject.Extensions;

namespace DataStructureAndAlgorithm.DynamicProgramming
{
    public partial class DynamicProgrammingProblems
    {
        public static int GetMaximumSumOfNonAdjacentElementsOptimized(List<int> numbers)
        {
            numbers.ThrowIfNullOrEmpty(nameof(numbers));

            int previous = numbers[0];

            int previous2 = 0;

            for (int i = 1; i < numbers.Count; i++)
            {
                int includeCurrent = numbers[i];

                if (i > 1)
                {
                    includeCurrent += previous2;
                }

                int excludeCurrent = previous;

                int currentMax = Math.Max(includeCurrent, excludeCurrent);

                previous2 = previous;

                previous = currentMax;
            }

            return previous;
        }

    }
}
