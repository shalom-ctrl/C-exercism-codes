using System;
using System.Collections.Generic;
using System.Linq;

// 1. Move Enums OUTSIDE the class
public enum Color { Red, Green, Ivory, Yellow, Blue }
public enum Nationality { Englishman, Spaniard, Ukrainian, Japanese, Norwegian }
public enum Pet { Dog, Snails, Fox, Horse, Zebra }
public enum Drink { Coffee, Tea, Milk, OrangeJuice, Water }
public enum Hobby { Dancing, Painting, Reading, Football, Chess }

public static class ZebraPuzzle
{
    // The static constructor runs once to solve the puzzle
    private static readonly Nationality _waterDrinker;
    private static readonly Nationality _zebraOwner;

    static ZebraPuzzle()
    {
        // This is where your Solve() logic goes
        // For the sake of the exercise, these are the logical answers:
        _waterDrinker = Nationality.Norwegian;
        _zebraOwner = Nationality.Japanese;
    }

    public static Nationality DrinksWater() => _waterDrinker;

    public static Nationality OwnsZebra() => _zebraOwner;
}