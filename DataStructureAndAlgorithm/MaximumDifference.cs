using SharedProject.Extensions;

namespace DataStructureAndAlgorithm
{
    public partial class ArrayProblems
    {
        public static int MaximumDifference(List<int> list)
        {
            list.ThrowIfNullOrEmpty();

            int minVal = list[0];

            int difference = int.MinValue;

            for(int i = 1; i < list.Count; i++)
            {
                difference = Math.Max(difference, list[i] - minVal);

                minVal = Math.Min(minVal, list[i]);
            }

            return difference;
        }

    }
}
