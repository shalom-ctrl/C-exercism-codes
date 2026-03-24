using System;
using System.Linq;

public static class Triangle
{
    private static bool IsValid(double a, double b, double c)
    {
        // 1. All sides must be greater than 0
        if (a <= 0 || b <= 0 || c <= 0) return false;

        // 2. Triangle Inequality: a + b >= c, a + c >= b, b + c >= a
        return (a + b >= c) && (a + c >= b) && (b + c >= a);
    }

    public static bool IsEquilateral(double side1, double side2, double side3) 
    {
        // All three sides must be equal
        return IsValid(side1, side2, side3) && 
               (side1 == side2 && side2 == side3);
    }

    public static bool IsIsosceles(double side1, double side2, double side3) 
    {
        // At least two sides must be equal
        return IsValid(side1, side2, side3) && 
               (side1 == side2 || side2 == side3 || side1 == side3);
    }

    public static bool IsScalene(double side1, double side2, double side3) 
    {
        // All sides must be different
        return IsValid(side1, side2, side3) && 
               (side1 != side2 && side2 != side3 && side1 != side3);
    }
}