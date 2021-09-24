using System;
using System.Linq;

namespace _2._Squares_in_Matrix
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] size = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int rows = size[0];
            int cols = size[1];
            int row1 = 0;
            int col1 = 0;
            int row2 = 0;
            int col2 = 0;

            string[,] matrix = new string[rows, cols];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            while (true)
            {
                string input = Console.ReadLine();
                string[] arg = input.Split();

                if (input == "END")
                {
                    break;
                }
                if ((!(arg.Length == 5)) || (!input.Contains("swap")))
                {
                    Console.WriteLine($"Invalid input!");
                    continue;

                }

                row1 = int.Parse(arg[1]);
                col1 = int.Parse(arg[2]);
                row2 = int.Parse(arg[3]);
                col2 = int.Parse(arg[4]);

                if (row1 < 0 || row1 > matrix.GetLength(0) ||
                    col1 < 0 || col1 > matrix.GetLength(1) ||
                    row2 < 0 || row2 > matrix.GetLength(0) ||
                    col2 < 0 || col2 > matrix.GetLength(1))
                {
                    Console.WriteLine($"Invalid input!");
                    continue;
                }

                string current = matrix[row1, col1];
                matrix[row1, col1] = matrix[row2, col2];
                matrix[row2, col2] = current;

                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        Console.Write(matrix[i, j] + " ");
                    }
                    Console.WriteLine();
                }
            }
        }
    }
}
