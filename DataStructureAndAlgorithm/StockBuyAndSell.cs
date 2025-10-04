using SharedProject.Extensions;

namespace DataStructureAndAlgorithm
{
    public partial class ArrayProblems
    {
        public static int StockBuyAndSell(List<int> values)
        {
            values.ThrowIfNullOrEmpty();

            var profit = 0;

            for (int i = 1; i < values.Count; i++)
            {
                if (values[i] > values[i - 1])
                {
                    profit += values[i] - values[i - 1];
                }
            }

            return profit;
        }
    }
}
 