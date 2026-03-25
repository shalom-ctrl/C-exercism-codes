using System;

static class GameMaster
{
    public static string Describe(Character character)
    {
        return $"You're a level {character.Level} {character.Class} with {character.HitPoints} hit points.";
    }

    public static string Describe(Destination destination)
    {
        return $"You've arrived at {destination.Name}, which has {destination.Inhabitants} inhabitants.";
    }

    public static string Describe(TravelMethod travelMethod)
    {
        // We move the preposition ("by" or "on") into the string variable 
        // to avoid "by on horseback"
        string methodDescription = travelMethod == TravelMethod.Walking 
            ? "by walking" 
            : "on horseback";

        return $"You're traveling to your destination {methodDescription}.";
    }

    public static string Describe(Character character, Destination destination, TravelMethod travelMethod)
    {
        // Concatenating the three parts with spaces in between
        return $"{Describe(character)} {Describe(travelMethod)} {Describe(destination)}";
    }

    public static string Describe(Character character, Destination destination)
    {
        // Default to Walking as per instructions
        return Describe(character, destination, TravelMethod.Walking);
    }
}

// Data structures and Enum remain the same
class Character
{
    public string Class { get; set; }
    public int Level { get; set; }
    public int HitPoints { get; set; }
}

class Destination
{
    public string Name { get; set; }
    public int Inhabitants { get; set; }
}

enum TravelMethod
{
    Walking,
    Horseback
}