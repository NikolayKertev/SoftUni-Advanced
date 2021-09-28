using System;
using System.Linq;

namespace _6._Jagged_Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int rows = int.Parse(Console.ReadLine());
            double[][] matrix = new double[rows][];
            bool isEqual = false;

            for (int i = 0; i < rows; i++)
            {
                double[] input = Console.ReadLine().Split().Select(double.Parse).ToArray();
                matrix[i] = input;
            }

            for (int row = 0; row < matrix.GetLength(0) - 1; row++)
            {
                isEqual = matrix[row].Length == matrix[row + 1].Length;

                for (int col = 0; col < matrix[row].Length; col++)
                {
                    isEqualMethod(matrix, isEqual, row, col);
                }
                for (int col2 = 0; col2 < matrix[row + 1].Length; col2++)
                {
                    isEqualMethod(matrix, isEqual, row + 1, col2);
                }
            }

            while (true)
            {
                string[] input = Console.ReadLine().Split();
                string action = input[0];
                if (action == "End")
                {
                    break;
                }

                int row = int.Parse(input[1]);
                int col = int.Parse(input[2]);
                int value = int.Parse(input[3]);

                if (action == "Add")
                {
                    if (row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix[row].Length)
                    {
                        matrix[row][col] += value;
                    }
                }
                else if (action == "Subtract")
                {
                    if (row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix[row].Length)
                    {
                        matrix[row][col] -= value;
                    }
                }
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                Console.WriteLine(string.Join(" ", matrix[row]));
            }
        }

        static void isEqualMethod(double[][] matrix, bool isEqual, int row, int col)
        {
            if (isEqual)
            {
                matrix[row][col] *= 2;
            }
            else
            {
                matrix[row][col] /= 2;
            }
        }
    }
}
