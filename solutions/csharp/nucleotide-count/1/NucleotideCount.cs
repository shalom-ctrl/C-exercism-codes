using System;
using System.Collections.Generic;

public static class NucleotideCount
{
    public static IDictionary<char, int> Count(string sequence)
    {
        // 1. Initialize the dictionary with the four valid nucleotides
        var counts = new Dictionary<char, int>
        {
            ['A'] = 0,
            ['C'] = 0,
            ['G'] = 0,
            ['T'] = 0
        };

        // 2. Loop through the sequence string
        foreach (char nucleotide in sequence)
        {
            // 3. Check if the character is a valid key in our dictionary
            if (counts.ContainsKey(nucleotide))
            {
                counts[nucleotide]++;
            }
            else
            {
                // Signal an error for invalid characters like 'X' or '7'
                throw new ArgumentException("Invalid nucleotide in sequence");
            }
        }

        return counts;
    }
}