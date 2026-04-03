using System;
using System.Linq;
using System.Text.RegularExpressions;

public static class PigLatin
{
    public static string Translate(string sentence)
    {
        // Split the sentence into words, translate each, then join back with spaces
        return string.Join(" ", sentence.Split(' ').Select(TranslateWord));
    }

    private static string TranslateWord(string word)
    {
        // Rule 1: Starts with vowel or 'xr' or 'yt'
        // Just add "ay" to the end
        if (Regex.IsMatch(word, @"^([aeiou]|xr|yt)"))
        {
            return word + "ay";
        }

        // Rule 3: Consonants followed by 'qu'
        // Moves the consonants and the 'qu' to the end (e.g., "square" -> "aresquay")
        var quMatch = Regex.Match(word, @"^([^aeiou]*qu)(.*)");
        if (quMatch.Success)
        {
            return quMatch.Groups[2].Value + quMatch.Groups[1].Value + "ay";
        }

        // Rule 4: One or more consonants followed by 'y'
        // Moves the consonants before the 'y' to the end (e.g., "rhythm" -> "ythmrhay")
        var yMatch = Regex.Match(word, @"^([^aeiou]+)(y.*)");
        if (yMatch.Success)
        {
            return yMatch.Groups[2].Value + yMatch.Groups[1].Value + "ay";
        }

        // Rule 2: One or more consonants
        // Moves all leading consonants to the end (e.g., "pig" -> "igpay")
        var consonantMatch = Regex.Match(word, @"^([^aeiou]+)(.*)");
        if (consonantMatch.Success)
        {
            return consonantMatch.Groups[2].Value + consonantMatch.Groups[1].Value + "ay";
        }

        return word;
    }
}