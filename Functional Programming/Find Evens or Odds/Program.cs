using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Find_Evens_or_Odds
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] range = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int startRange = range[0];
            int endRange = range[1] - range[0] + 1;
            string type = Console.ReadLine();

            Predicate<int> even = (number) => number % 2 == 0;
            Predicate<int> odd = (number) => number % 2 == 1;

            List<int> numbers = Enumerable.Range(startRange, endRange).ToList();

            Print(numbers, even, odd, type);
        }

        static void Print(List<int> numbers, Predicate<int> even, Predicate<int> odd, string type)
        {
            if (type == "odd")
            {
                numbers = numbers.FindAll(odd);
            }
            else if (type == "even")
            {
                numbers = numbers.FindAll(even);
            }

            Console.WriteLine(string.Join(" ", numbers));
        }
    }
}
