using System;
using System.Linq;
using System.Collections.Generic;

namespace Best_Sum__Tab_
{
    class Program
    {

        static List<int> GetBestSumPath(int targetSum, List<int> listOfValues)
        {
            List<List<int>> tableList = new(targetSum + 1);
            for (var i = 0; i <= targetSum; i++)
            {
                tableList.Add(null);
            }

            tableList[0] = new();

            for (int i = 0; i <= targetSum; i++)
            {
                var currentNumberPath = tableList[i];
                if (currentNumberPath != null)
                {
                    foreach(var number in listOfValues)
                    {
                        var indexToCheck = i + number;
                        if (indexToCheck <= targetSum && (tableList[indexToCheck] == null || tableList[indexToCheck].Count >= currentNumberPath.Count + 1))
                        {
                            List<int> newNumberPath = new(currentNumberPath);
                            tableList[indexToCheck] = newNumberPath;
                            newNumberPath.Add(number);
                        }
                        
                    }
                }
            }

            //PrintList(tableList);

            return tableList[targetSum];
        }

        static void PrintList(List<List<int>> theList)
        {
            if (theList != null)
            {
                foreach (var entry in theList)
                {
                    PrintList(entry);
                }

            }
        }
        static void PrintList(List<int> theList)
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
            //int num = 8;
            //List<int> numbersList = new() { 1, 2, 4 };
            int num = 3000;
            List<int> numbersList = new() { 3, 10, 7, 14 };


            var returnPath = GetBestSumPath(num, numbersList);

            Console.WriteLine("Answer Is---:");
            PrintList(returnPath);

            if (returnPath != null)
            {
                Console.WriteLine("Sum is---: " + returnPath.Sum());
                Console.WriteLine("Length is---: " + returnPath.Count);
            }
            else
            {
                Console.WriteLine("Null");
            }

        }
    }

}
