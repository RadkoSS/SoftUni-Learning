using System;
using System.Linq;
using System.Collections.Generic;

namespace P05.CountSymbols
{
    class Program
    {
        static void Main()
        {
            SortedDictionary<char, int> symbols = new SortedDictionary<char, int>();

            string text = Console.ReadLine();

            foreach (var symbol in text)
            {
                if (symbols.ContainsKey(symbol))
                {
                    symbols[symbol]++;
                }
                else
                {
                    symbols.Add(symbol, 1);
                }
            }

            foreach (var pair in symbols)
            {
                Console.WriteLine($"{pair.Key}: {pair.Value} time/s");
            }
        }
    }
}
