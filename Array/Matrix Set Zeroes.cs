/// <summary>
/// Set Matrix row/column to zeroes wherever we encounter a zero in matrix
/// 
/// Help Link:
/// https://takeuforward.org/data-structure/set-matrix-zero/
/// </summary>
namespace Arrays
{
    internal class Matrix_Set_Zeroes
    {
        private static int[][]? mat;

        public static void SetZeroesUsingHashSet()
        {
            int r = mat.Length;
            int c = mat[0].Length;
            

            HashSet<int> rows = new HashSet<int>();
            HashSet<int> cols = new HashSet<int>();

            for(int i = 0; i < r; i++)
            {
                for(int j = 0; j < c; j++)
                {
                    if(mat[i][j] == 0)
                    {
                        rows.Add(i);
                        cols.Add(j);
                    }
                }
            }

            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    if (rows.Contains(i) || cols.Contains(j))
                    {
                        mat[i][j] = 0;
                    }
                }
            }
        }

        public static void SetZeroesInPlace()
        {
            int col0 = 1, r = mat.Length, c = mat[0].Length;

            for(int i = 0; i < r; i++)
            {
                if (mat[i][0] == 0) col0 = 0; // if any zero is encountered in first column, set first cell as 0
                for(int j = 1; j < c; j++)
                {
                    if (mat[i][j] == 0)
                        mat[i][0] = mat[0][j] = 0; // where we encounter 0, we set its respective index in first colmn/row as 0
                }
            }

            // now traverse from backwards, since we are keeping track of 0 in first cell

            for(int i = r - 1; i >= 0; i--)
            {
                for(int j = c - 1; j >= 1; j--)
                {
                    if (mat[i][0] == 0 || mat[0][j] == 0)
                        mat[i][j] = 0; // now we fill rest of the array with 0 based on the first colmn/row
                }
                if (col0 == 0)
                    mat[i][0] = 0;
            }
        }

        public static void printMatrix()
        {
            int r = mat.Length;
            int c = mat[0].Length;

            for (int i = 0; i < r; i++)
            {
                Console.WriteLine();
                for (int j = 0; j < c; j++)
                {
                    Console.Write(mat[i][j] + " ");
                }
            }
        }

        public static void SetZeroesHelper(int choice)
        {
            if (choice == 1) SetZeroesUsingHashSet();
            SetZeroesInPlace();
        }

        public static void Main(string[] args)
        {
            
            mat = new int[][] {
                new int[] { 0, 1, 2, 0 },
                new int[]{ 3, 4, 5, 2 },
                new int[]{ 1, 3, 1, 5 }
            };
            Console.WriteLine("before setting zeroes: ");
            printMatrix();
            SetZeroesHelper(2);
            Console.WriteLine("\nafter setting zeroes: ");
            printMatrix();

        }
    }
}
