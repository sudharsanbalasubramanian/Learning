using SharedProject.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureAndAlgorithm.Searching
{
    public partial class SearchingProblems
    {
        public static int CountOccurence(List<int> numbers, int val)
        {
            numbers.ThrowIfNullOrEmpty(nameof(numbers));

            var firstOccurence = FirstOccurrence(numbers, val);

            if(firstOccurence == -1)
            {
                return 0;
            }

            int lastOccurence = LastOccurrence(numbers, val);

            return lastOccurence - firstOccurence + 1;
        }
    }
}
