using System;
using System.Linq;
using System.Collections.Generic;


namespace How_Sum__Tab_
{
    class Program
    {
        static List<long> GetSumPath(long targetSum, List<long> listOfValues)
        {
            // init lists to be null so we have a base case to compare
            List<List<long>> tableList = new((int)targetSum + 1);
            for (var i = 0; i <= targetSum; i++)
            {
                tableList.Add(null);
            }

            tableList[0] = new();


            for(long i = 0; i <= targetSum; i++)
            {
                // only add to entries that had a path from starting 0
                var currentNumberPath = tableList[(int)i];
                if (currentNumberPath != null)
                {
                    foreach (var number in listOfValues)
                    {
                        // make sure to not go out of list bounds
                        var indexToCheck = i + number;
                        if (indexToCheck <= targetSum)
                        {
                            List<long> copyList = new(currentNumberPath);
                            tableList[(int)indexToCheck] = copyList;
                            copyList.Add(number);
                        }
                    }
                }
                
            }

            return tableList[(int)targetSum];

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
            long num = 3000;
            List<long> numbersList = new() { 3, 10, 7, 14 };

            
            var returnPath = GetSumPath(num, numbersList);
            
            Console.WriteLine("Answer Is---:");
            PrintList(returnPath);

            if (returnPath != null)
            {
                Console.WriteLine("Sum is---: " + returnPath.Sum());
            }
            else
            {
                Console.WriteLine("Null") ;
            }
            
        }
    }
}
