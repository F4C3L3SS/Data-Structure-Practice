/// <summary>
/// LC: 62 - Unique Paths
/// 
/// Brute Force:
/// Count all the paths
/// 
/// Dp Approach: 
/// count the paths up and left (only 2 ways we can move in a cell)
/// TC: O(2^m*n)
/// SC: O(path length) 
/// where path length = O((m-1) + (n - 1))
/// 
/// Tabulation approach
/// TC: O(M*N)
/// SC: O(M*N)
/// </summary>

namespace Dynamic_Programming
{
    internal class Unique_Paths
    {
        private static int[,] dp;
        public static int func(int m, int n)
        {
            //return countPaths(m - 1, n - 1);

            dp = new int[m, n];
            return dpApp(m - 1, n - 1);

            //return tabulationApproach(m, n);
        }

        public static int countPaths(int m, int n)
        {
            if (m == 0 && n == 0) return 1;
            if (m < 0 || n < 0) return 0;

            int up = countPaths(m - 1, n);
            int left = countPaths(m, n - 1);
            return up + left;
        }

        public static int dpApp(int m, int n)
        {
            if (m == 0 && n == 0) return 1;
            if (m < 0 || n < 0) return 0;

            if (dp[m, n] != 0)
                return dp[m, n];

            int up = dpApp(m - 1, n);
            int left = dpApp(m, n - 1);
            return dp[m,n] = up + left;
        }

        public static int tabulationApproach(int m, int n)
        {
            int[,] dp = new int[m, n];

            for(int i = 0; i < m; i++)
            {
                for(int j = 0; j < n; j++)
                {
                    if (i == 0 || j == 0)
                        dp[i,j] = 1;
                    else
                    {
                        int up = dp[i - 1, j];
                        int left = dp[i, j - 1];
                        dp[i, j] = up + left;
                    }
                }
            }
            return dp[m - 1, n - 1];
        }

        public static void Main(string[] args)
        {
            int row = 3, col = 3;
            Console.WriteLine("Number of ways to reach the end of the maze: {0}", func(row, col));
        }
    }
}
