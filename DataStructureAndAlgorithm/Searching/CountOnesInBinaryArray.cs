using SharedProject.Extensions;

namespace DataStructureAndAlgorithm.Searching
{
    public partial class SearchingProblems
    {
        public static int CountOnesInBinaryArray(List<int> numbers)
        {
            numbers.ThrowIfNullOrEmpty(nameof(numbers));

            int low = 0;

            int high = numbers.Count - 1;

            while(low <= high)
            {
                int mid = low + (high - low) / 2;

                if (numbers[mid] == 0)
                {
                    low = mid + 1;
                }

                else 
                {
                    if(mid == 0 || numbers[mid - 1] == 0)
                    {
                        return mid;
                    }
                    else
                    {
                        high = mid - 1;
                    }
                }
            }

            return -1;
        }
    }
}
