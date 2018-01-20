using System;
using System.Collections.Generic;

namespace longest_substring_without_repeating_characters
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($"{LengthOfLongestSubstring("pwwkew")}");
        }

        // enumerate letters from index = 0
        // save letters in dictionary letter/index
        // when find existing letter reset count and dictionary and start at index of repeated letter
        // do until end of string
        public static int LengthOfLongestSubstring(string s) 
        {
            int index = 0;
            int count = 0;
            int max = 0;
            Dictionary<char, int> map = new Dictionary<char, int>();
            while(index < s.Length)
            {
                if(!map.ContainsKey(s[index]))
                {
                    map.Add(s[index], index);
                    count++;
                    if (count > max)
                        max = count;
                }
                else 
                {
                    count = 0;
                    index = map[s[index]];
                    map = new Dictionary<char, int>();
                }

                index++;
            }
            
            return max;
        }
    }
}
