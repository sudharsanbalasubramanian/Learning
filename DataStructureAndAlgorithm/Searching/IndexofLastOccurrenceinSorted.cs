using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureAndAlgorithm.Searching
{
    public partial class SearchingProblems
    {
        public static int LastOccurrence(List<int> numbers, int val)
        {

            int low = 0;
            int high = numbers.Count - 1;

            while (low <= high)
            {
                int mid = low + (high - low) / 2;

                if (numbers[mid] == val)
                {
                    if (mid == numbers.Count - 1 || numbers[mid + 1] != numbers[mid])
                    {
                        return mid;
                    }
                    else
                    {
                        low = mid + 1; // Continue searching right
                    }
                }
                else if (numbers[mid] > val)
                {
                    high = mid - 1; // Move left ✅
                }
                else
                {
                    low = mid + 1; // Move right ✅
                }
            }

            return -1; // Better than default
        }

    }
}
