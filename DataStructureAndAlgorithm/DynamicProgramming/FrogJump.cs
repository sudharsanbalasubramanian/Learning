namespace DataStructureAndAlgorithm.DynamicProgramming
{
    public partial class DynamicProgrammingProblems
    {
        //https://www.geeksforgeeks.org/problems/geek-jump/1

        private readonly static Dictionary<int, int> _frogJumpMemo = [];

        public static int FrogJump(int index, List<int> heights)
        {

            if(_frogJumpMemo.TryGetValue(index, out var energy))
            {
                return energy;
            }


            if (index == 0)
            {
                _frogJumpMemo[index] = 0;

                return 0;
            }

            var oneJumpEnergy = FrogJump(index - 1, heights) + Math.Abs(heights[index] - heights[index - 1]);

            int secondJumpEnergy = int.MaxValue;

            if (index > 1)
            {
                secondJumpEnergy = FrogJump(index - 2, heights) + Math.Abs(heights[index] - heights[index - 2]);
            }


            _frogJumpMemo[index] = Math.Min(oneJumpEnergy, secondJumpEnergy);

            return _frogJumpMemo[index];
        }
    }
}
