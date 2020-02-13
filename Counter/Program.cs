using System;
using System.Collections.Generic;
using System.Linq;

/*
-- Given a string which contains words separated by whitespace characters - implement two methods:
-- Dictionary﹤string, int﹥ GetWordsFrequencyCount(string text)- returns a dictionary,
where the key is a word and the value is the amount of times that word occurs in the text.
For example, GetWordsFrequencyCount("My bike and my book"); returns {"my": 2, "bike": 1, "and": 1, "book": 1},
because the world "my" occurs 2 times and other words occur only once.
-- Dictionary﹤int, int﹥ GetWordsLengthFrequencyCount(string text) - returns a dictionary,
where the key is the length of a word and the value is the amount of times a word
with such length is found in the text. For example,
GetWordsLenthFrequencyCount("My bike and my book"); returns {2: 2, 4: 2, 3: 1},
because there are 2 words that have 2 letters, 2 words that have 4 letters and 1 word that has 3 letters.
-- It is assumed that the text does not have punctuation marks and the results are case insensitive.
 */

namespace Counter
{
    public class Program
    {

        public static Dictionary<string, int> GetWordsFrequencyCount(string text)
        {
            Dictionary<string, int> dictionary = new Dictionary<string, int>();
            //An array of words, made to lowercase, because results are case sensitive;
            //The split() method is used to split a string into an array of substrings, which returns the new array;
            string[] wordsArray = text.ToLower().Split(' ');
            // foreach loop is used to count word's frequency in a string;
            foreach (string word in wordsArray)
            {
                if (dictionary.ContainsKey(word))
                    dictionary[word]++;
                else
                    dictionary[word] = 1;
            }
            return dictionary;
        }

        public static Dictionary<int, int> GetWordsFrequencyCountLength(string text)
        {
            Dictionary<int, int> dictionary = new Dictionary<int, int>();
            string[] wordsArray = text.ToLower().Split(' ');

            int stringLength = 0;
            int value = 0;
            // for loop is used to count word's LENGTH frequency in a string;
            for (int i = 0; i < wordsArray.Length; i++)
            {
                stringLength = wordsArray[i].Length;
                if (dictionary.TryGetValue(stringLength, out value))
                    dictionary[stringLength] = value + 1;
                else
                    dictionary.Add(stringLength, 1);
            }
            return dictionary;
        }

        //----------------------------------------------------------- M A I N --------------------------------------------------------

        public static void Main(string[] args)
        {
            string textCount = "My Bike and my BOOK";

            //-----------------------------------------------  GetWordsFrequencyCount(); ------------------------------------------------

            Dictionary<string, int> GWFC = GetWordsFrequencyCount(textCount);
            Console.Write("{");
            // string.Join(); Concatenates the elements of a specified array or the members of a collection, using the specified separator between each element or member.
            string wordsFrequencyCounts = string.Join(", ", GWFC.Select(y => "\"" + y.Key + "\"" + ": " + y.Value).ToArray());
            Console.Write(wordsFrequencyCounts);
            Console.WriteLine("}");
            Console.WriteLine();

            //---------------------------------------------  GetWordsFrequencyCountLength(); ----------------------------------------------

            Dictionary<int, int> GWFCL = GetWordsFrequencyCountLength(textCount);
            Console.Write("{");
            string wordsFrequencyCountLengths = string.Join(", ", GWFCL.Select(x => x.Key + ": " + x.Value).ToArray());
            Console.Write(wordsFrequencyCountLengths);
            Console.Write("}");
        }
    }
}
