using System;
using System.Collections.Generic;
using System.Linq;

namespace _06._Songs_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] songsArray = Console.ReadLine().Split(", ");
            Queue<string> songs = new Queue<string>(songsArray);

            while (true)
            {
                string input = Console.ReadLine();
                if (!songs.Any())
                {
                    Console.WriteLine($"No more songs!");
                    break;
                }
                if (input.Contains("Play"))
                {
                    songs.Dequeue();
                }
                else if (input.Contains("Add"))
                {
                    input = input.Substring(4, input.Length - 4);
                    if (songs.Contains(input))
                    {
                        Console.WriteLine($"{input} is already contained!");
                    }
                    else
                    {
                        songs.Enqueue(input);
                    }
                }
                else if (input.Contains("Show"))
                {
                    Console.WriteLine(string.Join(", ", songs));
                }
            }
        }
    }
}
