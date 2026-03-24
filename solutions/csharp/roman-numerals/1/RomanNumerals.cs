using System;
using System.Text;

public static class RomanNumeralExtension
{
    public static string ToRoman(this int value)
    {
        // Define the mapping from largest to smallest
        var arabicValues = new int[] { 1000, 900, 500, 400, 100, 90, 50, 40, 10, 9, 5, 4, 1 };
        var romanSymbols = new string[] { "M", "CM", "D", "CD", "C", "XC", "L", "XL", "X", "IX", "V", "IV", "I" };

        StringBuilder result = new StringBuilder();

        for (int i = 0; i < arabicValues.Length; i++)
        {
            // While the current value can "fit" into our remaining number
            while (value >= arabicValues[i])
            {
                result.Append(romanSymbols[i]);
                value -= arabicValues[i];
            }
        }

        return result.ToString();
    }
}