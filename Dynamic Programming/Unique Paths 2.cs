/// <summary>
/// LC - 63: Unique Paths 2
/// 
/// TC/ SC: same as Unique Paths 1
/// </summary>
namespace Dynamic_Programming
{
    internal class Unique_Paths_2
    {
        private static int[,] dp;
        public static int func(int[][] grid, int m, int n)
        {
            //return countPaths(grid, m - 1, n - 1);

            //dp = new int[m, n];
            //return dpApp(grid, m - 1, n - 1);

            return tabulationApproach(grid, m-1, n-1);
        }

        public static int countPaths(int[][] grid, int m, int n)
        {
            if (m >= 0 && n >= 0 && grid[m][n] == 1) return 0;
            if (m == 0 && n == 0) return 1;
            if (m < 0 || n < 0) return 0;

            int up = countPaths(grid, m - 1, n);
            int left = countPaths(grid, m, n - 1);
            return up + left;
        }

        public static int dpApp(int[][] grid, int m, int n)
        {
            if (m >= 0 && n >= 0 && grid[m][n] == 1) return 0;
            if (m == 0 && n == 0) return 1;
            if (m < 0 || n < 0) return 0;

            if (dp[m, n] != 0)
                return dp[m, n];

            int up = dpApp(grid, m - 1, n);
            int left = dpApp(grid, m, n - 1);
            return dp[m, n] = up + left;
        }

        public static int tabulationApproach(int[][] grid, int m, int n)
        {
            int[,] dpA = new int[m, n];

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (grid[m][n] == 1)
                        dpA[i, j] = 0;
                    else if (i == 0 || j == 0)
                        dpA[i, j] = 1;
                    else
                    {
                        int up = dpA[i - 1, j];
                        int left = dpA[i, j - 1];
                        dpA[i, j] = up + left;
                    }
                }
            }
            return dpA[m - 1, n - 1];
        }

        public static void Main(string[] args)
        {
            int row = 3, col = 3;
            int[][] grid =
            {
                new int[] { 0,0,0 },
                new int[] { 0,1,0 },
                new int[] { 0,0,0 }
            };
            Console.WriteLine("Number of ways to reach the end of the maze: {0}", func(grid, row, col));
        }
    }
}
