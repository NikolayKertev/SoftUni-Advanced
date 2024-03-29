﻿using System;
using System.Linq;

namespace _03._Custom_Min_Function
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Func<int[], int> smallest = delegate(int[] array)
            {
                return array.Min();
            };

            Console.WriteLine(smallest(numbers));
        }
    }
}
