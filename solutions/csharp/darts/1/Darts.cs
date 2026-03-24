using System;

public static class Darts
{
    public static int Score(double x, double y)
    {
        // Calculate the squared distance to avoid Math.Sqrt()
        // d^2 = x^2 + y^2
        double distanceSquared = (x * x) + (y * y);

        // Check from the inside out
        if (distanceSquared <= 1 * 1) 
        {
            return 10;
        }
        
        if (distanceSquared <= 5 * 5) 
        {
            return 5;
        }
        
        if (distanceSquared <= 10 * 10) 
        {
            return 1;
        }

        // Outside the target
        return 0;
    }
}