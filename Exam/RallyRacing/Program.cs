using System;

namespace RallyRacing
{
    class Program
    {
        static void Main(string[] args)
        {
            int N = int.Parse(Console.ReadLine());
            string racer = Console.ReadLine();
            string[,] matrix = new string[N, N];

            int carRow = 0;
            int carCol = 0;
            int distancePassed = 0;

            bool hasFinished = false;

            for (int row = 0; row < N; row++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    matrix[row, col] = input[col];
                }
            }
            matrix[0, 0] = "C";

            while (true)
            {
                string input = Console.ReadLine();

                switch (input)
                {
                    case "up":
                        CarMovement(matrix, carRow, carCol, ref distancePassed, -1, 0, ref carRow, ref carCol, ref hasFinished);
                        break;
                    case "down":
                        CarMovement(matrix, carRow, carCol, ref distancePassed, 1, 0, ref carRow, ref carCol, ref hasFinished);
                        break;
                    case "left":
                        CarMovement(matrix, carRow, carCol, ref distancePassed, 0, -1, ref carRow, ref carCol, ref hasFinished);
                        break;
                    case "right":
                        CarMovement(matrix, carRow, carCol, ref distancePassed, 0, 1, ref carRow, ref carCol, ref hasFinished);
                        break;
                }

                if (hasFinished)
                {
                    Console.WriteLine($"Racing car {racer} finished the stage!");
                    break;
                }
                else if (input == "End")
                {
                    Console.WriteLine($"Racing car {racer} DNF.");
                    break;
                }

                Console.Clear();

                for (int row = 0; row < N; row++)
                {
                    for (int col = 0; col < matrix.GetLength(1); col++)
                    {
                        Console.Write(matrix[row, col]);
                    }
                    Console.WriteLine();
                }
            }

            Console.WriteLine($"Distance covered {distancePassed} km." );


            for (int row = 0; row < N; row++)
            {
                for (int col = 0; col < matrix.GetLength(1); col++)
                {
                    Console.Write(matrix[row, col]);
                }
                Console.WriteLine();
            }
        }

        static void CarMovement(string[,] matrix, int row, int col, ref int distancePassed, int rowNumber, int colNumber, ref int carRow, ref int carCol, ref bool hasFinished)
        {
            bool hasGoneThroughTunel = false;

            matrix[row, col] = ".";

            if (matrix[row + rowNumber, col + colNumber] == "T")
            {
                matrix[row + rowNumber, col + colNumber] = ".";

                hasGoneThroughTunel = true;

                if (hasGoneThroughTunel)
                {
                    for (int r = 0; r < matrix.GetLength(0); r++)
                    {
                        bool hasPassed = false;

                        for (int c = 0; c < matrix.GetLength(1); c++)
                        {
                            if (matrix[r, c] == "T")
                            {
                                matrix[row, col] = ".";
                                row = r;
                                col = c;
                                matrix[row, col] = "C";

                                hasPassed = true;
                                break;
                            }
                        }
                        if (hasPassed)
                        {
                            break;
                        }
                    }
                }

                carRow = row;
                carCol = col;
                distancePassed += 30;
                return;
            }

            if (matrix[row + rowNumber, col + colNumber] == "F")
            {
                matrix[row, col] = ".";
                matrix[row + rowNumber, col + colNumber] = "C";
                hasFinished = true;
                distancePassed += 10;
                return;
            }

            matrix[row + rowNumber, col + colNumber] = "C";
            distancePassed += 10;
            carRow = row + rowNumber;
            carCol = col + colNumber;
        }
    }
}
