using System;
using System.Collections.Generic;
using System.Linq;

public class HighScores
{
    private readonly List<int> _scores;

    public HighScores(List<int> list)
    {
        _scores = list;
    }

    public List<int> Scores()
    {
        // Return the full list as-is
        return _scores;
    }

    public int Latest()
    {
        // The last item added to the list
        return _scores.Last();
    }

    public int PersonalBest()
    {
        // The single highest score
        return _scores.Max();
    }

    public List<int> PersonalTopThree()
    {
        // Sort descending, then grab the top 3
        return _scores
            .OrderByDescending(s => s)
            .Take(3)
            .ToList();
    }
}