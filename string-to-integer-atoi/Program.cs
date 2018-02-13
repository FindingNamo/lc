using System;
using System.Text;
using System.Text.RegularExpressions;

namespace string_to_integer_atoi {
    class Program {
        static void Main (string[] args) {
            Console.WriteLine ($"{new Solution().MyAtoi("+-2")}");
        }
    }

    public class Solution {
        public int MyAtoi (string str) {

            if (string.IsNullOrWhiteSpace (str))
                return 0;

            if (IsBeeEssCase(str))
                return 0;

            str.Trim();

            bool isNeg = str.Length > 1 && str[0] == '-';

            if(isNeg)
                str = str.Substring(1);

            str = TrimNonDigitPrefixes(str);

            var result = FirstNumber(str);

            try {
                return isNeg ? result * -1 : result;
            } catch {
                return 0;
            }
        }

        private bool IsBeeEssCase(string s){
            if(s.StartsWith("+-"))
                return true;

            return false;
        }

        private string TrimNonDigitPrefixes(string s){
            int temp;
            int index = -1;
            for(int i = 0; i < s.Length; i++){
                if(Int32.TryParse(s[i].ToString(), out temp)){
                    index = i;
                    break;
                }
                    
            }

            return index < 0 ? string.Empty :  s.Substring(index);
        }

        private int FirstNumber(string s){
            var result = 0;
            for(int i = 0; i < s.Length; i++){
                int curDigit;
                if(Int32.TryParse(s[i].ToString(), out curDigit)){
                    result = result * 10 + curDigit;
                }
                else
                {
                    return result;
                }
            }

            return result;
        }
    }
}