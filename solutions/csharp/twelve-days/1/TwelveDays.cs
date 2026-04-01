using System;
using System.Collections.Generic;
using System.Linq;

public static class TwelveDays
{
    private static readonly string[] Ordinals = 
    { 
        "first", "second", "third", "fourth", "fifth", "sixth", 
        "seventh", "eighth", "ninth", "tenth", "eleventh", "twelfth" 
    };

    private static readonly string[] Gifts = 
    {
        "a Partridge in a Pear Tree.",
        "two Turtle Doves, ",
        "three French Hens, ",
        "four Calling Birds, ",
        "five Gold Rings, ",
        "six Geese-a-Laying, ",
        "seven Swans-a-Swimming, ",
        "eight Maids-a-Milking, ",
        "seven Swans-a-Swimming, ", // Note: Ensure gifts match your test expectations exactly
        "nine Ladies Dancing, ",
        "ten Lords-a-Leaping, ",
        "eleven Pipers Piping, ",
        "twelve Drummers Drumming, "
    };
    
    // Improved Gift list for cleaner logic:
    private static readonly string[] RefinedGifts = 
    {
        "a Partridge in a Pear Tree.",
        "two Turtle Doves",
        "three French Hens",
        "four Calling Birds",
        "five Gold Rings",
        "six Geese-a-Laying",
        "seven Swans-a-Swimming",
        "eight Maids-a-Milking",
        "nine Ladies Dancing",
        "ten Lords-a-Leaping",
        "eleven Pipers Piping",
        "twelve Drummers Drumming"
    };

    public static string Recite(int verseNumber)
    {
        var ordinal = Ordinals[verseNumber - 1];
        var lyrics = $"On the {ordinal} day of Christmas my true love gave to me: ";
        
        var verseGifts = new List<string>();
        for (int i = verseNumber - 1; i >= 0; i--)
        {
            string gift = RefinedGifts[i];
            
            // Add "and " only if it's the last gift (Partridge) AND not the first verse
            if (i == 0 && verseNumber > 1)
            {
                verseGifts.Add("and " + gift);
            }
            else
            {
                verseGifts.Add(gift);
            }
        }

        return lyrics + string.Join(", ", verseGifts);
    }

    public static string Recite(int startVerse, int endVerse)
    {
        return string.Join("\n", Enumerable.Range(startVerse, endVerse - startVerse + 1)
                                           .Select(v => Recite(v)));
    }
}