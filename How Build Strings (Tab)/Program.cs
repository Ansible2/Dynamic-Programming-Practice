using System;
using System.Linq;
using System.Collections.Generic;

namespace How_Build_Strings__Tab_
{
    class Program
    { 
        static List<List<string>> WaysToBuildString(string targetString, List<string> wordBank)
        {
            List<List<string>> constructionLists = new(targetString.Length + 1);
            for(var i = 0; i <= targetString.Length; i++)
            {
                constructionLists.Add(null);
            }

            constructionLists[0] = new List<string>();

            List<List<string>> returnList = new();

            for (var indexInString = 0; indexInString <= targetString.Length; indexInString++)
            {
                var currentList = constructionLists[indexInString];
                if (currentList != null)
                {
                    foreach (var word in wordBank)
                    {
                        bool isStringOutOfBounds = word.Length + indexInString + 1 <= targetString.Length;
                        if (isStringOutOfBounds && targetString.Substring(indexInString, word.Length) == word)
                        {
                            var copyList = new List<string>(currentList)
                            {
                                word
                            };
                            constructionLists[indexInString + word.Length] = copyList;

                            if (indexInString + word.Length == targetString.Length)
                            {
                                returnList.Add(copyList);
                            }

                        }
                    }
                }
                
            }

            return returnList;
        }
        static void Main(string[] args)
        {
            //var wordBank = new List<string>() { "ab", "abc", "cd", "def", "abcd" };
            //var word = "abcdef";
            //var wordBank = new List<string>() { "ee", "eeeeeee", "eee", "eeee", "eeeeee", "e", "f" };
            //var word = "eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeef";
            var wordBank = new List<string>() { "purp", "p", "ur", "le", "purpl" };
            var word = "purple";

            var lists = WaysToBuildString(word, wordBank);
            PrintList(lists);
        }



        static void PrintList(List<List<string>> theList)
        {
            if (theList != null)
            {
                foreach (var entry in theList)
                {
                    PrintList(entry);
                }

            }
        }
        static void PrintList(List<string> theList)
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
