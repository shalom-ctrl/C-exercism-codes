using System;
using System.Linq;
using System.Text;

public class SimpleCipher
{
    private readonly string _key;
    private static readonly Random _random = new Random();

    public SimpleCipher()
    {
        // Generate a random key of at least 100 lowercase letters
        var sb = new StringBuilder();
        for (int i = 0; i < 100; i++)
        {
            sb.Append((char)_random.Next('a', 'z' + 1));
        }
        _key = sb.ToString();
    }

    public SimpleCipher(string key)
    {
        _key = key;
    }

    public string Key => _key;

    public string Encode(string plaintext)
    {
        var result = new StringBuilder();
        for (int i = 0; i < plaintext.Length; i++)
        {
            int shift = _key[i % _key.Length] - 'a';
            char encodedChar = (char)('a' + (plaintext[i] - 'a' + shift) % 26);
            result.Append(encodedChar);
        }
        return result.ToString();
    }

    public string Decode(string ciphertext)
    {
        var result = new StringBuilder();
        for (int i = 0; i < ciphertext.Length; i++)
        {
            int shift = _key[i % _key.Length] - 'a';
            // Adding 26 before the modulo ensures we don't get a negative result
            char decodedChar = (char)('a' + (ciphertext[i] - 'a' - shift + 26) % 26);
            result.Append(decodedChar);
        }
        return result.ToString();
    }
}