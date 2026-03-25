using System;
using System.Collections.Generic;
using System.Linq;

public static class ResistorColorDuo
{
    private static readonly string[] _colors = 
    { 
        "black", "brown", "red", "orange", "yellow", 
        "green", "blue", "violet", "grey", "white" 
    };

    public static int Value(string[] colors)
    {
        // We only care about the first two bands
        int firstDigit = Array.IndexOf(_colors, colors[0].ToLower());
        int secondDigit = Array.IndexOf(_colors, colors[1].ToLower());

        // Combine them into a two-digit number
        return (firstDigit * 10) + secondDigit;
    }
}
