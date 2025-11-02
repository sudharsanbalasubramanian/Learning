using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureAndAlgorithm.DynamicProgramming
{
    public partial class DynamicProgrammingProblems
    {
        public static int NinjaTrainingSpaceOptimized(List<List<int>> points)
        {
            int dayCount = points.Count;
            int taskCount = points[0].Count;

            int[] prev = new int[taskCount + 1];
            int[] curr = new int[taskCount + 1];

            // Base case: Day 0
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

                prev[last] = maxPoints;
            }

            // Fill from Day 1 onward
            for (int day = 1; day < dayCount; day++)
            {
                for (int last = 0; last <= taskCount; last++)
                {
                    int maxPoints = 0;

                    for (int task = 0; task < taskCount; task++)
                    {
                        if (task != last)
                        {
                            int currentPoints = points[day][task] + prev[task];
                            maxPoints = Math.Max(maxPoints, currentPoints);
                        }
                    }

                    curr[last] = maxPoints;
                }

                // Move current day to previous for next iteration
                Array.Copy(curr, prev, taskCount + 1);
            }

            // Final answer — last day, no restriction
            return prev[taskCount];
        }

    }
}
