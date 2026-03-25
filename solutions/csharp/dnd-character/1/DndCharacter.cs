using System;
using System.Collections.Generic;
using System.Linq;

public class DndCharacter
{
    private static readonly Random _random = new Random();

    public int Strength { get; private set; }
    public int Dexterity { get; private set; }
    public int Constitution { get; private set; }
    public int Intelligence { get; private set; }
    public int Wisdom { get; private set; }
    public int Charisma { get; private set; }
    public int Hitpoints { get; private set; }

    public static int Modifier(int score)
    {
        // Subtract 10, divide by 2.0 to get a double, 
        // then Floor to ensure we round down correctly even for negative results.
        return (int)Math.Floor((score - 10) / 2.0);
    }

    public static int Ability() 
    {
        var rolls = new List<int>();
        for (int i = 0; i < 4; i++)
        {
            rolls.Add(_random.Next(1, 7)); // 1 to 6
        }
        
        // Sort, drop the lowest (the first one), and sum the rest
        return rolls.OrderBy(r => r).Skip(1).Sum();
    }

    public static DndCharacter Generate()
    {
        var character = new DndCharacter();
        
        character.Strength = Ability();
        character.Dexterity = Ability();
        character.Constitution = Ability();
        character.Intelligence = Ability();
        character.Wisdom = Ability();
        character.Charisma = Ability();
        
        // Hitpoints = 10 + Con Modifier
        character.Hitpoints = 10 + Modifier(character.Constitution);

        return character;
    }
}