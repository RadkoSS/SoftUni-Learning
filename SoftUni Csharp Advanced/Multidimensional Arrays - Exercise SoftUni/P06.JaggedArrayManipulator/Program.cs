using System;
using System.Linq;

namespace P06.JaggedArrayManipulator
{
    class Program
    {
        static void Main()
        {
            int rowsCount = int.Parse(Console.ReadLine());

            int[][] jaggedArray = new int[rowsCount][];

            InitializeJaggedArray(jaggedArray, rowsCount);

            ExecuteCommands(jaggedArray);
        }
        static void InitializeJaggedArray(int[][] jaggedArray, int rowsCount)
        {
            for (int row = 0; row < rowsCount; row++)
            {
                jaggedArray[row] = ReadArray();
            }

            for (int row = 0; row < rowsCount - 1; row++)
            {
                int[] currentRow = jaggedArray[row];
                int[] nextRow = jaggedArray[row + 1];

                if (currentRow.Length == nextRow.Length)
                {
                    for (int column = 0; column < currentRow.Length; column++)
                    {
                        currentRow[column] *= 2;
                    }
                    for (int column = 0; column < nextRow.Length; column++)
                    {
                        nextRow[column] *= 2;
                    }
                }
                else
                {
                    for (int column = 0; column < currentRow.Length; column++)
                    {
                        currentRow[column] /= 2;
                    }
                    for (int column = 0; column < nextRow.Length; column++)
                    {
                        nextRow[column] /= 2;
                    }
                }
            }
        }
        static int[] ReadArray()
        {
            return Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        }
        static void ExecuteCommands(int[][] jaggedArray)
        {
            string command = string.Empty;
            while ((command = Console.ReadLine()) != "End")
            {
                string[] commandArguments = command.Split(" ", StringSplitOptions.RemoveEmptyEntries);

                if (commandArguments[0] == "Add")
                {
                    int rowNumber = int.Parse(commandArguments[1]);
                    int columnNumber = int.Parse(commandArguments[2]);
                    int valueToAdd = int.Parse(commandArguments[3]);

                    if (!CheckIfIndicesAreValid(jaggedArray, rowNumber, columnNumber))
                    {
                        continue;
                    }
                    jaggedArray[rowNumber][columnNumber] += valueToAdd;
                }
                else if (commandArguments[0] == "Subtract")
                {
                    int rowNumber = int.Parse(commandArguments[1]);
                    int columnNumber = int.Parse(commandArguments[2]);
                    int valueToSubtract = int.Parse(commandArguments[3]);

                    if (!CheckIfIndicesAreValid(jaggedArray, rowNumber, columnNumber))
                    {
                        continue;
                    }
                    jaggedArray[rowNumber][columnNumber] -= valueToSubtract;
                }
            }

            PrintMatrix(jaggedArray);
        }
        static bool CheckIfIndicesAreValid(int[][] jaggedArray, int rowNumber, int columnNumber)
        {
            if (rowNumber < 0 || rowNumber >= jaggedArray.GetLength(0) || columnNumber < 0 || columnNumber >= jaggedArray[rowNumber].Length)
            {
                return false;
            }
            return true;
        }
        static void PrintMatrix(int[][] jaggedArray)
        {
            for (int row = 0; row < jaggedArray.GetLength(0); row++)
            {
                for (int column = 0; column < jaggedArray[row].Length; column++)
                {
                    Console.Write($"{jaggedArray[row][column]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
