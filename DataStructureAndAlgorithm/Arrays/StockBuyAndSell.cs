using SharedProject.Extensions;

namespace DataStructureAndAlgorithm.Arrays
{
    public partial class ArrayProblems
    {
        public static int StockBuyAndSell(List<int> list)
        {
            list.ThrowIfNullOrEmpty(nameof(list));

            var totalProfit = 0;

            for (int i = 1; i < list.Count; i++)
            {
                var profit = list[i] - list[i - 1];

                if(profit > 0)
                {
                    totalProfit += profit;
                }
            }

            return totalProfit;
        }

    }
}
