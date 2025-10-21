namespace DataStructureAndAlgorithm.Arrays
{
    public partial class ArrayProblems
    {
        public static int MaxAppearingElement(int[] L, int[] R)
        {
            int n = L.Length;
            int maxRight = R.Max();

            // Step 1: create frequency array
            int[] freq = new int[maxRight + 2];

            // Step 2: mark starts and ends
            for (int i = 0; i < n; i++)
            {
                freq[L[i]]++;
                freq[R[i] + 1]--;
            }

            // Step 3: prefix sum + find max
            int maxFreq = freq[0];
            int res = 0;

            for (int i = 1; i <= maxRight; i++)
            {
                freq[i] += freq[i - 1];

                if (freq[i] > maxFreq)
                {
                    maxFreq = freq[i];
                    res = i;
                }
            }

            return res;
        }

    }
}
