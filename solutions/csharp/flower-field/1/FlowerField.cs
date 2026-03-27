using System;
using System.Text;
using System.Collections.Generic;

public static class FlowerField
{
    public static string[] Annotate(string[] input)
    {
        if (input.Length == 0) return Array.Empty<string>();
        
        int rows = input.Length;
        int cols = input[0].Length;
        string[] result = new string[rows];

        for (int r = 0; r < rows; r++)
        {
            StringBuilder rowBuilder = new StringBuilder();
            for (int c = 0; c < cols; c++)
            {
                if (input[r][c] == '*')
                {
                    rowBuilder.Append('*');
                }
                else
                {
                    int count = CountAdjacentFlowers(input, r, c, rows, cols);
                    rowBuilder.Append(count == 0 ? ' ' : (char)('0' + count));
                }
            }
            result[r] = rowBuilder.ToString();
        }

        return result;
    }

    private static int CountAdjacentFlowers(string[] board, int row, int col, int maxRows, int maxCols)
    {
        int count = 0;
        // Check 3x3 grid around the current cell
        for (int dr = -1; dr <= 1; dr++)
        {
            for (int dc = -1; dc <= 1; dc++)
            {
                int nr = row + dr;
                int nc = col + dc;

                // Ensure neighbor is within bounds and is not the cell itself
                if (nr >= 0 && nr < maxRows && nc >= 0 && nc < maxCols)
                {
                    if (board[nr][nc] == '*')
                    {
                        count++;
                    }
                }
            }
        }
        return count;
    }
}