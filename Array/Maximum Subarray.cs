/// <summary>
/// Maximum sum subarray
/// This code includes:
/// 1. brute force approach [O(n^2)]
/// 2. Kadanes algo [O(n)]
/// 3. Range of max sum with Kadane's Algo [O(n)]
/// </summary>
namespace Arrays
{
    internal class Maximum_Subarray
    {

        public static int BruteForceApproach(int[] arr)
        {
            // O(n^2)
            int length = arr.Length;
            int maxSum = Int32.MinValue;
            for (int i = 0; i < length; i++)
            {
                int sum = 0;
                for (int j = i; j < length; j++)
                {
                    sum += arr[j];
                    maxSum = Math.Max(maxSum, sum);
                }
            }

            return maxSum;
        }

        public static int KadanesAlgo(int[] arr)
        {
            // O(n)
            int sum = 0;
            int maxi = arr[0];
            for(int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];

                if (sum > maxi)
                    maxi = sum;

                // we are just simply dropping the negative sum 
                // since this will make not give use the max sum
                if (sum < 0)
                    sum = 0; 
            }

            return maxi;
        }

        static List<int>? subarr;

        public static int KadanesAlgoRange(int[] arr)
        {
            // O(n)
            subarr = new List<int>();
            int sum = 0;
            int maxi = arr[0];
            int s = 0;

            for (int i = 0; i < arr.Length; i++)
            {
                sum += arr[i];

                if(sum > maxi)
                {
                    subarr.Clear();
                    maxi = sum;
                    subarr.Add(s);
                    subarr.Add(i);
                }

                if(sum < 0)
                {
                    sum = 0;
                    s = i + 1;
                }
            }
            return maxi;
        }

        public static void printRange()
        {
            Console.Write("Range of max sub array is: ");
            foreach (var item in subarr)
            {
                Console.Write(item + " ");
            }
        }

        public static int MaxSubArrayHelper(int choice, int[] arr)
        {
            if (choice == 1) 
                return BruteForceApproach(arr);
            else if (choice == 2) 
                return KadanesAlgo(arr);
            else
            {
                int result = KadanesAlgoRange(arr);
                printRange();
                return result;
            }
        }

        public static void Main(string[] args)
        {
            int[] arr = new int[] { -2, 1, -3, 4, -1, 2, 1, -5, 4 };

            Console.Write("Maximum Sum: {0} \n", MaxSubArrayHelper(3, arr));
        }
    }
}
