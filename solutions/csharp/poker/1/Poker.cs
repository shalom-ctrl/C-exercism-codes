using System;
using System.Collections.Generic;
using System.Linq;

public static class Poker
{
    public static IEnumerable<string> BestHands(IEnumerable<string> hands)
    {
        var evaluatedHands = hands.Select(h => new Hand(h)).ToList();
        var maxScore = evaluatedHands.Max();
        return evaluatedHands.Where(h => h.CompareTo(maxScore) == 0).Select(h => h.RawHand);
    }
}

public class Hand : IComparable<Hand>
{
    public string RawHand { get; }
    private readonly List<int> _ranks;
    private readonly int _category;
    private readonly List<int> _tieBreakers;

    public Hand(string hand)
    {
        RawHand = hand;
        var cards = hand.Split(' ').Select(c => new Card(c)).ToList();
        _ranks = cards.Select(c => c.Value).OrderByDescending(v => v).ToList();
        
        // Handle Low Ace Straight (A, 2, 3, 4, 5)
        if (_ranks.SequenceEqual(new[] { 14, 5, 4, 3, 2 }))
            _ranks = new List<int> { 5, 4, 3, 2, 1 };

        var isFlush = cards.GroupBy(c => c.Suit).Count() == 1;
        var isStraight = _ranks.Distinct().Count() == 5 && _ranks.First() - _ranks.Last() == 4;
        var groups = _ranks.GroupBy(v => v).OrderByDescending(g => g.Count()).ThenByDescending(g => g.Key).ToList();

        // Assign Category and Tie-Breakers
        if (isStraight && isFlush) _category = 8;
        else if (groups[0].Count() == 4) _category = 7;
        else if (groups[0].Count() == 3 && groups[1].Count() == 2) _category = 6;
        else if (isFlush) _category = 5;
        else if (isStraight) _category = 4;
        else if (groups[0].Count() == 3) _category = 3;
        else if (groups[0].Count() == 2 && groups[1].Count() == 2) _category = 2;
        else if (groups[0].Count() == 2) _category = 1;
        else _category = 0;

        _tieBreakers = groups.Select(g => g.Key).ToList();
    }

    public int CompareTo(Hand other)
    {
        if (_category != other._category) return _category.CompareTo(other._category);
        for (int i = 0; i < _tieBreakers.Count; i++)
        {
            if (_tieBreakers[i] != other._tieBreakers[i])
                return _tieBreakers[i].CompareTo(other._tieBreakers[i]);
        }
        return 0;
    }
}

public class Card
{
    public int Value { get; }
    public char Suit { get; }

    public Card(string s)
    {
        var v = s.Substring(0, s.Length - 1);
        Suit = s.Last();
        Value = v switch { "A" => 14, "K" => 13, "Q" => 12, "J" => 11, "10" => 10, _ => int.Parse(v) };
    }
}