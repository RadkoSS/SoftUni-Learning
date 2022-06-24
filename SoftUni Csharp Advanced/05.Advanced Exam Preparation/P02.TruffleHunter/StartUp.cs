using System;

namespace P02.TruffleHunter
{
    public class StartUp
    {
        static void Main()
        {
            var size = int.Parse(Console.ReadLine());

            var matrix = new char[size, size];

            var countBlackTruffles = 0;
            var countSummerTruffles = 0;
            var countWhiteTruffles = 0;
            var countOfEatenTruffles = 0;

            InitializeMatrix(ref matrix);

            ExecuteCommands(ref matrix, ref countBlackTruffles, ref countSummerTruffles, ref countWhiteTruffles, ref countOfEatenTruffles);

            PrintResult(matrix, countBlackTruffles, countSummerTruffles, countWhiteTruffles, countOfEatenTruffles);
        }

        static void InitializeMatrix(ref char[,] matrix)
        {
            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                var line = Console.ReadLine().Replace(" ", string.Empty);

                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    matrix[row, column] = line[column];
                }
            }
        }

        static void ExecuteCommands(ref char[,] matrix, ref int countBlackTruffles, ref int countSummerTruffles, ref int countWhiteTruffles, ref int countOfEatenTruffles)
        {
            var command = string.Empty;

            while ((command = Console.ReadLine()) != "Stop the hunt")
            {
                var commandTokens = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                var commandType = commandTokens[0];

                var rowIndex = int.Parse(commandTokens[1]);

                var columnIndex = int.Parse(commandTokens[2]);

                if (commandType == "Collect")
                {
                    if (rowIndex >= 0 && rowIndex < matrix.GetLength(0) && columnIndex >= 0 && columnIndex < matrix.GetLength(1))
                    {
                        if (matrix[rowIndex, columnIndex] == 'B')
                        {
                            countBlackTruffles++;
                            matrix[rowIndex, columnIndex] = '-';
                        }
                        else if (matrix[rowIndex, columnIndex] == 'S')
                        {
                            countSummerTruffles++;
                            matrix[rowIndex, columnIndex] = '-';
                        }
                        else if (matrix[rowIndex, columnIndex] == 'W')
                        {
                            countWhiteTruffles++;
                            matrix[rowIndex, columnIndex] = '-';
                        }
                    }
                }

                else if (commandType == "Wild_Boar")
                {
                    var direction = commandTokens[3];

                    if (direction == "up")
                    {
                        for (int row = rowIndex; row >= 0; row -= 2)
                        {
                            var currentPosition = matrix[row, columnIndex];
                            if (currentPosition == 'W' || currentPosition == 'S' || currentPosition == 'B')
                            {
                                countOfEatenTruffles++;
                                matrix[row, columnIndex] = '-';
                            }
                        }
                    }

                    else if (direction == "down")
                    {
                        for (int row = rowIndex; row < matrix.GetLength(0); row += 2)
                        {
                            var currentPosition = matrix[row, columnIndex];
                            if (currentPosition == 'W' || currentPosition == 'S' || currentPosition == 'B')
                            {
                                countOfEatenTruffles++;
                                matrix[row, columnIndex] = '-';
                            }
                        }
                    }

                    else if (direction == "left")
                    {
                        for (int column = columnIndex; column >= 0; column -= 2)
                        {
                            var currentPosition = matrix[rowIndex, column];
                            if (currentPosition == 'W' || currentPosition == 'S' || currentPosition == 'B')
                            {
                                countOfEatenTruffles++;
                                matrix[rowIndex, column] = '-';
                            }
                        }
                    }

                    else if (direction == "right")
                    {
                        for (int column = columnIndex; column < matrix.GetLength(1); column += 2)
                        {
                            var currentPosition = matrix[rowIndex, column];
                            if (currentPosition == 'W' || currentPosition == 'S' || currentPosition == 'B')
                            {
                                countOfEatenTruffles++;
                                matrix[rowIndex, column] = '-';
                            }
                        }
                    }

                }
            }
        }

        static void PrintResult(char[,] matrix, int countBlackTruffles, int countSummerTruffles, int countWhiteTruffles, int countOfEatenTruffles)
        {
            Console.WriteLine($"Peter manages to harvest {countBlackTruffles} black, {countSummerTruffles} summer, and {countWhiteTruffles} white truffles.");

            Console.WriteLine($"The wild boar has eaten {countOfEatenTruffles} truffles.");

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                for (int column = 0; column < matrix.GetLength(1); column++)
                {
                    if (column == matrix.GetLength(1) - 1)
                        Console.Write(matrix[row, column]);

                    else
                        Console.Write($"{matrix[row, column]} ");
                }
                Console.WriteLine();
            }
        }
    }
}
