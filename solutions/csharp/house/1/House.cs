using System;

public static class House
{
    readonly static string[] lines = {
        "This is the house that Jack built.",
        "This is the malt that lay in the house that Jack built.",
        "This is the rat that ate the malt that lay in the house that Jack built.",
        "This is the cat that killed the rat that ate the malt that lay in the house that Jack built.",
        "This is the dog that worried the cat that killed the rat that ate the malt that lay in the house that Jack built.",
        "This is the cow with the crumpled horn that tossed the dog that worried the cat that killed the rat that ate the malt that lay in the house that Jack built.",
        "This is the maiden all forlorn that milked the cow with the crumpled horn that tossed the dog that worried the cat that killed the rat that ate the malt that lay in the house that Jack built.",
        "This is the man all tattered and torn that kissed the maiden all forlorn that milked the cow with the crumpled horn that tossed the dog that worried the cat that killed the rat that ate the malt that lay in the house that Jack built.",
        "This is the priest all shaven and shorn that married the man all tattered and torn that kissed the maiden all forlorn that milked the cow with the crumpled horn that tossed the dog that worried the cat that killed the rat that ate the malt that lay in the house that Jack built.",
        "This is the rooster that crowed in the morn that woke the priest all shaven and shorn that married the man all tattered and torn that kissed the maiden all forlorn that milked the cow with the crumpled horn that tossed the dog that worried the cat that killed the rat that ate the malt that lay in the house that Jack built.",
        "This is the farmer sowing his corn that kept the rooster that crowed in the morn that woke the priest all shaven and shorn that married the man all tattered and torn that kissed the maiden all forlorn that milked the cow with the crumpled horn that tossed the dog that worried the cat that killed the rat that ate the malt that lay in the house that Jack built.",
        "This is the horse and the hound and the horn that belonged to the farmer sowing his corn that kept the rooster that crowed in the morn that woke the priest all shaven and shorn that married the man all tattered and torn that kissed the maiden all forlorn that milked the cow with the crumpled horn that tossed the dog that worried the cat that killed the rat that ate the malt that lay in the house that Jack built.",
    };


    public static string Recite(int verseNumber)
    {
        if (verseNumber <= 0 && verseNumber > lines.Length) {
            throw new ArgumentException();
        }
        return lines[verseNumber - 1];
    }

    public static string Recite(int startVerse, int endVerse)
    {
        if (startVerse > endVerse) {
            throw new ArgumentException();
        }
        string rhyme = string.Empty;
        for (int i = startVerse; i <= endVerse; i++) {
            if (rhyme != string.Empty) {
                rhyme += "\n";
            }
            rhyme += Recite(i);
        }
        return rhyme;
    }
}