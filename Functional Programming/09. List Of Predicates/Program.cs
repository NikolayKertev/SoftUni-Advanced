using System;
using System.Collections.Generic;
using System.Linq;

namespace _09._List_Of_Predicates
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] numbers = new int[n];
            for (int i = 0; i < n; i++)
            {
                numbers[i] = i + 1;
            }

            int[] dividers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            var result = new List<int>();

            Action<int[], int[]> filter = delegate (int[] array, int[] dividers)
            {
                foreach (var number in numbers)
                {
                    bool canDivide = true;
                    foreach (var divider in dividers)
                    {
                        if (number % divider != 0)
                        {
                            canDivide = false;
                            break;
                        }
                    }

                    if (canDivide)
                    {
                        result.Add(number);
                    }
                }

                Console.WriteLine(string.Join(" ", result));
            };

            filter(numbers, dividers);
        }
    }
}
