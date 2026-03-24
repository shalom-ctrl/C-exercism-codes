using System;
using System.Collections.Generic;
using System.Linq;

public static class SaddlePoints
{
    public static IEnumerable<(int row, int col)> Calculate(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int cols = matrix.GetLength(1);
        var results = new List<(int, int)>();

        if (rows == 0 || cols == 0) return results;

        // 1. Find the maximum value in each row
        int[] rowMaxs = new int[rows];
        for (int r = 0; r < rows; r++)
        {
            int currentMax = int.MinValue;
            for (int c = 0; c < cols; c++)
            {
                if (matrix[r, c] > currentMax) currentMax = matrix[r, c];
            }
            rowMaxs[r] = currentMax;
        }

        // 2. Find the minimum value in each column
        int[] colMins = new int[cols];
        for (int c = 0; c < cols; c++)
        {
            int currentMin = int.MaxValue;
            for (int r = 0; r < rows; r++)
            {
                if (matrix[r, c] < currentMin) currentMin = matrix[r, c];
            }
            colMins[c] = currentMin;
        }

        // 3. Identify cells that are both the row max and column min
        for (int r = 0; r < rows; r++)
        {
            for (int c = 0; c < cols; c++)
            {
                if (matrix[r, c] == rowMaxs[r] && matrix[r, c] == colMins[c])
                {
                    // Adding 1 to convert from 0-based index to 1-based coordinates
                    results.Add((r + 1, c + 1));
                }
            }
        }

        return results;
    }
}