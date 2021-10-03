using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Reverse_And_Exclude
{
    class Program
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            int numberToDivide = int.Parse(Console.ReadLine());

            Func<int[], int, Stack<int>> reverse = delegate(int[] array, int number)
            {
                var reversedNumbers = new Stack<int>();
                for (int i = 0; i < array.Length; i++)
                {
                    if (array[i] % number == 0)
                    {
                        continue;
                    }

                    reversedNumbers.Push(array[i]);
                }

                return reversedNumbers;
            };

            foreach (var item in reverse(numbers, numberToDivide))
            {
                Console.Write(item + " ");
            }
        }
    }
}
