namespace DataStructureAndAlgorithm.Searching
{
    public partial class SearchingProblems
    {
        public static int SquareRoot(int value)
        {
            if (value < 0)
            {
                throw new ArgumentException("Square root of negative number is not defined");
            }

            if (value == 0 || value == 1)
            {
                return value;
            }

            int low = 0;
            int high = value;
            int result = 0;

            while (low <= high)
            {
                int mid = low + (high - low) / 2;

                long squaredValue = (long)mid * mid; 

                if (squaredValue == value)
                {
                    return mid; // perfect square
                }
                else if (squaredValue < value)
                {
                    result = mid; // store closest lower integer

                    low = mid + 1;
                }
                else
                {
                    high = mid - 1;
                }
            }

            return result; // integer part of square root
        }

    }
}
