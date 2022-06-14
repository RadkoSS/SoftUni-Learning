using System;
using System.Linq;
using System.Collections.Generic;

namespace P01.FoodFinder
{
    public class FoodFinder
    {
        static void Main()
        {
            
            Dictionary<string, char[]> words = new Dictionary<string, char[]>();

            Queue<char> vowels = new Queue<char>();

            Stack<char> consonants = new Stack<char>();

            InitializeCollections(ref words, ref vowels, ref consonants);

            ExecuteCommands(words, vowels, consonants);

            PrintResult(words);

        }

        static void InitializeCollections(ref Dictionary<string, char[]> words, ref Queue<char> vowels, ref Stack<char> consonants)
        {
            words.Add("pear", "pear".ToCharArray());
            words.Add("flour", "flour".ToCharArray());
            words.Add("pork", "pork".ToCharArray());
            words.Add("olive", "olive".ToCharArray());

            var volewsArray = Console.ReadLine().Split().Select(char.Parse).ToArray();

            var consonantsArray = Console.ReadLine().Split().Select(char.Parse).ToArray();

            vowels = new Queue<char>(volewsArray);

            consonants = new Stack<char>(consonantsArray);

        }

        static void ExecuteCommands(Dictionary<string, char[]> words, Queue<char> vowels, Stack<char> consonants)
        {
            while (consonants.Count > 0)
            {
                char currentConsonant = consonants.Pop();

                char currentVowel = vowels.Dequeue();

                var newPear = words["pear"].Where(ch => ch != currentConsonant).Where(ch => ch != currentVowel).ToArray();

                words["pear"] = newPear;

                var newFlour = words["flour"].Where(ch => ch != currentConsonant).Where(ch => ch != currentVowel).ToArray();

                words["flour"] = newFlour;

                var newPork = words["pork"].Where(ch => ch != currentConsonant).Where(ch => ch != currentVowel).ToArray();

                words["pork"] = newPork;

                var newOlive = words["olive"].Where(ch => ch != currentConsonant).Where(ch => ch != currentVowel).ToArray();

                words["olive"] = newOlive;

                vowels.Enqueue(currentVowel);
            }
        }

        static void PrintResult(Dictionary<string, char[]> words)
        {
            var wordsFound = 0;

            foreach (var word in words)
            {
                if (word.Value.Length == 0)
                {
                    wordsFound++;
                }
            }

            Console.WriteLine($"Words found: {wordsFound}");

            foreach (var word in words)
            {
                if (word.Value.Length == 0)
                {
                    Console.WriteLine(word.Key);
                }
            }
        }
    }
}
