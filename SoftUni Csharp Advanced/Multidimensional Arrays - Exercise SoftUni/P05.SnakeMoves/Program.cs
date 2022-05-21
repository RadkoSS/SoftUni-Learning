using System;
using System.Linq;

namespace P05.SnakeMoves
{
    class Program
    {
        static void Main()
        {
            int[] matrixDimensions = ReadArray();

            char[,] matrix = new char[matrixDimensions[0], matrixDimensions[1]];

            InitializeMatrix(matrix);

            PrintMatrix(matrix);
        }
        static int[] ReadArray()
        {
            return Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        }
        static void InitializeMatrix(char[,] matrix)
        {
            string word = Console.ReadLine();

            for (int row = 0, symbol = -1; row < matrix.GetLength(0); row++)
            {
                if (row % 2 == 0)
                {
                    for (int column = 0; column < matrix.GetLength(1); column++)
                    {
                        if (symbol == word.Length - 1)
                        {
                            symbol = -1;
                        }
                        symbol++;
                        matrix[row, column] = word[symbol];
                    }
                }
                else
                {
                    for (int column = matrix.GetLength(1) - 1; column >= 0; column--)
                    {
                        if (symbol == word.Length - 1)
                        {
                            symbol = -1;
                        }
                        symbol++;
                        matrix[row, column] = word[symbol];
                    }
                }
            }
        }
        static void PrintMatrix(char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    Console.Write(matrix[row, column]);
                }
                Console.WriteLine();
            }
        }
    }
}
