using System;
using System.Linq;
using System.Collections.Generic;

namespace Can_Build_String
{
    class Program
    {
        // one way
        /*
        static HashSet<string> stringCantBeSimplified = new();
        static HashSet<string> stringCanBeSimplified = new();
        static long countNumberOfWaysToBuildString(string targetString, List<string> wordBank)
        {
            if (stringCantBeSimplified.Contains(targetString))
            {
                return 0;
            }

            if (stringCanBeSimplified.Contains(targetString) || targetString.Length == 0 || targetString == "")
            {
                return 1;
            }

            long numberOfWays = 0;
            foreach (string word in wordBank)
            {
                if (targetString.StartsWith(word))
                {
                    string targetSubString = targetString.Remove(0, word.Length);
                    var count = countNumberOfWaysToBuildString(targetSubString, wordBank);
                    if (count == 0)
                    {
                        stringCantBeSimplified.Add(targetSubString);
                    }
                    else
                    {
                        stringCanBeSimplified.Add(targetSubString);
                        numberOfWays++;
                    }
                }
            }
            

            return numberOfWays;
        }
        */

        // their way
        static Dictionary<string, long> valueDictionary = new();
        static long countNumberOfWaysToBuildString(string targetString, List<string> wordBank)
        {
            if (valueDictionary.ContainsKey(targetString))
            {
                return valueDictionary[targetString];
            }

            if (targetString.Length == 0 /*|| targetString == ""*/)
            {
                return 1;
            }

            long numberOfWays = 0;

            foreach (string word in wordBank)
            {
                if (targetString.StartsWith(word))
                {
                    string targetSubString = targetString.Remove(0, word.Length);
                    var count = countNumberOfWaysToBuildString(targetSubString, wordBank);
                    numberOfWays += count; 
                }
            }

            valueDictionary[targetString] = numberOfWays;
            return numberOfWays;
        }


        static void Main(string[] args)
        {
            //var wordBank = new List<string>() { "ab", "c", "cd", "ef", "absd" };
            //var word = "abcdef";
            var wordBank = new List<string>() { "ee", "eeeeeee", "eee", "eeee", "eeeeee", "e" };
            var word = "eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeef";
            //var wordBank = new List<string>() { "purp", "p", "ur", "le", "purpl" };
            //var word = "purple";

            var numberOfConstructs = countNumberOfWaysToBuildString(word, wordBank);

            Console.WriteLine("Answer is---:");
            Console.WriteLine(numberOfConstructs);
        }
    }
}
