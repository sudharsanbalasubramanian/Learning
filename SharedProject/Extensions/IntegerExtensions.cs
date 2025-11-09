namespace SharedProject.Extensions
{
    public static class IntegerExtensions
    {
        public static bool IsEven(this int value)
        {
            return value % 2 == 0;
        }

        public static bool IsOdd(this int value)
        {
            return value % 2 == 1;
        }

        public static int MinOfThree(this int a, int b, int c)
        {
            return Math.Min(a, Math.Min(b, c));
        }
    }
}
