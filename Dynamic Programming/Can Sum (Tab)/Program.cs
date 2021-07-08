using System.Linq;
using System.Collections.Generic;
using System;


namespace Can_Sum__Tab_
{
    class Program
    {
        static bool CanSumFromList(long targetSum, List<long> listOfValues)
        {
            bool[] targetSumPossibleArray = new bool[(int)targetSum + 1];
            Array.Fill(targetSumPossibleArray, false);
            // we can always meake 0, so it acts as our base case for being true
            targetSumPossibleArray[0] = true;

            for (long i = 0; i <= targetSum; i++)
            {
                // if this position in the list is not true, we can't make that number
                if (targetSumPossibleArray[i])
                {
                    foreach (var number in listOfValues)
                    {
                        var indexToCheck = i + number;
                        if (indexToCheck <= targetSum && !targetSumPossibleArray[indexToCheck])
                        {
                            targetSumPossibleArray[indexToCheck] = true;
                        }
                    }
                }
                
            }


            return targetSumPossibleArray[targetSum];
        }


        static void PrintList(List<List<long>> theList)
        {
            if (theList != null)
            {
                foreach (var entry in theList)
                {
                    PrintList(entry);
                }

            }
        }
        static void PrintList(List<long> theList)
        {
            if (theList != null)
            {
                foreach (var entry in theList)
                {
                    Console.Write(entry + " ");
                }

                Console.WriteLine();
            }

        }


        static void Main(string[] args)
        {
            //long num = 7;
            //List<long> numbersList = new() { 5, 3, 4 };
            long num = 300;
            List<long> numbersList = new() { 7, 14 };

            Console.WriteLine(CanSumFromList(num, numbersList));
        }
    }
}