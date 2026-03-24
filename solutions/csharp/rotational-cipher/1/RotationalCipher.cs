using System;
using System.Text;

public static class RotationalCipher
{
    public static string Rotate(string text, int shiftKey)
    {
        StringBuilder sb = new StringBuilder();

        foreach (char c in text)
        {
            if (char.IsLetter(c))
            {
                // Determine if we use 'A' or 'a' as our starting point (0)
                char d = char.IsUpper(c) ? 'A' : 'a';
                
                // 1. (c - d): Get alphabetical index (0-25)
                // 2. + shiftKey: Move the letter
                // 3. % 26: Wrap around if we go past 'z'
                // 4. + d: Convert back to ASCII/UTF-16
                char shifted = (char)((((c - d) + shiftKey) % 26) + d);
                
                sb.Append(shifted);
            }
            else
            {
                // Numbers, spaces, and punctuation stay exactly as they are
                sb.Append(c);
            }
        }

        return sb.ToString();
    }
}