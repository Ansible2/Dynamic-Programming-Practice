using System.Linq;
using System.Collections.Generic;
using System;

namespace Grid_Traveler__Tab_
{
    class Program
    {
        static long getGridPaths(long x, long y)
        {
            
            List<List<long>> gridMatrixList = new List<List<long>>();
            for (long i = 0; i <= x; i++)
            {
                List<long> row = new();
                for (long j = 0; j <= y; j++)
                {
                    row.Add(0);
                }
                gridMatrixList.Add(row);
            }

            
            gridMatrixList[1][1] = 1;
            for (long column = 0; column <= y; column++)
            {
                for (long row = 0; row <= x; row++)
                {
                    var currentGridValue = gridMatrixList[(int)row][(int)column];
                    if (row + 1 <= x)
                    {
                        gridMatrixList[(int)row + 1][(int)column] += currentGridValue;
                    }
                    if (column + 1 <= y)
                    {
                        gridMatrixList[(int)row][(int)column + 1] += currentGridValue;
                    }
                }
            }
            
            foreach(var row in gridMatrixList)
            {
                printList(row);
            }

            return gridMatrixList[(int)x][(int)y];

        }

        static void Main(string[] args)
        {
            Console.WriteLine(getGridPaths(3,3));
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
