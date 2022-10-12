using System;
using System.Collections.Generic;
using System.Linq;

namespace Applied_Arithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();


            while (true)
            {
                string input = Console.ReadLine();

                Action<List<int>> add = numbers =>
                {
                    for (int i = 0; i < numbers.Count; i++)
                    {
                        numbers[i]++;
                    }
                };
                Action<List<int>> multiply = number =>
                {
                    for (int i = 0; i < numbers.Count; i++)
                    {
                        numbers[i] *= 2;
                    }
                };
                Action<List<int>> subtract = number =>
                {
                    for (int i = 0; i < numbers.Count; i++)
                    {
                        numbers[i]--;
                    }
                };
                Action<List<int>> print = number => Console.WriteLine(string.Join(" ", numbers)); ;

                if (input == "end")
                {
                    break;
                }

                switch (input)
                {
                    case "add":
                        add(numbers);
                        break;
                    case "multiply":
                        multiply(numbers);
                        break;
                    case "subtract":
                        subtract(numbers);
                        break;
                    case "print":
                        print(numbers);
                        break;
                }
            }
        }
    }
}
