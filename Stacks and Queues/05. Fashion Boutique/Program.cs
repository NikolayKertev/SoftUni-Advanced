using System;
using System.Collections.Generic;
using System.Linq;

namespace _05._Fashion_Boutique
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] clothesArray = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Stack<int> clothes = new Stack<int>(clothesArray);
            int racksNeeded = 0;
            int rackSize = int.Parse(Console.ReadLine());

            while (clothes.Any())
            {
                int currentRack = 0;
                while (true)
                {
                    if (!clothes.Any())
                    {
                        if (currentRack != 0)
                        {
                            racksNeeded++;
                        }
                        break;
                    }
                    if (currentRack + clothes.Peek() > rackSize || currentRack == rackSize)
                    {
                        racksNeeded++;
                        break;
                    }

                    currentRack += clothes.Pop();
                }
            }

            Console.WriteLine(racksNeeded);
        }
    }
}
