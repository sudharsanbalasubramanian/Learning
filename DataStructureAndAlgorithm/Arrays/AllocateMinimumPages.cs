using SharedProject.Extensions;

namespace DataStructureAndAlgorithm.Arrays
{
    public partial class ArrayProblems
    {
        public static int AllocateMinimumPages(List<int> pages, int noOfStudents)
        {
            pages.ThrowIfNullOrEmpty(nameof(pages));

            // ✅ Edge case checks
            if (noOfStudents > pages.Count)
            {
                return -1;
            }

            // Step 1️⃣: Define search space
            // Lowest possible answer = largest single book (at least one student gets this)
            int low = pages.Max();

            // Highest possible answer = sum of all pages (one student gets all)
            int high = pages.Sum();

            // Variable to store the best (minimum possible) maximum pages
            int result = high;

            // Step 2️⃣: Binary Search on the answer space
            while (low <= high)
            {
                // mid represents the maximum number of pages a student can be assigned
                int mid = low + (high - low) / 2;

                // Step 3️⃣: Check if it's possible to allocate books
                // such that no student reads more than 'mid' pages
                if (IsPossible(pages, noOfStudents, mid))
                {
                    // ✅ If possible, store the result
                    result = mid;

                    // Try to minimize further (check left side)
                    high = mid - 1;
                }
                else
                {
                    // ❌ Not possible with this 'mid'
                    // Need to increase limit (move right)
                    low = mid + 1;
                }
            }

            // Step 4️⃣: Return the minimum of all possible max values
            return result;
        }

        // Helper method to check feasibility for given maxPages
        private static bool IsPossible(List<int> pages, int noOfStudents, int maxPages)
        {
            int studentCount = 1;  // start with 1st student
            int pageSum = 0;       // track current student's total pages

            foreach (var p in pages)
            {
                // If adding this book exceeds max limit
                if (pageSum + p > maxPages)
                {
                    // Allocate to next student
                    studentCount++;
                    pageSum = p;  // start new sum for next student

                    // If we exceed the total number of students allowed
                    if (studentCount > noOfStudents)
                    {
                        return false;  // allocation not possible
                    }
                }
                else
                {
                    // Else, continue adding to current student
                    pageSum += p;
                }
            }

            // ✅ Allocation possible within given 'maxPages'
            return true;
        }
    }
}
