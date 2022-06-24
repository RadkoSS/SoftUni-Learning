using System;
using System.Collections.Generic;

namespace P02.BeaverAtWork
{
    public class StartUp
    {
        static void Main()
        {
            var size = int.Parse(Console.ReadLine());

            var pond = new char[size, size];

            var beaverRow = -1;

            var beaverColumn = -1;

            var branchesTotalCount = 0;

            InitializePond(ref pond, ref beaverRow, ref beaverColumn, ref branchesTotalCount);

            ExecuteCommandsAndPrint(ref pond, ref beaverRow, ref beaverColumn, branchesTotalCount);
        }

        static void InitializePond(ref char[,] pond, ref int beaverRow, ref int beaverColumn, ref int branchesTotalCount)
        {
            for (int row = 0; row < pond.GetLength(0); row++)
            {
                var line = Console.ReadLine().Replace(" ", string.Empty);

                if (line.Contains('B'))
                {
                    beaverRow = row;
                    beaverColumn = line.IndexOf('B');
                }

                foreach (char ch in line)
                {
                    if (char.IsLower(ch))
                    {
                        branchesTotalCount++;
                    }
                }

                for (int column = 0; column < pond.GetLength(1); column++)
                {
                    pond[row, column] = line[column];
                }
            }
        }

        static bool CheckIfCharIsLower(char ch) => char.IsLower(ch);


        private static void ExecuteCommandsAndPrint(ref char[,] pond, ref int beaverRow, ref int beaverColumn, int branchesTotalCount)
        {
            var collectedBranches = new List<char>();
            int collectedCount = 0;

            var command = string.Empty;

            while ((command = Console.ReadLine()) != "end" && collectedCount < branchesTotalCount)
            {

                if (command == "up" && beaverRow - 1 >= 0)
                {
                    pond[beaverRow, beaverColumn] = '-';
                    beaverRow--;
                }
               
                else if (command == "down" && beaverRow + 1 < pond.GetLength(0))
                {
                    pond[beaverRow, beaverColumn] = '-';
                    beaverRow++;
                }

                else if (command == "left" && beaverColumn - 1 >= 0)
                {
                    pond[beaverRow, beaverColumn] = '-';
                    beaverColumn--;
                }

                else if (command == "right" && beaverColumn + 1 < pond.GetLength(1))
                {
                    pond[beaverRow, beaverColumn] = '-';
                    beaverColumn++;
                }

                else
                {
                    if (collectedBranches.Count > 0)
                    {
                        collectedBranches.RemoveAt(collectedBranches.Count - 1);
                        continue;
                    }
                }

                var nextPosition = pond[beaverRow, beaverColumn];

                if (nextPosition == 'F')
                {
                    if (beaverRow == 0)
                    {
                        pond[beaverRow, beaverColumn] = '-';
                        beaverRow = pond.GetLength(0) - 1;
                    }

                    else if (beaverRow == pond.GetLength(0) - 1)
                    {
                        pond[beaverRow, beaverColumn] = '-';
                        beaverRow = 0;
                    }

                    else if (beaverColumn == 0)
                    {
                        pond[beaverRow, beaverColumn] = '-';
                        beaverColumn = pond.GetLength(0) - 1;
                    }

                    else if (beaverColumn == pond.GetLength(1) - 1)
                    {
                        pond[beaverRow, beaverColumn] = '-';
                        beaverColumn = 0;
                    }

                    else
                    {
                        if (command == "left")
                        {
                            pond[beaverRow, beaverColumn] = '-';
                            beaverColumn = 0;
                        }

                        else if (command == "right")
                        {
                            pond[beaverRow, beaverColumn] = '-';
                            beaverColumn = pond.GetLength(1) - 1;
                        }

                        else if (command == "up")
                        {
                            pond[beaverRow, beaverColumn] = '-';
                            beaverRow = 0;
                        }

                        else if (command == "down")
                        {
                            pond[beaverRow, beaverColumn] = '-';
                            beaverRow = pond.GetLength(0) - 1;
                        }
                    }
                    
                    var positionAfterSwimming = pond[beaverRow, beaverColumn];

                    if (CheckIfCharIsLower(positionAfterSwimming))
                    {
                        collectedBranches.Add(positionAfterSwimming);
                        collectedCount++;
                    }
                    
                }

                else if (CheckIfCharIsLower(nextPosition))
                {
                    collectedBranches.Add(nextPosition);
                    collectedCount++;
                }

                pond[beaverRow, beaverColumn] = 'B';
            }

            PrintPond(pond, collectedBranches, branchesTotalCount, collectedCount);
        }

        static void PrintPond(char[,] pond, List<char> collectedBranches, int totalBranchesCount, int collectedCount)
        {
            if (collectedCount < totalBranchesCount)
            {
                Console.WriteLine($"The Beaver failed to collect every wood branch. There are {totalBranchesCount - collectedCount} branches left.");
            }
            else
            {
                Console.WriteLine($"The Beaver successfully collect {collectedBranches.Count} wood branches: {string.Join(", ", collectedBranches)}.");
            }

            for (int row = 0; row < pond.GetLength(0); row++)
            {
                for (int column = 0; column < pond.GetLength(1); column++)
                {
                    if (column == pond.GetLength(1) - 1)
                    {
                        Console.Write(pond[row, column]);
                    }
                    else
                    {
                        Console.Write($"{pond[row, column]} ");
                    }
                }
                Console.WriteLine();
            }
        }
    }
}
