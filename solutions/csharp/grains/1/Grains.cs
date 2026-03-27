using System;

public static class Grains
{
    public static ulong Square(int n)
    {
        if (n < 1 || n > 64)
        {
            throw new ArgumentOutOfRangeException(nameof(n), "Square must be between 1 and 64.");
        }

        // 2 to the power of (n-1)
        // We use 1UL to ensure the shift happens on a 64-bit unsigned integer
        return 1UL << (n - 1);
    }

    public static ulong Total()
    {
        // The sum of 2^0 + 2^1 + ... + 2^63 is 2^64 - 1.
        // In C#, ulong.MaxValue is exactly 18,446,744,073,709,551,615.
        return ulong.MaxValue;
    }
}