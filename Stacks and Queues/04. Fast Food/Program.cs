using System;
using System.Collections.Generic;
using System.Linq;

namespace _04._Fast_Food
{
    class Program
    {
        static void Main(string[] args)
        {
            int food = int.Parse(Console.ReadLine());

            int[] ordersArray = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<int> orders = new Queue<int>(ordersArray);

            Console.WriteLine(orders.Max());

            while (orders.Any())
            {
                int requiredFood = orders.Peek();
                if (requiredFood > food)
                {
                    break;
                }

                food -= requiredFood;
                orders.Dequeue();
            }

            if (orders.Any())
            {
                Console.WriteLine($"Orders left: {string.Join(" ", orders)}");
            }
            else
            {
                Console.WriteLine("Orders complete");
            }
        }
    }
}
