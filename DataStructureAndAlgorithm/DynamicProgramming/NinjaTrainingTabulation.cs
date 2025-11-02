using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureAndAlgorithm.DynamicProgramming
{
    public partial class DynamicProgrammingProblems
    {
        public static int NinjaTrainingTabulation(List<List<int>> points)
        {
            int dayCount = points.Count;
            int taskCount = points[0].Count;

            int[,] dp = new int[dayCount, taskCount + 1];

            // Base case - Day 0
            for (int last = 0; last <= taskCount; last++)
            {
                int maxPoints = 0;

                for (int task = 0; task < taskCount; task++)
                {
                    if (task != last)
                    {
                        maxPoints = Math.Max(maxPoints, points[0][task]);
                    }
                }

                dp[0, last] = maxPoints;
            }

            // Fill DP table for remaining days
            for (int day = 1; day < dayCount; day++)
            {
                for (int last = 0; last <= taskCount; last++)
                {
                    int maxPoints = 0;

                    for (int task = 0; task < taskCount; task++)
                    {
                        if (task != last)
                        {
                            int currentPoints = points[day][task] + dp[day - 1, task];
                            maxPoints = Math.Max(maxPoints, currentPoints);
                        }
                    }

                    dp[day, last] = maxPoints;
                }
            }

            // Final answer = max points on the last day with no restriction
            return dp[dayCount - 1, taskCount];
        }

    }
}
