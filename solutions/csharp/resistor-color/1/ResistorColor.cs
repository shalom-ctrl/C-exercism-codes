using System;
using System.Linq;

public static class ResistorColor
{
    private static readonly string[] _colors = 
    { 
        "black", "brown", "red", "orange", "yellow", 
        "green", "blue", "violet", "grey", "white" 
    };

    public static int ColorCode(string color)
    {
        // Find the index of the color in our array
        return Array.IndexOf(_colors, color.ToLower());
    }

    public static string[] Colors()
    {
        // Return the full list of colors
        return _colors;
    }
}