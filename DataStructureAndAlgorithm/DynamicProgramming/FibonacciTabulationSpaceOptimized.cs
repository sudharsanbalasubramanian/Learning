namespace DataStructureAndAlgorithm.DynamicProgramming
{
    public partial class DynamicProgrammingProblems
    {
        public static int FibonacciTabulationSpaceOptimized(int n)
        {
            ArgumentOutOfRangeException.ThrowIfLessThan(n, 0);

            if (n == 0 || n == 1)
            {
                return n;
            }


            int prev2 = 0;
            int prev1 = 1;

            for(int i = 2; i < n; i++)
            {
                var cur = prev2 + prev1;

                prev2 = prev1;
                prev1 = cur;
            }

            return prev1;
        }
    }
}
