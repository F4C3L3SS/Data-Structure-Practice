/// <summary>
/// Merge overlapping intervals
/// 
/// 1. sort the array based on first element in each array
/// 2. keep track of previous and current just to avoid changing the original array
/// 3. if first element of current <= second element of previous ([1,3] [2,4]  3 >= 2) 
///    then we assign the smallest of 2nd elements in both the arrays Max of (3,4)
/// 4. otherwise. update previous with current array and add the previous array to the list (since that is the updated one)
/// </summary>
namespace Arrays
{
    internal class Merge_Overlapping_Intervals
    {
        static List<int[]> res = new();

        public static int[][] MergeIntervals(int[][] arr)
        {
            arr = arr.OrderBy(x => x[0]).ToArray();

            int[]? previous = null;

            for(int i = 0; i < arr.Length; i++)
            {
                int[] current = arr[i];
                if(previous != null && current[0] <= previous[1])
                {
                    previous[1] = Math.Max(current[1], previous[1]);
                }
                else
                {
                    previous = current;
                    res.Add(previous);
                }
            }
            return res.ToArray();
        }

        public static void printArray(int[][] arr)
        {
            int length = arr.Length;
            
            for (int i = 0; i < length; i++)
            {
                Console.Write("[");
                for (int j = 0; j < arr[i].Length; j++)
                {
                    Console.Write(arr[i][j] + " ");
                }
                Console.Write("]");
            }
        }

        public static void Main(string[] args)
        {
            int[][] arr = new int[][] {
               new int[] {1,3},
               new int[] {2,6},
               new int[] {8,10},
               new int[] {15,18}
            };

            int[][] res = MergeIntervals(arr);
            printArray(res);
        }
    }
}
