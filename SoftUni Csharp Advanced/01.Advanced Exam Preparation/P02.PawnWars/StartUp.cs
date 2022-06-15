using System;
using System.Linq;

namespace P02.PawnWars
{
    public class StartUp
    {
        static void Main()
        {
            char[,] board = new char[8, 8];

            int whiteRowIndex = -1;
            int whiteColumnIndex = -1;

            int blackRowIndex = -1;
            int blackColumnIndex = -1;

            for (int row = 0; row < board.GetLength(0); row++)
            {
                string currentRow = Console.ReadLine();

                if (currentRow.Contains('w'))
                {
                    whiteRowIndex = row;
                    whiteColumnIndex = currentRow.IndexOf('w');
                }

                if (currentRow.Contains('b'))
                {
                    blackRowIndex = row;
                    blackColumnIndex = currentRow.IndexOf('b');
                }

                for (int column = 0; column < board.GetLength(1); column++)
                {
                    board[row, column] = currentRow[column];
                }
            }

            bool IsOver = false;

            while (!IsOver)
            {
                for (int row = whiteRowIndex; row < board.GetLength(0) - 1; row++)
                {
                    for (int column = whiteColumnIndex; column < board.GetLength(1) - 1; column++)
                    {

                    }
                }
            }
        }
    }
}
