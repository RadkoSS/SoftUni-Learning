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
                    for (int i = 0; i < numbers.Length; i++)
                    {
                        matrix[row, i] = numbers[i];
                    }
                }
            }

            int primaryDiagSum = 0;
            for (int row = 0, col = 0; row < matrix.GetLength(0); row++, col++)
            {
                primaryDiagSum += matrix[row, col];
            }

            int secondaryDiagSum = 0;
            for (int row = 0, col = matrix.GetLength(1) - 1; row < matrix.GetLength(0); row++, col--)
            {
                secondaryDiagSum += matrix[row, col];
            }

            Console.WriteLine(Math.Abs(primaryDiagSum - secondaryDiagSum));
        }
    }
}
