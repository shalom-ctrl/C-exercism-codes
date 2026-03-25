using System;

public static class RealNumberExtension
{
    public static double Expreal(this int realNumber, RationalNumber r)
    {
        // x^(a/b) = root(x^a, b) which is equivalent to (x^a)^(1/b)
        return Math.Pow(Math.Pow(realNumber, r.Numerator), 1.0 / r.Denominator);
    }
}

public struct RationalNumber
{
    public int Numerator { get; }
    public int Denominator { get; }

    public RationalNumber(int numerator, int denominator)
    {
        // We use a temporary assignment then reduce
        int gcd = GetGcd(Math.Abs(numerator), Math.Abs(denominator));
        int sign = denominator < 0 ? -1 : 1;

        Numerator = (numerator / gcd) * sign;
        Denominator = (denominator / gcd) * sign;
    }

    public static RationalNumber operator +(RationalNumber r1, RationalNumber r2)
    {
        return new RationalNumber(r1.Numerator * r2.Denominator + r2.Numerator * r1.Denominator, 
                                  r1.Denominator * r2.Denominator);
    }

    public static RationalNumber operator -(RationalNumber r1, RationalNumber r2)
    {
        return new RationalNumber(r1.Numerator * r2.Denominator - r2.Numerator * r1.Denominator, 
                                  r1.Denominator * r2.Denominator);
    }

    public static RationalNumber operator *(RationalNumber r1, RationalNumber r2)
    {
        return new RationalNumber(r1.Numerator * r2.Numerator, r1.Denominator * r2.Denominator);
    }

    public static RationalNumber operator /(RationalNumber r1, RationalNumber r2)
    {
        return new RationalNumber(r1.Numerator * r2.Denominator, r1.Denominator * r2.Numerator);
    }

    public RationalNumber Abs() => new RationalNumber(Math.Abs(Numerator), Math.Abs(Denominator));

    public RationalNumber Reduce() => this; // Already reduced by constructor

    public RationalNumber Exprational(int power)
    {
        if (power >= 0)
        {
            return new RationalNumber((int)Math.Pow(Numerator, power), (int)Math.Pow(Denominator, power));
        }
        else
        {
            int m = Math.Abs(power);
            return new RationalNumber((int)Math.Pow(Denominator, m), (int)Math.Pow(Numerator, m));
        }
    }

    public double Expreal(int baseNumber)
    {
        // (a/b)^x = (a^x)/(b^x)
        return Math.Pow(Numerator, (double)baseNumber) / Math.Pow(Denominator, (double)baseNumber);
    }

    private static int GetGcd(int a, int b)
    {
        while (b != 0)
        {
            int t = b;
            b = a % b;
            a = t;
        }
        return a;
    }
}