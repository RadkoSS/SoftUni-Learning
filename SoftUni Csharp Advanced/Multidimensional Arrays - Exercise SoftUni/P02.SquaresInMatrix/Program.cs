using System;
using System.Linq;

namespace P02.SquaresInMatrix
{
    class Program
    {
        static void Main()
        {
            int[] matrixDimensions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            char[,] matrix = new char[matrixDimensions[0], matrixDimensions[1]];

            InitializeMatrix(matrix, matrixDimensions[0]);

            Console.WriteLine(CountMatrixes(matrix, matrixDimensions[0], matrixDimensions[1]));
        }

        static void InitializeMatrix(char[,] matrix, int rowsCount)
        {
            for (int row = 0; row < rowsCount; row++)
            {
                char[] line = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(char.Parse).ToArray();
                for (int column = 0; column < line.Length; column++)
                {
                    matrix[row, column] = line[column];
                }
            }
        }

        static int CountMatrixes(char[,] matrix, int rowsCount, int columnsCount)
        {
            int matrixesCount = 0;

            for (int row = 0; row < rowsCount - 1; row++)
            {
                for (int column = 0; column < columnsCount - 1; column++)
                {
                    if (matrix[row, column] == matrix[row, column + 1] && matrix[row + 1, column] == matrix[row + 1, column + 1] && matrix[row, column + 1] == matrix[row + 1, column] && matrix[row, column] == matrix[row + 1, column + 1])
                    {
                        matrixesCount++;
                    }
                }
            }

            return matrixesCount;
        }
    }
}
