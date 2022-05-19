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

            for (int row = 0; row < matrixSize; row++)
            {
                int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
                for (int column = 0; column < matrixSize; column++)
                {
                    matrix[row, column] = numbers[column];
                }
            }

            int primaryDiagSum = 0;
            int secondaryDiagSum = 0;

            for (int rows = 0; rows < matrixSize; rows++)
            {
                for (int cols = 0; cols < matrixSize; cols++)
                {
                    primaryDiagSum += matrix[rows, cols];
                }
            }
            Console.WriteLine(primaryDiagSum);
        }
    }
}
