using SharedProject.Extensions;

namespace DataStructureAndAlgorithm.Searching
{
    public partial class SearchingProblems
    {
        public static int FindInsertionIndex(List<int> numbers, int val)
        {
            numbers.ThrowIfNullOrEmpty(nameof(numbers));

            int low = 0;
            int high = numbers.Count - 1;

            while (low <= high)
            {
                int mid = low + (high - low) / 2;

                if (numbers[mid] == val)
                {
                    return mid; // value found
                }
                else if (numbers[mid] < val)
                {
                    low = mid + 1; // move right
                }
                else
                {
                    high = mid - 1; // move left
                }
            }

            // value not found, low is the insertion index
            return low;
        }
    }
}
