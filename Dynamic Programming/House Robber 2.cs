/// <summary>
/// LC 213, House Robber 2 (cannot pick adjacent and last & first house are adjacent)
/// </summary>
namespace Dynamic_Programming
{
    internal class House_Robber_2
    {
        public static int rob(int[] nums)
        {
            int n = nums.Length;
            // Handle the case with the single house
            if (n == 1) return nums[0];

            int[] temp1 = new int[n];
            int[] temp2 = new int[n];

            for(int i = 0; i < n; i++)
            {
                if (i != 0) temp1[i] = nums[i];
                if (i != n - 1) temp2[i] = nums[i];
            }

            //return Math.Max(solve(temp1), solve(temp2));

            return Math.Max(optimizeSolve(temp1), optimizeSolve(temp2));
        }

        // Consumes the house robber 1 solution only
        public static int solve(int[] nums)
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

        public static int optimizeSolve(int[] nums)
        {
            int n = nums.Length;
            int prev2 = 0;
            int prev = nums[n - 1];

            for(int i = n - 2; i >= 0; i--)
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
            int[] nums = new int[] { 6, 6, 4, 8, 4, 3, 3, 10 };
            Console.WriteLine("Maximum robbed money: {0}", rob(nums));
        }
    }
}
