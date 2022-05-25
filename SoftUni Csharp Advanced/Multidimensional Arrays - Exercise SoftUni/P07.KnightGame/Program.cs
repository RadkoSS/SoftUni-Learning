using System;

namespace P07.KnightGame
{
    class Program
    {
        static void Main()
        {
            int boardSize = int.Parse(Console.ReadLine());

            char[,] board = new char[boardSize, boardSize];

            InitializeBoard(board);

            Console.WriteLine(CountRemovableKnights(board));
        }
        static void InitializeBoard(char[,] boardMatrix)
        {
            for (int row = 0; row < boardMatrix.GetLength(0); row++)
            {
                string currentRow = Console.ReadLine();

                for (int column = 0; column < boardMatrix.GetLength(1); column++)
                {
                    boardMatrix[row, column] = currentRow[column];
                }
            }
        }
        static int CountRemovableKnights(char[,] board)
        {
            int removableKnights = 0;

            for (int row = 0; row < board.GetLength(0) - 2; row++)
            {
                for (int column = 0; column < board.GetLength(1) - 2; column++)
                {
                    char currentSquare = board[row, column];
                    if (currentSquare == 'K')
                    {
                        char firstMove = board[row + 1, column + 2];
                        char secondMove = board[row + 2, column + 1];

                        if (firstMove == 'K' || secondMove == 'K')
                        {
                            board[row, column] = '0';
                            removableKnights++;
                        }
                        if (row >= 2 && column >= 2)
                        {
                            char thirdMove = board[row - 1, column - 2];
                            char fourthMove = board[row - 2, column - 1];
                            if (thirdMove == 'K' || fourthMove == 'K')
                            {
                                board[row, column] = '0';
                                removableKnights++;
                            }
                        }
                        
                    }

                }
            }

            return removableKnights;
        }
    }
}
