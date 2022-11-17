using System;
using System.Collections.Generic;
using System.Linq;

namespace EnergyDrinks
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> caffeineInput = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();
            List<int> drinksInput = Console.ReadLine().Split(", ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            int currentCoffeine = 0;

            Stack<int> caffeine = new Stack<int>(caffeineInput);
            Queue<int> drinks = new Queue<int>(drinksInput);

            while (drinks.Any() && caffeine.Any())
            {
                int firstCaffeine = caffeine.Pop();
                int firstDrink = drinks.Dequeue();

                int totalCaffeine = firstCaffeine * firstDrink;

                if (totalCaffeine + currentCoffeine <= 300)
                {
                    currentCoffeine += totalCaffeine;
                    continue;
                }

                drinks.Enqueue(firstDrink);

                currentCoffeine -= 30;

                if (currentCoffeine < 0)
                {
                    currentCoffeine = 0;
                }
            }

            if (drinks.Any())
            {
                var join = String.Join(", ", drinks);
                Console.WriteLine($"Drinks left: {join}");
            }
            else
            {
                Console.WriteLine("At least Stamat wasn't exceeding the maximum caffeine.");
            }
            Console.WriteLine($"Stamat is going to sleep with {currentCoffeine} mg caffeine.");
        }
    }
}
