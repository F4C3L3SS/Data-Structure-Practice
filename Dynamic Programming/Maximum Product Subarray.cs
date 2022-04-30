/// <summary>
/// Maximum Product Subarray
/// 
/// BruteForce: O(n^2)
/// We just compute the product of all the possible sub arrays in the given array
/// and keep track of the maximum product
/// 
/// Optimal approach: O(n)
/// Keep track of both maximum product so far and minimum product so far
/// max_so_far: Max(current number, currentNumber * max_so_far, currentNumber * min_so_far)
/// min_so_far: Max(current number, currentNumber * max_so_far, currentNumber * min_so_far)
/// 
/// we are keeping track of min_so_far, coz we need to handle negative numbers separately,
/// think of all negative case,
/// Also, we are including the current number in case of computing min_so_far & max_so_far 
/// so as to handle zero [0,4], or [-3,5]
/// </summary>
namespace Dynamic_Programming
{
    internal class Maximum_Product_Subarray
    {
        private static int MaxProductSubarray(int[] nums)
        {
            if (nums.Length == 0)
                return 0;
            
            int min_so_far = nums[0];
            int max_so_far = nums[0];
            int result = max_so_far;

            for (int i = 1; i < nums.Length; i++)
            {
                int curr = nums[i];
                // we are keeping track of old max_so_far in max_so_far, and keeping track of new max in tempmaxsofar
                int tempMaxSoFar = Math.Max(Math.Max(curr, max_so_far * curr), min_so_far * curr);
                min_so_far = Math.Min(Math.Min(curr, max_so_far * curr), min_so_far * curr);

                max_so_far = tempMaxSoFar;

                result = Math.Max(result, max_so_far);
            }

            return result;

        }
        public static void Main(string[] args)
        {
            //int[] nums = new int[] { 2, 3, -2, 4 };
            //int[] nums = new int[] { -2, -3, -2, -4 };
            int[] nums = new int[] { -2, -3, -2, -4, 0, 96 };
            Console.WriteLine("Maximum Product in the array is :{0}", MaxProductSubarray(nums));
        }
    }
}
