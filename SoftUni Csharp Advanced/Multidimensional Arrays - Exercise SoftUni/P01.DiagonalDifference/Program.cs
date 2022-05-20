using System;
using System.Linq;

namespace P01.DiagonalDifference
{
    class Program
    {
        static void Main()
        {
            int matrixSize = int.Parse(Console.ReadLine());
            int[,] matrix = new int[matrixSize, matrixSize];

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();

                if (numbers.Length == matrixSize)
                {
                    for (int column = 0; column < numbers.Length; column++)
                    {
                        matrix[row, column] = numbers[column];
                    }
                }
            }

            int primaryDiagSum = 0;
            for (int row = 0, column = 0; row < matrix.GetLength(0); row++, column++)
            {
                primaryDiagSum += matrix[row, column];
            }

            int secondaryDiagSum = 0;
            for (int row = 0, column = matrix.GetLength(1) - 1; row < matrix.GetLength(0); row++, column--)
            {
                secondaryDiagSum += matrix[row, column];
            }

            Console.WriteLine(Math.Abs(primaryDiagSum - secondaryDiagSum));
        }
    }
}
