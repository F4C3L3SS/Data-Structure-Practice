/// <summary>
/// LC 198
/// 
/// Brute Force Approach:
/// look for all combinations in which you can chose to commit the robbery
/// time complexity: O(N^2)
/// space complexity: O(N)
/// 
/// Optimal Approach: 
/// we have pick or non-pick choices for all the houses
/// start with first index (0th)
/// pick it -> add the value and add index + 2, (we cannot pick adjacent)
/// non-pick -> just increment the index + 1
/// TC: O(N)
/// Space Complexity: O(N) + O(N) [recursion stack space + cache space]
/// 
/// optimized tabulation approach:
/// we optimize space, instead of using the array,
/// we use 2 variables to store previous 2 values only
/// and compute further results
/// TC: O(N)
/// Space complexity: O(1)
/// </summary>
namespace Dynamic_Programming
{
    internal class House_Robber
    {
        private static int[]? cache;

        public static int Rob(int[] nums)
        {
            cache = new int[nums.Length];
            //return Func(0, nums);
            //return Tabulation(nums);
            return optimizedTabulation(nums);
        }

        public static int Func(int i, int[] nums)
        {
            if (i >= nums.Length)
                return 0;

            if (cache[i] != 0)
                return cache[i];

            int pick = nums[i] + Func(i + 2, nums);
            int notPick = Func(i + 1, nums);

            cache[i] = Math.Max(pick, notPick);
            return cache[i];
        }

        public static int Tabulation(int[] nums)
        {
            int[] dp = new int[nums.Length + 1];
            dp[nums.Length] = 0;
            dp[nums.Length - 1] = nums[nums.Length - 1];
            for (int i = nums.Length - 2; i >= 0; i--)
            {
                int pick = nums[i] + dp[i + 2];
                int notPick = dp[i + 1];
                dp[i] = Math.Max(pick, notPick);
            }

            return dp[0];
        }

        // .   .  .
        // i-2 i-1 i , at one step i, we only need 2 prev values,
        // pr2 pr  cur
        public static int optimizedTabulation(int[] nums)
        {
            int prev2 = 0;
            int prev = nums[nums.Length - 1];

            for (int i = nums.Length - 2; i >= 0; i--)
            {
                int pick = nums[i] + prev2;
                int notPick = prev;

                int cur = Math.Max(pick, notPick);
                prev2 = prev;
                prev = cur;
            }

            return prev;
        }

        public static void Main(string[] args)
        {
            int[] nums = new int[] { 2, 7, 9, 3, 1 };
            Console.WriteLine("Maximum money robbed: {0}", Rob(nums));
        }
    }
}
