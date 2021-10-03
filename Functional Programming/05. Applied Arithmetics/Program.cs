using System;
using System.Linq;

namespace _05._Applied_Arithmetics
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            string input = Console.ReadLine();

            while (input != "end")
            {
                if (input == "add")
                {
                    for (int i = 0; i < numbers.Length; i++)
                    {
                        numbers[i] += 1;
                    }
                }
                else if (input == "multiply")
                {
                    for (int i = 0; i < numbers.Length; i++)
                    {
                        numbers[i] *= 2;
                    }
                }
                else if (input == "subtract")
                {
                    for (int i = 0; i < numbers.Length; i++)
                    {
                        numbers[i] -= 1;
                    }
                }
                else if (input == "print")
                {
                    Console.WriteLine(string.Join(" ", numbers));
                }

                input = Console.ReadLine();
            }
        }
    }
}
