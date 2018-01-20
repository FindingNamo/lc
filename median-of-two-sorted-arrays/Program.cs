using System;

namespace median_of_two_sorted_arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            Console.WriteLine($"{FindMedianSortedArrays(new [] {1, 2}, new [] {3, 4}).ToString("N1")}");
        }

        // Merge arrays
        // Find middle (length / 2 - 0.5) if odd, avg of length /2 and length / 2 -1 if even
        public static double FindMedianSortedArrays(int[] nums1, int[] nums2) 
        {
            int[] merged = Merge(nums1, nums2);
            return CalculateMedian(merged);
        }

        public static double CalculateMedian(int[] nums)
        {
            if (nums.Length % 2 == 0)
            {
                int index1 = nums.Length / 2;
                int index2 = index1 - 1;
                return (Convert.ToDouble(nums[index1]) + Convert.ToDouble(nums[index2])) / 2;
            }
            else
            {
                return Convert.ToDouble(nums[nums.Length / 2]);
            }
        }
        
        public static int[] Merge(int[] nums1, int[] nums2)
        {
            int index1 = 0;
            int index2 = 0;
            int indexResult = 0;
            int[] result = new int[nums1.Length + nums2.Length];
            
            while (index1 < nums1.Length && index2 < nums2.Length)
            {
                if(nums1[index1] < nums2[index2])
                {
                    result[indexResult] = nums1[index1];
                    index1++;
                }
                else
                {
                    result[indexResult] = nums2[index2];
                    index2++;
                }
                indexResult++;
            }
            
            while(index1 < nums1.Length)
            {
                result[indexResult] = nums1[index1];
                indexResult++;
                index1++;
            }
            
            while(index2 < nums2.Length)
            {
                result[indexResult] = nums2[index2];
                indexResult++;
                index2++;
            }
            
            return result;
        }
    }


}
