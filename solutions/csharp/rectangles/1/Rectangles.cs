using System;
using System.Collections.Generic;

public static class Rectangles
{
    public static int Count(string[] rows)
    {
        if (rows.Length == 0) return 0;

        int count = 0;
        var corners = new List<(int r, int c)>();

        // Step 1: Identify all corners
        for (int r = 0; r < rows.Length; r++)
        {
            for (int c = 0; c < rows[r].Length; c++)
            {
                if (rows[r][c] == '+') corners.Add((r, c));
            }
        }

        // Step 2: Check every pair of corners as top-left and bottom-right
        for (int i = 0; i < corners.Count; i++)
        {
            for (int j = i + 1; j < corners.Count; j++)
            {
                var tl = corners[i];
                var br = corners[j];

                // br must be strictly below and to the right of tl
                if (br.r > tl.r && br.c > tl.c)
                {
                    if (IsRectangle(rows, tl, br)) count++;
                }
            }
        }

        return count;
    }

    private static bool IsRectangle(string[] rows, (int r, int c) tl, (int r, int c) br)
    {
        // Check if the other two corners exist
        if (rows[tl.r][br.c] != '+' || rows[br.r][tl.c] != '+') return false;

        // Check horizontal lines (top and bottom)
        for (int c = tl.c + 1; c < br.c; c++)
        {
            if (!"+-".Contains(rows[tl.r][c]) || !"+-".Contains(rows[br.r][c]))
                return false;
        }

        // Check vertical lines (left and right)
        for (int r = tl.r + 1; r < br.r; r++)
        {
            if (!"+|".Contains(rows[r][tl.c]) || !"+|".Contains(rows[r][br.c]))
                return false;
        }

        return true;
    }
}