namespace DataStructureAndAlgorithm.DynamicProgramming
{
    public partial class DynamicProgrammingProblems
    {
        public static int NinjaTraining(List<List<int>> points, int day, int lastPerformedTask)
        {
            int taskCount = points[0].Count;

            // Base case: first day
            if (day == 0)
            {
                int maxPoints = 0;

                for (int task = 0; task < taskCount; task++)
                {
                    if (task == lastPerformedTask)
                    {
                        continue;
                    }

                    maxPoints = Math.Max(maxPoints, points[0][task]);
                }

                return maxPoints;
            }

            int maxPoint = 0;

            for (int task = 0; task < taskCount; task++)
            {
                if (task == lastPerformedTask)
                {
                    continue;
                }

                int currentPoint = points[day][task] + NinjaTraining(points, day - 1, task);

                maxPoint = Math.Max(maxPoint, currentPoint);
            }

            return maxPoint;
        }

    }
}
