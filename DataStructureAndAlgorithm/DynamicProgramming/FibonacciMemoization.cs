namespace DataStructureAndAlgorithm.DynamicProgramming
{
    public partial class DynamicProgrammingProblems
    {
        public static readonly Dictionary<int, int> _memo = [];
        public static int Fibonacci(int n)
        {
            if(_memo.TryGetValue(n, out int val))
            {
                return val;
            }

            if(n == 0 || n == 1)
            {
                _memo[n] = n;

                return n;
            }

            _memo[n] = Fibonacci(n - 1) + Fibonacci(n - 2);

            return _memo[n];
        }
    }
}
