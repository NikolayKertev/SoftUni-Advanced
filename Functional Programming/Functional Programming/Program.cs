using System;

namespace Functional_Programming
{
    class Program
    {
        static void Main(string[] args)
        {
            Action<string[]> print = name => Console.WriteLine(string.Join(Environment.NewLine, name));

            string[] names = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

            print(names);
        }
    }
}
