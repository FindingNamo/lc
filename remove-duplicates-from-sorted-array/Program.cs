using System;

namespace remove_duplicates_from_sorted_array
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class Solution {
    public int RemoveDuplicates(int[] nums) {
        // if 0 return 0
        // if 1 return 1
        // if more than 1
        //   check if repeated (same as last char) and remember index of last unrepeated
        //     if repeated increment read index until end or until different if any then copy that to last unrepeated and increment unrepeated
        
        
        if (nums.Length == 0)
            return 0;
        
        if (nums.Length == 0)
            return 1;
        
        
        
        int unrepeated = 0;
        
        for(int i = 1; i < nums.Length; i++){
            if (nums[i] != nums[i-1]){
                nums[unrepeated+1] = nums[i];
                unrepeated++;
            }
            else{
                while(i < nums.Length && nums[i] == nums[i-1]){
                    i++;
                }
                
                if (i< nums.Length){
                    nums[unrepeated+1] = nums[i];
                    unrepeated++;
                }
            }
                
        }
        
        return unrepeated + 1;
    }
}
}
