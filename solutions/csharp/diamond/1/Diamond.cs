using System;
using System.Collections.Generic;
using System.Text;

public static class Diamond
{
    public static string Make(char target)
    {
        int n = target - 'A';
        int size = 2 * n + 1;
        var rows = new List<string>();

        // Iterate from top to bottom (-n to n)
        for (int i = -n; i <= n; i++)
        {
            int rowDist = Math.Abs(i);
            char currentRowChar = (char)('A' + (n - rowDist));
            int outerSpacesCount = rowDist;
            int innerSpacesCount = size - 2 * (outerSpacesCount + 1);

            string outerPadding = new string(' ', outerSpacesCount);
            
            if (innerSpacesCount < 0)
            {
                // Special case for 'A'
                rows.Add($"{outerPadding}A{outerPadding}");
            }
            else
            {
                // Case for all other letters
                string innerPadding = new string(' ', innerSpacesCount);
                rows.Add($"{outerPadding}{currentRowChar}{innerPadding}{currentRowChar}{outerPadding}");
            }
        }

        return string.Join("\n", rows);
    }
}