using System;

namespace _07._Predicate_For_Names
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            var names = Console.ReadLine().Split();

            Action<int, string[]> filter = delegate(int n, string[] names)
            {
                foreach (var name in names)
                {
                    if (name.Length <= n)
                    {
                        Console.WriteLine(name);
                    }
                }
            };

            filter(n, names);
        }
    }
}
