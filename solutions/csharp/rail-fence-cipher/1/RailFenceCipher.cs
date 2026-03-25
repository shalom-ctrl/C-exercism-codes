using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class RailFenceCipher
{
    private readonly int _rails;

    public RailFenceCipher(int rails)
    {
        _rails = rails;
    }

    public string Encode(string input)
    {
        if (_rails <= 1) return input;

        var fence = Enumerable.Range(0, _rails).Select(_ => new StringBuilder()).ToArray();
        int rail = 0;
        int direction = 1;

        foreach (char c in input)
        {
            fence[rail].Append(c);
            rail += direction;

            if (rail == 0 || rail == _rails - 1)
                direction *= -1;
        }

        return string.Join("", fence.Select(r => r.ToString()));
    }

    public string Decode(string input)
    {
        if (_rails <= 1) return input;

        // Step 1: Determine the pattern of indices
        int[] pattern = GetZigZagPattern(input.Length);
        
        // Step 2: Create a mapping of where each character from the input goes
        // We sort the pattern to see which characters land on Rail 0, then Rail 1, etc.
        char[] decoded = new char[input.Length];
        var sortedPattern = pattern
            .Select((rail, index) => new { rail, index })
            .OrderBy(x => x.rail)
            .ThenBy(x => x.index)
            .ToList();

        for (int i = 0; i < input.Length; i++)
        {
            decoded[sortedPattern[i].index] = input[i];
        }

        return new string(decoded);
    }

    private int[] GetZigZagPattern(int length)
    {
        int[] pattern = new int[length];
        int rail = 0;
        int direction = 1;

        for (int i = 0; i < length; i++)
        {
            pattern[i] = rail;
            rail += direction;

            if (rail == 0 || rail == _rails - 1)
                direction *= -1;
        }
        return pattern;
    }
}