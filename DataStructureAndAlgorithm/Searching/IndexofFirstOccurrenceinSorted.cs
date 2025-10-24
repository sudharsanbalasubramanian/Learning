using SharedProject.Extensions;

namespace DataStructureAndAlgorithm.Searching
{
    public partial class Searching
    {
        public static int FirstOccurrence(List<int> numbers, int val)
        {
            numbers.ThrowIfNullOrEmpty(nameof(numbers));

            int low = 0;
            int high = numbers.Count - 1;

            while (low <= high)
            {
                int mid = low + (high - low) / 2;

                if (numbers[mid] > val)
                {
                    high = mid - 1;
                }
                else if (numbers[mid] < val)
                {
                    low = mid + 1;
                }
                else
                {
                    if (mid == 0 || numbers[mid - 1] != numbers[mid])
                    {
                        return mid;
                    }
                    else
                        high = mid - 1;
                }
            }

            return -1;
        }

    }
}
