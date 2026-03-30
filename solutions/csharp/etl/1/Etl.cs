using System;
using System.Collections.Generic;

public static class Etl
{
    public static Dictionary<string, int> Transform(Dictionary<int, string[]> old)
    {
        var newFormat = new Dictionary<string, int>();

        // 1. Extract: Loop through each score group
        foreach (var entry in old)
        {
            int score = entry.Key;
            string[] letters = entry.Value;

            // 2. Transform & Load: Map each letter individually
            foreach (string letter in letters)
            {
                // Convert to lowercase as requested
                string lowerLetter = letter.ToLower();
                
                // Add to the new one-to-one mapping
                newFormat[lowerLetter] = score;
            }
        }

        return newFormat;
    }
}