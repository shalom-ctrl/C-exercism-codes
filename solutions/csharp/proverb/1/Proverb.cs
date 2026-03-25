using System;
using System.Collections.Generic;

public static class Proverb
{
    public static string[] Recite(string[] subjects)
    {
        if (subjects.Length == 0)
        {
            return Array.Empty<string>();
        }

        var lines = new List<string>();

        // Build the chain (from index 0 to n-2)
        for (int i = 0; i < subjects.Length - 1; i++)
        {
            lines.Add($"For want of a {subjects[i]} the {subjects[i + 1]} was lost.");
        }

        // Add the final line using the first subject
        lines.Add($"And all for the want of a {subjects[0]}.");

        return lines.ToArray();
    }
}