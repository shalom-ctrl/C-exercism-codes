using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class Transpose
{
    public static string String(string input)
    {
        if (string.IsNullOrEmpty(input)) return "";

        string[] rows = input.Split('\n');
        int maxColumn = rows.Max(r => r.Length);
        var result = new List<string>();

        for (int c = 0; c < maxColumn; c++)
        {
            var sb = new StringBuilder();
            for (int r = 0; r < rows.Length; r++)
            {
                if (c < rows[r].Length)
                {
                    sb.Append(rows[r][c]);
                }
                else if (rows.Skip(r).Any(row => c < row.Length))
                {
                    // Pad only if a later row has a character at this column index
                    sb.Append(' ');
                }
            }
            result.Add(sb.ToString());
        }

        return string.Join("\n", result);
    }
}