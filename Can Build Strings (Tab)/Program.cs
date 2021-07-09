using System;
using System.Linq;
using System.Collections.Generic;

namespace Can_Build_Strings__Tab_
{
    class Program
    {

        static bool canConstructString(string targetString, List<string> wordBank)
        {
            List<bool> constructionList = new();
            for (var i = 0; i < targetString.Length + 1; i++)
            {
                constructionList.Add(false);
            }
            // you can always make an empty string
            constructionList[0] = true;

            for (var indexInString = 0; indexInString <= targetString.Length; indexInString++)
            {
                // if the current letter is reacheable
                if (constructionList[indexInString])
                {
                    foreach(var word in wordBank)
                    {
                        bool isWordOutOfBounds = indexInString + word.Length <= targetString.Length;
                        
                        if (isWordOutOfBounds && targetString.Substring(indexInString,word.Length) == word)
                        {
                            Console.WriteLine(targetString.Substring(indexInString, word.Length));
                            Console.WriteLine(word);
                            constructionList[indexInString + word.Length] = true;
                        }
                    }
                }
            }

            PrintList(constructionList);
            return constructionList[targetString.Length];
        }


        static void Main(string[] args)
        {
            //var wordBank = new List<string>() { "ab", "abc", "cd", "def", "abcd" };
            //var word = "abcdef";
            var wordBank = new List<string>() { "ee", "eeeeeee", "eee", "eeee", "eeeeee", "e", "f"};
            var word = "eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeef";

            var canConstruct = canConstructString(word, wordBank);
            Console.WriteLine(canConstruct);
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
