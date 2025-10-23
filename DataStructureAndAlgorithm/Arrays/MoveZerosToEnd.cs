using SharedProject.Extensions;

namespace DataStructureAndAlgorithm.Arrays
{
    public partial class ArrayProblems
    {
        public static void MoveZeroToEnd(List<int> values)
        {
            values.ThrowIfNullOrEmpty(nameof(values));

            int countOfZero = 0;

            for(int i = 0; i < values.Count; i++)
            {
                if(values[i] != 0)
                {
                    (values[i], values[countOfZero]) = (values[countOfZero], values[i]);
                    countOfZero += 1;
                }
            }

        }
    }
}
