using System;
using System.Linq;
using System.Text;
using System.Collections.Generic;

public static class AtbashCipher
{
    private const string Alphabet = "abcdefghijklmnopqrstuvwxyz";

    public static string Encode(string plainValue)
    {
        var encodedChars = Process(plainValue);
        
        // Group into blocks of 5
        var result = new StringBuilder();
        for (int i = 0; i < encodedChars.Count; i++)
        {
            if (i > 0 && i % 5 == 0)
            {
                result.Append(' ');
            }
            result.Append(encodedChars[i]);
        }
        
        return result.ToString();
    }

    public static string Decode(string encodedValue)
    {
        // Decoding is just the mirror process without the 5-letter spacing
        return new string(Process(encodedValue).ToArray());
    }

    private static List<char> Process(string input)
    {
        var processed = new List<char>();
        
        foreach (char c in input.ToLower())
        {
            if (char.IsLetter(c))
            {
                // Mirror the letter: a -> z, b -> y, etc.
                char mirrored = (char)('z' - (c - 'a'));
                processed.Add(mirrored);
            }
            else if (char.IsDigit(c))
            {
                // Keep digits as they are
                processed.Add(c);
            }
            // Ignore punctuation and spaces
        }
        
        return processed;
    }
}