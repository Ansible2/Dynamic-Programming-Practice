using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text.RegularExpressions;
using System.Text;
using System;



class Result
{

    /*
     * Complete the 'minChairs' function below.
     *
     * The function is expected to return an INTEGER_ARRAY.
     * The function accepts STRING_ARRAY simulations as parameter.
     */

    public static List<int> minChairs(List<string> simulations)
    {
        List<int> simulationReturnList = new List<int>();
        foreach (var simulation in simulations)
        {
            int numberOfChairsNeeded = 0;
            int numberOfFreeChairs = 0;
            
            //var upperStr = simulation.ToUpper();
            foreach(char symbol in simulation)
            {
                switch(symbol)
                {
                    case 'C':
                        if (numberOfFreeChairs > 0)
                        {
                            numberOfFreeChairs--;
                        }
                        else
                        {
                            numberOfChairsNeeded++;
                        }
                        break;

                    case 'R':
                        numberOfFreeChairs++;
                        break;

                    case 'U':
                        if (numberOfFreeChairs > 0)
                        {
                            numberOfFreeChairs--;
                        }
                        else
                        {
                            numberOfChairsNeeded++;
                        }
                        
                        break;

                    case 'L':
                        numberOfFreeChairs++;
                        break;
                }
            }

            simulationReturnList.Add(numberOfChairsNeeded);
        }

        return simulationReturnList;
    }

}

class Solution
{
    public static void Main(string[] args)
    {
        //TextWriter textWriter = new StreamWriter(@System.Environment.GetEnvironmentVariable("OUTPUT_PATH"), true);

        int simulationsCount = Convert.ToInt32(Console.ReadLine().Trim());

        List<string> simulations = new List<string>();

        for (int i = 0; i < simulationsCount; i++)
        {
            string simulationsItem = Console.ReadLine();
            simulations.Add(simulationsItem);
        }

        List<int> result = Result.minChairs(simulations);

        Console.WriteLine(String.Join("\n", result));

        //textWriter.Flush();
        //textWriter.Close();
    }
}
