using System;
using System.Collections.Generic;

public static class BottleSong
{
    public static IEnumerable<string> Recite(int startBottles, int takeDown)
    {
        var lyrics = new List<string>();

        for (int i = 0; i < takeDown; i++)
        {
            int current = startBottles - i;
            int next = current - 1;

            string currentWord = NumberToWord(current);
            string nextWord = NumberToWord(next).ToLower();

            // Handle "bottle" vs "bottles"
            string currentLabel = current == 1 ? "bottle" : "bottles";
            string nextLabel = next == 1 ? "bottle" : "bottles";

            lyrics.Add($"{currentWord} green {currentLabel} hanging on the wall,");
            lyrics.Add($"{currentWord} green {currentLabel} hanging on the wall,");
            lyrics.Add("And if one green bottle should accidentally fall,");
            lyrics.Add($"There'll be {nextWord} green {nextLabel} hanging on the wall.");

            // Add an empty line between verses, but not after the last verse
            if (i < takeDown - 1)
            {
                lyrics.Add("");
            }
        }

        return lyrics;
    }

    private static string NumberToWord(int number)
    {
        return number switch
        {
            10 => "Ten",
            9 => "Nine",
            8 => "Eight",
            7 => "Seven",
            6 => "Six",
            5 => "Five",
            4 => "Four",
            3 => "Three",
            2 => "Two",
            1 => "One",
            0 => "No",
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}