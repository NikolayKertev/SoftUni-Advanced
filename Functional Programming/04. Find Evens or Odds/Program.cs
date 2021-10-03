using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Find_Evens_or_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int start = input[0];
            int end = input[1];
            List<int> numbers = new List<int>();
            var numbersToPrint = new List<int>();

            for (int i = start; i <= end; i++)
            {
                numbers.Add(i);
            }

            string input2 = Console.ReadLine();

            if (input2 == "odd")
            {
                Predicate<int> odds = x => x % 2 == 1;
                foreach (var item in numbers)
                {

                    if (odds(item))
                    {
                        numbersToPrint.Add(item);
                    }
                }

                Console.WriteLine(string.Join(" ", numbersToPrint));
            }
            else if (input2 == "even")
            {
                Predicate<int> odds = x => x % 2 == 0;
                foreach (var item in numbers)
                {

                    if (odds(item))
                    {
                        numbersToPrint.Add(item);
                    }
                }

                Console.WriteLine(string.Join(" ", numbersToPrint));
            }
        }
    }
}
