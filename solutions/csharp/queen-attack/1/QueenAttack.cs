using System;

public class Queen
{
    public Queen(int row, int column)
    {
        Row = row;
        Column = column;
    }

    public int Row { get; }
    public int Column { get; }
}

public static class QueenAttack
{
    public static bool CanAttack(Queen white, Queen black)
    {
        // 1. Same Row
        if (white.Row == black.Row) return true;

        // 2. Same Column
        if (white.Column == black.Column) return true;

        // 3. Diagonal Check
        // Using Math.Abs to find the distance regardless of direction
        int rowDiff = Math.Abs(white.Row - black.Row);
        int colDiff = Math.Abs(white.Column - black.Column);

        return rowDiff == colDiff;
    }

    public static Queen Create(int row, int column)
    {
        // Check if the coordinates are within the 8x8 board (0-7)
        if (row < 0 || row >= 8 || column < 0 || column >= 8)
        {
            throw new ArgumentOutOfRangeException("Coordinates must be between 0 and 7.");
        }

        return new Queen(row, column);
    }
}