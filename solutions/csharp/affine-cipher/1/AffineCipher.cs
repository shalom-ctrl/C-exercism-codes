using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public static class AffineCipher
{
    private const int M = 26;

    public static string Encode(string plainText, int a, int b)
    {
        if (Gcd(a, M) != 1) throw new ArgumentException("Error: 'a' and 'm' must be coprime.");

        var encoded = new StringBuilder();
        int count = 0;

        foreach (char c in plainText.ToLower())
        {
            if (char.IsLetterOrDigit(c))
            {
                // Add space for grouping every 5 characters
                if (count > 0 && count % 5 == 0) encoded.Append(' ');

                if (char.IsLetter(c))
                {
                    int x = c - 'a';
                    int encryptedX = (a * x + b) % M;
                    encoded.Append((char)(encryptedX + 'a'));
                }
                else
                {
                    encoded.Append(c);
                }
                count++;
            }
        }
        return encoded.ToString();
    }

    public static string Decode(string cipheredText, int a, int b)
    {
        if (Gcd(a, M) != 1) throw new ArgumentException("Error: 'a' and 'm' must be coprime.");

        int aInverse = GetModularInverse(a, M);
        var decoded = new StringBuilder();

        foreach (char c in cipheredText)
        {
            if (char.IsLetter(c))
            {
                int y = c - 'a';
                // (a^-1 * (y - b)) mod 26
                // Adding M before the modulo handles potential negative results
                int decryptedY = (aInverse * (y - b % M + M)) % M;
                decoded.Append((char)(decryptedY + 'a'));
            }
            else if (char.IsDigit(c))
            {
                decoded.Append(c);
            }
        }
        return decoded.ToString();
    }

    private static int Gcd(int a, int b)
    {
        while (b != 0)
        {
            a %= b;
            (a, b) = (b, a);
        }
        return a;
    }

    private static int GetModularInverse(int a, int n)
    {
        for (int x = 1; x < n; x++)
        {
            if ((a * x) % n == 1) return x;
        }
        return -1;
    }
}