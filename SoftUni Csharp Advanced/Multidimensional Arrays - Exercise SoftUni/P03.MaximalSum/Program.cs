using System;
using System.Linq;
using System.Text;

namespace P03.MaximalSum
{
    class Program
    {
        static void Main()
        {
            int[] matrixDimensions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int[,] matrix = new int[matrixDimensions[0], matrixDimensions[1]];

            InitializeMatrix(matrix, matrixDimensions[0]);

            PrintSumAndSquare(matrix, matrixDimensions[0], matrixDimensions[1]);
        }

        static void InitializeMatrix(int[,] matrix, int rowsCount)
        {
            for (int row = 0; row < rowsCount; row++)
            {
                int[] numbers = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

                for (int column = 0; column < numbers.Length; column++)
                {
                    matrix[row, column] = numbers[column];
                }
            }
        }

        static void PrintSumAndSquare(int[,] matrix, int rowsCount, int columnsCount)
        {
            long maximalSum = long.MinValue;
            string maximal3x3Square = string.Empty;

            for (int row = 0; row < rowsCount - 2; row++)
            {
                for (int column = 0; column < columnsCount - 2; column++)
                {
                    long currentSquareSum = matrix[row, column] + matrix[row, column + 1] + matrix[row, column + 2] + matrix[row + 1, column] + matrix[row + 1, column + 1] + matrix[row + 1, column + 2] + matrix[row + 2, column] + matrix[row + 2, column + 1] + matrix[row + 2, column + 2];
                    
                    if (maximalSum < currentSquareSum)
                    {
                        maximalSum = currentSquareSum;

                        StringBuilder square3x3 = new StringBuilder();
                        square3x3.AppendLine($"{matrix[row, column]} {matrix[row, column + 1]} {matrix[row, column + 2]}");
                        square3x3.AppendLine($"{matrix[row + 1, column]} {matrix[row + 1, column + 1]} {matrix[row + 1, column + 2]}");
                        square3x3.AppendLine($"{matrix[row + 2, column]} {matrix[row + 2, column + 1]} {matrix[row + 2, column + 2]}");

                        maximal3x3Square = square3x3.ToString();
                    }
                }
            }
            Console.WriteLine($"Sum = {maximalSum}");
            Console.WriteLine(maximal3x3Square);
        }
    }
}
