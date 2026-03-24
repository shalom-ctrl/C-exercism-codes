using System;
using System.Linq;

public static class DifferenceOfSquares
{
    public static int CalculateSquareOfSum(int n)
    {
        int sum = Enumerable.Range(1, n).Sum();
        return sum * sum;
    }

    public static int CalculateSumOfSquares(int n)
    {
        return Enumerable.Range(1, n).Select(x => x * x).Sum();
    }

    public static int CalculateDifferenceOfSquares(int n)
    {
        return CalculateSquareOfSum(n) - CalculateSumOfSquares(n);
    }
}