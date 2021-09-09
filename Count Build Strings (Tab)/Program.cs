using System;
using System.Linq;
using System.Collections.Generic;

namespace Count_Build_Strings__Tab_
{
    class Program
    {

        static int CountNumWaysToBuildString(string targetString, List<string> wordBank)
        {
            List<int> constructionTable = new(targetString.Length + 1);
            for (int i = 0; i <= targetString.Length; i++)
            {
                constructionTable.Add(0);
            }
            // there is always atleast 1 way to make an empty string
            constructionTable[0] = 1;


            for (int indexInTarget = 0; indexInTarget < targetString.Length; indexInTarget++)
            {
                foreach (var word in wordBank)
                {

                    bool isWordOutOfBounds = word.Length + indexInTarget <= targetString.Length;
                    if (isWordOutOfBounds && targetString.Substring(indexInTarget, word.Length) == word)
                    {
                        constructionTable[indexInTarget + word.Length] += constructionTable[indexInTarget];
                    }
                }
                
            }

            return constructionTable[targetString.Length];
        }
        static void Main(string[] args)
        {
            //var wordBank = new List<string>() { "ab", "abc", "cd", "def", "abcd" };
            //var word = "abcdef";
            var wordBank = new List<string>() { "ee", "eeeeeee", "eee", "eeee", "eeeeee", "e", "f" };
            var word = "eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeef";
            //var wordBank = new List<string>() { "purp", "p", "ur", "le", "purpl" };
            //var word = "purple";

            var numWays = CountNumWaysToBuildString(word, wordBank);
            Console.WriteLine(numWays);
        }



        static void PrintList(List<List<bool>> theList)
        {
            if (theList != null)
            {
                foreach (var entry in theList)
                {
                    PrintList(entry);
                }

            }
        }
        static void PrintList(List<bool> theList)
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
