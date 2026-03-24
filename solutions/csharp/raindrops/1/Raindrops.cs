using System;

public static class Raindrops
{
    public static string Convert(int number)
    {
        string result = "";

        // Check if divisible by 3
        if (number % 3 == 0)
        {
            result += "Pling";
        }

        // Check if divisible by 5
        if (number % 5 == 0)
        {
            result += "Plang";
        }

        // Check if divisible by 7
        if (number % 7 == 0)
        {
            result += "Plong";
        }

        // If no sounds were added, return the number itself as a string
        return string.IsNullOrEmpty(result) ? number.ToString() : result;
    }
}