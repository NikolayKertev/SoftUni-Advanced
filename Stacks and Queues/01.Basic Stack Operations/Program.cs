using System;
using System.Collections.Generic;
using System.Linq;

namespace _01.Basic_Stack_Operations
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] actionsCount = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int[] numbersArray = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> numbers = new Stack<int>(numbersArray);
            int min = 0;

            int numbersToPop = actionsCount[1];
            int numberToCheckFor = actionsCount[2];

            for (int i = 0; i < numbersToPop; i++)
            {
                if (numbers.Any())
                {
                    numbers.Pop();
                }
            }

            if (numbers.Contains(numberToCheckFor))
            {
                Console.WriteLine("true");
            }
            else
            {
                if (numbers.Any())
                {
                    min = numbers.Min();
                }

                Console.WriteLine(min);
            }

        }
    }
}
