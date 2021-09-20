using System;
using System.Collections.Generic;
using System.Linq;

namespace _07._Truck_Tour
{
    class Program
    {
        static void Main(string[] args)
        {
            int amountOfPumps = int.Parse(Console.ReadLine());
            Queue<int[]> stations = new Queue<int[]>();

            int currentPetrol = 0;
            int requiredDistance = 0;

            for (int i = 0; i < amountOfPumps; i++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

                stations.Enqueue(input);
            }

            int startPoint = 0;

            while (stations.Any())
            {
                Queue<int[]> currentStation = new Queue<int[]>(stations.ToArray());


                while (currentStation.Any())
                {
                    int[] currentQueue = currentStation.Peek();
                    currentPetrol += currentQueue[0];
                    requiredDistance = currentQueue[1];

                    if (currentPetrol >= requiredDistance)
                    {
                        currentStation.Dequeue();
                        currentPetrol -= requiredDistance;
                    }
                    else if (currentPetrol < requiredDistance)
                    {
                        currentPetrol = 0;
                        startPoint++;
                        int[] elementToAdd = stations.Dequeue();
                        stations.Enqueue(elementToAdd);
                        break;
                    }
                }

                if (!currentStation.Any())
                {
                    break;
                }
                if (startPoint == amountOfPumps + 1)
                {
                    break;
                }
            }

            if (stations.Any() && startPoint == amountOfPumps + 1)
            {
                
            }
            else
            {
                Console.WriteLine(startPoint);
            }
        }
    }
}
