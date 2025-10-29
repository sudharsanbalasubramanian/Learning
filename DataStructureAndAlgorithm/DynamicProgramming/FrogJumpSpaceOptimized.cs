using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructureAndAlgorithm.DynamicProgramming
{
    public partial class DynamicProgrammingProblems
    {
        //https://www.geeksforgeeks.org/problems/geek-jump/1

        public static int FrogJumpOptimized(List<int> heights)
        {
            int prev = 0, prev2 = 0;

            for (int i = 1; i < heights.Count; i++)
            {
                int oneStep = prev + Math.Abs(heights[i] - heights[i - 1]);
                int twoStep = int.MaxValue;

                if (i > 1)
                {
                    twoStep = prev2 + Math.Abs(heights[i] - heights[i - 2]);
                }

                int curr = Math.Min(oneStep, twoStep);
                prev2 = prev;
                prev = curr;
            }

            return prev;
        }
    }
}
