/// <summary>
/// logic for merge sort algorithm
/// divide and conquer by 2 until we get 2 sorted subarays then sort them
/// do above recursively
/// Time Complexity: O(nlogn);
/// </summary>

namespace SearchingAndSorting
{
    internal class Merge_Sort
    {

        static void PrintArray(int[] arr)
        {
            foreach (var n in arr)
                Console.Write(n + " ");
        }

        static void MergeSort(int[] arr, int low, int high)
        {
            if(low < high)
            {
                int mid = low + (high - low) / 2;

                MergeSort(arr, low, mid);
                MergeSort(arr, mid + 1, high);

                Merge(arr, low, mid, high);
            }
        }

        static void Merge(int[] arr, int low, int mid, int high)
        {
            int n1 = mid - low + 1;
            int n2 = high - mid;

            int[] L = new int[n1];
            int[] R = new int[n2];
            int i, j;

            for (i = 0; i < n1; i++)
                L[i] = arr[low + i];
            for (j = 0; j < n2; j++)
                R[j] = arr[mid + 1 + j];

            i = 0; j = 0;

            int k = low;
            while(i < n1 && j < n2)
            {
                if(L[i] <= R[j])
                {
                    arr[k++] = L[i++];
                }
                else
                {
                    arr[k++] = R[j++];
                }
            }

            while (i < n1)
                arr[k++] = L[i++];

            while (j < n2)
                arr[k++] = R[j++];

        }

        public static void Main(string[] args)
        {
            int[] arr = new int[] { 12, 11, 13, 5, 6, 7 };
            Console.WriteLine("Array before sorting: ");
            PrintArray(arr);
            MergeSort(arr, 0, arr.Length - 1);
            Console.WriteLine("\nArray after sorting: ");
            PrintArray(arr);
        }
    }
}
