using System.Collections.Generic;
using System;

namespace Can_Sum
{
    class Program
    {
        static Dictionary<long, bool> CanNumBeSummedDictionary = new Dictionary<long, bool>();
        static bool CanGetSum(long targetSum, long[] numbersArray)
        {
            if (CanNumBeSummedDictionary.ContainsKey(targetSum))
                return CanNumBeSummedDictionary[targetSum];

            if (targetSum == 0)
                return true;

            if (targetSum < 0)
                return false;

            foreach(long number in numbersArray)
            {
                if (CanGetSum(targetSum - number, numbersArray))
                {
                    CanNumBeSummedDictionary[targetSum] = true;
                    return true;
                }
                    
            }

            CanNumBeSummedDictionary[targetSum] = false;
            return false;
        }

        static void Main(string[] args)
        {
            Console.WriteLine( CanGetSum(300, new long[] {7,14}) );
        }
    }
}
