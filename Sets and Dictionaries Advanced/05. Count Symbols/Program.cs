using System;
using System.Collections.Generic;

namespace _05._Count_Symbols
{
    class Program
    {
        static void Main(string[] args)
        {
            string text = Console.ReadLine();
            var characters = new SortedDictionary<char, int>();

            for (int i = 0; i < text.Length; i++)
            {
                if (!characters.ContainsKey(text[i]))
                {
                    characters.Add(text[i], 0);
                }

                characters[text[i]]++;
            }

            foreach (var ch in characters)
            {
                Console.WriteLine($"{ch.Key}: {ch.Value} time/s");
            }
        }
    }
}
