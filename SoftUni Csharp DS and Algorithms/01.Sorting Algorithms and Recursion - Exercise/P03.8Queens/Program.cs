namespace P03._8Queens;

using System;

internal class Program
{
    private const int Size = 8;
    private static readonly char[,] Chessboard = new char[Size, Size];

    private static readonly HashSet<int> AttackedRows = new ();
    private static readonly HashSet<int> AttackedColumns = new ();
    private static readonly HashSet<int> AttackedLeftDiagonals = new ();
    private static readonly HashSet<int> AttackedRightDiagonals = new ();

    private static void Main()
    {
        CreateChessboard();

        Solve(0);
    }

    private static void CreateChessboard()
    {
        for (int row = 0; row < Size; row++)
        {
            for (int column = 0; column < Size; column++)
            {
                Chessboard[row, column] = '-';
            }
        }
    }

    private static void Solve(int rowIndex)
    {
        if (rowIndex >= Chessboard.GetLength(0))
        {
            PrintSolution();
            return;
        }

        for (int columnIndex = 0; columnIndex < Chessboard.GetLength(1); columnIndex++)
        {
            if (CanPlaceQueen(rowIndex, columnIndex))
            {
                MarkQueenPosition(rowIndex, columnIndex);

                Solve(rowIndex + 1);

                UnMarkQueenPosition(rowIndex, columnIndex);
            }
        }
    }

    private static void UnMarkQueenPosition(int rowIndex, int columnIndex)
    {
        Chessboard[rowIndex, columnIndex] = '-';
        AttackedColumns.Remove(columnIndex);
        AttackedRows.Remove(rowIndex);
        AttackedLeftDiagonals.Remove(columnIndex - rowIndex);
        AttackedRightDiagonals.Remove(columnIndex + rowIndex);
    }

    private static void MarkQueenPosition(int rowIndex, int columnIndex)
    {
        Chessboard[rowIndex, columnIndex] = 'Q';
        AttackedColumns.Add(columnIndex);
        AttackedRows.Add(rowIndex);
        AttackedLeftDiagonals.Add(columnIndex - rowIndex);
        AttackedRightDiagonals.Add(columnIndex + rowIndex);
    }

    private static void PrintSolution()
    {
        for (int row = 0; row < Size; row++)
        {
            for (int column = 0; column < Size; column++)
            {
                Console.Write(Chessboard[row, column]);
            }

            Console.WriteLine();
        }

        Console.WriteLine();
    }

    private static bool CanPlaceQueen(int rowIndex, int columnIndex)
    {
        if (AttackedRows.Contains(rowIndex) 
            || AttackedColumns.Contains(columnIndex) 
            || AttackedLeftDiagonals.Contains(columnIndex - rowIndex) 
            || AttackedRightDiagonals.Contains(columnIndex + rowIndex))
        {
            return false;
        }

        return true;
    }
}