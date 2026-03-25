using System;

public struct CurrencyAmount
{
    private decimal amount;
    private string currency;

    public CurrencyAmount(decimal amount, string currency)
    {
        this.amount = amount;
        this.currency = currency;
    }

    // Helper to enforce currency consistency
    private static void EnsureSameCurrency(CurrencyAmount a, CurrencyAmount b)
    {
        if (a.currency != b.currency)
        {
            throw new ArgumentException("Currencies must match for this operation.");
        }
    }

    // Task 1: Equality Operators
    public static bool operator ==(CurrencyAmount a, CurrencyAmount b)
    {
        EnsureSameCurrency(a, b);
        return a.amount == b.amount;
    }

    public static bool operator !=(CurrencyAmount a, CurrencyAmount b)
    {
        EnsureSameCurrency(a, b);
        return a.amount != b.amount;
    }

    // Task 2: Comparison Operators
    public static bool operator >(CurrencyAmount a, CurrencyAmount b)
    {
        EnsureSameCurrency(a, b);
        return a.amount > b.amount;
    }

    public static bool operator <(CurrencyAmount a, CurrencyAmount b)
    {
        EnsureSameCurrency(a, b);
        return a.amount < b.amount;
    }

    // Task 3: Addition and Subtraction
    public static CurrencyAmount operator +(CurrencyAmount a, CurrencyAmount b)
    {
        EnsureSameCurrency(a, b);
        return new CurrencyAmount(a.amount + b.amount, a.currency);
    }

    public static CurrencyAmount operator -(CurrencyAmount a, CurrencyAmount b)
    {
        EnsureSameCurrency(a, b);
        return new CurrencyAmount(a.amount - b.amount, a.currency);
    }

    // Task 4: Multiplication and Division (Scalar)
    public static CurrencyAmount operator *(CurrencyAmount a, decimal multiplier)
    {
        return new CurrencyAmount(a.amount * multiplier, a.currency);
    }

    public static CurrencyAmount operator /(CurrencyAmount a, decimal divisor)
    {
        return new CurrencyAmount(a.amount / divisor, a.currency);
    }

    // Task 5: Explicit cast to double
    public static explicit operator double(CurrencyAmount a)
    {
        return (double)a.amount;
    }

    // Task 6: Implicit conversion to decimal
    public static implicit operator decimal(CurrencyAmount a)
    {
        return a.amount;
    }

    // Standard overrides for equality consistency
    public override bool Equals(object obj) => obj is CurrencyAmount other && this == other;
    public override int GetHashCode() => (amount, currency).GetHashCode();
}