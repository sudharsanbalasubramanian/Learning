using SharedProject.Extensions;

namespace DataStructureAndAlgorithm
{
    public partial class ArrayProblems
    {
        public static IEnumerable<int> Leaders(List<int> values)
        {
            values.ThrowIfNullOrEmpty();

            Stack<int> leaders = [];

            int lastElement = values[^1];

            leaders.Push(lastElement);

            for(int i = values.Count - 2; i >= 0; i -= 1)
            {
                var largestSoFar = leaders.Peek();

                if(largestSoFar < values[i])
                {
                    leaders.Push(values[i]);
                }
            }

            return leaders.Reverse();
        }
    }
}
