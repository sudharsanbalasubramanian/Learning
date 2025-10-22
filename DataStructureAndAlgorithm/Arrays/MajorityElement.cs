using SharedProject.Extensions;

namespace DataStructureAndAlgorithm.Arrays
{
    public partial class ArrayProblems
    {
        public static int MajorityElement(List<int> elements)
        {
            elements.ThrowIfNullOrEmpty(nameof(elements));

            // Step 1: Find candidate
            int candidate = elements[0];
            int count = 1;

            for (int i = 1; i < elements.Count; i++)
            {
                if (elements[i] == candidate)
                {
                    count++;
                }
                else
                {
                    count--;
                }

                if (count == 0)
                {
                    candidate = elements[i];
                    count = 1;
                }
            }

            // Step 2: Verify candidate
            count = 0;
            foreach (var num in elements)
            {
                if (num == candidate)
                {
                    count++;
                }
            }

            return count > elements.Count / 2 ? candidate : 0; // return 0 if no majority
        }


    }
}
