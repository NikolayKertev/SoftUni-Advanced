using System;
using System.Collections.Generic;

namespace _03._Periodic_Table
{
    class Program
    {
        static void Main(string[] args)
        {
            int count = int.Parse(Console.ReadLine());
            var elements = new SortedSet<string>();

            for (int i = 0; i < count; i++)
            {
                string[] input = Console.ReadLine().Split();

                for (int j = 0; j < input.Length; j++)
                {
                    elements.Add(input[j]);
                }
            }

            Console.WriteLine(string.Join(" ", elements));
        }
    }
}
