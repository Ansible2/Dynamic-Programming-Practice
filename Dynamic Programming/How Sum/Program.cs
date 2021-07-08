using System;
using System.Collections.Generic;

namespace How_Sum
{
    class Program
    {
        static HashSet<long> NumCantBeSummedHashSet = new HashSet<long>();

        static List<long> FindSumPath(long targetSum, List<long> numbersList)
        {
            if (NumCantBeSummedHashSet.Contains(targetSum))
            {
                return null;
            }
                

            if (targetSum == 0)
            {
                return new List<long>();
            } 
                

            if (targetSum < 0)
            {
                return null;
            }
                

            foreach(var number in numbersList)
            {
                var elements = FindSumPath(targetSum - number, numbersList);

                if (elements != null)
                {
                    elements.Add(number);
                    
                    Console.WriteLine("Checked path--:");
                    printList(elements);

                    return elements;
                }
            }

            NumCantBeSummedHashSet.Add(targetSum);
            return null;
        }
        static void Main(string[] args)
        {
            var sumPath = FindSumPath(5000, new List<long> { 99,53,78,55,7,8, 6, 45, 10,20 });

            if (sumPath != null)
            {
                Console.WriteLine("Found Answer List--:");
                printList(sumPath);
                long sum = 0;
                foreach(var number in sumPath)
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
