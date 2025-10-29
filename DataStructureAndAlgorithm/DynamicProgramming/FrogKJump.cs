namespace DataStructureAndAlgorithm.DynamicProgramming
{
    public partial class DynamicProgrammingProblems
    {
        public static int FrogKJump(int currentIndex, List<int> heights, int maxJump)
        {
            if (currentIndex == 0)
            {
                return 0;
            }

            int minEnergyRequired = int.MaxValue;

            for (int jump = 1; jump <= maxJump; jump++)
            {
                if (currentIndex - jump >= 0)
                {
                    int jumpEnergy = FrogKJump(currentIndex - jump, heights, maxJump)
                                     + Math.Abs(heights[currentIndex] - heights[currentIndex - jump]);

                    minEnergyRequired = Math.Min(minEnergyRequired, jumpEnergy);
                }
            }

            return minEnergyRequired;
        }


    }
}
