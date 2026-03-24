using System;
using System.Linq;

public static class Isogram
{
    public static bool IsIsogram(string word)
    {
        var lettersOnly = word.ToLower()
                              .Where(ch => char.IsLetter(ch))
                              .ToList();
        return lettersOnly.Count == lettersOnly.Distinct().Count();
    }
}