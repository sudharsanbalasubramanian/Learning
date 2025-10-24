using SharedProject.Extensions;

namespace DataStructureAndAlgorithm.Searching
{
    public partial class Searching
    {
        public static int AllocateMinimumPages(List<int> pages, int noOfStudents)
        {
            pages.ThrowIfNullOrEmpty(nameof(pages));

            if (noOfStudents > pages.Count)
            {
                return -1;
            }

            int low = pages.Max();

            int high = pages.Sum();

            int result = high;

            while (low <= high)
            {
                int mid = low + (high - low) / 2;

                if (IsPossible(pages, noOfStudents, mid))
                {
                    result = mid;
                    high = mid - 1;
                }
                else
                {
                    low = mid + 1;
                }
            }

            return result;
        }

        private static bool IsPossible(List<int> pages, int noOfStudents, int maxPages)
        {
            int studentCount = 1;
            int pageSum = 0;

            foreach (var p in pages)
            {
                if (pageSum + p > maxPages)
                {
                    studentCount++;
                    pageSum = p;

                    if (studentCount > noOfStudents)
                    {
                        return false;
                    }

                    return true;
                }

                pageSum += p;
            }

            return true;
        }
    }
}
