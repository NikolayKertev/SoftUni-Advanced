using System;

namespace _01._Action_Print
{
    class Program
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine().Split(" ");

            Action<string> print = delegate (string x)
            {
                Console.WriteLine($"Sir {x}");
            };

            foreach (var item in input)
            {
                print(item);
            }
        }
    }
}