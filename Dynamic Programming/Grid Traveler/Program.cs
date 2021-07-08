using System.Collections.Generic;
using System;

namespace Grid_Traveler
{
    class Program
    {
        static Dictionary<string, long> FoundPathValues = new Dictionary<string, long>();
        static long FindGridPaths(int x, int y)
        {
            string key_1 = new string(x.ToString() + ',' + y.ToString());
            string key_2 = new string(y.ToString() + ',' +  x.ToString());

            if (FoundPathValues.ContainsKey(key_1) || FoundPathValues.ContainsKey(key_2))
            {
                return FoundPathValues[key_1];
            }

            // return no path because no grid exists
            if (x == 0 || y == 0)
                return 0;

            // reached end of path
            if (x == 1 && y == 1)
                return 1;


            var pathValue = FindGridPaths(x - 1, y) + FindGridPaths(x, y - 1);
            FoundPathValues[key_1] = pathValue;
            FoundPathValues[key_2] = pathValue;

            return pathValue;
        }


        static void Main(string[] args)
        {
            Console.WriteLine(FindGridPaths(18,18));
        }
    }
}
