using System;
using System.Linq;

namespace P04.MatrixShuffling
{
    class Program
    {
        static void Main()
        {
            int[] matrixDimensions = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            string[,] matrix = new string[matrixDimensions[0], matrixDimensions[1]];

            InitializeMatrix(matrix, matrixDimensions[0]);

            ExecuteCommands(matrix);
        }
        static void InitializeMatrix(string[,] matrix, int rowsCount)
        {
            for (int row = 0; row < rowsCount; row++)
            {
                string[] line = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);

                for (int column = 0; column < line.Length; column++)
                {
                    matrix[row, column] = line[column];
                }
            }
        }
        static void ExecuteCommands(string[,] matrix)
        {
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "END")
            {
                string[] commandArgs = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                
                if (commandArgs[0] == "swap" && commandArgs.Length == 5)
                {
                    int firstNumber = int.Parse(commandArgs[1]);
                    int secondNumber = int.Parse(commandArgs[2]);
                    int thirdNumber = int.Parse(commandArgs[3]);
                    int fourthNumber = int.Parse(commandArgs[4]);

                    if (!CheckIfIndicesAreValid(matrix, firstNumber, secondNumber, thirdNumber, fourthNumber))
                    {
                        Console.WriteLine("Invalid input!");
                        continue;
                    }

                    string originalValue = matrix[firstNumber, secondNumber];

                    matrix[firstNumber, secondNumber] = matrix[thirdNumber, fourthNumber];

                    matrix[thirdNumber, fourthNumber] = originalValue;

                    PrintMatrix(matrix);
                }
                else
                    Console.WriteLine("Invalid input!");
            }
        }
        static bool CheckIfIndicesAreValid(string[,] matrix, int firstNumber, int secondNumber, int thirdNumber, int fourthNumber)
        {
            if (firstNumber < 0 || firstNumber >= matrix.GetLength(0) || secondNumber < 0 || secondNumber >= matrix.GetLength(1) || thirdNumber < 0 || thirdNumber >= matrix.GetLength(0) || fourthNumber < 0 || fourthNumber >= matrix.GetLength(1))
            {
                return false;
            }
            return true;
        }
        static void PrintMatrix(string[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    Console.Write($"{matrix[row, column]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
