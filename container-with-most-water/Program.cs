using System;

namespace container_with_most_water {
    class Program {
        static void Main (string[] args) {
            Console.WriteLine (new Solution().MaxArea(new [] {1,2,3}));
        }
    }

    public class Solution {
        public int MaxArea (int[] height) {
            int maxArea = 0;
            /* Brute Force 
            for(int i = 1; i < height.Length; i++){
                for (int j = 0; j < i; j++){
                    var minHeight = Math.Min(height[j], height[i]);
                    var curArea = minHeight * (i - j);
                    if (curArea > maxArea)
                        maxArea = curArea;

                }
            }*/
            int left = 0;
            int right = height.Length - 1;
            int curArea =0;
            while(left<right){
                curArea = Math.Min(height[left],height[right]) * (right - left);
                if (curArea > maxArea)
                    maxArea = curArea;
                if(height[left] >= height[right])
                    right--;
                else
                    left++;
            }
            

            return maxArea;
        }
    }
}