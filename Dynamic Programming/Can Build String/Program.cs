using System;
using System.Linq;
using System.Collections.Generic;

namespace Can_Build_String
{
    class Program
    {
        static HashSet<string> stringCantBeSimplified = new();
        static bool CanConstructStringFromWordBank(string targetString, List<string> wordBank)
        {
            if (stringCantBeSimplified.Contains(targetString))
            {
                return false;
            }

            if (targetString.Length == 0 || targetString == "")
            {
                return true;
            }


            foreach(string word in wordBank)
            {
                if (targetString.StartsWith(word))
                {
                    string targetSubString = targetString.Remove(0, word.Length);
                    if (CanConstructStringFromWordBank(targetSubString, wordBank))
                    {
                        return true;
                    }
                }
            }

            stringCantBeSimplified.Add(targetString);
            return false;
        }

        static void Main(string[] args)
        {
            //var wordBank = new List<string>() { "ab", "c", "cdd", "ef", "absd" };
            //var word = "abcdef";
            var wordBank = new List<string>() { "ee", "eeeeeee", "eee", "eeee", "eeeeee" , "e", "f" };
            var word = "eeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeeef";

            var canConstruct = CanConstructStringFromWordBank(word, wordBank);
            Console.WriteLine(canConstruct);
        }
    }
}
