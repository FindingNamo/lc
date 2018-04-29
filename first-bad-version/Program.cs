using System;

namespace first_bad_version
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            new Solution().FirstBadVersion(2126753390);
        }
    }

    /* The isBadVersion API is defined in the parent class VersionControl.
      bool IsBadVersion(int version); */

      

public class Solution {

    bool IsBadVersion(int version){
          return version == 1702766719;
      }

    public int FirstBadVersion(int n) { 
        return Util(1,n);
    }
    
    private int Util(int min, int max){
        int n = (max + min) / 2;
        
        if(IsBadVersion(n)){
            if(n == 1)
                return 1;
            
            if(!IsBadVersion(n-1))
                return n;
            
            return Util(min, n-1);
                
        }
        else{
            return Util(n+1, max);
        }
    }
}
}
