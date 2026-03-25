using System;

public class Player
{
    // We define 'random' as a field so the seed persists across rolls
    private readonly Random _random = new Random();

    public int RollDie()
    {
        // Next(1, 19) returns a value >= 1 and < 19 (so 1 to 18)
        return _random.Next(1, 19);
    }

    public double GenerateSpellStrength()
    {
        // NextDouble() returns >= 0.0 and < 1.0
        // Multiplying by 100.0 gives us the range [0.0, 100.0)
        return _random.NextDouble() * 100.0;
    }
}