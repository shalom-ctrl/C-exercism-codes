using System;
using System.Numerics;

public static class DiffieHellman
{
    private static readonly Random _random = new Random();

    public static BigInteger PrivateKey(BigInteger primeP) 
    {
        // Pick a private key 'a' where 1 < a < primeP
        // For simplicity in this exercise, we generate a random long, 
        // but it must be smaller than primeP.
        byte[] bytes = primeP.ToByteArray();
        BigInteger a;

        do {
            _random.NextBytes(bytes);
            a = new BigInteger(bytes);
        } while (a <= 1 || a >= primeP);

        return a;
    }

    public static BigInteger PublicKey(BigInteger primeP, BigInteger primeG, BigInteger privateKey) 
    {
        // A = g^a mod p
        return BigInteger.ModPow(primeG, privateKey, primeP);
    }

    public static BigInteger Secret(BigInteger primeP, BigInteger publicKey, BigInteger privateKey) 
    {
        // s = B^a mod p (or A^b mod p)
        return BigInteger.ModPow(publicKey, privateKey, primeP);
    }
}