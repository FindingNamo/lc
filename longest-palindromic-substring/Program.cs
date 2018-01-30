using System;

namespace longest_palindromic_substring
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(new Solution().LongestPalindrome("babad"));
        }
    }

    public class Solution {
    public string LongestPalindrome(string s) {
        int length = s.Length;
        int index = 0;
        string subString = s.Substring(index, length);
        var pa = new PalindromeAnalyzer();
        while(!pa.IsPalindrome(subString))
        {
            if(index + length == s.Length){
                index = 0;
                length--;
            }
            else
            {
                index++;    
            }
            subString = s.Substring(index, length);
        }
        
        return s.Substring(index, length);
    }
}

public class PalindromeAnalyzer{
    
    public PalindromeAnalyzer(){
        
    }
    
    public bool IsPalindrome(string s){
        if(string.IsNullOrWhiteSpace(s))
            return false;
        
        if(s.Length == 1)
            return true;
        
        for(int i = 0; i <= s.Length / 2; i++)
        {
            if(s[i] != s[s.Length - 1 - i])
                return false;
        }
        
        return true;
    }
}
}
