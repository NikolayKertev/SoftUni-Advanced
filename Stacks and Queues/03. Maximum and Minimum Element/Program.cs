using System;
using System.Collections.Generic;
using System.Linq;

namespace _03._Maximum_and_Minimum_Element
{
    class Program
    {
        static void Main(string[] args)
        {
            Stack<int> sequence = new Stack<int>();

            int n = int.Parse(Console.ReadLine());



            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();
                int[] arg = input.Split().Select(int.Parse).ToArray();
                int action = arg[0];

                if (action == 1)
                {
                    sequence.Push(arg[1]);
                }
                else if (action == 2)
                {
                    if (sequence.Any())
                    {
                        sequence.Pop();
                    }
                }
                else if (action == 3)
                {
                    if (sequence.Any())
                    {
                        Console.WriteLine(sequence.Max());
                    }
                }
                else if (action == 4)
                {
                    if (sequence.Any())
                    {
                        Console.WriteLine(sequence.Min());
                    }
                }
            }

            Console.WriteLine(string.Join(", ", sequence));

        }
    }
}
