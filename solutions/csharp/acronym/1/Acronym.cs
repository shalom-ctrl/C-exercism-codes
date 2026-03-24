using System;
using System.Linq;

public static class Acronym
{
    public static string Abbreviate(string phrase)
    {
        // 1. Replace hyphens with spaces to treat them as word breaks
        // 2. Split by space, removing any empty entries (caused by multiple spaces)
        string[] words = phrase.Replace('-', ' ')
                               .Split(' ', StringSplitOptions.RemoveEmptyEntries);

        // 3. Process each word
        var initials = words.Select(word => 
        {
            // Find the first actual letter in the word (skips leading punctuation)
            char firstLetter = word.FirstOrDefault(ch => char.IsLetter(ch));
            return char.ToUpper(firstLetter);
        });

        // 4. Join the characters back into a single string
        // We filter out '\0' in case a "word" had no letters at all
        return new string(initials.Where(c => c != '\0').ToArray());
    }
}