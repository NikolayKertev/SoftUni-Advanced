using System;
using System.Linq;
namespace _11._TriFunction
{
    class Program
    {
        static void Main(string[] args)
        {
            int number = int.Parse(Console.ReadLine());

            var names = Console.ReadLine().Split();

            Func<string[], int, string> charToInt = delegate(string[] names, int number)
            {
                foreach (var name in names)
                {
                    int sum = 0;
                    for (int i = 0; i < name.Length; i++)
                    {
                        char symbol = name[i];
                        sum += symbol;
                    }

                    if (sum >= number)
                    {
                        return name;
                    }
                }
                return null;
            };
            
            Console.WriteLine(charToInt(names, number));
        }
    }
}
