using System;
using System.Linq;
using System.Collections.Generic;

// 1. Define the enum OUTSIDE the class
public enum YachtCategory
{
    Ones = 1,
    Twos = 2,
    Threes = 3,
    Fours = 4,
    Fives = 5,
    Sixes = 6,
    FullHouse = 7,
    FourOfAKind = 8,
    LittleStraight = 9,
    BigStraight = 10,
    Choice = 11,
    Yacht = 12
}

public static class YachtGame
{
    public static int Score(int[] dice, YachtCategory category)
    {
        var groups = dice.GroupBy(d => d).ToDictionary(g => g.Key, g => g.Count());
        var sortedDice = dice.OrderBy(d => d).ToArray();

        return category switch
        {
            YachtCategory.Ones => dice.Where(d => d == 1).Sum(),
            YachtCategory.Twos => dice.Where(d => d == 2).Sum(),
            YachtCategory.Threes => dice.Where(d => d == 3).Sum(),
            YachtCategory.Fours => dice.Where(d => d == 4).Sum(),
            YachtCategory.Fives => dice.Where(d => d == 5).Sum(),
            YachtCategory.Sixes => dice.Where(d => d == 6).Sum(),
            
            YachtCategory.FullHouse => 
                groups.Count == 2 && groups.Values.Contains(3) ? dice.Sum() : 0,
            
            YachtCategory.FourOfAKind => 
                groups.Any(g => g.Value >= 4) ? groups.First(g => g.Value >= 4).Key * 4 : 0,
            
            YachtCategory.LittleStraight => 
                sortedDice.SequenceEqual(new[] { 1, 2, 3, 4, 5 }) ? 30 : 0,
            
            YachtCategory.BigStraight => 
                sortedDice.SequenceEqual(new[] { 2, 3, 4, 5, 6 }) ? 30 : 0,
            
            YachtCategory.Choice => dice.Sum(),
            
            YachtCategory.Yacht => groups.Count == 1 ? 50 : 0,
            
            _ => 0
        };
    }
}