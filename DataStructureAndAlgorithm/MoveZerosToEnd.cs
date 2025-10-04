using SharedProject.Extensions;

namespace DataStructureAndAlgorithm
{
    public partial class ArrayProblems
    {
        public static void MoveZeroToEnd(List<int> list)
        {
            list.ThrowIfNullOrEmpty();

            int nonZeroElementCount = 0;

            for (int i = 0; i < list.Count; i++)
            {
                if (list[i] != 0)
                {
                    if (i != nonZeroElementCount)
                    {
                        list.Swap(i, nonZeroElementCount);
                    }

                    nonZeroElementCount++;
                }
            }
        }
    }
}
