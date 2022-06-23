using System;

namespace P02.ReVolt
{
    public class StartUp
    {
        static void Main()
        {
            var sizeOfField = int.Parse(Console.ReadLine());

            var countOfComms = int.Parse(Console.ReadLine());

            var playerRow = -1;

            var playerColumn = -1;

            var field = new char[sizeOfField, sizeOfField];

            InitializeField(ref field, ref playerRow, ref playerColumn);

            ExecuteCommandsAndPrint(ref field, ref playerRow, ref playerColumn, countOfComms);

        }

        static void InitializeField(ref char[,] field, ref int playerRow, ref int playerColumn)
        {

            for (int row = 0; row < field.GetLength(0); row++)
            {
                var line = Console.ReadLine();

                if (line.Contains('f'))
                {
                    playerRow = row;
                    playerColumn = line.IndexOf('f');
                }

                for (int column = 0; column < field.GetLength(1); column++)
                {
                    field[row, column] = line[column];
                }
            }

        }

        static void ExecuteCommandsAndPrint(ref char[,] field, ref int playerRow, ref int playerColumn, int countOfCommands)
        {
            var commandsCounter = 0;
            var finishReached = false;

            while (commandsCounter < countOfCommands && !finishReached)
            {
                var direction = Console.ReadLine();

                var unchangedRow = playerRow;
                var unchangedColumn = playerColumn;

                var moveSucessful = MoveInMatrix(direction, ref playerRow, ref playerColumn, field);

                if (moveSucessful)
                {
                    
                    if (field[playerRow, playerColumn] == 'F')
                    {
                        field[unchangedRow, unchangedColumn] = '-';
                        field[playerRow, playerColumn] = 'f';

                        finishReached = true;
                        break;
                    }

                    else if (field[playerRow, playerColumn] == 'B')
                    {
                        field[unchangedRow, unchangedColumn] = '-';

                        var isInMatrix = MoveInMatrix(direction, ref playerRow, ref playerColumn, field);

                        if (!isInMatrix)
                        {
                            ChangeSides(direction, ref playerRow, ref playerColumn, field);
                        }

                        if (field[playerRow, playerColumn] == 'F')
                        {
                            finishReached = true;
                        }

                        field[playerRow, playerColumn] = 'f';
                    }

                    else if (field[playerRow, playerColumn] == 'T')
                    {
                        field[unchangedRow, unchangedColumn] = '-';

                        if (direction == "up")
                        {
                            direction = "down";
                        }
                        else if (direction == "down")
                        {
                            direction = "up";
                        }
                        else if (direction == "left")
                        {
                            direction = "right";
                        }
                        else if (direction == "right")
                        {
                            direction = "left";
                        }

                        var isInMatrix = MoveInMatrix(direction, ref playerRow, ref playerColumn, field);

                        if (!isInMatrix)
                        {
                            ChangeSides(direction, ref playerRow, ref playerColumn, field);
                        }

                        if (field[playerRow, playerColumn] == 'F')
                        {
                            finishReached = true;
                        }

                        field[playerRow, playerColumn] = 'f';
                    }

                    else
                    {
                        field[unchangedRow, unchangedColumn] = '-';
                        field[playerRow, playerColumn] = 'f';
                    }
                }

                else
                {
                    field[unchangedRow, unchangedColumn] = '-';

                    ChangeSides(direction, ref playerRow, ref playerColumn, field);

                    if (field[playerRow, playerColumn] == 'F')
                    {
                        finishReached = true;
                    }

                    field[playerRow, playerColumn] = 'f';
                }

                commandsCounter++;
            }

            PrintFinalState(finishReached, field);
        }

        static bool MoveInMatrix(string direction, ref int rowIndex, ref int columnIndex, char[,] matrix)
        {
            if (direction == "up")
            {
                if (rowIndex - 1 >= 0)
                {
                    rowIndex--;
                    return true;
                }
            }

            else if (direction == "down")
            {
                if (rowIndex + 1 < matrix.GetLength(0))
                {
                    rowIndex++;
                    return true;
                }
            }

            else if (direction == "left")
            {
                if (columnIndex - 1 >= 0)
                {
                    columnIndex--;
                    return true;
                }

            }

            else if (direction == "right")
            {
                if (columnIndex + 1 < matrix.GetLength(1))
                {
                    columnIndex++;
                    return true;
                }
            }

            return false;
        }

        static void ChangeSides(string direction, ref int playerRow, ref int playerColumn, char[,] matrix)
        {
            if (direction == "up")
            {
                playerRow = matrix.GetLength(0) - 1;
            }
            else if (direction == "down")
            {
                playerRow = 0;
            }
            else if (direction == "left")
            {
                playerColumn = matrix.GetLength(1) - 1;
            }
            else if (direction == "right")
            {
                playerColumn = 0;
            }
        }

        static void PrintFinalState(bool finishReached, char[,] field)
        {
            if (finishReached)
                Console.WriteLine("Player won!");

            else
                Console.WriteLine("Player lost!");

            for (int row = 0; row < field.GetLength(0); row++)
            {
                for (int column = 0; column < field.GetLength(1); column++)
                {
                    Console.Write(field[row, column]);
                }
                Console.WriteLine();
            }
        }
    }
}
