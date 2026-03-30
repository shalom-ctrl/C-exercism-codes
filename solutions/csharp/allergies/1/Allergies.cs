using System;
using System.Collections.Generic;
using System.Linq;

public enum Allergen
{
    Eggs = 1,
    Peanuts = 2,
    Shellfish = 4,
    Strawberries = 8,
    Tomatoes = 16,
    Chocolate = 32,
    Pollen = 64,
    Cats = 128
}

public class Allergies
{
    private readonly int _mask;

    public Allergies(int mask)
    {
        _mask = mask;
    }

    public bool IsAllergicTo(Allergen allergen)
    {
        // Use bitwise AND to see if the allergen's bit is set in the mask
        int allergenValue = (int)allergen;
        return (_mask & allergenValue) == allergenValue;
    }

    public Allergen[] List()
    {
        // Iterate through all enum values and filter by those that match the mask
        return Enum.GetValues(typeof(Allergen))
                   .Cast<Allergen>()
                   .Where(IsAllergicTo)
                   .ToArray();
    }
}