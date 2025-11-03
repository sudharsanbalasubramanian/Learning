namespace DataStructureAndAlgorithm.DynamicProgramming
{
    public partial class DynamicProgrammingProblems
    {
        private static readonly Dictionary<int, int> _maxSumOfNonAdjacentElementMemo = [];

        public static int MaximumSumOfNon_AdjacentElements(int index, List<int> elements)
        {
            if (index == -1)
            {
                return 0;
            }

            if (index == 0)
            {
                return elements[index];
            }

            if (_maxSumOfNonAdjacentElementMemo.TryGetValue(index, out var cached))
            {
                return cached;
            }

            var pick = elements[index] + MaximumSumOfNon_AdjacentElements(index - 2, elements);

            var notPick = MaximumSumOfNon_AdjacentElements(index - 1, elements);

            return _maxSumOfNonAdjacentElementMemo[index] = Math.Max(pick, notPick);
        }

    }
}
