using SharedProject.Extensions;

namespace DataStructureAndAlgorithm
{
    public partial class ArrayProblems
    {
        public static void LeftRotate<T>(List<T> values, int d)
        {
            ArgumentOutOfRangeException.ThrowIfLessThan(d, 0);

            values.ThrowIfNullOrEmpty();

            d %= values.Count;

            if(d == 0)
            {
                return;
            }

            values.Reverse(0, d);

            values.Reverse(d, values.Count - d);

            values.Reverse();
        }
    }
}
