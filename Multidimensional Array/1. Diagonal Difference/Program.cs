using System;
using System.Linq;

namespace _1._Diagonal_Difference
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[,] matrix = new int[n, n];
            int firstSum = 0;
            int secondSum = 0;
            int counter = n - 1;

            for (int i = 0; i < n; i++)
            {
                int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int j = 0; j < n; j++)
                {
                    matrix[i, j] = input[j];
                }
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int col = row; col <= row; col++)
                {
                    firstSum += matrix[row, col];
                    secondSum += matrix[row, counter];
                    counter--;
                }
            }

            Console.WriteLine(Math.Abs(firstSum - secondSum));
        }
    }
}
