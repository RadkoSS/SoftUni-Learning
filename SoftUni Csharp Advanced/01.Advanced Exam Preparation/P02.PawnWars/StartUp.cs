using System;
using System.Text;

namespace P02.PawnWars
{
    public class StartUp
    {
        static void Main()
        {

            int whiteRowIndex = -1;
            int whiteColumnIndex = -1;

            int blackRowIndex = -1;
            int blackColumnIndex = -1;

            char[,] board = new char[8, 8];

            InitializeIndexesAndBoard(ref board, ref whiteRowIndex, ref whiteColumnIndex, ref blackRowIndex, ref blackColumnIndex);

            PlayGame(board, whiteRowIndex, whiteColumnIndex, blackRowIndex, blackColumnIndex);

        }


        static void InitializeIndexesAndBoard(ref char[,] board, ref int whiteRowIndex, ref int whiteColumnIndex, ref int blackRowIndex, ref int blackColumnIndex)
        {
            for (int row = 0; row < board.GetLength(0); row++)
            {
                string line = Console.ReadLine();

                if (line.Contains('w'))
                {
                    whiteRowIndex = row;
                    whiteColumnIndex = line.IndexOf('w');
                }

                if (line.Contains('b'))
                {
                    blackRowIndex = row;
                    blackColumnIndex = line.IndexOf('b');
                }

                for (int column = 0; column < board.GetLength(1); column++)
                {
                    board[row, column] = line[column];
                }

            }
        }


        static void PlayGame(char[,] board, int whiteRowIndex, int whiteColumnIndex, int blackRowIndex, int blackColumnIndex)
        {
            bool gameOverByCapture = false;

            bool gameOverByPromotion = false;

            string winner = string.Empty;

            string coordinates = string.Empty;

            while (whiteRowIndex > 0 && blackRowIndex < 7 && string.IsNullOrEmpty(winner))
            {
                if (IsInMatrix(board, whiteRowIndex - 1, whiteColumnIndex - 1) && board[whiteRowIndex - 1, whiteColumnIndex - 1] == 'b')
                {
                    gameOverByCapture = true;
                    winner = "White";
                    coordinates = SetPosition(whiteRowIndex - 1, whiteColumnIndex - 1);
                }

                else if (IsInMatrix(board, whiteRowIndex - 1, whiteColumnIndex + 1) && board[whiteRowIndex - 1, whiteColumnIndex + 1] == 'b')
                {
                    gameOverByCapture = true;
                    winner = "White";
                    coordinates = SetPosition(whiteRowIndex - 1, whiteColumnIndex + 1);
                }

                else
                {
                    var temp = board[whiteRowIndex, whiteColumnIndex];

                    board[whiteRowIndex, whiteColumnIndex] = '-';

                    whiteRowIndex--;

                    board[whiteRowIndex, whiteColumnIndex] = temp;

                    if (whiteRowIndex == 0)
                    {
                        gameOverByPromotion = true;
                        winner = "White";
                        coordinates = SetPosition(whiteRowIndex, whiteColumnIndex);
                    }
                }

                if (!string.IsNullOrEmpty(winner))
                {
                    break;
                }

                if (IsInMatrix(board, blackRowIndex + 1, blackColumnIndex - 1) && board[blackRowIndex + 1, blackColumnIndex - 1] == 'w')
                {
                    gameOverByCapture = true;
                    winner = "Black";
                    coordinates = SetPosition(blackRowIndex + 1, blackColumnIndex - 1);
                }

                else if (IsInMatrix(board, blackRowIndex + 1, blackColumnIndex + 1) && board[blackRowIndex + 1, blackColumnIndex + 1] == 'w')
                {
                    gameOverByCapture = true;
                    winner = "Black";
                    coordinates = SetPosition(blackRowIndex + 1, blackColumnIndex + 1);
                }

                else
                {
                    var temp = board[blackRowIndex, blackColumnIndex];

                    board[blackRowIndex, blackColumnIndex] = '-';

                    blackRowIndex++;

                    board[blackRowIndex, blackColumnIndex] = temp;

                    if (blackRowIndex == 7)
                    {
                        gameOverByPromotion = true;
                        winner = "Black";
                        coordinates = SetPosition(blackRowIndex, blackColumnIndex);
                    }
                }
            }

            if (gameOverByPromotion)
                Console.WriteLine($"Game over! {winner} pawn is promoted to a queen at {coordinates}.");

            else if (gameOverByCapture)
                Console.WriteLine($"Game over! {winner} capture on {coordinates}.");
        }


        static bool IsInMatrix(char[,] board, int row, int column) => row >= 0 && row < board.GetLength(0) && column >= 0 && column < board.GetLength(1);


        static string SetPosition(int rowIndex, int columnIndex)
        {
            var position = new StringBuilder();

            for (int column = 0; column < 8; column++)
            {
                if (columnIndex == column)
                {
                    position.Append((char)(column + 97));
                }
            }

            var positionIndex = 8;

            for (int row = 0; row < 8; row++)
            {
                if (rowIndex == row)
                {
                    position.Append(positionIndex);
                }
                positionIndex--;
            }

            return position.ToString().TrimEnd();
        }
    }

}
