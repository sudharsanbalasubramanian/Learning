using SharedProject.Extensions;

namespace DataStructureAndAlgorithm
{
    public partial class ArrayProblems
    {
        public static Dictionary<int, int> Frequencies(List<int> values)
        {
            values.ThrowIfNullOrEmpty();

            var dict = new Dictionary<int, int>();

            foreach (var value in values)
            {
                dict.TryGetValue(value, out int count);

                dict[value] = count + 1;
            }

            return dict;
        }
    }
}
