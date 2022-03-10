/// <summary>
/// logic for quick sort algorithm |
/// find pivot in a given array, could be first, last, mid, or random index
/// loop through the items, always ignoring the pivot index.
/// maintain i index for elements smaller than pivot element.
/// if current element is lower then pivot inc i according to pivot index 
///	then swap ith element with current element.
///	end of loop.
///	now swap ith or i+1th element with pivot based on pivot being < or > i.
///	finally recall itself for the 2 divided parts by the pivot element's final position;
///	|
///	Time Complexity: Worst case: O(n ^ 2), Average case: O(nlogn)
/// </summary>

namespace SearchingAndSorting
{
    internal class Quick_Sort
    {
        static void Swap(ref int[] arr, int a, int b)
        {
            if (a == b)
                return;
            int temp = arr[a];
            arr[a] = arr[b];
            arr[b] = temp;
        }

        static void PrintArray(int[] arr)
        {
            foreach (var n in arr)
            {
                Console.Write(n + " ");
            }
        }


        /// <summary>
        /// logic for partitioning using last index as pivot |
	    /// in this case we loop through elements excluding last one
        /// we maintain i while swapping each element
        /// since index will always be >= i here 
	    /// we directly swap pivot(last) with i+1th
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="low"></param>
        /// <param name="high"></param>
        /// <returns></returns>
        static int PartitionUsingLast(int[] arr, int low, int high)
        {
            int i = low - 1; // index of the smaller element indicates the right position of pivot found so far
            int pivot = arr[high]; // pivot

            for(int j = low; j <= high - 1; j++)
            {
                // if current element is smaller than pivot
                if(arr[j] < pivot)
                {
                    // increment the index of smaller element first
                    i++;
                    Swap(ref arr, i, j);
                }    
            }

            Swap(ref arr, i + 1, high);
            return i + 1;
        }

        /// <summary>
        /// logic for partitioning  using first index as pivot |
	    /// since we take 1st element as pivot, we ignore first element instead of last here
	    /// so loop starts from second element
	    /// and since pivot will always be <= i
        /// we swap ith element with pivot
        /// Note: swaping i+1 with pivot would move bigger element left to pivot here,
	    /// which would be wrong
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="low"></param>
        /// <param name="high"></param>
        /// <returns></returns>
        static int PartitionUsingFirst(int[] arr, int low, int high)
        {
            int i = low;
            int pivot = arr[low]; // picking first element as pivot

            for(int j = low + 1; j <= high; j++)
            {
                if(arr[j] <= pivot)
                {
                    i++;
                    Swap(ref arr, i, j);
                }
            }
            Swap(ref arr, i, low);
            return i;
        }

        /// <summary>
        /// logic for partitioning using mid index as pivot
	    /// this is culmination of first and last index as pivot logics
	    /// instead of avoiding first or last, we just avoid the pivot index itself
	    /// big difference here is if we have pivot in the middle
	    /// then i needs to be incremented 2 times when it is 1 below pivot to avoid touching pivot
   	    /// after the loop, we need a check to see pivot or i is bigger
        /// then swap i or i+1th element with pivot just like first and last index partitioning
        /// </summary>
        /// <param name="arr"></param>
        /// <param name="low"></param>
        /// <param name="high"></param>
        /// <returns></returns>
        static int PartitionUsingMid(int[] arr, int low, int high)
        {
            // start i with -1 as we do not know what first element can be
            int i = low - 1;
            int mid = low + (high - low) / 2;
            int pivot = arr[mid];

            for(int j = low; j <= high; j++)
            {
                // skip if current index is pivot  
                // otherwise swap if current element is lower than pivot element
                if (arr[j] <= pivot && j != mid)
                {
                    // if i is 1 less then pivot, we need to inc. i twice to skip pivot index
                    if (i == mid - 1)
                        i = i + 2;
                    else
                        i++;  // otherwise we just inc i once like normal

                    Swap(ref arr, i, j);
                }
            }

            // swap the ith element with pivot element if pivot < 1
            if(mid < i)
            {
                Swap(ref arr, mid, i);
            }
            // swap the i+1th element with pivot element as pivot > 1
            else if(mid > i)
            {
                i++;
                Swap(ref arr, mid, i);
            }
            return i;
        }

        static void QuickSort(int[] arr, int low, int high)
        {
            if (low < high)
            {
                //int pi = PartitionUsingLast(arr, low, high);
                //int pi = PartitionUsingFirst(arr, low, high);
                int pi = PartitionUsingMid(arr, low, high);
                QuickSort(arr, low, pi - 1);
                QuickSort(arr, pi + 1, high);
            }
        }

        public static void Main(string[] args)
        {
            int[] arr = new int[] { 10, 7, 8, 9, 1, 5 };
            int n = arr.Length;

            Console.WriteLine("array before sorting: ");
            PrintArray(arr);
            QuickSort(arr, 0, n - 1);
            Console.WriteLine("\narray after sorting: ");
            PrintArray(arr);
        }
    }
}
