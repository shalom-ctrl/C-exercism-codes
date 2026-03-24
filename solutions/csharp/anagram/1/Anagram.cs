using System;
using System.Collections.Generic;
using System.Linq;

public class Anagram
{
    private readonly string _target;

    public Anagram(string target)
    {
        _target = target;
    }

    public string[] FindAnagrams(string[] candidates)
    {
        // 1. Prepare the target for comparison
        string lowerTarget = _target.ToLower();
        string sortedTarget = SortString(lowerTarget);

        var matches = new List<string>();

        foreach (string candidate in candidates)
        {
            string lowerCandidate = candidate.ToLower();

            // Rule: A word is not its own anagram
            if (lowerCandidate == lowerTarget) continue;

            // Rule: Must be same length
            if (lowerCandidate.Length != lowerTarget.Length) continue;

            // Rule: Sorted characters must match
            if (SortString(lowerCandidate) == sortedTarget)
            {
                matches.Add(candidate);
            }
        }

        return matches.ToArray();
    }

    // Helper method to sort characters in a string
    private string SortString(string word)
    {
        return new string(word.OrderBy(c => c).ToArray());
    }
}
