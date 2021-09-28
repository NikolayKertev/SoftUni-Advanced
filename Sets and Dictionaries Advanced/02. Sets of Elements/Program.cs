using System;
using System.Collections.Generic;
using System.Linq;

namespace _02._Sets_of_Elements
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] firstLine = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var firstSet = new HashSet<int>();
            var secondSet = new HashSet<int>();
            int first = firstLine[0];
            int second = firstLine[1];

            for (int i = 0; i < first; i++)
            {
                int number = int.Parse(Console.ReadLine());
                firstSet.Add(number);
            }

            for (int i = 0; i < second; i++)
            {
                int number = int.Parse(Console.ReadLine());
                secondSet.Add(number);
            }

            Console.WriteLine(string.Join(" ", firstSet.Intersect(secondSet).ToArray()));
        }
    }
}
