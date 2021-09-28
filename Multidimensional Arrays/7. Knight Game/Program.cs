using System;
using System.Linq;

namespace _6._Jagged_Array_Manipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int size = int.Parse(Console.ReadLine());
            char[,] matrix = new char[size, size];
            int rowIndex = 0;
            int colIndex = 0;
            int attackCounter = 0;

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                string input = Console.ReadLine();

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }

            while (true)
            {
                bool didWeFindAttacks = false;
                int maxKnightAttacked = 0;

                for (int row = 0; row < matrix.GetLength(0); row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        int knightsAttacked = 0;

                        if (matrix[row, col] == 'K')
                        {
                            didWeAttackMethod(matrix, ref didWeFindAttacks, row, col, ref knightsAttacked, -2, 1);
                            didWeAttackMethod(matrix, ref didWeFindAttacks, row, col, ref knightsAttacked, -1, 2);
                            didWeAttackMethod(matrix, ref didWeFindAttacks, row, col, ref knightsAttacked, 1, 2);
                            didWeAttackMethod(matrix, ref didWeFindAttacks, row, col, ref knightsAttacked, 2, 1);
                            didWeAttackMethod(matrix, ref didWeFindAttacks, row, col, ref knightsAttacked, 2, -1);
                            didWeAttackMethod(matrix, ref didWeFindAttacks, row, col, ref knightsAttacked, 1, -2);
                            didWeAttackMethod(matrix, ref didWeFindAttacks, row, col, ref knightsAttacked, -1, -2);
                            didWeAttackMethod(matrix, ref didWeFindAttacks, row, col, ref knightsAttacked, -2, -1);
                        }

                        if (knightsAttacked > maxKnightAttacked)
                        {
                            maxKnightAttacked = knightsAttacked;
                            rowIndex = row;
                            colIndex = col;
                            didWeFindAttacks = true;
                        }
                    }
                }

                if (didWeFindAttacks)
                {
                    matrix[rowIndex, colIndex] = '0';
                    attackCounter++;
                }
                else
                {
                    break;
                }
            }

            Console.WriteLine(attackCounter);
        }

        static void didWeAttackMethod(char[,] matrix, ref bool didWeFindAttacks, int row, int col, ref int knightsAttacked, int rowNumber, int colNumber)
        {
            if (row + rowNumber >= 0 
                && row + rowNumber < matrix.GetLength(1) 
                && col + colNumber < matrix.GetLength(1) 
                && col + colNumber >= 0 
                && matrix[row + rowNumber, col + colNumber] == 'K')
            {
                knightsAttacked++;
            }
        }
    }
}
