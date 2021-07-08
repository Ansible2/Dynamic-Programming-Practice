using System;
using System.Linq;
using System.Collections.Generic;

namespace Best_Sum
{
    class Program
    {
        //static HashSet<long> NumCantBeSummedHashSet = new HashSet<long>();
        static Dictionary<long, List<long>> shortestSumPathDictionary = new Dictionary<long, List<long>>();

        static List<long> FindShortestSumPath(long targetSum, List<long> numbersList)
        {
            
            if (shortestSumPathDictionary.ContainsKey(targetSum))
            {
                return shortestSumPathDictionary[targetSum];
            }

            if (targetSum < 0)
            {
                return null;
            }

            if (targetSum == 0)
            {
                return new List<long>();
            }


            List<long> shortestList = null;
            foreach (long number in numbersList)
            {
                long remainder = targetSum - number;
                List<long> comboList = FindShortestSumPath(remainder, numbersList);

                if (comboList != null)
                {
                    // not sure why, but you need to copy this list to a new combo list or else you get erroroeus returns
                    List<long> comboList2 = new(comboList);
                    comboList2.Add(number);

                    Console.WriteLine("Checked path--:");
                    printList(comboList2);

                    if (shortestList == null || shortestList.Count > comboList2.Count)
                    {
                        shortestList = comboList2;
                    }
                }
            }

            shortestSumPathDictionary[targetSum] = shortestList;
            return shortestList;
        }


        static void Main(string[] args)
        {
            //var sumPath = FindShortestSumPath(5000, new List<long> { 99, 53, 78, 55, 7, 8, 6, 45, 10, 20 });
            var sumPath = FindShortestSumPath(100, new List<long> { 1, 2, 5, 25 });
            //var sumPath = FindShortestSumPath(7, new List<long> { 5,3,4,7 });
            //var sumPath = FindShortestSumPath(8, new List<long> { 1, 4, 5 });

            if (sumPath != null)
            {
                Console.WriteLine("Found Answer List--:");
                printList(sumPath);
                long sum = 0;
                foreach (var number in sumPath)
                {
                    sum += number;
                }
                Console.WriteLine("Debug Sum is--: " + sum);
            }
            else
            {
                Console.WriteLine("null");
            }

        }

        static void printList(List<long> theList)
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
    }
}
