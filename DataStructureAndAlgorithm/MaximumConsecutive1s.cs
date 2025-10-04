using SharedProject.Extensions;

namespace DataStructureAndAlgorithm
{
    public partial class ArrayProblems
    {
        public static int MaximumConsecutive1s(List<int> list)
        {
            list.ThrowIfNullOrEmpty();

            int res = 0;
            int curRes = 0;

            foreach (var value in list)
            {
                if (value == 0)
                {
                    curRes = 0;
                }
                else
                {
                    curRes++;
                    res = Math.Max(curRes, res);
                }
            }

            return res;
        }
    }
}
