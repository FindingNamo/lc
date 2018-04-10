using System;

namespace daily_temperatures
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }

    public class Solution {
    
    /*
    For each day
    Look forward until higher
    Count days
    Populate result
    
    We could also look for a peak while keeping a trail of lower temperatures
    */
    public int[] DailyTemperatures(int[] temperatures) {
        
        if(temperatures.Length == 0)
            return new int[0];
        
        int numDays = temperatures.Length;
        int[] r = new int[numDays];
        
        for(int i = 0; i < numDays; i++){
            if(i > 0 && temperatures[i] == temperatures[i-1] )
            {
                if (r[i-1] != 0)
                    r[i] = r[i-1] - 1;
                else
                    r[i] = 0;
            }
                
            else
                r[i] = DaysTilHotter(i, temperatures);
        }
        
        return r;
        
    }
    
    // 1,2,3
    // i=0
    private int DaysTilHotter(int i, int[] temperatures){
        int numDays = temperatures.Length;
        int curTemp = temperatures[i];
        
        if (curTemp == 100)
            return 0;
        
        int count = 1;
        for(int j = i + 1; j < numDays; j++){
            if(temperatures[j] > curTemp)
                return count;
            else
                count++;
        }
        
        return 0;
    }
}
}
