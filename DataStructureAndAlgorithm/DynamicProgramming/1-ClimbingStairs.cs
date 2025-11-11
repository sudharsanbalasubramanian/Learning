namespace DataStructureAndAlgorithm.DynamicProgramming
{
    public partial class DynamicProgrammingProblems
    {
        //https://takeuforward.org/plus/dsa/problems/climbing-stairs

        private static readonly Dictionary<int, int> _climbStairsMemo = [];

        public static int ClimbStairs(int n)
        {
            if(_climbStairsMemo.TryGetValue(n, out var value))
            {
                return value;
            }

            if(n == 0 || n == 1)
            {
                return 1;
            }

            return _climbStairsMemo[n] = ClimbStairs(n - 1) + ClimbStairs(n - 2);
        }

        public static int ClimbStairsTabulation(int n)
        {
            if (n == 0 || n == 1)
            {
                return 1;
            }

            int[] dp = new int[n + 1];
            dp[0] = 1;
            dp[1] = 1;

            for (int i = 2; i <= n; i++)
            {
                dp[i] = dp[i - 1] + dp[i - 2];
            }

            return dp[n];
        }


        public static int ClimbStairsSpaceOptimized(int n)
        {
            if (n == 0 || n == 1)
            {
                return 1;
            }

            int prev = 1; // ways to reach step 0
            int cur = 1;  // ways to reach step 1

            for (int i = 2; i <= n; i++)
            {
                int next = prev + cur;
                prev = cur;
                cur = next;
            }

            return cur;
        }

    }
}
