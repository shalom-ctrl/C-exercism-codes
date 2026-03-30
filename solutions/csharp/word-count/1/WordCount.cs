using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public static class WordCount
{
    public static IDictionary<string, int> CountWords(string phrase)
    {
        var counts = new Dictionary<string, int>();

        // This regex finds:
        // 1. Alphanumeric characters at the start: \w+
        // 2. An optional apostrophe followed by more alphanumeric: ('\w+)?
        // The \b (word boundaries) ensure we don't pick up 'quotes' around words
        var regex = new Regex(@"\b[\w']+\b");
        
        var matches = regex.Matches(phrase.ToLower());

        foreach (Match match in matches)
        {
            string word = match.Value;

            // Clean up edge cases where \b might leave a leading/trailing apostrophe
            // (e.g., 'word')
            word = word.Trim('\'');

            if (string.IsNullOrWhiteSpace(word)) continue;

            if (counts.ContainsKey(word))
            {
                counts[word]++;
            }
            else
            {
                counts[word] = 1;
            }
        }

        return counts;
    }
}