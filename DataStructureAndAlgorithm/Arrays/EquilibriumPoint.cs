using SharedProject.Extensions;

namespace DataStructureAndAlgorithm.Arrays
{
    public partial class ArrayProblems
    {

        public static int EquilibriumPoint(List<int> values)
        {
            values.ThrowIfNullOrEmpty(nameof(values));

            int totalSum = values.Sum();
            int leftSum = 0;

            for (int i = 0; i < values.Count; i++)
            {
                int rightSum = totalSum - leftSum - values[i];

                if (leftSum == rightSum)
                {
                    return i; // Equilibrium index found
                }

                leftSum += values[i];
            }

            return -1; // No equilibrium index
        }
    }
}
