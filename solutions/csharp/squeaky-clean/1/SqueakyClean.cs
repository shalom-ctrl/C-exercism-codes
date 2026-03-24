using System;
using System.Text;

public static class Identifier
{
    public static string Clean(string input)
    {
        if (string.IsNullOrEmpty(input)) return "";

        StringBuilder sb = new StringBuilder();
        bool nextIsUpper = false;

        foreach (char c in input)
        {
            if (c == ' ')
            {
                sb.Append('_');
            }
            else if (char.IsControl(c))
            {
                sb.Append("CTRL");
            }
            else if (c == '-')
            {
                // Signal that the next valid letter should be uppercase
                nextIsUpper = true;
            }
            else if (IsGreekLowercase(c))
            {
                // Omit Greek letters α to ω (U+03B1 to U+03C9)
                continue;
            }
            else if (char.IsLetter(c))
            {
                // If the previous char was a dash, uppercase this one
                if (nextIsUpper)
                {
                    sb.Append(char.ToUpper(c));
                    nextIsUpper = false;
                }
                else
                {
                    sb.Append(c);
                }
            }
            // All other characters (numbers, emojis, symbols) are ignored
        }

        return sb.ToString();
    }

    private static bool IsGreekLowercase(char c)
    {
        // Greek lowercase range is α (alpha) through ω (omega)
        return c >= '\u03B1' && c <= '\u03C9';
    }
}