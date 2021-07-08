using System.Linq;
using System.Collections.Generic;
using System;

namespace How_Build_Strings
{
    class Program
    {
        static Dictionary<string, List<List<string>>> stringDictionary = new();

        static List<List<string>> GetAllPossibleStringCombos(string targetString, List<string> wordBank)
        {
            if (stringDictionary.ContainsKey(targetString))
            {
                return stringDictionary[targetString];
            }
            if (targetString.Length == 0)
            {
                return new List<List<string>>() { new List<string>() };
            }


            List<List<string>> returnList = new();
            
            foreach(var word in wordBank)
            {
                if (targetString.StartsWith(word))
                {
                    string subString = targetString.Remove(0, word.Length);
                    var waysToBuildFromWordList = GetAllPossibleStringCombos(subString, wordBank);

                    if (waysToBuildFromWordList.Count != 0)
                    {
                        waysToBuildFromWordList.ForEach(x => x.Insert(0,word));
                        returnList.AddRange(waysToBuildFromWordList);
                    }

                }
            }

            stringDictionary[targetString] = returnList;
            return returnList;
            
        }

        static void Main(string[] args)
        {
            //var wordBank = new List<string>() { "ab", "abc", "cd", "def", "abcd", "ef", "c" };
            //var word = "abcdef";
            var wordBank = new List<string>() { "ee", "eeeeeee", "eee", "eeee", "eeeeee", "e", "f" };
            var word = "eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeef";
            //var wordBank = new List<string>() { "purp", "p", "ur", "le", "purpl" };
            //var word = "purple";

            var listOfLists = GetAllPossibleStringCombos(word, wordBank);
            Console.WriteLine("\nAnswer ---------:");
            if (listOfLists.Count == 0)
            {
                Console.WriteLine("List returned empty");
            }
            else
            {
                for (int i = 0; i < listOfLists.Count; i++)
                {
                    Console.WriteLine("\nList " + (i + 1) + " ---:");
                    printList(listOfLists[i]);
                }
            }
            
        }

        static void printList(List<string> theList)
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
