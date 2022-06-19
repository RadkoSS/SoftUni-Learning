using System;

namespace P02.TheBattleOfTheFiveArmies
{
    public class StartUp
    {
        static void Main()
        {
            int armor = int.Parse(Console.ReadLine());

            int rowsCount = int.Parse(Console.ReadLine());

            char[][] battleField = new char[rowsCount][];

            int armyRow = -1;
            int armyColumn = -1;

            InitializeBatllefield(rowsCount, ref battleField, ref armyRow, ref armyColumn);

            bool isOver = false;
            bool warWasWon = false;

            ExecuteOrders(ref battleField, ref armor, ref armyRow, ref armyColumn, ref isOver, ref warWasWon);

            if (warWasWon)
            {
                Console.WriteLine($"The army managed to free the Middle World! Armor left: {armor}");
            }

            else if (isOver)
            {
                Console.WriteLine($"The army was defeated at {armyRow};{armyColumn}.");
            }

            for (int row = 0; row < battleField.GetLength(0); row++)
            {
                Console.WriteLine(battleField[row]);
            }

        }

        static void InitializeBatllefield(int rowsCount, ref char[][] battleField, ref int armyRow, ref int armyColumn)
        {
            for (int row = 0; row < rowsCount; row++)
            {
                var line = Console.ReadLine().Replace(" ", string.Empty);

                if (line.Contains('A'))
                {
                    armyRow = row;
                    armyColumn = line.IndexOf('A');
                }

                battleField[row] = line.ToCharArray();

            }
        }

        static void ExecuteOrders(ref char[][] battleField, ref int armor, ref int armyRow, ref int armyColumn, ref bool isOver, ref bool warWasWon)
        {
            while (!isOver && armor > 0)
            {
                var command = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                var direction = command[0];
                var row = int.Parse(command[1]);
                var column = int.Parse(command[2]);

                battleField[row][column] = 'O';

                armor--;

                if (direction == "up")
                {
                    if (IsRowValid(battleField, armyRow - 1))
                    {

                        var nextPlace = battleField[armyRow - 1][armyColumn];

                        if (nextPlace == 'M')
                        {
                            battleField[armyRow][armyColumn] = '-';

                            battleField[armyRow - 1][armyColumn] = '-';

                            warWasWon = true;

                            isOver = true;
                        }

                        else if (nextPlace == 'O')
                        {
                            armor -= 2;
                            if (armor <= 0)
                            {
                                battleField[armyRow - 1][armyColumn] = 'X';
                                battleField[armyRow][armyColumn] = '-';
                                isOver = true;
                            }
                            else
                            {
                                battleField[armyRow - 1][armyColumn] = 'A';
                                battleField[armyRow][armyColumn] = '-';
                            }
                        }

                        else
                        {
                            battleField[armyRow - 1][armyColumn] = 'A';
                            battleField[armyRow][armyColumn] = '-';
                        }

                        armyRow--;
                    }
                }
                else if (direction == "down")
                {

                    if (IsRowValid(battleField, armyRow + 1))
                    {

                        var nextPlace = battleField[armyRow + 1][armyColumn];

                        if (nextPlace == 'M')
                        {
                            battleField[armyRow][armyColumn] = '-';

                            battleField[armyRow + 1][armyColumn] = '-';

                            warWasWon = true;

                            isOver = true;
                        }

                        else if (nextPlace == 'O')
                        {
                            armor -= 2;
                            if (armor <= 0)
                            {
                                battleField[armyRow + 1][armyColumn] = 'X';
                                battleField[armyRow][armyColumn] = '-';
                                isOver = true;
                            }
                            else
                            {
                                battleField[armyRow + 1][armyColumn] = 'A';
                                battleField[armyRow][armyColumn] = '-';
                            }
                        }

                        else
                        {
                            battleField[armyRow + 1][armyColumn] = 'A';
                            battleField[armyRow][armyColumn] = '-';
                        }

                        armyRow++;
                    }
                }
                else if (direction == "left")
                {

                    if (IsColumnValid(battleField, armyRow, armyColumn - 1))
                    {

                        var nextPlace = battleField[armyRow][armyColumn - 1];

                        if (nextPlace == 'M')
                        {
                            battleField[armyRow][armyColumn] = '-';

                            battleField[armyRow][armyColumn - 1] = '-';

                            warWasWon = true;

                            isOver = true;
                        }

                        else if (nextPlace == 'O')
                        {
                            armor -= 2;
                            if (armor <= 0)
                            {
                                battleField[armyRow][armyColumn - 1] = 'X';
                                battleField[armyRow][armyColumn] = '-';
                                isOver = true;
                            }
                            else
                            {
                                battleField[armyRow][armyColumn - 1] = 'A';
                                battleField[armyRow][armyColumn] = '-';
                            }
                        }

                        else
                        {
                            battleField[armyRow][armyColumn - 1] = 'A';
                            battleField[armyRow][armyColumn] = '-';
                        }

                        armyColumn--;
                    }
                }
                else if (direction == "right")
                {
                    if (IsColumnValid(battleField, armyRow, armyColumn + 1))
                    {

                        var nextPlace = battleField[armyRow][armyColumn + 1];

                        if (nextPlace == 'M')
                        {
                            battleField[armyRow][armyColumn] = '-';

                            battleField[armyRow][armyColumn + 1] = '-';

                            warWasWon = true;

                            isOver = true;
                        }

                        else if (nextPlace == 'O')
                        {
                            armor -= 2;
                            if (armor <= 0)
                            {
                                battleField[armyRow][armyColumn + 1] = 'X';
                                battleField[armyRow][armyColumn] = '-';
                                isOver = true;
                            }
                            else
                            {
                                battleField[armyRow][armyColumn + 1] = 'A';
                                battleField[armyRow][armyColumn] = '-';
                            }
                        }

                        else
                        {
                            battleField[armyRow][armyColumn + 1] = 'A';
                            battleField[armyRow][armyColumn] = '-';
                        }

                        armyColumn++;
                    }
                }
            }
        }

        static bool IsRowValid(char[][] jaggedArray, int row) => row >= 0 && row < jaggedArray.GetLength(0);

        static bool IsColumnValid(char[][] jaggedArray, int row, int column) => column >= 0 && column < jaggedArray[row].Length;

    }
}
