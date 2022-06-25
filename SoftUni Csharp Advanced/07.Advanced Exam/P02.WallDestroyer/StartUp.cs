using System;

namespace P02.WallDestroyer
{
    public class StartUp
    {
        static void Main()
        {
            var size = int.Parse(Console.ReadLine());

            var wall = new char[size, size];

            var vankoRow = -1;
            var vankoColumn = -1;

            var isElectrocuted = false;

            InitializeWall(ref wall, ref vankoRow, ref vankoColumn);

            ExecuteCommandsAndPrint(ref wall, ref vankoRow, ref vankoColumn, ref isElectrocuted);
        }

        static void InitializeWall(ref char[,] wall, ref int vankoRow, ref int vankoColumn)
        {
            for (int row = 0; row < wall.GetLength(0); row++)
            {
                var line = Console.ReadLine();

                if (line.Contains('V'))
                {
                    vankoRow = row;
                    vankoColumn = line.IndexOf('V');
                }

                for (int column = 0; column < wall.GetLength(1); column++)
                {
                    wall[row, column] = line[column];
                }
            }
        }

        static void ExecuteCommandsAndPrint(ref char[,] wall, ref int vankoRow, ref int vankoColumn, ref bool isElectrocuted)
        {
            var direction = string.Empty;
            var holesCreated = 1;
            var countOfRods = 0;

            while ((direction = Console.ReadLine()) != "End" && !isElectrocuted)
            {
                var unchangedRow = vankoRow;
                var unchangedColumn = vankoColumn;
                
                if (IsInside(direction, ref vankoRow, ref vankoColumn, wall))
                {
                    var nextPosition = wall[vankoRow, vankoColumn];

                    if (nextPosition == '*')
                    {
                        Console.WriteLine($"The wall is already destroyed at position [{vankoRow}, {vankoColumn}]!");

                        wall[unchangedRow, unchangedColumn] = '*';
                        wall[vankoRow, vankoColumn] = 'V';

                    }

                    if (nextPosition == '-')
                    {
                        wall[unchangedRow, unchangedColumn] = '*';
                        wall[vankoRow, vankoColumn] = 'V';

                        holesCreated++;
                    }

                    else if (nextPosition == 'C')
                    {
                        wall[unchangedRow, unchangedColumn] = '*';
                        wall[vankoRow, vankoColumn] = 'E';

                        holesCreated++;

                        isElectrocuted = true;
                    }

                    else if (nextPosition == 'R')
                    {
                        vankoRow = unchangedRow;
                        vankoColumn = unchangedColumn;

                        countOfRods++;

                        Console.WriteLine("Vanko hit a rod!");
                    }
                }
            }

            PrintResult(wall, vankoRow, vankoColumn, holesCreated, countOfRods, isElectrocuted);
        }

        static bool IsInside(string direction, ref int vankoRow, ref int vankoColumn, char[,] wall)
        {
            if (direction == "up" && vankoRow - 1 >= 0)
            {
                vankoRow--;
                return true;
            }
            else if (direction == "down" && vankoRow + 1 < wall.GetLength(0))
            {
                vankoRow++;
                return true;
            }
            else if (direction == "left" && vankoColumn - 1 >= 0)
            {
                vankoColumn--;
                return true;
            }
            else if (direction == "right" && vankoColumn + 1 < wall.GetLength(1))
            {
                vankoColumn++;
                return true;
            }
            return false;
        }

        static void PrintResult(char[,] wall, int vankoRow, int vankoColumn, int holesCreated, int countOfRods, bool isElectrocuted)
        {
            if (isElectrocuted)
            {
                Console.WriteLine($"Vanko got electrocuted, but he managed to make {holesCreated} hole(s).");
            }
            else
            {
                Console.WriteLine($"Vanko managed to make {holesCreated} hole(s) and he hit only {countOfRods} rod(s).");
            }

            for (int row = 0; row < wall.GetLength(0); row++)
            {
                for (int column = 0; column < wall.GetLength(1); column++)
                {
                    Console.Write(wall[row, column]);
                }
                Console.WriteLine();
            }
        }
    }
}
