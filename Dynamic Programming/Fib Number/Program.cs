using System.Collections.Generic;
using System;

namespace Dynamic_Programming
{
    class Program
    {
        static Dictionary<long, long> FibNumberDictionary = new Dictionary<long, long>();
        static long getFibNumber(long numberInSequence)
        {
            if (FibNumberDictionary.ContainsKey(numberInSequence))
                return FibNumberDictionary[numberInSequence];

            if (numberInSequence <= 2)
                return 1;

            long fibNumber = getFibNumber(numberInSequence - 1) + getFibNumber(numberInSequence - 2);
            FibNumberDictionary.Add(numberInSequence, fibNumber);


            return fibNumber;
        }

        static void Main(string[] args)
        {
            Console.WriteLine(getFibNumber(50));
        }
    }
}
