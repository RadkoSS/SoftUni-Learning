using System;

namespace P02.SuperMario
{
    public class StartUp
    {
        static void Main()
        {
            var lives = int.Parse(Console.ReadLine());

            var rowsOfCastle = int.Parse(Console.ReadLine());

            var castleMatrix = new char[rowsOfCastle][];

            var superMarioRow = -1;

            var superMarioColumn = -1;

            InitializeCaste(ref castleMatrix, ref superMarioRow, ref superMarioColumn);

            var isOver = false;
            var princesSaved = false;

            MoveInCastle(ref castleMatrix, ref isOver, ref princesSaved, ref superMarioRow, ref superMarioColumn, ref lives);

            PrintResult(castleMatrix, isOver, princesSaved, superMarioRow, superMarioColumn, lives);
            
        }

        static void InitializeCaste(ref char[][] castleMatrix, ref int superMarioRow, ref int superMarioColumn)
        {
            for (int row = 0; row < castleMatrix.GetLength(0); row++)
            {
                var line = Console.ReadLine();

                if (line.Contains('M'))
                {
                    superMarioRow = row;
                    superMarioColumn = line.IndexOf('M');
                }

                castleMatrix[row] = line.ToCharArray();
            }
        }

        static void MoveInCastle(ref char[][] castleMatrix, ref bool isOver, ref bool princesSaved, ref int superMarioRow, ref int superMarioColumn, ref int lives)
        {
            while (!isOver)
            {
                var command = Console.ReadLine().Split();

                var move = char.Parse(command[0]);

                var spawnRow = int.Parse(command[1]);

                var spawnColumn = int.Parse(command[2]);

                castleMatrix[spawnRow][spawnColumn] = 'B';

                if (move == 'W' && superMarioRow - 1 >= 0)
                {
                    castleMatrix[superMarioRow][superMarioColumn] = '-';
                    superMarioRow--;
                }

                else if (move == 'S' && superMarioRow + 1 < castleMatrix.GetLength(0))
                {
                    castleMatrix[superMarioRow][superMarioColumn] = '-';
                    superMarioRow++;
                }

                else if (move == 'A' && superMarioColumn - 1 >= 0)
                {
                    castleMatrix[superMarioRow][superMarioColumn] = '-';
                    superMarioColumn--;
                }

                else if (move == 'D' && superMarioColumn + 1 < castleMatrix[superMarioRow].Length)
                {
                    castleMatrix[superMarioRow][superMarioColumn] = '-';
                    superMarioColumn++;
                }

                lives--;

                if (castleMatrix[superMarioRow][superMarioColumn] == 'P')
                {
                    castleMatrix[superMarioRow][superMarioColumn] = '-';
                    princesSaved = true;

                    isOver = true;
                }

                else if (lives <= 0)
                {
                    castleMatrix[superMarioRow][superMarioColumn] = 'X';

                    isOver = true;
                }

                else if (castleMatrix[superMarioRow][superMarioColumn] == 'B')
                {
                    lives -= 2;
                    if (lives <= 0)
                    {
                        castleMatrix[superMarioRow][superMarioColumn] = 'X';

                        isOver = true;
                    }
                }

            }

        }

        static void PrintResult(char[][] matrix, bool isOver, bool princesSaved, int superMarioRow, int superMarioColumn, int lives)
        {
            if (isOver && princesSaved)
            {
                Console.WriteLine($"Mario has successfully saved the princess! Lives left: {lives}");
            }

            else if (isOver)
            {
                Console.WriteLine($"Mario died at {superMarioRow};{superMarioColumn}.");
            }

            for (int row = 0; row < matrix.GetLength(0); row++)
            {
                Console.WriteLine(string.Join(string.Empty, matrix[row]));
            }
        }
    }
}
