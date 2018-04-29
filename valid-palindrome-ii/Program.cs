using System;

namespace valid_palindrome_ii
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            new Solution().ValidPalindrome("aguokepatgbnvfqmgmlcupuufxoohdfpgjdmysgvhmvffcnqxjjxqncffvmhvgsymdjgpfdhooxfuupuculmgmqfvnbgtapekouga");
        }
    }

    public class Solution {
    // abdca false
    // abca true
    public bool ValidPalindrome(string s) {
        if(s.Length < 3)
            return true;
            
        bool oops = false;
        
        int left = 0;
        int right = s.Length - 1;
        
        while(left < right){
            if(s[left] != s[right]){
                if (oops)
                    return false;
                else if (right == left + 1){
                    return true;
                }
                else{
                    oops = true;
                    if(s[left+1] == s[right])
                        left++;
                    else if (s[left] == s[right-1])
                        right--;
                    else
                        return false;
                }
            }
            else{
                left++;
                right--;
            }
        }
        
        return true;
        
    }
}
}
