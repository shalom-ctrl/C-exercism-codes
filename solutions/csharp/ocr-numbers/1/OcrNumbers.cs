using System;
using System.Collections.Generic;
using System.Linq;

public static class OcrNumbers
{
    // The "fingerprints" for digits 0-9
    private static readonly Dictionary<string, string> DigitMap = new()
    {
        [" _ | ||_|   "] = "0",
        ["     |  |   "] = "1",
        [" _  _||_    "] = "2",
        [" _  _| _|   "] = "3",
        ["   |_|  |   "] = "4",
        [" _ |_  _|   "] = "5",
        [" _ |_ |_|   "] = "6",
        [" _   |  |   "] = "7",
        [" _ |_||_|   "] = "8",
        [" _ |_| _|   "] = "9"
    };

    public static string Convert(string input)
    {
        string[] lines = input.Split('\n');
        if (lines.Length % 4 != 0) throw new ArgumentException("Height must be multiple of 4.");
        if (lines.Any(l => l.Length % 3 != 0)) throw new ArgumentException("Width must be multiple of 3.");

        var resultRows = new List<string>();

        // Process every group of 4 lines (one row of digits)
        for (int row = 0; row < lines.Length; row += 4)
        {
            resultRows.Add(ProcessRow(lines.Skip(row).Take(4).ToArray()));
        }

        return string.Join(",", resultRows);
    }

    private static string ProcessRow(string[] lines)
    {
        string rowResult = "";
        int numberOfDigits = lines[0].Length / 3;

        for (int i = 0; i < numberOfDigits; i++)
        {
            // Extract the 3x4 cell and flatten it into a string key
            string cell = "";
            for (int r = 0; r < 4; r++)
            {
                cell += lines[r].Substring(i * 3, 3);
            }

            rowResult += DigitMap.ContainsKey(cell) ? DigitMap[cell] : "?";
        }

        return rowResult;
    }
}