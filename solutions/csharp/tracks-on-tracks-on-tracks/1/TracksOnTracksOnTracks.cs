using System;
using System.Collections.Generic;
using System.Linq;

public static class Languages
{
    // Task 1: Create a new empty list
    public static List<string> NewList() => new List<string>();

    // Task 2: Return a pre-filled list
    public static List<string> GetExistingLanguages() => 
        new List<string> { "C#", "Clojure", "Elm" };

    // Task 3: Add an item to the end
    public static List<string> AddLanguage(List<string> languages, string language)
    {
        languages.Add(language);
        return languages;
    }

    // Task 4: Get the count
    public static int CountLanguages(List<string> languages) => languages.Count;

    // Task 5: Check if item exists
    public static bool HasLanguage(List<string> languages, string language) => 
        languages.Contains(language);

    // Task 6: Reverse the order
    public static List<string> ReverseList(List<string> languages)
    {
        languages.Reverse();
        return languages;
    }

    // Task 7: Check "Exciting" conditions
    public static bool IsExciting(List<string> languages)
    {
        int count = languages.Count;
        if (count == 0) return false;

        // Condition 1: First is C#
        if (languages[0] == "C#") return true;

        // Condition 2: Second is C# and count is 2 or 3
        if (languages[1] == "C#" && (count == 2 || count == 3)) return true;

        return false;
    }

    // Task 8: Remove a specific language
    public static List<string> RemoveLanguage(List<string> languages, string language)
    {
        languages.Remove(language);
        return languages;
    }

    // Task 9: Check for duplicates
    public static bool IsUnique(List<string> languages)
    {
        // We compare the total count to the count of unique (Distinct) items
        return languages.Count == languages.Distinct().Count();
    }
}