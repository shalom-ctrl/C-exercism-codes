using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class FoodChain
{
    private static readonly string[] Animals = { 
        "", "fly", "spider", "bird", "cat", "dog", "goat", "cow", "horse" 
    };

    private static readonly string[] Reactions = {
        "",
        "",
        "It wriggled and jiggled and tickled inside her.",
        "How absurd to swallow a bird!",
        "Imagine that, to swallow a cat!",
        "What a hog, to swallow a dog!",
        "Just opened her throat and swallowed a goat!",
        "I don't know how she swallowed a cow!",
        "She's dead, of course!"
    };

    public static string Recite(int verseNumber)
    {
        var sb = new StringBuilder();
        sb.AppendLine($"I know an old lady who swallowed a {Animals[verseNumber]}.");
        
        if (verseNumber > 0 && !string.IsNullOrEmpty(Reactions[verseNumber]))
        {
            sb.AppendLine(Reactions[verseNumber]);
        }

        // The horse is the "kill switch" for the song
        if (verseNumber == 8) 
        {
            return sb.ToString().TrimEnd();
        }

        // Build the cumulative chain
        for (int i = verseNumber; i > 1; i--)
        {
            string extra = (i == 3) ? " that wriggled and jiggled and tickled inside her" : "";
            sb.AppendLine($"She swallowed the {Animals[i]} to catch the {Animals[i - 1]}{extra}.");
        }

        sb.AppendLine("I don't know why she swallowed the fly. Perhaps she'll die.");
        
        return sb.ToString().TrimEnd();
    }

    public static string Recite(int startVerse, int endVerse)
    {
        var verses = new List<string>();
        for (int i = startVerse; i <= endVerse; i++)
        {
            verses.Add(Recite(i));
        }
        // Verses are separated by a blank line
        return string.Join("\n\n", verses);
    }
}