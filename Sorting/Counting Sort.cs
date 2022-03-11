/// <summary>
/// Counting sort
/// 
/// Time complexity: O(n + k)
/// Space complexity: O(n + k)
/// 
/// see this link for illustration: https://www.programiz.com/dsa/counting-sort
/// </summary>

namespace SearchingAndSorting
{
    internal class Counting_Sort
    {

        static void CountSort(int[] arr)
        {
            int n = arr.Length;
            int[] output = new int[n];

            int max = arr.Max();

            // store the count of the each array elements in a count array
            int[] count = new int[max + 1];

            // initialize all the array elements in count array as 0
            Array.Fill(count, 0);

            // store the frequency/count of each elements of given array in count array
            for (int i = 0; i < n; i++)
                count[arr[i]]++;

            // store the sum of current element and previous element in each index
            for (int i = 1; i <= max; i++)
                count[i] += count[i - 1];

            // iterate the original array in reverse order
            // we ll take the value from original array and compare with the count array index
            // at that particular index in count array, we take the value as the index for the output array
            // and index value as the actual value, and we decrement value in count array
            for (int i = n - 1; i >= 0; i--)
            {
                output[count[arr[i]] - 1] = arr[i]; // either do a right shift by 1 in count array or subtract by 1 here
                --count[arr[i]];
            }

            printSortedArray(output);
        }

        static void printSortedArray(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
        }

        public static void Main(string[] args)
        {
            int[] arr = new int[] { 1, 3, 4, 4, 3, 1, 1, 2, 2, 1 };

            CountSort(arr);
        }
    }
}
