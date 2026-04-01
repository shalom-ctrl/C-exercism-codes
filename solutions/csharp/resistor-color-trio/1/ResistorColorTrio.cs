using System;
using System.Collections.Generic;

public static class ResistorColorTrio
{
    private static readonly List<string> Colors = new List<string> 
    { 
        "black", "brown", "red", "orange", "yellow", 
        "green", "blue", "violet", "grey", "white" 
    };

    public static string Label(string[] colors)
    {
        // 1. Convert first two colors to digits
        long digit1 = Colors.IndexOf(colors[0]);
        long digit2 = Colors.IndexOf(colors[1]);
        
        // 2. The third color is the exponent (number of zeros)
        int exponent = Colors.IndexOf(colors[2]);
        
        // 3. Calculate raw value: (Digit1 * 10 + Digit2) * 10^Exponent
        long value = (digit1 * 10 + digit2) * (long)Math.Pow(10, exponent);

        // 4. Determine prefix and format string
        if (value >= 1_000_000_000)
            return $"{value / 1_000_000_000} gigaohms";
        
        if (value >= 1_000_000)
            return $"{value / 1_000_000} megaohms";
        
        if (value >= 1_000)
            return $"{value / 1_000} kiloohms";

        return $"{value} ohms";
    }
}